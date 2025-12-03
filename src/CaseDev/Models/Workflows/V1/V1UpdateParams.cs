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

    public ApiEnum<string, TriggerTypeModel>? TriggerType
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<string, TriggerTypeModel>>(
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

    public ApiEnum<string, VisibilityModel>? Visibility
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<string, VisibilityModel>>(
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

[JsonConverter(typeof(TriggerTypeModelConverter))]
public enum TriggerTypeModel
{
    Manual,
    Webhook,
    Schedule,
    VaultUpload,
}

sealed class TriggerTypeModelConverter : JsonConverter<TriggerTypeModel>
{
    public override TriggerTypeModel Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "manual" => TriggerTypeModel.Manual,
            "webhook" => TriggerTypeModel.Webhook,
            "schedule" => TriggerTypeModel.Schedule,
            "vault_upload" => TriggerTypeModel.VaultUpload,
            _ => (TriggerTypeModel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TriggerTypeModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TriggerTypeModel.Manual => "manual",
                TriggerTypeModel.Webhook => "webhook",
                TriggerTypeModel.Schedule => "schedule",
                TriggerTypeModel.VaultUpload => "vault_upload",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(VisibilityModelConverter))]
public enum VisibilityModel
{
    Private,
    Org,
    Public,
}

sealed class VisibilityModelConverter : JsonConverter<VisibilityModel>
{
    public override VisibilityModel Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "private" => VisibilityModel.Private,
            "org" => VisibilityModel.Org,
            "public" => VisibilityModel.Public,
            _ => (VisibilityModel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VisibilityModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                VisibilityModel.Private => "private",
                VisibilityModel.Org => "org",
                VisibilityModel.Public => "public",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
