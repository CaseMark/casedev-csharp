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
/// Create a new visual workflow with nodes, edges, and trigger configuration.
/// </summary>
public sealed record class V1CreateParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Workflow name
    /// </summary>
    public required string Name
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawBodyData, "name"); }
        init { ModelBase.Set(this._rawBodyData, "name", value); }
    }

    /// <summary>
    /// Workflow description
    /// </summary>
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

    /// <summary>
    /// React Flow edges
    /// </summary>
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

    /// <summary>
    /// React Flow nodes
    /// </summary>
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

    /// <summary>
    /// Trigger configuration
    /// </summary>
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

    public ApiEnum<string, TriggerType>? TriggerType
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<string, TriggerType>>(
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

    /// <summary>
    /// Workflow visibility
    /// </summary>
    public ApiEnum<string, Visibility>? Visibility
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<string, Visibility>>(
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

    public V1CreateParams() { }

    public V1CreateParams(
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
    V1CreateParams(
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
    public static V1CreateParams FromRawUnchecked(
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/workflows/v1")
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

[JsonConverter(typeof(TriggerTypeConverter))]
public enum TriggerType
{
    Manual,
    Webhook,
    Schedule,
    VaultUpload,
}

sealed class TriggerTypeConverter : JsonConverter<TriggerType>
{
    public override TriggerType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "manual" => TriggerType.Manual,
            "webhook" => TriggerType.Webhook,
            "schedule" => TriggerType.Schedule,
            "vault_upload" => TriggerType.VaultUpload,
            _ => (TriggerType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TriggerType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TriggerType.Manual => "manual",
                TriggerType.Webhook => "webhook",
                TriggerType.Schedule => "schedule",
                TriggerType.VaultUpload => "vault_upload",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Workflow visibility
/// </summary>
[JsonConverter(typeof(VisibilityConverter))]
public enum Visibility
{
    Private,
    Org,
    Public,
}

sealed class VisibilityConverter : JsonConverter<Visibility>
{
    public override Visibility Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "private" => Visibility.Private,
            "org" => Visibility.Org,
            "public" => Visibility.Public,
            _ => (Visibility)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Visibility value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Visibility.Private => "private",
                Visibility.Org => "org",
                Visibility.Public => "public",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
