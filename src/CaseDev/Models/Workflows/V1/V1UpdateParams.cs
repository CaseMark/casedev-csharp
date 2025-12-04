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

namespace CaseDev.Models.Workflows.V1;

/// <summary>
/// Update an existing workflow's configuration.
/// </summary>
public sealed record class V1UpdateParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ID { get; init; }

    public string? Description
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "description"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "description", value);
        }
    }

    public IReadOnlyList<JsonElement>? Edges
    {
        get { return ModelBase.GetNullableClass<List<JsonElement>>(this.RawBodyData, "edges"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "edges", value);
        }
    }

    public string? Name
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "name"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "name", value);
        }
    }

    public IReadOnlyList<JsonElement>? Nodes
    {
        get { return ModelBase.GetNullableClass<List<JsonElement>>(this.RawBodyData, "nodes"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "nodes", value);
        }
    }

    public JsonElement? TriggerConfig
    {
        get { return ModelBase.GetNullableStruct<JsonElement>(this.RawBodyData, "triggerConfig"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "triggerConfig", value);
        }
    }

    public ApiEnum<string, V1UpdateParamsTriggerType>? TriggerType
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<string, V1UpdateParamsTriggerType>>(
                this.RawBodyData,
                "triggerType"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "triggerType", value);
        }
    }

    public ApiEnum<string, V1UpdateParamsVisibility>? Visibility
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<string, V1UpdateParamsVisibility>>(
                this.RawBodyData,
                "visibility"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "visibility", value);
        }
    }

    public V1UpdateParams() { }

    public V1UpdateParams(
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
    V1UpdateParams(
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

    public static V1UpdateParams FromRawUnchecked(
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
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/workflows/v1/{0}", this.ID)
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

[JsonConverter(typeof(V1UpdateParamsTriggerTypeConverter))]
public enum V1UpdateParamsTriggerType
{
    Manual,
    Webhook,
    Schedule,
    VaultUpload,
}

sealed class V1UpdateParamsTriggerTypeConverter : JsonConverter<V1UpdateParamsTriggerType>
{
    public override V1UpdateParamsTriggerType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "manual" => V1UpdateParamsTriggerType.Manual,
            "webhook" => V1UpdateParamsTriggerType.Webhook,
            "schedule" => V1UpdateParamsTriggerType.Schedule,
            "vault_upload" => V1UpdateParamsTriggerType.VaultUpload,
            _ => (V1UpdateParamsTriggerType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        V1UpdateParamsTriggerType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                V1UpdateParamsTriggerType.Manual => "manual",
                V1UpdateParamsTriggerType.Webhook => "webhook",
                V1UpdateParamsTriggerType.Schedule => "schedule",
                V1UpdateParamsTriggerType.VaultUpload => "vault_upload",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(V1UpdateParamsVisibilityConverter))]
public enum V1UpdateParamsVisibility
{
    Private,
    Org,
    Public,
}

sealed class V1UpdateParamsVisibilityConverter : JsonConverter<V1UpdateParamsVisibility>
{
    public override V1UpdateParamsVisibility Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "private" => V1UpdateParamsVisibility.Private,
            "org" => V1UpdateParamsVisibility.Org,
            "public" => V1UpdateParamsVisibility.Public,
            _ => (V1UpdateParamsVisibility)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        V1UpdateParamsVisibility value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                V1UpdateParamsVisibility.Private => "private",
                V1UpdateParamsVisibility.Org => "org",
                V1UpdateParamsVisibility.Public => "public",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
