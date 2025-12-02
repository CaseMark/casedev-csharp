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
        get { return ModelBase.GetNotNullClass<string>(this.RawBodyData, "query"); }
        init { ModelBase.Set(this._rawBodyData, "query", value); }
    }

    /// <summary>
    /// Exclude these domains from search
    /// </summary>
    public IReadOnlyList<string>? ExcludeDomains
    {
        get { return ModelBase.GetNullableClass<List<string>>(this.RawBodyData, "excludeDomains"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "excludeDomains", value);
        }
    }

    /// <summary>
    /// Only search within these domains
    /// </summary>
    public IReadOnlyList<string>? IncludeDomains
    {
        get { return ModelBase.GetNullableClass<List<string>>(this.RawBodyData, "includeDomains"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "includeDomains", value);
        }
    }

    /// <summary>
    /// Maximum tokens for LLM response
    /// </summary>
    public long? MaxTokens
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawBodyData, "maxTokens"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "maxTokens", value);
        }
    }

    /// <summary>
    /// LLM model to use when useCustomLLM is true
    /// </summary>
    public string? Model
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "model"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "model", value);
        }
    }

    /// <summary>
    /// Number of search results to consider
    /// </summary>
    public long? NumResults
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawBodyData, "numResults"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "numResults", value);
        }
    }

    /// <summary>
    /// Type of search to perform
    /// </summary>
    public ApiEnum<string, SearchType>? SearchType
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<string, SearchType>>(
                this.RawBodyData,
                "searchType"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "searchType", value);
        }
    }

    /// <summary>
    /// Stream the response (only for native provider answers)
    /// </summary>
    public bool? Stream
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawBodyData, "stream"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "stream", value);
        }
    }

    /// <summary>
    /// LLM temperature for answer generation
    /// </summary>
    public double? Temperature
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawBodyData, "temperature"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "temperature", value);
        }
    }

    /// <summary>
    /// Include text content in response
    /// </summary>
    public bool? Text
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawBodyData, "text"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "text", value);
        }
    }

    /// <summary>
    /// Use Case.dev LLM for answer generation instead of provider's native answer
    /// </summary>
    public bool? UseCustomLlm
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawBodyData, "useCustomLLM"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "useCustomLLM", value);
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
