using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CaseDev.Core;
using CaseDev.Exceptions;
using CaseDev.Models.Compute.V1.Invoke;

namespace CaseDev.Services.Compute.V1;

/// <inheritdoc/>
public sealed class InvokeService : IInvokeService
{
    /// <inheritdoc/>
    public IInvokeService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new InvokeService(this._client.WithOptions(modifier));
    }

    readonly ICasedevClient _client;

    public InvokeService(ICasedevClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<InvokeRunResponse> Run(
        InvokeRunParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.FunctionID == null)
        {
            throw new CasedevInvalidDataException("'parameters.FunctionID' cannot be null");
        }

        HttpRequest<InvokeRunParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<InvokeRunResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    /// <inheritdoc/>
    public async Task<InvokeRunResponse> Run(
        string functionID,
        InvokeRunParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return await this.Run(parameters with { FunctionID = functionID }, cancellationToken);
    }
}
