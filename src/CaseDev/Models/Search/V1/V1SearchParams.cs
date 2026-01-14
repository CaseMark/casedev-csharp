using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
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
    readonly JsonDictionary _rawBodyData = new();
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("query");
        }
        init { this._rawBodyData.Set("query", value); }
    }

    /// <summary>
    /// Additional related search queries to enhance results
    /// </summary>
    public IReadOnlyList<string>? AdditionalQueries
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>("additionalQueries");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<string>?>(
                "additionalQueries",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("category");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("category", value);
        }
    }

    /// <summary>
    /// Specific content type to search for
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
    /// End date for crawl date filtering
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
    /// End date for published date filtering
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
    /// Domains to exclude from search results
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
    /// Domains to include in search results
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
    /// Whether to include full text content in results
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
    /// Number of search results to return
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
    /// Start date for crawl date filtering
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
    /// Start date for published date filtering
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

    /// <summary>
    /// Type of search to perform
    /// </summary>
    public ApiEnum<string, global::CaseDev.Models.Search.V1.Type>? Type
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<
                ApiEnum<string, global::CaseDev.Models.Search.V1.Type>
            >("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("type", value);
        }
    }

    /// <summary>
    /// Geographic location for localized results
    /// </summary>
    public string? UserLocation
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("userLocation");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("userLocation", value);
        }
    }

    public V1SearchParams() { }

    public V1SearchParams(V1SearchParams v1SearchParams)
        : base(v1SearchParams)
    {
        this._rawBodyData = new(v1SearchParams._rawBodyData);
    }

    public V1SearchParams(
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
    V1SearchParams(
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
