using System;
using System.Threading;
using System.Threading.Tasks;
using Casedev.Core;
using Casedev.Models.Compute.V1.Environments;

namespace Casedev.Services.Compute.V1;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IEnvironmentService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IEnvironmentServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEnvironmentService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Creates a new compute environment for running serverless workloads. Each
    /// environment gets its own isolated namespace with a unique domain for hosting
    /// applications and APIs. The first environment created becomes the default
    /// environment for the organization.
    /// </summary>
    Task<EnvironmentCreateResponse> Create(
        EnvironmentCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a specific compute environment by name. Returns environment configuration
    /// including status, domain, and metadata for your serverless compute infrastructure.
    /// </summary>
    Task<EnvironmentRetrieveResponse> Retrieve(
        EnvironmentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(EnvironmentRetrieveParams, CancellationToken)"/>
    Task<EnvironmentRetrieveResponse> Retrieve(
        string name,
        EnvironmentRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve all compute environments for your organization. Environments provide
    /// isolated execution contexts for running code and workflows.
    /// </summary>
    Task<EnvironmentListResponse> List(
        EnvironmentListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Permanently delete a compute environment and all its associated resources.
    /// This will stop all running deployments and clean up related configurations.
    /// The default environment cannot be deleted if other environments exist.
    /// </summary>
    Task<EnvironmentDeleteResponse> Delete(
        EnvironmentDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(EnvironmentDeleteParams, CancellationToken)"/>
    Task<EnvironmentDeleteResponse> Delete(
        string name,
        EnvironmentDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sets a compute environment as the default for the organization. Only one
    /// environment can be default at a time - setting a new default will automatically
    /// unset the previous one.
    /// </summary>
    Task<EnvironmentSetDefaultResponse> SetDefault(
        EnvironmentSetDefaultParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="SetDefault(EnvironmentSetDefaultParams, CancellationToken)"/>
    Task<EnvironmentSetDefaultResponse> SetDefault(
        string name,
        EnvironmentSetDefaultParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IEnvironmentService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IEnvironmentServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEnvironmentServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `post /compute/v1/environments`, but is otherwise the
    /// same as <see cref="IEnvironmentService.Create(EnvironmentCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<EnvironmentCreateResponse>> Create(
        EnvironmentCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /compute/v1/environments/{name}`, but is otherwise the
    /// same as <see cref="IEnvironmentService.Retrieve(EnvironmentRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<EnvironmentRetrieveResponse>> Retrieve(
        EnvironmentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(EnvironmentRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<EnvironmentRetrieveResponse>> Retrieve(
        string name,
        EnvironmentRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /compute/v1/environments`, but is otherwise the
    /// same as <see cref="IEnvironmentService.List(EnvironmentListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<EnvironmentListResponse>> List(
        EnvironmentListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `delete /compute/v1/environments/{name}`, but is otherwise the
    /// same as <see cref="IEnvironmentService.Delete(EnvironmentDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<EnvironmentDeleteResponse>> Delete(
        EnvironmentDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(EnvironmentDeleteParams, CancellationToken)"/>
    Task<HttpResponse<EnvironmentDeleteResponse>> Delete(
        string name,
        EnvironmentDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /compute/v1/environments/{name}/default`, but is otherwise the
    /// same as <see cref="IEnvironmentService.SetDefault(EnvironmentSetDefaultParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<EnvironmentSetDefaultResponse>> SetDefault(
        EnvironmentSetDefaultParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="SetDefault(EnvironmentSetDefaultParams, CancellationToken)"/>
    Task<HttpResponse<EnvironmentSetDefaultResponse>> SetDefault(
        string name,
        EnvironmentSetDefaultParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
