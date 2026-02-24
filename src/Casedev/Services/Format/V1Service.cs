using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Casedev.Core;
using Casedev.Models.Format.V1;
using Casedev.Services.Format.V1;

namespace Casedev.Services.Format;

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
        _templates = new(() => new TemplateService(client));
    }

    readonly Lazy<ITemplateService> _templates;
    public ITemplateService Templates
    {
        get { return _templates.Value; }
    }

    /// <inheritdoc/>
    public Task<HttpResponse> CreateDocument(
        V1CreateDocumentParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.CreateDocument(parameters, cancellationToken);
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

        _templates = new(() => new TemplateServiceWithRawResponse(client));
    }

    readonly Lazy<ITemplateServiceWithRawResponse> _templates;
    public ITemplateServiceWithRawResponse Templates
    {
        get { return _templates.Value; }
    }

    /// <inheritdoc/>
    public Task<HttpResponse> CreateDocument(
        V1CreateDocumentParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<V1CreateDocumentParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }
}
