using System;
using System.Threading;
using System.Threading.Tasks;
using CaseDev.Core;
using CaseDev.Models.Payments.V1.Transfers;

namespace CaseDev.Services.Payments.V1;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ITransferService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ITransferServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITransferService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create a transfer between payment accounts
    /// </summary>
    Task Create(TransferCreateParams parameters, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get transfer details by ID
    /// </summary>
    Task Retrieve(TransferRetrieveParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Retrieve(TransferRetrieveParams, CancellationToken)"/>
    Task Retrieve(
        string id,
        TransferRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List transfers with optional filters
    /// </summary>
    Task List(TransferListParams? parameters = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Approve and execute a pending transfer
    /// </summary>
    Task Approve(TransferApproveParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Approve(TransferApproveParams, CancellationToken)"/>
    Task Approve(
        string id,
        TransferApproveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Cancel a pending transfer
    /// </summary>
    Task Cancel(TransferCancelParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Cancel(TransferCancelParams, CancellationToken)"/>
    Task Cancel(
        string id,
        TransferCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ITransferService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ITransferServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITransferServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `post /payments/v1/transfers`, but is otherwise the
    /// same as <see cref="ITransferService.Create(TransferCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Create(
        TransferCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /payments/v1/transfers/{id}`, but is otherwise the
    /// same as <see cref="ITransferService.Retrieve(TransferRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Retrieve(
        TransferRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(TransferRetrieveParams, CancellationToken)"/>
    Task<HttpResponse> Retrieve(
        string id,
        TransferRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /payments/v1/transfers`, but is otherwise the
    /// same as <see cref="ITransferService.List(TransferListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> List(
        TransferListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /payments/v1/transfers/{id}/approve`, but is otherwise the
    /// same as <see cref="ITransferService.Approve(TransferApproveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Approve(
        TransferApproveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Approve(TransferApproveParams, CancellationToken)"/>
    Task<HttpResponse> Approve(
        string id,
        TransferApproveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /payments/v1/transfers/{id}/cancel`, but is otherwise the
    /// same as <see cref="ITransferService.Cancel(TransferCancelParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Cancel(
        TransferCancelParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Cancel(TransferCancelParams, CancellationToken)"/>
    Task<HttpResponse> Cancel(
        string id,
        TransferCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
