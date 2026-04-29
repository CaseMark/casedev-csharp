using System;
using System.Threading;
using System.Threading.Tasks;
using Casedev.Core;
using Casedev.Models.Worker.V1;

namespace Casedev.Services.Worker;

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
    /// Creates a Daytona-backed worker runtime. The worker exposes its native runtime
    /// API through /worker/v1/:id/* without reshaping payloads or events.
    /// </summary>
    Task Create(V1CreateParams? parameters = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get worker
    /// </summary>
    Task Retrieve(V1RetrieveParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Retrieve(V1RetrieveParams, CancellationToken)"/>
    Task Retrieve(
        string id,
        V1RetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// End worker
    /// </summary>
    Task Delete(V1DeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(V1DeleteParams, CancellationToken)"/>
    Task Delete(
        string id,
        V1DeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Starts or resumes the worker sandbox and OpenCode server. Native
    /// /worker/v1/:id/* proxy routes require this lifecycle primitive to have completed
    /// first.
    /// </summary>
    Task Boot(V1BootParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Boot(V1BootParams, CancellationToken)"/>
    Task Boot(
        string id,
        V1BootParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Forwards a DELETE request to the worker runtime without translating response
    /// shapes.
    /// </summary>
    Task ProxyDelete(V1ProxyDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="ProxyDelete(V1ProxyDeleteParams, CancellationToken)"/>
    Task ProxyDelete(
        string workerPath,
        V1ProxyDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Forwards a GET request to the worker runtime without translating response or SSE
    /// event shapes.
    /// </summary>
    Task ProxyGet(V1ProxyGetParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="ProxyGet(V1ProxyGetParams, CancellationToken)"/>
    Task ProxyGet(
        string workerPath,
        V1ProxyGetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Forwards a PATCH request to the worker runtime without translating request or
    /// response shapes.
    /// </summary>
    Task ProxyPatch(V1ProxyPatchParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="ProxyPatch(V1ProxyPatchParams, CancellationToken)"/>
    Task ProxyPatch(
        string workerPath,
        V1ProxyPatchParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Forwards a POST request to the worker runtime without translating request,
    /// response, or SSE event shapes.
    /// </summary>
    Task ProxyPost(V1ProxyPostParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="ProxyPost(V1ProxyPostParams, CancellationToken)"/>
    Task ProxyPost(
        string workerPath,
        V1ProxyPostParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Forwards a PUT request to the worker runtime without translating request or
    /// response shapes.
    /// </summary>
    Task ProxyPut(V1ProxyPutParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="ProxyPut(V1ProxyPutParams, CancellationToken)"/>
    Task ProxyPut(
        string workerPath,
        V1ProxyPutParams parameters,
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
    /// Returns a raw HTTP response for <c>post /worker/v1</c>, but is otherwise the
    /// same as <see cref="IV1Service.Create(V1CreateParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Create(
        V1CreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /worker/v1/{id}</c>, but is otherwise the
    /// same as <see cref="IV1Service.Retrieve(V1RetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Retrieve(
        V1RetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(V1RetrieveParams, CancellationToken)"/>
    Task<HttpResponse> Retrieve(
        string id,
        V1RetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /worker/v1/{id}</c>, but is otherwise the
    /// same as <see cref="IV1Service.Delete(V1DeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        V1DeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(V1DeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string id,
        V1DeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /worker/v1/{id}/boot</c>, but is otherwise the
    /// same as <see cref="IV1Service.Boot(V1BootParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Boot(V1BootParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Boot(V1BootParams, CancellationToken)"/>
    Task<HttpResponse> Boot(
        string id,
        V1BootParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /worker/v1/{id}/{workerPath}</c>, but is otherwise the
    /// same as <see cref="IV1Service.ProxyDelete(V1ProxyDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> ProxyDelete(
        V1ProxyDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ProxyDelete(V1ProxyDeleteParams, CancellationToken)"/>
    Task<HttpResponse> ProxyDelete(
        string workerPath,
        V1ProxyDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /worker/v1/{id}/{workerPath}</c>, but is otherwise the
    /// same as <see cref="IV1Service.ProxyGet(V1ProxyGetParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> ProxyGet(
        V1ProxyGetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ProxyGet(V1ProxyGetParams, CancellationToken)"/>
    Task<HttpResponse> ProxyGet(
        string workerPath,
        V1ProxyGetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /worker/v1/{id}/{workerPath}</c>, but is otherwise the
    /// same as <see cref="IV1Service.ProxyPatch(V1ProxyPatchParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> ProxyPatch(
        V1ProxyPatchParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ProxyPatch(V1ProxyPatchParams, CancellationToken)"/>
    Task<HttpResponse> ProxyPatch(
        string workerPath,
        V1ProxyPatchParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /worker/v1/{id}/{workerPath}</c>, but is otherwise the
    /// same as <see cref="IV1Service.ProxyPost(V1ProxyPostParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> ProxyPost(
        V1ProxyPostParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ProxyPost(V1ProxyPostParams, CancellationToken)"/>
    Task<HttpResponse> ProxyPost(
        string workerPath,
        V1ProxyPostParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /worker/v1/{id}/{workerPath}</c>, but is otherwise the
    /// same as <see cref="IV1Service.ProxyPut(V1ProxyPutParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> ProxyPut(
        V1ProxyPutParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ProxyPut(V1ProxyPutParams, CancellationToken)"/>
    Task<HttpResponse> ProxyPut(
        string workerPath,
        V1ProxyPutParams parameters,
        CancellationToken cancellationToken = default
    );
}
