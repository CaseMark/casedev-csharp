using System;
using Router.Core;
using Router.Services.Privilege;

namespace Router.Services;

/// <inheritdoc/>
public sealed class PrivilegeService : IPrivilegeService
{
    readonly Lazy<IPrivilegeServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IPrivilegeServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICasedevClient _client;

    /// <inheritdoc/>
    public IPrivilegeService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PrivilegeService(this._client.WithOptions(modifier));
    }

    public PrivilegeService(ICasedevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new PrivilegeServiceWithRawResponse(client.WithRawResponse));
        _v1 = new(() => new V1Service(client));
    }

    readonly Lazy<IV1Service> _v1;
    public IV1Service V1
    {
        get { return _v1.Value; }
    }
}

/// <inheritdoc/>
public sealed class PrivilegeServiceWithRawResponse : IPrivilegeServiceWithRawResponse
{
    readonly ICasedevClientWithRawResponse _client;

    /// <inheritdoc/>
    public IPrivilegeServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PrivilegeServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public PrivilegeServiceWithRawResponse(ICasedevClientWithRawResponse client)
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
