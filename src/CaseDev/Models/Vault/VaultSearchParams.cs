using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;
using CaseDev.Exceptions;

namespace CaseDev.Models.Vault;

/// <summary>
/// Search across vault documents using multiple methods including hybrid vector
/// + graph search, GraphRAG global search, entity-based search, and fast similarity
/// search. Returns relevant documents and contextual answers based on the search method.
/// </summary>
public sealed record class VaultSearchParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ID { get; init; }

    /// <summary>
    /// Search query or question to find relevant documents
    /// </summary>
    public required string Query
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawBodyData, "query"); }
        init { ModelBase.Set(this._rawBodyData, "query", value); }
    }

    /// <summary>
    /// Additional filters to apply to search results
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Filters
    {
        get
        {
            return ModelBase.GetNullableClass<Dictionary<string, JsonElement>>(
                this.RawBodyData,
                "filters"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "filters", value);
        }
    }

    /// <summary>
    /// Search method: 'global' for comprehensive questions, 'entity' for specific
    /// entities, 'fast' for quick similarity search, 'hybrid' for combined approach
    /// </summary>
    public ApiEnum<string, Method>? Method
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<string, Method>>(this.RawBodyData, "method");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "method", value);
        }
    }

    /// <summary>
    /// Maximum number of results to return
    /// </summary>
    public long? TopK
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawBodyData, "topK"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "topK", value);
        }
    }

    public VaultSearchParams() { }

    public VaultSearchParams(VaultSearchParams vaultSearchParams)
        : base(vaultSearchParams)
    {
        this._rawBodyData = [.. vaultSearchParams._rawBodyData];
    }

    public VaultSearchParams(
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
    VaultSearchParams(
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

    /// <inheritdoc cref="IFromRaw.FromRawUnchecked"/>
    public static VaultSearchParams FromRawUnchecked(
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
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/vault/{0}/search", this.ID)
        )
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
/// Search method: 'global' for comprehensive questions, 'entity' for specific entities,
/// 'fast' for quick similarity search, 'hybrid' for combined approach
/// </summary>
[JsonConverter(typeof(MethodConverter))]
public enum Method
{
    Vector,
    Graph,
    Hybrid,
    Global,
    Local,
    Fast,
    Entity,
}

sealed class MethodConverter : JsonConverter<Method>
{
    public override Method Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "vector" => Method.Vector,
            "graph" => Method.Graph,
            "hybrid" => Method.Hybrid,
            "global" => Method.Global,
            "local" => Method.Local,
            "fast" => Method.Fast,
            "entity" => Method.Entity,
            _ => (Method)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Method value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Method.Vector => "vector",
                Method.Graph => "graph",
                Method.Hybrid => "hybrid",
                Method.Global => "global",
                Method.Local => "local",
                Method.Fast => "fast",
                Method.Entity => "entity",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
