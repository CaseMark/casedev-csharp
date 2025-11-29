using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using CaseDev.Core;
using CaseDev.Exceptions;

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
        get
        {
            if (!this._rawBodyData.TryGetValue("url", out JsonElement element))
                throw new CasedevInvalidDataException(
                    "'url' cannot be null",
                    new ArgumentOutOfRangeException("url", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CasedevInvalidDataException(
                    "'url' cannot be null",
                    new ArgumentNullException("url")
                );
        }
        init
        {
            this._rawBodyData["url"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Additional content to consider for similarity matching
    /// </summary>
    public string? Contents
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("contents", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData["contents"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Only include pages crawled before this date
    /// </summary>
    public
#if NET
    DateOnly
#else
    DateTimeOffset
#endif
    ? EndCrawlDate
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("endCrawlDate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<
#if NET
            DateOnly
#else
            DateTimeOffset
#endif
            ?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData["endCrawlDate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Only include pages published before this date
    /// </summary>
    public
#if NET
    DateOnly
#else
    DateTimeOffset
#endif
    ? EndPublishedDate
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("endPublishedDate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<
#if NET
            DateOnly
#else
            DateTimeOffset
#endif
            ?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData["endPublishedDate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Exclude results from these domains
    /// </summary>
    public IReadOnlyList<string>? ExcludeDomains
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("excludeDomains", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData["excludeDomains"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
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
            if (!this._rawBodyData.TryGetValue("includeDomains", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData["includeDomains"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
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
            if (!this._rawBodyData.TryGetValue("includeText", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData["includeText"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Number of similar results to return
    /// </summary>
    public long? NumResults
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("numResults", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData["numResults"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Only include pages crawled after this date
    /// </summary>
    public
#if NET
    DateOnly
#else
    DateTimeOffset
#endif
    ? StartCrawlDate
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("startCrawlDate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<
#if NET
            DateOnly
#else
            DateTimeOffset
#endif
            ?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData["startCrawlDate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Only include pages published after this date
    /// </summary>
    public
#if NET
    DateOnly
#else
    DateTimeOffset
#endif
    ? StartPublishedDate
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("startPublishedDate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<
#if NET
            DateOnly
#else
            DateTimeOffset
#endif
            ?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData["startPublishedDate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public V1SimilarParams() { }

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

    internal override StringContent? BodyContent()
    {
        return new(JsonSerializer.Serialize(this.RawBodyData), Encoding.UTF8, "application/json");
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
