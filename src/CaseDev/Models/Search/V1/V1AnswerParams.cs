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
/// Generate comprehensive answers to questions using web search results. Supports
/// two modes: native provider answers or custom LLM-powered answers using Case.dev's
/// AI gateway. Perfect for legal research, fact-checking, and gathering supporting
/// evidence for cases.
/// </summary>
public sealed record class V1AnswerParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The question or topic to research and answer
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
    /// Exclude these domains from search
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
    /// Maximum tokens for LLM response
    /// </summary>
    public long? MaxTokens
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("maxTokens", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData["maxTokens"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// LLM model to use when useCustomLLM is true
    /// </summary>
    public string? Model
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("model", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData["model"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Number of search results to consider
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
    /// Type of search to perform
    /// </summary>
    public ApiEnum<string, SearchType>? SearchType
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("searchType", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, SearchType>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData["searchType"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Stream the response (only for native provider answers)
    /// </summary>
    public bool? Stream
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("stream", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData["stream"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// LLM temperature for answer generation
    /// </summary>
    public double? Temperature
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("temperature", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData["temperature"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Include text content in response
    /// </summary>
    public bool? Text
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("text", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData["text"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Use Case.dev LLM for answer generation instead of provider's native answer
    /// </summary>
    public bool? UseCustomLlm
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("useCustomLLM", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData["useCustomLLM"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public V1AnswerParams() { }

    public V1AnswerParams(
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
    V1AnswerParams(
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

    public static V1AnswerParams FromRawUnchecked(
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
        return new System::UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/search/v1/answer")
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
[JsonConverter(typeof(SearchTypeConverter))]
public enum SearchType
{
    Auto,
    Web,
    News,
    Academic,
}

sealed class SearchTypeConverter : JsonConverter<SearchType>
{
    public override SearchType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "auto" => SearchType.Auto,
            "web" => SearchType.Web,
            "news" => SearchType.News,
            "academic" => SearchType.Academic,
            _ => (SearchType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SearchType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SearchType.Auto => "auto",
                SearchType.Web => "web",
                SearchType.News => "news",
                SearchType.Academic => "academic",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
