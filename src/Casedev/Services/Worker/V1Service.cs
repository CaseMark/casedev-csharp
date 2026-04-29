using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Casedev.Core;
using Casedev.Exceptions;
using Casedev.Models.Worker.V1;

namespace Casedev.Services.Worker;

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
    }

    /// <inheritdoc/>
    public Task Create(
        V1CreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Create(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Retrieve(V1RetrieveParams parameters, CancellationToken cancellationToken = default)
    {
        return this.WithRawResponse.Retrieve(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Retrieve(
        string id,
        V1RetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Retrieve(parameters with { ID = id }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(V1DeleteParams parameters, CancellationToken cancellationToken = default)
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string id,
        V1DeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { ID = id }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task ProxyDelete(
        V1ProxyDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.ProxyDelete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task ProxyDelete(
        string workerPath,
        V1ProxyDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.ProxyDelete(parameters with { WorkerPath = workerPath }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task ProxyGet(V1ProxyGetParams parameters, CancellationToken cancellationToken = default)
    {
        return this.WithRawResponse.ProxyGet(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task ProxyGet(
        string workerPath,
        V1ProxyGetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.ProxyGet(parameters with { WorkerPath = workerPath }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task ProxyPatch(
        V1ProxyPatchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.ProxyPatch(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task ProxyPatch(
        string workerPath,
        V1ProxyPatchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.ProxyPatch(parameters with { WorkerPath = workerPath }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task ProxyPost(
        V1ProxyPostParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.ProxyPost(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task ProxyPost(
        string workerPath,
        V1ProxyPostParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.ProxyPost(parameters with { WorkerPath = workerPath }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task ProxyPut(V1ProxyPutParams parameters, CancellationToken cancellationToken = default)
    {
        return this.WithRawResponse.ProxyPut(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task ProxyPut(
        string workerPath,
        V1ProxyPutParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.ProxyPut(parameters with { WorkerPath = workerPath }, cancellationToken)
            .ConfigureAwait(false);
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
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Create(
        V1CreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<V1CreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Retrieve(
        V1RetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CasedevInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<V1RetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Retrieve(
        string id,
        V1RetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        V1DeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CasedevInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<V1DeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string id,
        V1DeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> ProxyDelete(
        V1ProxyDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.WorkerPath == null)
        {
            throw new CasedevInvalidDataException("'parameters.WorkerPath' cannot be null");
        }

        HttpRequest<V1ProxyDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> ProxyDelete(
        string workerPath,
        V1ProxyDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.ProxyDelete(parameters with { WorkerPath = workerPath }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> ProxyGet(
        V1ProxyGetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.WorkerPath == null)
        {
            throw new CasedevInvalidDataException("'parameters.WorkerPath' cannot be null");
        }

        HttpRequest<V1ProxyGetParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> ProxyGet(
        string workerPath,
        V1ProxyGetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.ProxyGet(parameters with { WorkerPath = workerPath }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> ProxyPatch(
        V1ProxyPatchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.WorkerPath == null)
        {
            throw new CasedevInvalidDataException("'parameters.WorkerPath' cannot be null");
        }

        HttpRequest<V1ProxyPatchParams> request = new()
        {
            Method = CasedevClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> ProxyPatch(
        string workerPath,
        V1ProxyPatchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.ProxyPatch(parameters with { WorkerPath = workerPath }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> ProxyPost(
        V1ProxyPostParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.WorkerPath == null)
        {
            throw new CasedevInvalidDataException("'parameters.WorkerPath' cannot be null");
        }

        HttpRequest<V1ProxyPostParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> ProxyPost(
        string workerPath,
        V1ProxyPostParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.ProxyPost(parameters with { WorkerPath = workerPath }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> ProxyPut(
        V1ProxyPutParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.WorkerPath == null)
        {
            throw new CasedevInvalidDataException("'parameters.WorkerPath' cannot be null");
        }

        HttpRequest<V1ProxyPutParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> ProxyPut(
        string workerPath,
        V1ProxyPutParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.ProxyPut(parameters with { WorkerPath = workerPath }, cancellationToken);
    }
}
