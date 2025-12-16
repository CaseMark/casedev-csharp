using System;
using CaseDev.Core;

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
}
