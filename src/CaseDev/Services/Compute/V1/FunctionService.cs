using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CaseDev.Core;
using CaseDev.Exceptions;
using CaseDev.Models.Compute.V1.Functions;

namespace CaseDev.Services.Compute.V1;

/// <inheritdoc/>
public sealed class FunctionService : IFunctionService
{
    /// <inheritdoc/>
    public IFunctionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new FunctionService(this._client.WithOptions(modifier));
    }

    readonly ICasedevClient _client;

    public FunctionService(ICasedevClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task List(
        FunctionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<FunctionListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task GetLogs(
        FunctionGetLogsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CasedevInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<FunctionGetLogsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task GetLogs(
        string id,
        FunctionGetLogsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.GetLogs(parameters with { ID = id }, cancellationToken);
    }
}
