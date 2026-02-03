using System;
using CaseDev.Core;
using CaseDev.Services.Applications;

namespace CaseDev.Services;

/// <inheritdoc/>
public sealed class ApplicationService : IApplicationService
{
    readonly Lazy<IApplicationServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IApplicationServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICasedevClient _client;

    /// <inheritdoc/>
    public IApplicationService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ApplicationService(this._client.WithOptions(modifier));
    }

    public ApplicationService(ICasedevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ApplicationServiceWithRawResponse(client.WithRawResponse));
        _v1 = new(() => new V1Service(client));
    }

    readonly Lazy<IV1Service> _v1;
    public IV1Service V1
    {
        get { return _v1.Value; }
    }
}

/// <inheritdoc/>
public sealed class ApplicationServiceWithRawResponse : IApplicationServiceWithRawResponse
{
    readonly ICasedevClientWithRawResponse _client;

    /// <inheritdoc/>
    public IApplicationServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ApplicationServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ApplicationServiceWithRawResponse(ICasedevClientWithRawResponse client)
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
