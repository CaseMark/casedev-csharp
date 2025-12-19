using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using CaseDev.Core;

namespace CaseDev.Models.Search.V1;

/// <summary>
/// Find web pages and documents similar to a given URL. Useful for legal research
/// to discover related case law, statutes, or legal commentary that shares similar
/// themes or content structure.
/// </summary>
public sealed record class V1SimilarParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The URL to find similar content for
    /// </summary>
    public required string URL
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawBodyData, "url"); }
        init { JsonModel.Set(this._rawBodyData, "url", value); }
    }

    /// <summary>
    /// Additional content to consider for similarity matching
    /// </summary>
    public string? Contents
    {
        get { return JsonModel.GetNullableClass<string>(this.RawBodyData, "contents"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawBodyData, "contents", value);
        }
    }

    /// <summary>
    /// Only include pages crawled before this date
    /// </summary>
    public string? EndCrawlDate
    {
        get { return JsonModel.GetNullableClass<string>(this.RawBodyData, "endCrawlDate"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawBodyData, "endCrawlDate", value);
        }
    }

    /// <summary>
    /// Only include pages published before this date
    /// </summary>
    public string? EndPublishedDate
    {
        get { return JsonModel.GetNullableClass<string>(this.RawBodyData, "endPublishedDate"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawBodyData, "endPublishedDate", value);
        }
    }

    /// <summary>
    /// Exclude results from these domains
    /// </summary>
    public IReadOnlyList<string>? ExcludeDomains
    {
        get { return JsonModel.GetNullableClass<List<string>>(this.RawBodyData, "excludeDomains"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawBodyData, "excludeDomains", value);
        }
    }

    /// <summary>
    /// Only search within these domains
    /// </summary>
    public IReadOnlyList<string>? IncludeDomains
    {
        get { return JsonModel.GetNullableClass<List<string>>(this.RawBodyData, "includeDomains"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawBodyData, "includeDomains", value);
        }
    }

    /// <summary>
    /// Whether to include extracted text content in results
    /// </summary>
    public bool? IncludeText
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawBodyData, "includeText"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawBodyData, "includeText", value);
        }
    }

    /// <summary>
    /// Number of similar results to return
    /// </summary>
    public long? NumResults
    {
        get { return JsonModel.GetNullableStruct<long>(this.RawBodyData, "numResults"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawBodyData, "numResults", value);
        }
    }

    /// <summary>
    /// Only include pages crawled after this date
    /// </summary>
    public string? StartCrawlDate
    {
        get { return JsonModel.GetNullableClass<string>(this.RawBodyData, "startCrawlDate"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawBodyData, "startCrawlDate", value);
        }
    }

    /// <summary>
    /// Only include pages published after this date
    /// </summary>
    public string? StartPublishedDate
    {
        get { return JsonModel.GetNullableClass<string>(this.RawBodyData, "startPublishedDate"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawBodyData, "startPublishedDate", value);
        }
    }

    public V1SimilarParams() { }

    public V1SimilarParams(V1SimilarParams v1SimilarParams)
        : base(v1SimilarParams)
    {
        this._rawBodyData = [.. v1SimilarParams._rawBodyData];
    }

    public V1SimilarParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1SimilarParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static V1SimilarParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/search/v1/similar")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
