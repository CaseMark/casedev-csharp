using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Casedev.Core;

namespace Casedev.Models.Memory.V1;

[JsonConverter(typeof(JsonModelConverter<V1RetrieveResponse, V1RetrieveResponseFromRaw>))]
public sealed record class V1RetrieveResponse : JsonModel
{
    /// <summary>
    /// Memory ID
    /// </summary>
    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    public DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("created_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("created_at", value);
        }
    }

    /// <summary>
    /// Memory content
    /// </summary>
    public string? Memory
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("memory");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("memory", value);
        }
    }

    /// <summary>
    /// Memory metadata
    /// </summary>
    public JsonElement? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("metadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("metadata", value);
        }
    }

    public DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("updated_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("updated_at", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.Memory;
        _ = this.Metadata;
        _ = this.UpdatedAt;
    }

    public V1RetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public V1RetrieveResponse(V1RetrieveResponse v1RetrieveResponse)
        : base(v1RetrieveResponse) { }
#pragma warning restore CS8618

    public V1RetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1RetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="V1RetrieveResponseFromRaw.FromRawUnchecked"/>
    public static V1RetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class V1RetrieveResponseFromRaw : IFromRawJson<V1RetrieveResponse>
{
    /// <inheritdoc/>
    public V1RetrieveResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        V1RetrieveResponse.FromRawUnchecked(rawData);
}
