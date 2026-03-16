using System;
using System.Threading;
using System.Threading.Tasks;
using Casedev.Core;
using Casedev.Models.Operator.V1;

namespace Casedev.Services.Operator;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IV1Service
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IV1ServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IV1Service WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Provision a new operator instance for the organization.
    /// </summary>
    Task Create(V1CreateParams parameters, CancellationToken cancellationToken = default);

    /// <summary>
    /// Proxy a chat completion request to the organization's operator instance.
    /// </summary>
    Task CreateChatCompletion(
        V1CreateChatCompletionParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Proxy a response request to the organization's operator instance.
    /// </summary>
    Task CreateResponse(
        V1CreateResponseParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get the status of the organization's operator instance.
    /// </summary>
    Task GetStatus(
        V1GetStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IV1Service"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IV1ServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IV1ServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `post /operator/v1/create`, but is otherwise the
    /// same as <see cref="IV1Service.Create(V1CreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Create(
        V1CreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /operator/v1/chat/completions`, but is otherwise the
    /// same as <see cref="IV1Service.CreateChatCompletion(V1CreateChatCompletionParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> CreateChatCompletion(
        V1CreateChatCompletionParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /operator/v1/responses`, but is otherwise the
    /// same as <see cref="IV1Service.CreateResponse(V1CreateResponseParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> CreateResponse(
        V1CreateResponseParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /operator/v1/status`, but is otherwise the
    /// same as <see cref="IV1Service.GetStatus(V1GetStatusParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> GetStatus(
        V1GetStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
