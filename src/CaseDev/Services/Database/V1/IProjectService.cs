using System;
using System.Threading;
using System.Threading.Tasks;
using CaseDev.Core;
using CaseDev.Models.Database.V1.Projects;

namespace CaseDev.Services.Database.V1;

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
    /// Creates a new serverless Postgres database project powered by Neon. Includes
    /// automatic scaling, connection pooling, and a default 'main' branch with 'neondb'
    /// database. Supports branching for isolated dev/staging environments. Perfect
    /// for case management applications, document workflows, and litigation support systems.
    /// </summary>
    Task<ProjectCreateResponse> Create(
        ProjectCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves detailed information about a specific database project including
    /// branches, databases, storage/compute metrics, connection host, and linked
    /// deployments. Fetches live usage statistics from Neon API.
    /// </summary>
    Task<ProjectRetrieveResponse> Retrieve(
        ProjectRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ProjectRetrieveParams, CancellationToken)"/>
    Task<ProjectRetrieveResponse> Retrieve(
        string id,
        ProjectRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves all serverless Postgres database projects for the authenticated
    /// organization. Includes storage and compute metrics, plus linked deployments
    /// from Thurgood apps and Compute instances.
    /// </summary>
    Task<ProjectListResponse> List(
        ProjectListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Permanently deletes a database project from Neon and marks it as deleted
    /// in Case.dev. This action cannot be undone and will destroy all data including
    /// branches and databases. Use with caution.
    /// </summary>
    Task<ProjectDeleteResponse> Delete(
        ProjectDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(ProjectDeleteParams, CancellationToken)"/>
    Task<ProjectDeleteResponse> Delete(
        string id,
        ProjectDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates a new branch from the specified parent branch (or default 'main'
    /// branch). Branches provide instant point-in-time clones of your database for
    /// isolated development, staging, testing, or feature work. Perfect for testing
    /// schema changes, running migrations safely, or creating ephemeral preview environments.
    /// </summary>
    Task<ProjectCreateBranchResponse> CreateBranch(
        ProjectCreateBranchParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="CreateBranch(ProjectCreateBranchParams, CancellationToken)"/>
    Task<ProjectCreateBranchResponse> CreateBranch(
        string id,
        ProjectCreateBranchParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves the PostgreSQL connection URI for a database project. Supports
    /// selecting specific branches and pooled vs direct connections. Connection strings
    /// include credentials and should be stored securely. Use for configuring applications
    /// and deployment environments.
    /// </summary>
    Task<ProjectGetConnectionResponse> GetConnection(
        ProjectGetConnectionParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetConnection(ProjectGetConnectionParams, CancellationToken)"/>
    Task<ProjectGetConnectionResponse> GetConnection(
        string id,
        ProjectGetConnectionParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves all branches for a database project. Branches enable isolated development
    /// and testing environments with instant point-in-time cloning. Each branch
    /// includes the default branch and any custom branches created for staging, testing,
    /// or feature development.
    /// </summary>
    Task<ProjectListBranchesResponse> ListBranches(
        ProjectListBranchesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListBranches(ProjectListBranchesParams, CancellationToken)"/>
    Task<ProjectListBranchesResponse> ListBranches(
        string id,
        ProjectListBranchesParams? parameters = null,
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
    /// Returns a raw HTTP response for `post /database/v1/projects`, but is otherwise the
    /// same as <see cref="IProjectService.Create(ProjectCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ProjectCreateResponse>> Create(
        ProjectCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /database/v1/projects/{id}`, but is otherwise the
    /// same as <see cref="IProjectService.Retrieve(ProjectRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ProjectRetrieveResponse>> Retrieve(
        ProjectRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ProjectRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<ProjectRetrieveResponse>> Retrieve(
        string id,
        ProjectRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /database/v1/projects`, but is otherwise the
    /// same as <see cref="IProjectService.List(ProjectListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ProjectListResponse>> List(
        ProjectListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `delete /database/v1/projects/{id}`, but is otherwise the
    /// same as <see cref="IProjectService.Delete(ProjectDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ProjectDeleteResponse>> Delete(
        ProjectDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(ProjectDeleteParams, CancellationToken)"/>
    Task<HttpResponse<ProjectDeleteResponse>> Delete(
        string id,
        ProjectDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /database/v1/projects/{id}/branches`, but is otherwise the
    /// same as <see cref="IProjectService.CreateBranch(ProjectCreateBranchParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ProjectCreateBranchResponse>> CreateBranch(
        ProjectCreateBranchParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="CreateBranch(ProjectCreateBranchParams, CancellationToken)"/>
    Task<HttpResponse<ProjectCreateBranchResponse>> CreateBranch(
        string id,
        ProjectCreateBranchParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /database/v1/projects/{id}/connection`, but is otherwise the
    /// same as <see cref="IProjectService.GetConnection(ProjectGetConnectionParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ProjectGetConnectionResponse>> GetConnection(
        ProjectGetConnectionParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetConnection(ProjectGetConnectionParams, CancellationToken)"/>
    Task<HttpResponse<ProjectGetConnectionResponse>> GetConnection(
        string id,
        ProjectGetConnectionParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /database/v1/projects/{id}/branches`, but is otherwise the
    /// same as <see cref="IProjectService.ListBranches(ProjectListBranchesParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ProjectListBranchesResponse>> ListBranches(
        ProjectListBranchesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListBranches(ProjectListBranchesParams, CancellationToken)"/>
    Task<HttpResponse<ProjectListBranchesResponse>> ListBranches(
        string id,
        ProjectListBranchesParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
