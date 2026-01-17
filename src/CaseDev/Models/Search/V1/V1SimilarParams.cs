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
/// Find web pages and documents similar to a given URL. Useful for legal research
/// to discover related case law, statutes, or legal commentary that shares similar
/// themes or content structure.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class V1SimilarParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The URL to find similar content for
    /// </summary>
    public required string UrlValue
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("url");
        }
        init { this._rawBodyData.Set("url", value); }
    }

    /// <summary>
    /// Additional content to consider for similarity matching
    /// </summary>
    public string? Contents
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("contents");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("contents", value);
        }
    }

    /// <summary>
    /// Only include pages crawled before this date
    /// </summary>
    public string? EndCrawlDate
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("endCrawlDate");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("endCrawlDate", value);
        }
    }

    /// <summary>
    /// Only include pages published before this date
    /// </summary>
    public string? EndPublishedDate
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("endPublishedDate");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("endPublishedDate", value);
        }
    }

    /// <summary>
    /// Exclude results from these domains
    /// </summary>
    public IReadOnlyList<string>? ExcludeDomains
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>("excludeDomains");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<string>?>(
                "excludeDomains",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Only search within these domains
    /// </summary>
    public IReadOnlyList<string>? IncludeDomains
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>("includeDomains");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<string>?>(
                "includeDomains",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Whether to include extracted text content in results
    /// </summary>
    public bool? IncludeText
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("includeText");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("includeText", value);
        }
    }

    /// <summary>
    /// Number of similar results to return
    /// </summary>
    public long? NumResults
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("numResults");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("numResults", value);
        }
    }

    /// <summary>
    /// Only include pages crawled after this date
    /// </summary>
    public string? StartCrawlDate
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("startCrawlDate");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("startCrawlDate", value);
        }
    }

    /// <summary>
    /// Only include pages published after this date
    /// </summary>
    public string? StartPublishedDate
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("startPublishedDate");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("startPublishedDate", value);
        }
    }

    public V1SimilarParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public V1SimilarParams(V1SimilarParams v1SimilarParams)
        : base(v1SimilarParams)
    {
        this._rawBodyData = new(v1SimilarParams._rawBodyData);
    }
#pragma warning restore CS8618

    public V1SimilarParams(
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
    V1SimilarParams(
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

    public virtual bool Equals(V1SimilarParams? other)
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/search/v1/similar")
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
