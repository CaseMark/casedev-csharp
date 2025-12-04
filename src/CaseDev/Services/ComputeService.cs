using System;
using CaseDev.Core;
using CaseDev.Services.Compute;

namespace CaseDev.Services;

/// <inheritdoc/>
public sealed class ComputeService : IComputeService
{
    /// <inheritdoc/>
    public IComputeService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ComputeService(this._client.WithOptions(modifier));
    }

    readonly ICasedevClient _client;

    public ComputeService(ICasedevClient client)
    {
        _client = client;
        _v1 = new(() => new V1Service(client));
    }

    readonly Lazy<IV1Service> _v1;
    public IV1Service V1
    {
        get { return _v1.Value; }
    }
}
