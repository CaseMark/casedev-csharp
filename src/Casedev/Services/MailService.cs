using System;
using Casedev.Core;
using Casedev.Services.Mail;

namespace Casedev.Services;

/// <inheritdoc/>
public sealed class MailService : IMailService
{
    readonly Lazy<IMailServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IMailServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICasedevClient _client;

    /// <inheritdoc/>
    public IMailService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new MailService(this._client.WithOptions(modifier));
    }

    public MailService(ICasedevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new MailServiceWithRawResponse(client.WithRawResponse));
        _v1 = new(() => new V1Service(client));
    }

    readonly Lazy<IV1Service> _v1;
    public IV1Service V1
    {
        get { return _v1.Value; }
    }
}

/// <inheritdoc/>
public sealed class MailServiceWithRawResponse : IMailServiceWithRawResponse
{
    readonly ICasedevClientWithRawResponse _client;

    /// <inheritdoc/>
    public IMailServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new MailServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public MailServiceWithRawResponse(ICasedevClientWithRawResponse client)
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
