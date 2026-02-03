using System;
using System.Threading;
using System.Threading.Tasks;
using CaseDev.Core;
using CaseDev.Models.Payments.V1.Holds;

namespace CaseDev.Services.Payments.V1;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IHoldService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IHoldServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IHoldService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create a hold on funds in an account with release conditions
    /// </summary>
    Task Create(HoldCreateParams parameters, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get hold details by ID
    /// </summary>
    Task Retrieve(HoldRetrieveParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Retrieve(HoldRetrieveParams, CancellationToken)"/>
    Task Retrieve(
        string id,
        HoldRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List holds with optional filters
    /// </summary>
    Task List(HoldListParams? parameters = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Record an approval for a hold release condition
    /// </summary>
    Task Approve(HoldApproveParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Approve(HoldApproveParams, CancellationToken)"/>
    Task Approve(
        string id,
        HoldApproveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Cancel an active hold
    /// </summary>
    Task Cancel(HoldCancelParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Cancel(HoldCancelParams, CancellationToken)"/>
    Task Cancel(
        string id,
        HoldCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Manually release a hold
    /// </summary>
    Task Release(HoldReleaseParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Release(HoldReleaseParams, CancellationToken)"/>
    Task Release(
        string id,
        HoldReleaseParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IHoldService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IHoldServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IHoldServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `post /payments/v1/holds`, but is otherwise the
    /// same as <see cref="IHoldService.Create(HoldCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Create(
        HoldCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /payments/v1/holds/{id}`, but is otherwise the
    /// same as <see cref="IHoldService.Retrieve(HoldRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Retrieve(
        HoldRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(HoldRetrieveParams, CancellationToken)"/>
    Task<HttpResponse> Retrieve(
        string id,
        HoldRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /payments/v1/holds`, but is otherwise the
    /// same as <see cref="IHoldService.List(HoldListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> List(
        HoldListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /payments/v1/holds/{id}/approve`, but is otherwise the
    /// same as <see cref="IHoldService.Approve(HoldApproveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Approve(
        HoldApproveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Approve(HoldApproveParams, CancellationToken)"/>
    Task<HttpResponse> Approve(
        string id,
        HoldApproveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /payments/v1/holds/{id}/cancel`, but is otherwise the
    /// same as <see cref="IHoldService.Cancel(HoldCancelParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Cancel(
        HoldCancelParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Cancel(HoldCancelParams, CancellationToken)"/>
    Task<HttpResponse> Cancel(
        string id,
        HoldCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /payments/v1/holds/{id}/release`, but is otherwise the
    /// same as <see cref="IHoldService.Release(HoldReleaseParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Release(
        HoldReleaseParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Release(HoldReleaseParams, CancellationToken)"/>
    Task<HttpResponse> Release(
        string id,
        HoldReleaseParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
