using System;
using CaseDev.Core;
using CaseDev.Services.Format;

namespace CaseDev.Services;

/// <inheritdoc />
public sealed class FormatService : IFormatService
{
    /// <inheritdoc/>
    public IFormatService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new FormatService(this._client.WithOptions(modifier));
    }

    readonly ICasedevClient _client;

    public FormatService(ICasedevClient client)
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
