using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CaseDev.Core;
using CaseDev.Exceptions;
using CaseDev.Models.Vault.Graphrag;

namespace CaseDev.Services.Vault;

/// <inheritdoc/>
public sealed class GraphragService : IGraphragService
{
    readonly Lazy<IGraphragServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IGraphragServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICasedevClient _client;

    /// <inheritdoc/>
    public IGraphragService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new GraphragService(this._client.WithOptions(modifier));
    }

    public GraphragService(ICasedevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new GraphragServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<GraphragGetStatsResponse> GetStats(
        GraphragGetStatsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.GetStats(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<GraphragGetStatsResponse> GetStats(
        string id,
        GraphragGetStatsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetStats(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<GraphragInitResponse> Init(
        GraphragInitParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Init(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<GraphragInitResponse> Init(
        string id,
        GraphragInitParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Init(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<GraphragProcessObjectResponse> ProcessObject(
        GraphragProcessObjectParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ProcessObject(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<GraphragProcessObjectResponse> ProcessObject(
        string objectID,
        GraphragProcessObjectParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.ProcessObject(parameters with { ObjectID = objectID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class GraphragServiceWithRawResponse : IGraphragServiceWithRawResponse
{
    readonly ICasedevClientWithRawResponse _client;

    /// <inheritdoc/>
    public IGraphragServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new GraphragServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public GraphragServiceWithRawResponse(ICasedevClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<GraphragGetStatsResponse>> GetStats(
        GraphragGetStatsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CasedevInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<GraphragGetStatsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<GraphragGetStatsResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<GraphragGetStatsResponse>> GetStats(
        string id,
        GraphragGetStatsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetStats(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<GraphragInitResponse>> Init(
        GraphragInitParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CasedevInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<GraphragInitParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<GraphragInitResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<GraphragInitResponse>> Init(
        string id,
        GraphragInitParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Init(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<GraphragProcessObjectResponse>> ProcessObject(
        GraphragProcessObjectParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ObjectID == null)
        {
            throw new CasedevInvalidDataException("'parameters.ObjectID' cannot be null");
        }

        HttpRequest<GraphragProcessObjectParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<GraphragProcessObjectResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<GraphragProcessObjectResponse>> ProcessObject(
        string objectID,
        GraphragProcessObjectParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.ProcessObject(parameters with { ObjectID = objectID }, cancellationToken);
    }
}
