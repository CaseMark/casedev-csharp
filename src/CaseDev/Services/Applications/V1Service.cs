using System;
using CaseDev.Core;
using V1 = CaseDev.Services.Applications.V1;

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
        _deployments = new(() => new V1::DeploymentService(client));
        _projects = new(() => new V1::ProjectService(client));
        _workflows = new(() => new V1::WorkflowService(client));
    }

    readonly Lazy<V1::IDeploymentService> _deployments;
    public V1::IDeploymentService Deployments
    {
        get { return _deployments.Value; }
    }

    readonly Lazy<V1::IProjectService> _projects;
    public V1::IProjectService Projects
    {
        get { return _projects.Value; }
    }

    readonly Lazy<V1::IWorkflowService> _workflows;
    public V1::IWorkflowService Workflows
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

        _deployments = new(() => new V1::DeploymentServiceWithRawResponse(client));
        _projects = new(() => new V1::ProjectServiceWithRawResponse(client));
        _workflows = new(() => new V1::WorkflowServiceWithRawResponse(client));
    }

    readonly Lazy<V1::IDeploymentServiceWithRawResponse> _deployments;
    public V1::IDeploymentServiceWithRawResponse Deployments
    {
        get { return _deployments.Value; }
    }

    readonly Lazy<V1::IProjectServiceWithRawResponse> _projects;
    public V1::IProjectServiceWithRawResponse Projects
    {
        get { return _projects.Value; }
    }

    readonly Lazy<V1::IWorkflowServiceWithRawResponse> _workflows;
    public V1::IWorkflowServiceWithRawResponse Workflows
    {
        get { return _workflows.Value; }
    }
}
