using System;
using CaseDev.Core;
using CaseDev.Services.Applications.V1;

namespace CaseDev.Services.Applications;

/// <inheritdoc/>
public sealed class V1Service : IV1Service
{
    readonly Lazy<IV1ServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IV1ServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICasedevClient _client;

    /// <inheritdoc/>
    public IV1Service WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new V1Service(this._client.WithOptions(modifier));
    }

    public V1Service(ICasedevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new V1ServiceWithRawResponse(client.WithRawResponse));
        _deployments = new(() => new DeploymentService(client));
        _projects = new(() => new ProjectService(client));
        _workflows = new(() => new WorkflowService(client));
    }

    readonly Lazy<IDeploymentService> _deployments;
    public IDeploymentService Deployments
    {
        get { return _deployments.Value; }
    }

    readonly Lazy<IProjectService> _projects;
    public IProjectService Projects
    {
        get { return _projects.Value; }
    }

    readonly Lazy<IWorkflowService> _workflows;
    public IWorkflowService Workflows
    {
        get { return _workflows.Value; }
    }
}

/// <inheritdoc/>
public sealed class V1ServiceWithRawResponse : IV1ServiceWithRawResponse
{
    readonly ICasedevClientWithRawResponse _client;

    /// <inheritdoc/>
    public IV1ServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new V1ServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public V1ServiceWithRawResponse(ICasedevClientWithRawResponse client)
    {
        _client = client;

        _deployments = new(() => new DeploymentServiceWithRawResponse(client));
        _projects = new(() => new ProjectServiceWithRawResponse(client));
        _workflows = new(() => new WorkflowServiceWithRawResponse(client));
    }

    readonly Lazy<IDeploymentServiceWithRawResponse> _deployments;
    public IDeploymentServiceWithRawResponse Deployments
    {
        get { return _deployments.Value; }
    }

    readonly Lazy<IProjectServiceWithRawResponse> _projects;
    public IProjectServiceWithRawResponse Projects
    {
        get { return _projects.Value; }
    }

    readonly Lazy<IWorkflowServiceWithRawResponse> _workflows;
    public IWorkflowServiceWithRawResponse Workflows
    {
        get { return _workflows.Value; }
    }
}
