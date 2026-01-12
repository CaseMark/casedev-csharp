using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CaseDev.Core;
using CaseDev.Services;

namespace CaseDev;

/// <summary>
/// A client for interacting with the Casedev REST API.
///
/// <para>This client performs best when you create a single instance and reuse it
/// for all interactions with the REST API. This is because each client holds its
/// own connection pool and thread pools. Reusing connections and threads reduces
/// latency and saves memory.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ICasedevClient : IDisposable
{
    /// <inheritdoc cref="ClientOptions.HttpClient" />
    HttpClient HttpClient { get; init; }

    /// <inheritdoc cref="ClientOptions.BaseUrl" />
    string BaseUrl { get; init; }

    /// <inheritdoc cref="ClientOptions.ResponseValidation" />
    bool ResponseValidation { get; init; }

    /// <inheritdoc cref="ClientOptions.MaxRetries" />
    int? MaxRetries { get; init; }

    /// <inheritdoc cref="ClientOptions.Timeout" />
    TimeSpan? Timeout { get; init; }

    /// <summary>
    /// API key authentication. Use your case.dev API key (e.g., sk_case_your_api_key_here)
    /// </summary>
    string ApiKey { get; init; }

    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICasedevClientWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICasedevClient WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IActionService Actions { get; }

    IComputeService Compute { get; }

    IConvertService Convert { get; }

    IFormatService Format { get; }

    ILlmService Llm { get; }

    IOcrService Ocr { get; }

    ISearchService Search { get; }

    IVaultService Vault { get; }

    IVoiceService Voice { get; }

    IWebhookService Webhooks { get; }

    ITemplateService Templates { get; }

    IWorkflowService Workflows { get; }
}

/// <summary>
/// A view of <see cref="ICasedevClient"/> that provides access to raw HTTP responses for each method.
/// </summary>
public interface ICasedevClientWithRawResponse : IDisposable
{
    /// <inheritdoc cref="ClientOptions.HttpClient" />
    HttpClient HttpClient { get; init; }

    /// <inheritdoc cref="ClientOptions.BaseUrl" />
    string BaseUrl { get; init; }

    /// <inheritdoc cref="ClientOptions.ResponseValidation" />
    bool ResponseValidation { get; init; }

    /// <inheritdoc cref="ClientOptions.MaxRetries" />
    int? MaxRetries { get; init; }

    /// <inheritdoc cref="ClientOptions.Timeout" />
    TimeSpan? Timeout { get; init; }

    /// <summary>
    /// API key authentication. Use your case.dev API key (e.g., sk_case_your_api_key_here)
    /// </summary>
    string ApiKey { get; init; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICasedevClientWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IActionServiceWithRawResponse Actions { get; }

    IComputeServiceWithRawResponse Compute { get; }

    IConvertServiceWithRawResponse Convert { get; }

    IFormatServiceWithRawResponse Format { get; }

    ILlmServiceWithRawResponse Llm { get; }

    IOcrServiceWithRawResponse Ocr { get; }

    ISearchServiceWithRawResponse Search { get; }

    IVaultServiceWithRawResponse Vault { get; }

    IVoiceServiceWithRawResponse Voice { get; }

    IWebhookServiceWithRawResponse Webhooks { get; }

    ITemplateServiceWithRawResponse Templates { get; }

    IWorkflowServiceWithRawResponse Workflows { get; }

    /// <summary>
    /// Sends a request to the Casedev REST API.
    /// </summary>
    Task<HttpResponse> Execute<T>(
        HttpRequest<T> request,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase;
}
