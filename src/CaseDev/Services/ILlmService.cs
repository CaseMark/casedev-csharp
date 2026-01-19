using System;
using System.Threading;
using System.Threading.Tasks;
using CaseDev.Core;
using CaseDev.Models.Llm;
using CaseDev.Services.Llm;

namespace CaseDev.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ILlmService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ILlmServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ILlmService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IV1Service V1 { get; }

    /// <summary>
    /// Retrieves the AI Gateway configuration including all available language models
    /// and their specifications. This endpoint returns model information compatible
    /// with the Vercel AI SDK Gateway format, making it easy to integrate with existing
    /// AI applications.
    ///
    /// <para>Use this endpoint to: - Discover available language models - Get model
    /// specifications and pricing - Configure AI SDK clients - Build model selection interfaces</para>
    /// </summary>
    Task<LlmGetConfigResponse> GetConfig(
        LlmGetConfigParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ILlmService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ILlmServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ILlmServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IV1ServiceWithRawResponse V1 { get; }

    /// <summary>
    /// Returns a raw HTTP response for `get /llm/config`, but is otherwise the
    /// same as <see cref="ILlmService.GetConfig(LlmGetConfigParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<LlmGetConfigResponse>> GetConfig(
        LlmGetConfigParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
