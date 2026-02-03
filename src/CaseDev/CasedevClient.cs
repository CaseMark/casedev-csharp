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
    readonly ClientOptions _options;

    /// <inheritdoc/>
    public HttpClient HttpClient
    {
        get { return this._options.HttpClient; }
        init { this._options.HttpClient = value; }
    }

    /// <inheritdoc/>
    public string BaseUrl
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
    public string ApiKey
    {
        get { return this._options.ApiKey; }
        init { this._options.ApiKey = value; }
    }

    readonly Lazy<ICasedevClientWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICasedevClientWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    /// <inheritdoc/>
    public ICasedevClient WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CasedevClient(modifier(this._options));
    }

    readonly Lazy<IApplicationService> _applications;
    public IApplicationService Applications
    {
        get { return _applications.Value; }
    }

    readonly Lazy<IComputeService> _compute;
    public IComputeService Compute
    {
        get { return _compute.Value; }
    }

    readonly Lazy<IDatabaseService> _database;
    public IDatabaseService Database
    {
        get { return _database.Value; }
    }

    readonly Lazy<IFormatService> _format;
    public IFormatService Format
    {
        get { return _format.Value; }
    }

    readonly Lazy<ILegalService> _legal;
    public ILegalService Legal
    {
        get { return _legal.Value; }
    }

    readonly Lazy<ILlmService> _llm;
    public ILlmService Llm
    {
        get { return _llm.Value; }
    }

    readonly Lazy<IMemoryService> _memory;
    public IMemoryService Memory
    {
        get { return _memory.Value; }
    }

    readonly Lazy<IOcrService> _ocr;
    public IOcrService Ocr
    {
        get { return _ocr.Value; }
    }

    readonly Lazy<IPaymentService> _payments;
    public IPaymentService Payments
    {
        get { return _payments.Value; }
    }

    readonly Lazy<IPrivilegeService> _privilege;
    public IPrivilegeService Privilege
    {
        get { return _privilege.Value; }
    }

    readonly Lazy<IProjectService> _projects;
    public IProjectService Projects
    {
        get { return _projects.Value; }
    }

    readonly Lazy<ISearchService> _search;
    public ISearchService Search
    {
        get { return _search.Value; }
    }

    readonly Lazy<ISuperdocService> _superdoc;
    public ISuperdocService Superdoc
    {
        get { return _superdoc.Value; }
    }

    readonly Lazy<ITranslateService> _translate;
    public ITranslateService Translate
    {
        get { return _translate.Value; }
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

    public void Dispose() => this.HttpClient.Dispose();

    public CasedevClient()
    {
        _options = new();

        _withRawResponse = new(() => new CasedevClientWithRawResponse(this._options));
        _applications = new(() => new ApplicationService(this));
        _compute = new(() => new ComputeService(this));
        _database = new(() => new DatabaseService(this));
        _format = new(() => new FormatService(this));
        _legal = new(() => new LegalService(this));
        _llm = new(() => new LlmService(this));
        _memory = new(() => new MemoryService(this));
        _ocr = new(() => new OcrService(this));
        _payments = new(() => new PaymentService(this));
        _privilege = new(() => new PrivilegeService(this));
        _projects = new(() => new ProjectService(this));
        _search = new(() => new SearchService(this));
        _superdoc = new(() => new SuperdocService(this));
        _translate = new(() => new TranslateService(this));
        _vault = new(() => new VaultService(this));
        _voice = new(() => new VoiceService(this));
    }

    public CasedevClient(ClientOptions options)
        : this()
    {
        _options = options;
    }
}

/// <inheritdoc/>
public sealed class CasedevClientWithRawResponse : ICasedevClientWithRawResponse
{
#if NET
    static readonly Random Random = Random.Shared;
#else
    static readonly ThreadLocal<Random> _threadLocalRandom = new(() => new Random());

    static Random Random
    {
        get { return _threadLocalRandom.Value!; }
    }
#endif

    internal static HttpMethod PatchMethod = new("PATCH");

    readonly ClientOptions _options;

    /// <inheritdoc/>
    public HttpClient HttpClient
    {
        get { return this._options.HttpClient; }
        init { this._options.HttpClient = value; }
    }

    /// <inheritdoc/>
    public string BaseUrl
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
    public string ApiKey
    {
        get { return this._options.ApiKey; }
        init { this._options.ApiKey = value; }
    }

    /// <inheritdoc/>
    public ICasedevClientWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CasedevClientWithRawResponse(modifier(this._options));
    }

    readonly Lazy<IApplicationServiceWithRawResponse> _applications;
    public IApplicationServiceWithRawResponse Applications
    {
        get { return _applications.Value; }
    }

    readonly Lazy<IComputeServiceWithRawResponse> _compute;
    public IComputeServiceWithRawResponse Compute
    {
        get { return _compute.Value; }
    }

    readonly Lazy<IDatabaseServiceWithRawResponse> _database;
    public IDatabaseServiceWithRawResponse Database
    {
        get { return _database.Value; }
    }

    readonly Lazy<IFormatServiceWithRawResponse> _format;
    public IFormatServiceWithRawResponse Format
    {
        get { return _format.Value; }
    }

    readonly Lazy<ILegalServiceWithRawResponse> _legal;
    public ILegalServiceWithRawResponse Legal
    {
        get { return _legal.Value; }
    }

    readonly Lazy<ILlmServiceWithRawResponse> _llm;
    public ILlmServiceWithRawResponse Llm
    {
        get { return _llm.Value; }
    }

    readonly Lazy<IMemoryServiceWithRawResponse> _memory;
    public IMemoryServiceWithRawResponse Memory
    {
        get { return _memory.Value; }
    }

    readonly Lazy<IOcrServiceWithRawResponse> _ocr;
    public IOcrServiceWithRawResponse Ocr
    {
        get { return _ocr.Value; }
    }

    readonly Lazy<IPaymentServiceWithRawResponse> _payments;
    public IPaymentServiceWithRawResponse Payments
    {
        get { return _payments.Value; }
    }

    readonly Lazy<IPrivilegeServiceWithRawResponse> _privilege;
    public IPrivilegeServiceWithRawResponse Privilege
    {
        get { return _privilege.Value; }
    }

    readonly Lazy<IProjectServiceWithRawResponse> _projects;
    public IProjectServiceWithRawResponse Projects
    {
        get { return _projects.Value; }
    }

    readonly Lazy<ISearchServiceWithRawResponse> _search;
    public ISearchServiceWithRawResponse Search
    {
        get { return _search.Value; }
    }

    readonly Lazy<ISuperdocServiceWithRawResponse> _superdoc;
    public ISuperdocServiceWithRawResponse Superdoc
    {
        get { return _superdoc.Value; }
    }

    readonly Lazy<ITranslateServiceWithRawResponse> _translate;
    public ITranslateServiceWithRawResponse Translate
    {
        get { return _translate.Value; }
    }

    readonly Lazy<IVaultServiceWithRawResponse> _vault;
    public IVaultServiceWithRawResponse Vault
    {
        get { return _vault.Value; }
    }

    readonly Lazy<IVoiceServiceWithRawResponse> _voice;
    public IVoiceServiceWithRawResponse Voice
    {
        get { return _voice.Value; }
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
                response = await ExecuteOnce(request, retries, cancellationToken)
                    .ConfigureAwait(false);
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
                if (response.IsSuccessStatusCode)
                {
                    return response;
                }

                try
                {
                    throw CasedevExceptionFactory.CreateApiException(
                        response.StatusCode,
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
        int retryCount,
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
        if (!requestMessage.Headers.Contains("x-stainless-retry-count"))
        {
            requestMessage.Headers.Add("x-stainless-retry-count", retryCount.ToString());
        }
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
        return new() { RawMessage = responseMessage, CancellationToken = cts.Token };
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
        response?.TryGetHeaderValues("Retry-After-Ms", out headerValues);
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
        response?.TryGetHeaderValues("Retry-After", out headerValues);
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
            response.TryGetHeaderValues("X-Should-Retry", out var headerValues)
            && bool.TryParse(Enumerable.FirstOrDefault(headerValues), out var shouldRetry)
        )
        {
            // If the server explicitly says whether to retry, then we obey.
            return shouldRetry;
        }

        return (int)response.StatusCode switch
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

    public void Dispose() => this.HttpClient.Dispose();

    public CasedevClientWithRawResponse()
    {
        _options = new();

        _applications = new(() => new ApplicationServiceWithRawResponse(this));
        _compute = new(() => new ComputeServiceWithRawResponse(this));
        _database = new(() => new DatabaseServiceWithRawResponse(this));
        _format = new(() => new FormatServiceWithRawResponse(this));
        _legal = new(() => new LegalServiceWithRawResponse(this));
        _llm = new(() => new LlmServiceWithRawResponse(this));
        _memory = new(() => new MemoryServiceWithRawResponse(this));
        _ocr = new(() => new OcrServiceWithRawResponse(this));
        _payments = new(() => new PaymentServiceWithRawResponse(this));
        _privilege = new(() => new PrivilegeServiceWithRawResponse(this));
        _projects = new(() => new ProjectServiceWithRawResponse(this));
        _search = new(() => new SearchServiceWithRawResponse(this));
        _superdoc = new(() => new SuperdocServiceWithRawResponse(this));
        _translate = new(() => new TranslateServiceWithRawResponse(this));
        _vault = new(() => new VaultServiceWithRawResponse(this));
        _voice = new(() => new VoiceServiceWithRawResponse(this));
    }

    public CasedevClientWithRawResponse(ClientOptions options)
        : this()
    {
        _options = options;
    }
}
