using System;
using System.Threading;
using System.Threading.Tasks;
using Casedev.Core;
using Casedev.Models.Webhooks.V1.Endpoints;

namespace Casedev.Services.Webhooks.V1;

/// <summary>
/// Webhook endpoint management
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IEndpointService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IEndpointServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEndpointService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Creates a webhook endpoint that receives platform events matching the supplied
    /// event-type filters. Returns the generated signing secret ONCE — the response is
    /// the only time it is shown in plaintext.
    /// </summary>
    Task Create(EndpointCreateParams parameters, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get webhook endpoint
    /// </summary>
    Task Retrieve(EndpointRetrieveParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Retrieve(EndpointRetrieveParams, CancellationToken)"/>
    Task Retrieve(
        string id,
        EndpointRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Partially updates a webhook endpoint. Any omitted field is left unchanged.
    /// Signing secrets are rotated via the separate /rotate_secret endpoint.
    /// </summary>
    Task Update(EndpointUpdateParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Update(EndpointUpdateParams, CancellationToken)"/>
    Task Update(
        string id,
        EndpointUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the organization's webhook endpoints, newest first. Signing secrets are
    /// never included.
    /// </summary>
    Task List(EndpointListParams? parameters = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Soft-deletes a webhook endpoint. Delivery stops immediately and the endpoint no
    /// longer appears in list results. Delivery history is preserved (and can be
    /// fetched via GET /deliveries with the endpoint_id filter) so audit trails and
    /// post-mortem debugging remain possible.
    /// </summary>
    Task Delete(EndpointDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(EndpointDeleteParams, CancellationToken)"/>
    Task Delete(
        string id,
        EndpointDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Generates a new signing secret for the endpoint. The previous secret remains
    /// valid until `previousSecretExpiresInSec` elapses (default 24h, max 30 days).
    /// During the grace window deliveries are signed with both secrets so receivers can
    /// migrate without downtime. Returns the new secret — this is the only time it is
    /// shown in plaintext.
    /// </summary>
    Task RotateSecret(
        EndpointRotateSecretParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RotateSecret(EndpointRotateSecretParams, CancellationToken)"/>
    Task RotateSecret(
        string id,
        EndpointRotateSecretParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Synchronously delivers a synthetic `webhook.test` event to the endpoint and
    /// returns the HTTP result. No retries. Useful for validating that a new endpoint
    /// is reachable and its signature verifier works. The delivery is not persisted in
    /// the delivery history.
    /// </summary>
    Task Test(EndpointTestParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Test(EndpointTestParams, CancellationToken)"/>
    Task Test(
        string id,
        EndpointTestParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IEndpointService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IEndpointServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEndpointServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /webhooks/v1/endpoints</c>, but is otherwise the
    /// same as <see cref="IEndpointService.Create(EndpointCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Create(
        EndpointCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /webhooks/v1/endpoints/{id}</c>, but is otherwise the
    /// same as <see cref="IEndpointService.Retrieve(EndpointRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Retrieve(
        EndpointRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(EndpointRetrieveParams, CancellationToken)"/>
    Task<HttpResponse> Retrieve(
        string id,
        EndpointRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /webhooks/v1/endpoints/{id}</c>, but is otherwise the
    /// same as <see cref="IEndpointService.Update(EndpointUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Update(
        EndpointUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(EndpointUpdateParams, CancellationToken)"/>
    Task<HttpResponse> Update(
        string id,
        EndpointUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /webhooks/v1/endpoints</c>, but is otherwise the
    /// same as <see cref="IEndpointService.List(EndpointListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> List(
        EndpointListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /webhooks/v1/endpoints/{id}</c>, but is otherwise the
    /// same as <see cref="IEndpointService.Delete(EndpointDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        EndpointDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(EndpointDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string id,
        EndpointDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /webhooks/v1/endpoints/{id}/rotate_secret</c>, but is otherwise the
    /// same as <see cref="IEndpointService.RotateSecret(EndpointRotateSecretParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> RotateSecret(
        EndpointRotateSecretParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RotateSecret(EndpointRotateSecretParams, CancellationToken)"/>
    Task<HttpResponse> RotateSecret(
        string id,
        EndpointRotateSecretParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /webhooks/v1/endpoints/{id}/test</c>, but is otherwise the
    /// same as <see cref="IEndpointService.Test(EndpointTestParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Test(
        EndpointTestParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Test(EndpointTestParams, CancellationToken)"/>
    Task<HttpResponse> Test(
        string id,
        EndpointTestParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
