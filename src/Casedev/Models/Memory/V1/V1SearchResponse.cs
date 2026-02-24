using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Casedev.Core;

namespace Casedev.Models.Memory.V1;

[JsonConverter(typeof(JsonModelConverter<V1SearchResponse, V1SearchResponseFromRaw>))]
public sealed record class V1SearchResponse : JsonModel
{
    public IReadOnlyList<V1SearchResponseResult>? Results
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<V1SearchResponseResult>>(
                "results"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<V1SearchResponseResult>?>(
                "results",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Results ?? [])
        {
            item.Validate();
        }
    }

    public V1SearchResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public V1SearchResponse(V1SearchResponse v1SearchResponse)
        : base(v1SearchResponse) { }
#pragma warning restore CS8618

    public V1SearchResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1SearchResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="V1SearchResponseFromRaw.FromRawUnchecked"/>
    public static V1SearchResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class V1SearchResponseFromRaw : IFromRawJson<V1SearchResponse>
{
    /// <inheritdoc/>
    public V1SearchResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        V1SearchResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<V1SearchResponseResult, V1SearchResponseResultFromRaw>))]
public sealed record class V1SearchResponseResult : JsonModel
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
    /// Additional metadata
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

    /// <summary>
    /// Similarity score (0-1)
    /// </summary>
    public double? Score
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("score");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("score", value);
        }
    }

    /// <summary>
    /// Tag values for this memory
    /// </summary>
    public Tags? Tags
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Tags>("tags");
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
        _ = this.Score;
        this.Tags?.Validate();
        _ = this.UpdatedAt;
    }

    public V1SearchResponseResult() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public V1SearchResponseResult(V1SearchResponseResult v1SearchResponseResult)
        : base(v1SearchResponseResult) { }
#pragma warning restore CS8618

    public V1SearchResponseResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1SearchResponseResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="V1SearchResponseResultFromRaw.FromRawUnchecked"/>
    public static V1SearchResponseResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class V1SearchResponseResultFromRaw : IFromRawJson<V1SearchResponseResult>
{
    /// <inheritdoc/>
    public V1SearchResponseResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => V1SearchResponseResult.FromRawUnchecked(rawData);
}

/// <summary>
/// Tag values for this memory
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Tags, TagsFromRaw>))]
public sealed record class Tags : JsonModel
{
    public string? Tag1
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("tag_1");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("tag_1", value);
        }
    }

    public string? Tag10
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("tag_10");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("tag_10", value);
        }
    }

    public string? Tag11
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("tag_11");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("tag_11", value);
        }
    }

    public string? Tag12
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("tag_12");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("tag_12", value);
        }
    }

    public string? Tag2
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("tag_2");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("tag_2", value);
        }
    }

    public string? Tag3
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("tag_3");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("tag_3", value);
        }
    }

    public string? Tag4
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("tag_4");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("tag_4", value);
        }
    }

    public string? Tag5
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("tag_5");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("tag_5", value);
        }
    }

    public string? Tag6
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("tag_6");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("tag_6", value);
        }
    }

    public string? Tag7
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("tag_7");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("tag_7", value);
        }
    }

    public string? Tag8
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("tag_8");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("tag_8", value);
        }
    }

    public string? Tag9
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("tag_9");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("tag_9", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Tag1;
        _ = this.Tag10;
        _ = this.Tag11;
        _ = this.Tag12;
        _ = this.Tag2;
        _ = this.Tag3;
        _ = this.Tag4;
        _ = this.Tag5;
        _ = this.Tag6;
        _ = this.Tag7;
        _ = this.Tag8;
        _ = this.Tag9;
    }

    public Tags() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Tags(Tags tags)
        : base(tags) { }
#pragma warning restore CS8618

    public Tags(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Tags(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TagsFromRaw.FromRawUnchecked"/>
    public static Tags FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TagsFromRaw : IFromRawJson<Tags>
{
    /// <inheritdoc/>
    public Tags FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Tags.FromRawUnchecked(rawData);
}
