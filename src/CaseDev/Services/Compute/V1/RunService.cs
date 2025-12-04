using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CaseDev.Core;
using CaseDev.Exceptions;
using CaseDev.Models.Compute.V1.Runs;

namespace CaseDev.Services.Compute.V1;

/// <inheritdoc/>
public sealed class RunService : IRunService
{
    /// <inheritdoc/>
    public IRunService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new RunService(this._client.WithOptions(modifier));
    }

    readonly ICasedevClient _client;

    public RunService(ICasedevClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task Retrieve(
        RunRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CasedevInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<RunRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task Retrieve(
        string id,
        RunRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task List(
        RunListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<RunListParams> request = new() { Method = HttpMethod.Get, Params = parameters };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }
}
