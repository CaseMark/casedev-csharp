using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CaseDev.Core;
using CaseDev.Models.Format.V1;
using V1 = CaseDev.Services.Format.V1;

namespace CaseDev.Services.Format;

/// <inheritdoc/>
public sealed class V1Service : IV1Service
{
    /// <inheritdoc/>
    public IV1Service WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new V1Service(this._client.WithOptions(modifier));
    }

    readonly ICasedevClient _client;

    public V1Service(ICasedevClient client)
    {
        _client = client;
        _templates = new(() => new V1::TemplateService(client));
    }

    readonly Lazy<V1::ITemplateService> _templates;
    public V1::ITemplateService Templates
    {
        get { return _templates.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse> CreateDocument(
        V1CreateDocumentParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<V1CreateDocumentParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return response;
    }
}
