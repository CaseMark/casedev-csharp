using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Casedev.Core;

namespace Casedev.Models.Memory.V1;

[JsonConverter(typeof(JsonModelConverter<V1ListResponse, V1ListResponseFromRaw>))]
public sealed record class V1ListResponse : JsonModel
{
    /// <summary>
    /// Total count matching filters
    /// </summary>
    public long? Count
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("count");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("count", value);
        }
    }

    public IReadOnlyList<V1ListResponseResult>? Results
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<V1ListResponseResult>>("results");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<V1ListResponseResult>?>(
                "results",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Count;
        foreach (var item in this.Results ?? [])
        {
            item.Validate();
        }
    }

    public V1ListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public V1ListResponse(V1ListResponse v1ListResponse)
        : base(v1ListResponse) { }
#pragma warning restore CS8618

    public V1ListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1ListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="V1ListResponseFromRaw.FromRawUnchecked"/>
    public static V1ListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class V1ListResponseFromRaw : IFromRawJson<V1ListResponse>
{
    /// <inheritdoc/>
    public V1ListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        V1ListResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<V1ListResponseResult, V1ListResponseResultFromRaw>))]
public sealed record class V1ListResponseResult : JsonModel
{
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

    public JsonElement? Tags
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("tags");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("tags", value);
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
        _ = this.Tags;
        _ = this.UpdatedAt;
    }

    public V1ListResponseResult() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public V1ListResponseResult(V1ListResponseResult v1ListResponseResult)
        : base(v1ListResponseResult) { }
#pragma warning restore CS8618

    public V1ListResponseResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1ListResponseResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="V1ListResponseResultFromRaw.FromRawUnchecked"/>
    public static V1ListResponseResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class V1ListResponseResultFromRaw : IFromRawJson<V1ListResponseResult>
{
    /// <inheritdoc/>
    public V1ListResponseResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => V1ListResponseResult.FromRawUnchecked(rawData);
}
