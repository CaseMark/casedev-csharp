using System;
using CaseDev.Core;
using CaseDev.Services.Webhooks;

namespace CaseDev.Services;

/// <inheritdoc/>
public sealed class WebhookService : IWebhookService
{
    /// <inheritdoc/>
    public IWebhookService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new WebhookService(this._client.WithOptions(modifier));
    }

    readonly ICasedevClient _client;

    public WebhookService(ICasedevClient client)
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
