using System;
using Casedev.Core;
using Casedev.Services.Format;

namespace Casedev.Services;

/// <inheritdoc/>
public sealed class FormatService : IFormatService
{
    readonly Lazy<IFormatServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IFormatServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICasedevClient _client;

    /// <inheritdoc/>
    public IFormatService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new FormatService(this._client.WithOptions(modifier));
    }

    public FormatService(ICasedevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new FormatServiceWithRawResponse(client.WithRawResponse));
        _v1 = new(() => new V1Service(client));
    }

    readonly Lazy<IV1Service> _v1;
    public IV1Service V1
    {
        get { return _v1.Value; }
    }
}

/// <inheritdoc/>
public sealed class FormatServiceWithRawResponse : IFormatServiceWithRawResponse
{
    readonly ICasedevClientWithRawResponse _client;

    /// <inheritdoc/>
    public IFormatServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new FormatServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public FormatServiceWithRawResponse(ICasedevClientWithRawResponse client)
    {
        _client = client;

        _v1 = new(() => new V1ServiceWithRawResponse(client));
    }

    readonly Lazy<IV1ServiceWithRawResponse> _v1;
    public IV1ServiceWithRawResponse V1
    {
        get { return _v1.Value; }
    }
}
