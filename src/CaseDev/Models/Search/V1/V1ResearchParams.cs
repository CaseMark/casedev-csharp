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
/// Performs deep research by conducting multi-step analysis, gathering information
/// from multiple sources, and providing comprehensive insights. Ideal for legal research,
/// case analysis, and due diligence investigations.
/// </summary>
public sealed record class V1ResearchParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Research instructions or query
    /// </summary>
    public required string Instructions
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawBodyData, "instructions"); }
        init { ModelBase.Set(this._rawBodyData, "instructions", value); }
    }

    /// <summary>
    /// Research quality level - fast (quick), normal (balanced), pro (comprehensive)
    /// </summary>
    public ApiEnum<string, Model>? Model
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<string, Model>>(this.RawBodyData, "model");
        }
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
    /// Optional JSON schema to structure the research output
    /// </summary>
    public JsonElement? OutputSchema
    {
        get { return ModelBase.GetNullableStruct<JsonElement>(this.RawBodyData, "outputSchema"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "outputSchema", value);
        }
    }

    /// <summary>
    /// Alias for instructions (for convenience)
    /// </summary>
    public string? Query
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "query"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "query", value);
        }
    }

    public V1ResearchParams() { }

    public V1ResearchParams(
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
    V1ResearchParams(
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
    public static V1ResearchParams FromRawUnchecked(
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
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/search/v1/research"
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
/// Research quality level - fast (quick), normal (balanced), pro (comprehensive)
/// </summary>
[JsonConverter(typeof(ModelConverter1))]
public enum Model
{
    Fast,
    Normal,
    Pro,
}

sealed class ModelConverter1 : JsonConverter<Model>
{
    public override Model Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "fast" => Model.Fast,
            "normal" => Model.Normal,
            "pro" => Model.Pro,
            _ => (Model)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Model value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Model.Fast => "fast",
                Model.Normal => "normal",
                Model.Pro => "pro",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
