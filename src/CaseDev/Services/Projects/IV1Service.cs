using System;
using System.Threading;
using System.Threading.Tasks;
using CaseDev.Core;
using CaseDev.Models.Projects.V1;

namespace CaseDev.Services.Projects;

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
    /// Create a new project for deployments
    /// </summary>
    Task Create(V1CreateParams parameters, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get a project by ID with its deployments and settings
    /// </summary>
    Task Retrieve(V1RetrieveParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Retrieve(V1RetrieveParams, CancellationToken)"/>
    Task Retrieve(
        string id,
        V1RetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List all projects for the organization
    /// </summary>
    Task<V1ListResponse> List(
        V1ListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a project and all its associated deployments, environment variables,
    /// and domains.
    /// </summary>
    Task<V1DeleteResponse> Delete(
        V1DeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(V1DeleteParams, CancellationToken)"/>
    Task<V1DeleteResponse> Delete(
        string id,
        V1DeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create or update environment variables for a project
    /// </summary>
    Task CreateEnvVars(
        V1CreateEnvVarsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="CreateEnvVars(V1CreateEnvVarsParams, CancellationToken)"/>
    Task CreateEnvVars(
        string id,
        V1CreateEnvVarsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List all environment variables for a project, grouped by environment
    /// </summary>
    Task ListEnvVars(V1ListEnvVarsParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="ListEnvVars(V1ListEnvVarsParams, CancellationToken)"/>
    Task ListEnvVars(
        string id,
        V1ListEnvVarsParams? parameters = null,
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
    /// Returns a raw HTTP response for `post /projects/v1`, but is otherwise the
    /// same as <see cref="IV1Service.Create(V1CreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Create(
        V1CreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /projects/v1/{id}`, but is otherwise the
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
    /// Returns a raw HTTP response for `get /projects/v1`, but is otherwise the
    /// same as <see cref="IV1Service.List(V1ListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<V1ListResponse>> List(
        V1ListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `delete /projects/v1/{id}`, but is otherwise the
    /// same as <see cref="IV1Service.Delete(V1DeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<V1DeleteResponse>> Delete(
        V1DeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(V1DeleteParams, CancellationToken)"/>
    Task<HttpResponse<V1DeleteResponse>> Delete(
        string id,
        V1DeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /projects/v1/{id}/env-vars`, but is otherwise the
    /// same as <see cref="IV1Service.CreateEnvVars(V1CreateEnvVarsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> CreateEnvVars(
        V1CreateEnvVarsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="CreateEnvVars(V1CreateEnvVarsParams, CancellationToken)"/>
    Task<HttpResponse> CreateEnvVars(
        string id,
        V1CreateEnvVarsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /projects/v1/{id}/env-vars`, but is otherwise the
    /// same as <see cref="IV1Service.ListEnvVars(V1ListEnvVarsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> ListEnvVars(
        V1ListEnvVarsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListEnvVars(V1ListEnvVarsParams, CancellationToken)"/>
    Task<HttpResponse> ListEnvVars(
        string id,
        V1ListEnvVarsParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
