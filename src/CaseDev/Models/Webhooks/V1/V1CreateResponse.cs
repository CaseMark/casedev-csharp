using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;

namespace CaseDev.Models.Webhooks.V1;

[JsonConverter(typeof(ModelConverter<V1CreateResponse, V1CreateResponseFromRaw>))]
public sealed record class V1CreateResponse : ModelBase
{
    /// <summary>
    /// Unique webhook endpoint ID
    /// </summary>
    public string? ID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "id"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "id", value);
        }
    }

    /// <summary>
    /// Creation timestamp
    /// </summary>
    public DateTimeOffset? CreatedAt
    {
        get { return ModelBase.GetNullableStruct<DateTimeOffset>(this.RawData, "createdAt"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "createdAt", value);
        }
    }

    /// <summary>
    /// Webhook description
    /// </summary>
    public string? Description
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "description"); }
        init { ModelBase.Set(this._rawData, "description", value); }
    }

    /// <summary>
    /// Subscribed event types
    /// </summary>
    public IReadOnlyList<string>? Events
    {
        get { return ModelBase.GetNullableClass<List<string>>(this.RawData, "events"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "events", value);
        }
    }

    /// <summary>
    /// Whether webhook is active
    /// </summary>
    public bool? IsActive
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "isActive"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "isActive", value);
        }
    }

    /// <summary>
    /// Webhook signing secret (only shown on creation)
    /// </summary>
    public string? Secret
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "secret"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "secret", value);
        }
    }

    /// <summary>
    /// Webhook destination URL
    /// </summary>
    public string? URL
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "url"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "url", value);
        }
    }

    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.Description;
        _ = this.Events;
        _ = this.IsActive;
        _ = this.Secret;
        _ = this.URL;
    }

    public V1CreateResponse() { }

    public V1CreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1CreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static V1CreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class V1CreateResponseFromRaw : IFromRaw<V1CreateResponse>
{
    public V1CreateResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        V1CreateResponse.FromRawUnchecked(rawData);
}
