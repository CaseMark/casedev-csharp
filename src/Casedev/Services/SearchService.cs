using System;
using Casedev.Core;
using Casedev.Services.Search;

namespace Casedev.Services;

/// <inheritdoc/>
public sealed class SearchService : ISearchService
{
    readonly Lazy<ISearchServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ISearchServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICasedevClient _client;

    /// <inheritdoc/>
    public ISearchService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SearchService(this._client.WithOptions(modifier));
    }

    public SearchService(ICasedevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new SearchServiceWithRawResponse(client.WithRawResponse));
        _v1 = new(() => new V1Service(client));
    }

    readonly Lazy<IV1Service> _v1;
    public IV1Service V1
    {
        get { return _v1.Value; }
    }
}

/// <inheritdoc/>
public sealed class SearchServiceWithRawResponse : ISearchServiceWithRawResponse
{
    readonly ICasedevClientWithRawResponse _client;

    /// <inheritdoc/>
    public ISearchServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SearchServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public SearchServiceWithRawResponse(ICasedevClientWithRawResponse client)
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
