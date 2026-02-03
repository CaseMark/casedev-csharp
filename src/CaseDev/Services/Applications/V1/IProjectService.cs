using System;
using System.Threading;
using System.Threading.Tasks;
using CaseDev.Core;
using CaseDev.Models.Applications.V1.Projects;

namespace CaseDev.Services.Applications.V1;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IProjectService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IProjectServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IProjectService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create a new web application project
    /// </summary>
    Task Create(ProjectCreateParams parameters, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get details of a specific web application project
    /// </summary>
    Task Retrieve(ProjectRetrieveParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Retrieve(ProjectRetrieveParams, CancellationToken)"/>
    Task Retrieve(
        string id,
        ProjectRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List all web application projects
    /// </summary>
    Task<ProjectListResponse> List(
        ProjectListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a web application project
    /// </summary>
    Task Delete(ProjectDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(ProjectDeleteParams, CancellationToken)"/>
    Task Delete(
        string id,
        ProjectDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Trigger a new deployment for a project.
    /// </summary>
    Task CreateDeployment(
        ProjectCreateDeploymentParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="CreateDeployment(ProjectCreateDeploymentParams, CancellationToken)"/>
    Task CreateDeployment(
        string id,
        ProjectCreateDeploymentParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Add a custom domain to a project
    /// </summary>
    Task CreateDomain(
        ProjectCreateDomainParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="CreateDomain(ProjectCreateDomainParams, CancellationToken)"/>
    Task CreateDomain(
        string id,
        ProjectCreateDomainParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create a new environment variable for a project
    /// </summary>
    Task CreateEnv(
        ProjectCreateEnvParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="CreateEnv(ProjectCreateEnvParams, CancellationToken)"/>
    Task CreateEnv(
        string id,
        ProjectCreateEnvParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Remove a domain from a project
    /// </summary>
    Task DeleteDomain(
        ProjectDeleteDomainParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="DeleteDomain(ProjectDeleteDomainParams, CancellationToken)"/>
    Task DeleteDomain(
        string domain,
        ProjectDeleteDomainParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete an environment variable from a project
    /// </summary>
    Task DeleteEnv(
        ProjectDeleteEnvParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="DeleteEnv(ProjectDeleteEnvParams, CancellationToken)"/>
    Task DeleteEnv(
        string envID,
        ProjectDeleteEnvParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get runtime/function logs for a project
    /// </summary>
    Task GetRuntimeLogs(
        ProjectGetRuntimeLogsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetRuntimeLogs(ProjectGetRuntimeLogsParams, CancellationToken)"/>
    Task GetRuntimeLogs(
        string id,
        ProjectGetRuntimeLogsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List deployments for a specific project
    /// </summary>
    Task ListDeployments(
        ProjectListDeploymentsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListDeployments(ProjectListDeploymentsParams, CancellationToken)"/>
    Task ListDeployments(
        string id,
        ProjectListDeploymentsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List all domains configured for a project
    /// </summary>
    Task ListDomains(
        ProjectListDomainsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListDomains(ProjectListDomainsParams, CancellationToken)"/>
    Task ListDomains(
        string id,
        ProjectListDomainsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List all environment variables for a project (values are hidden unless decrypt=true)
    /// </summary>
    Task ListEnv(ProjectListEnvParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="ListEnv(ProjectListEnvParams, CancellationToken)"/>
    Task ListEnv(
        string id,
        ProjectListEnvParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IProjectService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IProjectServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IProjectServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `post /applications/v1/projects`, but is otherwise the
    /// same as <see cref="IProjectService.Create(ProjectCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Create(
        ProjectCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /applications/v1/projects/{id}`, but is otherwise the
    /// same as <see cref="IProjectService.Retrieve(ProjectRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Retrieve(
        ProjectRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ProjectRetrieveParams, CancellationToken)"/>
    Task<HttpResponse> Retrieve(
        string id,
        ProjectRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /applications/v1/projects`, but is otherwise the
    /// same as <see cref="IProjectService.List(ProjectListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ProjectListResponse>> List(
        ProjectListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `delete /applications/v1/projects/{id}`, but is otherwise the
    /// same as <see cref="IProjectService.Delete(ProjectDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        ProjectDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(ProjectDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string id,
        ProjectDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /applications/v1/projects/{id}/deployments`, but is otherwise the
    /// same as <see cref="IProjectService.CreateDeployment(ProjectCreateDeploymentParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> CreateDeployment(
        ProjectCreateDeploymentParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="CreateDeployment(ProjectCreateDeploymentParams, CancellationToken)"/>
    Task<HttpResponse> CreateDeployment(
        string id,
        ProjectCreateDeploymentParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /applications/v1/projects/{id}/domains`, but is otherwise the
    /// same as <see cref="IProjectService.CreateDomain(ProjectCreateDomainParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> CreateDomain(
        ProjectCreateDomainParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="CreateDomain(ProjectCreateDomainParams, CancellationToken)"/>
    Task<HttpResponse> CreateDomain(
        string id,
        ProjectCreateDomainParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /applications/v1/projects/{id}/env`, but is otherwise the
    /// same as <see cref="IProjectService.CreateEnv(ProjectCreateEnvParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> CreateEnv(
        ProjectCreateEnvParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="CreateEnv(ProjectCreateEnvParams, CancellationToken)"/>
    Task<HttpResponse> CreateEnv(
        string id,
        ProjectCreateEnvParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `delete /applications/v1/projects/{id}/domains/{domain}`, but is otherwise the
    /// same as <see cref="IProjectService.DeleteDomain(ProjectDeleteDomainParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> DeleteDomain(
        ProjectDeleteDomainParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="DeleteDomain(ProjectDeleteDomainParams, CancellationToken)"/>
    Task<HttpResponse> DeleteDomain(
        string domain,
        ProjectDeleteDomainParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `delete /applications/v1/projects/{id}/env/{envId}`, but is otherwise the
    /// same as <see cref="IProjectService.DeleteEnv(ProjectDeleteEnvParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> DeleteEnv(
        ProjectDeleteEnvParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="DeleteEnv(ProjectDeleteEnvParams, CancellationToken)"/>
    Task<HttpResponse> DeleteEnv(
        string envID,
        ProjectDeleteEnvParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /applications/v1/projects/{id}/runtime-logs`, but is otherwise the
    /// same as <see cref="IProjectService.GetRuntimeLogs(ProjectGetRuntimeLogsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> GetRuntimeLogs(
        ProjectGetRuntimeLogsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetRuntimeLogs(ProjectGetRuntimeLogsParams, CancellationToken)"/>
    Task<HttpResponse> GetRuntimeLogs(
        string id,
        ProjectGetRuntimeLogsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /applications/v1/projects/{id}/deployments`, but is otherwise the
    /// same as <see cref="IProjectService.ListDeployments(ProjectListDeploymentsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> ListDeployments(
        ProjectListDeploymentsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListDeployments(ProjectListDeploymentsParams, CancellationToken)"/>
    Task<HttpResponse> ListDeployments(
        string id,
        ProjectListDeploymentsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /applications/v1/projects/{id}/domains`, but is otherwise the
    /// same as <see cref="IProjectService.ListDomains(ProjectListDomainsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> ListDomains(
        ProjectListDomainsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListDomains(ProjectListDomainsParams, CancellationToken)"/>
    Task<HttpResponse> ListDomains(
        string id,
        ProjectListDomainsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /applications/v1/projects/{id}/env`, but is otherwise the
    /// same as <see cref="IProjectService.ListEnv(ProjectListEnvParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> ListEnv(
        ProjectListEnvParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListEnv(ProjectListEnvParams, CancellationToken)"/>
    Task<HttpResponse> ListEnv(
        string id,
        ProjectListEnvParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
