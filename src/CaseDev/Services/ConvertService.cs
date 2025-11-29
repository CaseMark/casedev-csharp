using System;
using CaseDev.Core;
using CaseDev.Services.Convert;

namespace CaseDev.Services;

/// <inheritdoc />
public sealed class ConvertService : IConvertService
{
    /// <inheritdoc/>
    public IConvertService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ConvertService(this._client.WithOptions(modifier));
    }

    readonly ICasedevClient _client;

    public ConvertService(ICasedevClient client)
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
