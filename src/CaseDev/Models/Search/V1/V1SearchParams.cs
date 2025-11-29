using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;
using CaseDev.Exceptions;
using System = System;

namespace CaseDev.Models.Search.V1;

/// <summary>
/// Executes intelligent web search queries with advanced filtering and customization
/// options. Ideal for legal research, case law discovery, and gathering supporting
/// documentation for litigation or compliance matters.
/// </summary>
public sealed record class V1SearchParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Primary search query
    /// </summary>
    public required string Query
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("query", out JsonElement element))
                throw new CasedevInvalidDataException(
                    "'query' cannot be null",
                    new System::ArgumentOutOfRangeException("query", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CasedevInvalidDataException(
                    "'query' cannot be null",
                    new System::ArgumentNullException("query")
                );
        }
        init
        {
            this._rawBodyData["query"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Additional related search queries to enhance results
    /// </summary>
    public IReadOnlyList<string>? AdditionalQueries
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("additionalQueries", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData["additionalQueries"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Category filter for search results
    /// </summary>
    public string? Category
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("category", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData["category"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Specific content type to search for
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
    /// End date for crawl date filtering
    /// </summary>
    public
#if NET
    System::DateOnly
#else
    System::DateTimeOffset
#endif
    ? EndCrawlDate
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("endCrawlDate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<
#if NET
            System::DateOnly
#else
            System::DateTimeOffset
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
    /// End date for published date filtering
    /// </summary>
    public
#if NET
    System::DateOnly
#else
    System::DateTimeOffset
#endif
    ? EndPublishedDate
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("endPublishedDate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<
#if NET
            System::DateOnly
#else
            System::DateTimeOffset
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
    /// Domains to exclude from search results
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
    /// Domains to include in search results
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
    /// Whether to include full text content in results
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
    /// Number of search results to return
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
    /// Start date for crawl date filtering
    /// </summary>
    public
#if NET
    System::DateOnly
#else
    System::DateTimeOffset
#endif
    ? StartCrawlDate
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("startCrawlDate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<
#if NET
            System::DateOnly
#else
            System::DateTimeOffset
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
    /// Start date for published date filtering
    /// </summary>
    public
#if NET
    System::DateOnly
#else
    System::DateTimeOffset
#endif
    ? StartPublishedDate
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("startPublishedDate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<
#if NET
            System::DateOnly
#else
            System::DateTimeOffset
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

    /// <summary>
    /// Type of search to perform
    /// </summary>
    public ApiEnum<string, global::CaseDev.Models.Search.V1.Type>? Type
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<
                string,
                global::CaseDev.Models.Search.V1.Type
            >?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Geographic location for localized results
    /// </summary>
    public string? UserLocation
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("userLocation", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData["userLocation"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public V1SearchParams() { }

    public V1SearchParams(
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
    V1SearchParams(
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

    public static V1SearchParams FromRawUnchecked(
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

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/search/v1/search")
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

/// <summary>
/// Type of search to perform
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Auto,
    Search,
    News,
}

sealed class TypeConverter : JsonConverter<global::CaseDev.Models.Search.V1.Type>
{
    public override global::CaseDev.Models.Search.V1.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "auto" => global::CaseDev.Models.Search.V1.Type.Auto,
            "search" => global::CaseDev.Models.Search.V1.Type.Search,
            "news" => global::CaseDev.Models.Search.V1.Type.News,
            _ => (global::CaseDev.Models.Search.V1.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::CaseDev.Models.Search.V1.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::CaseDev.Models.Search.V1.Type.Auto => "auto",
                global::CaseDev.Models.Search.V1.Type.Search => "search",
                global::CaseDev.Models.Search.V1.Type.News => "news",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
