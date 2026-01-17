using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
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
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class V1ContentsParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Array of URLs to scrape and extract content from
    /// </summary>
    public required IReadOnlyList<string> Urls
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<ImmutableArray<string>>("urls");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<string>>(
                "urls",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Context to guide content extraction and summarization
    /// </summary>
    public string? Context
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("context");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("context", value);
        }
    }

    /// <summary>
    /// Additional extraction options
    /// </summary>
    public JsonElement? Extras
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<JsonElement>("extras");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("extras", value);
        }
    }

    /// <summary>
    /// Whether to include content highlights
    /// </summary>
    public bool? Highlights
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("highlights");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("highlights", value);
        }
    }

    /// <summary>
    /// Whether to perform live crawling for dynamic content
    /// </summary>
    public bool? Livecrawl
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("livecrawl");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("livecrawl", value);
        }
    }

    /// <summary>
    /// Timeout in seconds for live crawling
    /// </summary>
    public long? LivecrawlTimeout
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("livecrawlTimeout");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("livecrawlTimeout", value);
        }
    }

    /// <summary>
    /// Whether to extract content from linked subpages
    /// </summary>
    public bool? Subpages
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("subpages");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("subpages", value);
        }
    }

    /// <summary>
    /// Maximum number of subpages to crawl
    /// </summary>
    public long? SubpageTarget
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("subpageTarget");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("subpageTarget", value);
        }
    }

    /// <summary>
    /// Whether to generate content summaries
    /// </summary>
    public bool? Summary
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("summary");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("summary", value);
        }
    }

    /// <summary>
    /// Whether to extract text content
    /// </summary>
    public bool? Text
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("text");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("text", value);
        }
    }

    public V1ContentsParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public V1ContentsParams(V1ContentsParams v1ContentsParams)
        : base(v1ContentsParams)
    {
        this._rawBodyData = new(v1ContentsParams._rawBodyData);
    }
#pragma warning restore CS8618

    public V1ContentsParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1ContentsParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
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

    public override string ToString() =>
        JsonSerializer.Serialize(
            new Dictionary<string, object?>()
            {
                ["HeaderData"] = this._rawHeaderData.Freeze(),
                ["QueryData"] = this._rawQueryData.Freeze(),
                ["BodyData"] = this._rawBodyData.Freeze(),
            },
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(V1ContentsParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
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
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
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

    public override int GetHashCode()
    {
        return 0;
    }
}
