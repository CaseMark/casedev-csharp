using System;
using CaseDev.Core;

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
}
