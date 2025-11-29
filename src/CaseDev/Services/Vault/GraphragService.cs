using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CaseDev.Core;
using CaseDev.Exceptions;
using CaseDev.Models.Vault.Graphrag;

namespace CaseDev.Services.Vault;

/// <inheritdoc />
public sealed class GraphragService : IGraphragService
{
    /// <inheritdoc/>
    public IGraphragService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new GraphragService(this._client.WithOptions(modifier));
    }

    readonly ICasedevClient _client;

    public GraphragService(ICasedevClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task GetStats(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task GetStats(
        string id,
        GraphragGetStatsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.GetStats(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Init(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task Init(
        string id,
        GraphragInitParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Init(parameters with { ID = id }, cancellationToken);
    }
}
