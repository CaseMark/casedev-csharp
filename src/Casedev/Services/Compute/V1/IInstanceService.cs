using System;
using System.Threading;
using System.Threading.Tasks;
using Casedev.Core;
using Casedev.Models.Compute.V1.Instances;

namespace Casedev.Services.Compute.V1;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IInstanceService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IInstanceServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInstanceService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Launches a new GPU compute instance with automatic SSH key generation. Supports
    /// mounting Case.dev Vaults as filesystems and configurable auto-shutdown. Instance
    /// boots in ~2-5 minutes. Perfect for batch OCR processing, AI model training,
    /// and intensive document analysis workloads.
    /// </summary>
    Task<InstanceCreateResponse> Create(
        InstanceCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves detailed information about a GPU instance including SSH connection
    /// details, vault mount scripts, real-time cost tracking, and current status.
    /// SSH private key included for secure access.
    /// </summary>
    Task<InstanceRetrieveResponse> Retrieve(
        InstanceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(InstanceRetrieveParams, CancellationToken)"/>
    Task<InstanceRetrieveResponse> Retrieve(
        string id,
        InstanceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves all GPU compute instances for your organization with real-time
    /// status updates from Lambda Labs. Includes pricing, runtime metrics, and auto-shutdown
    /// configuration. Perfect for monitoring AI workloads, document processing jobs,
    /// and cost tracking.
    /// </summary>
    Task<InstanceListResponse> List(
        InstanceListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Terminates a running GPU instance, calculates final cost, and cleans up SSH
    /// keys. This action is permanent and cannot be undone. All data on the instance
    /// will be lost.
    /// </summary>
    Task<InstanceDeleteResponse> Delete(
        InstanceDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(InstanceDeleteParams, CancellationToken)"/>
    Task<InstanceDeleteResponse> Delete(
        string id,
        InstanceDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IInstanceService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IInstanceServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInstanceServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `post /compute/v1/instances`, but is otherwise the
    /// same as <see cref="IInstanceService.Create(InstanceCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<InstanceCreateResponse>> Create(
        InstanceCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /compute/v1/instances/{id}`, but is otherwise the
    /// same as <see cref="IInstanceService.Retrieve(InstanceRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<InstanceRetrieveResponse>> Retrieve(
        InstanceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(InstanceRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<InstanceRetrieveResponse>> Retrieve(
        string id,
        InstanceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /compute/v1/instances`, but is otherwise the
    /// same as <see cref="IInstanceService.List(InstanceListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<InstanceListResponse>> List(
        InstanceListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `delete /compute/v1/instances/{id}`, but is otherwise the
    /// same as <see cref="IInstanceService.Delete(InstanceDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<InstanceDeleteResponse>> Delete(
        InstanceDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(InstanceDeleteParams, CancellationToken)"/>
    Task<HttpResponse<InstanceDeleteResponse>> Delete(
        string id,
        InstanceDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
