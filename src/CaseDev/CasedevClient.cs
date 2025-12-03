using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CaseDev.Core;
using CaseDev.Exceptions;
using CaseDev.Services;

namespace CaseDev;

/// <inheritdoc/>
public sealed class CasedevClient : ICasedevClient
{
    static readonly ThreadLocal<Random> _threadLocalRandom = new(() => new Random());

    static Random Random
    {
        get { return _threadLocalRandom.Value!; }
    }

    readonly ClientOptions _options;

    /// <inheritdoc/>
    public HttpClient HttpClient
    {
        get { return this._options.HttpClient; }
        init { this._options.HttpClient = value; }
    }

    /// <inheritdoc/>
    public Uri BaseUrl
    {
        get { return this._options.BaseUrl; }
        init { this._options.BaseUrl = value; }
    }

    /// <inheritdoc/>
    public bool ResponseValidation
    {
        get { return this._options.ResponseValidation; }
        init { this._options.ResponseValidation = value; }
    }

    /// <inheritdoc/>
    public int? MaxRetries
    {
        get { return this._options.MaxRetries; }
        init { this._options.MaxRetries = value; }
    }

    /// <inheritdoc/>
    public TimeSpan? Timeout
    {
        get { return this._options.Timeout; }
        init { this._options.Timeout = value; }
    }

    /// <inheritdoc/>
    public string APIKey
    {
        get { return this._options.APIKey; }
        init { this._options.APIKey = value; }
    }

    internal static HttpMethod PatchMethod = new("PATCH");

    /// <inheritdoc/>
    public ICasedevClient WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CasedevClient(modifier(this._options));
    }

    readonly Lazy<IActionService> _actions;
    public IActionService Actions
    {
        get { return _actions.Value; }
    }

    readonly Lazy<IComputeService> _compute;
    public IComputeService Compute
    {
        get { return _compute.Value; }
    }

    readonly Lazy<IConvertService> _convert;
    public IConvertService Convert
    {
        get { return _convert.Value; }
    }

    readonly Lazy<IFormatService> _format;
    public IFormatService Format
    {
        get { return _format.Value; }
    }

    readonly Lazy<ILlmService> _llm;
    public ILlmService Llm
    {
        get { return _llm.Value; }
    }

    readonly Lazy<IOcrService> _ocr;
    public IOcrService Ocr
    {
        get { return _ocr.Value; }
    }

    readonly Lazy<ISearchService> _search;
    public ISearchService Search
    {
        get { return _search.Value; }
    }

    readonly Lazy<IVaultService> _vault;
    public IVaultService Vault
    {
        get { return _vault.Value; }
    }

    readonly Lazy<IVoiceService> _voice;
    public IVoiceService Voice
    {
        get { return _voice.Value; }
    }

    readonly Lazy<IWebhookService> _webhooks;
    public IWebhookService Webhooks
    {
        get { return _webhooks.Value; }
    }

    readonly Lazy<ITemplateService> _templates;
    public ITemplateService Templates
    {
        get { return _templates.Value; }
    }

    readonly Lazy<IWorkflowService> _workflows;
    public IWorkflowService Workflows
    {
        get { return _workflows.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse> Execute<T>(
        HttpRequest<T> request,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase
    {
        var maxRetries = this.MaxRetries ?? ClientOptions.DefaultMaxRetries;
        var retries = 0;
        while (true)
        {
            HttpResponse? response = null;
            try
            {
                response = await ExecuteOnce(request, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                if (++retries > maxRetries || !ShouldRetry(e))
                {
                    throw;
                }
            }

            if (response != null && (++retries > maxRetries || !ShouldRetry(response)))
            {
                if (response.Message.IsSuccessStatusCode)
                {
                    return response;
                }

                try
                {
                    throw CasedevExceptionFactory.CreateApiException(
                        response.Message.StatusCode,
                        await response.ReadAsString(cancellationToken).ConfigureAwait(false)
                    );
                }
                catch (HttpRequestException e)
                {
                    throw new CasedevIOException("I/O Exception", e);
                }
                finally
                {
                    response.Dispose();
                }
            }

            var backoff = ComputeRetryBackoff(retries, response);
            response?.Dispose();
            await Task.Delay(backoff, cancellationToken).ConfigureAwait(false);
        }
    }

    async Task<HttpResponse> ExecuteOnce<T>(
        HttpRequest<T> request,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase
    {
        using HttpRequestMessage requestMessage = new(
            request.Method,
            request.Params.Url(this._options)
        )
        {
            Content = request.Params.BodyContent(),
        };
        request.Params.AddHeadersToRequest(requestMessage, this._options);
        using CancellationTokenSource timeoutCts = new(
            this.Timeout ?? ClientOptions.DefaultTimeout
        );
        using var cts = CancellationTokenSource.CreateLinkedTokenSource(
            timeoutCts.Token,
            cancellationToken
        );
        HttpResponseMessage responseMessage;
        try
        {
            responseMessage = await this
                .HttpClient.SendAsync(
                    requestMessage,
                    HttpCompletionOption.ResponseHeadersRead,
                    cts.Token
                )
                .ConfigureAwait(false);
        }
        catch (HttpRequestException e)
        {
            throw new CasedevIOException("I/O exception", e);
        }
        return new() { Message = responseMessage, CancellationToken = cts.Token };
    }

    static TimeSpan ComputeRetryBackoff(int retries, HttpResponse? response)
    {
        TimeSpan? apiBackoff = ParseRetryAfterMsHeader(response) ?? ParseRetryAfterHeader(response);
        if (apiBackoff != null && apiBackoff < TimeSpan.FromMinutes(1))
        {
            // If the API asks us to wait a certain amount of time (and it's a reasonable amount), then just
            // do what it says.
            return (TimeSpan)apiBackoff;
        }

        // Apply exponential backoff, but not more than the max.
        var backoffSeconds = Math.Min(0.5 * Math.Pow(2.0, retries - 1), 8.0);
        var jitter = 1.0 - 0.25 * Random.NextDouble();
        return TimeSpan.FromSeconds(backoffSeconds * jitter);
    }

    static TimeSpan? ParseRetryAfterMsHeader(HttpResponse? response)
    {
        IEnumerable<string>? headerValues = null;
        response?.Message.Headers.TryGetValues("Retry-After-Ms", out headerValues);
        var headerValue = headerValues == null ? null : Enumerable.FirstOrDefault(headerValues);
        if (headerValue == null)
        {
            return null;
        }

        if (float.TryParse(headerValue, out var retryAfterMs))
        {
            return TimeSpan.FromMilliseconds(retryAfterMs);
        }

        return null;
    }

    static TimeSpan? ParseRetryAfterHeader(HttpResponse? response)
    {
        IEnumerable<string>? headerValues = null;
        response?.Message.Headers.TryGetValues("Retry-After", out headerValues);
        var headerValue = headerValues == null ? null : Enumerable.FirstOrDefault(headerValues);
        if (headerValue == null)
        {
            return null;
        }

        if (float.TryParse(headerValue, out var retryAfterSeconds))
        {
            return TimeSpan.FromSeconds(retryAfterSeconds);
        }
        else if (DateTimeOffset.TryParse(headerValue, out var retryAfterDate))
        {
            return retryAfterDate - DateTimeOffset.Now;
        }

        return null;
    }

    static bool ShouldRetry(HttpResponse response)
    {
        if (
            response.Message.Headers.TryGetValues("X-Should-Retry", out var headerValues)
            && bool.TryParse(Enumerable.FirstOrDefault(headerValues), out var shouldRetry)
        )
        {
            // If the server explicitly says whether to retry, then we obey.
            return shouldRetry;
        }

        return (int)response.Message.StatusCode switch
        {
            // Retry on request timeouts
            408
            or
            // Retry on lock timeouts
            409
            or
            // Retry on rate limits
            429
            or
            // Retry internal errors
            >= 500 => true,
            _ => false,
        };
    }

    static bool ShouldRetry(Exception e)
    {
        return e is IOException || e is CasedevIOException;
    }

    public CasedevClient()
    {
        _options = new();

        _actions = new(() => new ActionService(this));
        _compute = new(() => new ComputeService(this));
        _convert = new(() => new ConvertService(this));
        _format = new(() => new FormatService(this));
        _llm = new(() => new LlmService(this));
        _ocr = new(() => new OcrService(this));
        _search = new(() => new SearchService(this));
        _vault = new(() => new VaultService(this));
        _voice = new(() => new VoiceService(this));
        _webhooks = new(() => new WebhookService(this));
        _templates = new(() => new TemplateService(this));
        _workflows = new(() => new WorkflowService(this));
    }

    public CasedevClient(ClientOptions options)
        : this()
    {
        _options = options;
    }
}
