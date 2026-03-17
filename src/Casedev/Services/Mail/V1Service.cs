using System;
using Casedev.Core;
using Casedev.Services.Mail.V1;

namespace Casedev.Services.Mail;

/// <inheritdoc/>
public sealed class V1Service : IV1Service
{
    readonly Lazy<IV1ServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IV1ServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICasedevClient _client;

    /// <inheritdoc/>
    public IV1Service WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new V1Service(this._client.WithOptions(modifier));
    }

    public V1Service(ICasedevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new V1ServiceWithRawResponse(client.WithRawResponse));
        _inboxes = new(() => new InboxService(client));
    }

    readonly Lazy<IInboxService> _inboxes;
    public IInboxService Inboxes
    {
        get { return _inboxes.Value; }
    }
}

/// <inheritdoc/>
public sealed class V1ServiceWithRawResponse : IV1ServiceWithRawResponse
{
    readonly ICasedevClientWithRawResponse _client;

    /// <inheritdoc/>
    public IV1ServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new V1ServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public V1ServiceWithRawResponse(ICasedevClientWithRawResponse client)
    {
        _client = client;

        _inboxes = new(() => new InboxServiceWithRawResponse(client));
    }

    readonly Lazy<IInboxServiceWithRawResponse> _inboxes;
    public IInboxServiceWithRawResponse Inboxes
    {
        get { return _inboxes.Value; }
    }
}
