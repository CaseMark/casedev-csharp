using System;
using System.Threading;
using System.Threading.Tasks;
using Router.Core;
using Router.Models.Compute.V1.InstanceTypes;

namespace Router.Services.Compute.V1;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IInstanceTypeService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IInstanceTypeServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInstanceTypeService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Retrieves all available GPU instance types with pricing, specifications, and
    /// regional availability. Includes T4, A10, A100, H100, and H200 GPUs powered
    /// by Lambda Labs. Perfect for AI model training, inference workloads, and legal
    /// document OCR processing at scale.
    /// </summary>
    Task<InstanceTypeListResponse> List(
        InstanceTypeListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IInstanceTypeService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IInstanceTypeServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInstanceTypeServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `get /compute/v1/instance-types`, but is otherwise the
    /// same as <see cref="IInstanceTypeService.List(InstanceTypeListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<InstanceTypeListResponse>> List(
        InstanceTypeListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
