using System;
using CaseDev.Core;

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
}
