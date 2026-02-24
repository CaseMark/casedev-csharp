using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Casedev.Core;
using Casedev.Exceptions;
using Casedev.Models.Applications.V1.Projects;

namespace Casedev.Services.Applications.V1;

/// <inheritdoc/>
public sealed class ProjectService : IProjectService
{
    readonly Lazy<IProjectServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IProjectServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICasedevClient _client;

    /// <inheritdoc/>
    public IProjectService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ProjectService(this._client.WithOptions(modifier));
    }

    public ProjectService(ICasedevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ProjectServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public Task Create(
        ProjectCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Create(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Retrieve(
        ProjectRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Retrieve(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Retrieve(
        string id,
        ProjectRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Retrieve(parameters with { ID = id }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ProjectListResponse> List(
        ProjectListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(
        ProjectDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string id,
        ProjectDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { ID = id }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task CreateDeployment(
        ProjectCreateDeploymentParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.CreateDeployment(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task CreateDeployment(
        string id,
        ProjectCreateDeploymentParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.CreateDeployment(parameters with { ID = id }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task CreateDomain(
        ProjectCreateDomainParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.CreateDomain(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task CreateDomain(
        string id,
        ProjectCreateDomainParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.CreateDomain(parameters with { ID = id }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task CreateEnv(
        ProjectCreateEnvParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.CreateEnv(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task CreateEnv(
        string id,
        ProjectCreateEnvParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.CreateEnv(parameters with { ID = id }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task DeleteDomain(
        ProjectDeleteDomainParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.DeleteDomain(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task DeleteDomain(
        string domain,
        ProjectDeleteDomainParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.DeleteDomain(parameters with { Domain = domain }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task DeleteEnv(
        ProjectDeleteEnvParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.DeleteEnv(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task DeleteEnv(
        string envID,
        ProjectDeleteEnvParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.DeleteEnv(parameters with { EnvID = envID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task GetRuntimeLogs(
        ProjectGetRuntimeLogsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.GetRuntimeLogs(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task GetRuntimeLogs(
        string id,
        ProjectGetRuntimeLogsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.GetRuntimeLogs(parameters with { ID = id }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task ListDeployments(
        ProjectListDeploymentsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.ListDeployments(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task ListDeployments(
        string id,
        ProjectListDeploymentsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.ListDeployments(parameters with { ID = id }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task ListDomains(
        ProjectListDomainsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.ListDomains(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task ListDomains(
        string id,
        ProjectListDomainsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.ListDomains(parameters with { ID = id }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task ListEnv(
        ProjectListEnvParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.ListEnv(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task ListEnv(
        string id,
        ProjectListEnvParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.ListEnv(parameters with { ID = id }, cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class ProjectServiceWithRawResponse : IProjectServiceWithRawResponse
{
    readonly ICasedevClientWithRawResponse _client;

    /// <inheritdoc/>
    public IProjectServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ProjectServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ProjectServiceWithRawResponse(ICasedevClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Create(
        ProjectCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ProjectCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Retrieve(
        ProjectRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CasedevInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<ProjectRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Retrieve(
        string id,
        ProjectRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ProjectListResponse>> List(
        ProjectListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ProjectListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var projects = await response
                    .Deserialize<ProjectListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    projects.Validate();
                }
                return projects;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        ProjectDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CasedevInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<ProjectDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string id,
        ProjectDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> CreateDeployment(
        ProjectCreateDeploymentParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CasedevInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<ProjectCreateDeploymentParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> CreateDeployment(
        string id,
        ProjectCreateDeploymentParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.CreateDeployment(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> CreateDomain(
        ProjectCreateDomainParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CasedevInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<ProjectCreateDomainParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> CreateDomain(
        string id,
        ProjectCreateDomainParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.CreateDomain(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> CreateEnv(
        ProjectCreateEnvParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CasedevInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<ProjectCreateEnvParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> CreateEnv(
        string id,
        ProjectCreateEnvParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.CreateEnv(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> DeleteDomain(
        ProjectDeleteDomainParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Domain == null)
        {
            throw new CasedevInvalidDataException("'parameters.Domain' cannot be null");
        }

        HttpRequest<ProjectDeleteDomainParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> DeleteDomain(
        string domain,
        ProjectDeleteDomainParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.DeleteDomain(parameters with { Domain = domain }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> DeleteEnv(
        ProjectDeleteEnvParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.EnvID == null)
        {
            throw new CasedevInvalidDataException("'parameters.EnvID' cannot be null");
        }

        HttpRequest<ProjectDeleteEnvParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> DeleteEnv(
        string envID,
        ProjectDeleteEnvParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.DeleteEnv(parameters with { EnvID = envID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> GetRuntimeLogs(
        ProjectGetRuntimeLogsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CasedevInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<ProjectGetRuntimeLogsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> GetRuntimeLogs(
        string id,
        ProjectGetRuntimeLogsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetRuntimeLogs(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> ListDeployments(
        ProjectListDeploymentsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CasedevInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<ProjectListDeploymentsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> ListDeployments(
        string id,
        ProjectListDeploymentsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListDeployments(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> ListDomains(
        ProjectListDomainsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CasedevInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<ProjectListDomainsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> ListDomains(
        string id,
        ProjectListDomainsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListDomains(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> ListEnv(
        ProjectListEnvParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CasedevInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<ProjectListEnvParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> ListEnv(
        string id,
        ProjectListEnvParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListEnv(parameters with { ID = id }, cancellationToken);
    }
}
