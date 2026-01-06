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
/// Scrapes and extracts text content from web pages, PDFs, and documents. Useful
/// for legal research, evidence collection, and document analysis. Supports live
/// crawling, subpage extraction, and content summarization.
/// </summary>
public sealed record class V1ContentsParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Array of URLs to scrape and extract content from
    /// </summary>
    public required IReadOnlyList<string> Urls
    {
        get { return JsonModel.GetNotNullClass<List<string>>(this.RawBodyData, "urls"); }
        init { JsonModel.Set(this._rawBodyData, "urls", value); }
    }

    /// <summary>
    /// Context to guide content extraction and summarization
    /// </summary>
    public string? Context
    {
        get { return JsonModel.GetNullableClass<string>(this.RawBodyData, "context"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawBodyData, "context", value);
        }
    }

    /// <summary>
    /// Additional extraction options
    /// </summary>
    public JsonElement? Extras
    {
        get { return JsonModel.GetNullableStruct<JsonElement>(this.RawBodyData, "extras"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawBodyData, "extras", value);
        }
    }

    /// <summary>
    /// Whether to include content highlights
    /// </summary>
    public bool? Highlights
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawBodyData, "highlights"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawBodyData, "highlights", value);
        }
    }

    /// <summary>
    /// Whether to perform live crawling for dynamic content
    /// </summary>
    public bool? Livecrawl
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawBodyData, "livecrawl"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawBodyData, "livecrawl", value);
        }
    }

    /// <summary>
    /// Timeout in seconds for live crawling
    /// </summary>
    public long? LivecrawlTimeout
    {
        get { return JsonModel.GetNullableStruct<long>(this.RawBodyData, "livecrawlTimeout"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawBodyData, "livecrawlTimeout", value);
        }
    }

    /// <summary>
    /// Whether to extract content from linked subpages
    /// </summary>
    public bool? Subpages
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawBodyData, "subpages"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawBodyData, "subpages", value);
        }
    }

    /// <summary>
    /// Maximum number of subpages to crawl
    /// </summary>
    public long? SubpageTarget
    {
        get { return JsonModel.GetNullableStruct<long>(this.RawBodyData, "subpageTarget"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawBodyData, "subpageTarget", value);
        }
    }

    /// <summary>
    /// Whether to generate content summaries
    /// </summary>
    public bool? Summary
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawBodyData, "summary"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawBodyData, "summary", value);
        }
    }

    /// <summary>
    /// Whether to extract text content
    /// </summary>
    public bool? Text
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawBodyData, "text"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawBodyData, "text", value);
        }
    }

    public V1ContentsParams() { }

    public V1ContentsParams(V1ContentsParams v1ContentsParams)
        : base(v1ContentsParams)
    {
        this._rawBodyData = [.. v1ContentsParams._rawBodyData];
    }

    public V1ContentsParams(
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
    V1ContentsParams(
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
    public static V1ContentsParams FromRawUnchecked(
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/search/v1/contents")
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
