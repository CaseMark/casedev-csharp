using System;
using CaseDev.Core;
using CaseDev.Services.Templates;

namespace CaseDev.Services;

/// <inheritdoc/>
public sealed class TemplateService : ITemplateService
{
    readonly Lazy<ITemplateServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ITemplateServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICasedevClient _client;

    /// <inheritdoc/>
    public ITemplateService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TemplateService(this._client.WithOptions(modifier));
    }

    public TemplateService(ICasedevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new TemplateServiceWithRawResponse(client.WithRawResponse));
        _v1 = new(() => new V1Service(client));
    }

    readonly Lazy<IV1Service> _v1;
    public IV1Service V1
    {
        get { return _v1.Value; }
    }
}

/// <inheritdoc/>
public sealed class TemplateServiceWithRawResponse : ITemplateServiceWithRawResponse
{
    readonly ICasedevClientWithRawResponse _client;

    /// <inheritdoc/>
    public ITemplateServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TemplateServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public TemplateServiceWithRawResponse(ICasedevClientWithRawResponse client)
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
