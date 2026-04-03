using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Casedev.Core;

namespace Casedev.Models.Vault.Memory;

[JsonConverter(typeof(JsonModelConverter<MemoryListResponse, MemoryListResponseFromRaw>))]
public sealed record class MemoryListResponse : JsonModel
{
    public IReadOnlyList<MemoryListResponseEntry>? Entries
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<MemoryListResponseEntry>>(
                "entries"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<MemoryListResponseEntry>?>(
                "entries",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public Meta? Meta
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Meta>("meta");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("meta", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Entries ?? [])
        {
            item.Validate();
        }
        this.Meta?.Validate();
    }

    public MemoryListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MemoryListResponse(MemoryListResponse memoryListResponse)
        : base(memoryListResponse) { }
#pragma warning restore CS8618

    public MemoryListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MemoryListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MemoryListResponseFromRaw.FromRawUnchecked"/>
    public static MemoryListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MemoryListResponseFromRaw : IFromRawJson<MemoryListResponse>
{
    /// <inheritdoc/>
    public MemoryListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MemoryListResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<MemoryListResponseEntry, MemoryListResponseEntryFromRaw>))]
public sealed record class MemoryListResponseEntry : JsonModel
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

    public string? Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("content");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("content", value);
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

    public string? CreatedBy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("created_by");
        }
        init { this._rawData.Set("created_by", value); }
    }

    public string? Source
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("source");
        }
        init { this._rawData.Set("source", value); }
    }

    public IReadOnlyList<string>? Tags
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("tags");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "tags",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
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
        _ = this.Content;
        _ = this.CreatedAt;
        _ = this.CreatedBy;
        _ = this.Source;
        _ = this.Tags;
        _ = this.Type;
        _ = this.UpdatedAt;
    }

    public MemoryListResponseEntry() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MemoryListResponseEntry(MemoryListResponseEntry memoryListResponseEntry)
        : base(memoryListResponseEntry) { }
#pragma warning restore CS8618

    public MemoryListResponseEntry(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MemoryListResponseEntry(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MemoryListResponseEntryFromRaw.FromRawUnchecked"/>
    public static MemoryListResponseEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MemoryListResponseEntryFromRaw : IFromRawJson<MemoryListResponseEntry>
{
    /// <inheritdoc/>
    public MemoryListResponseEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MemoryListResponseEntry.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Meta, MetaFromRaw>))]
public sealed record class Meta : JsonModel
{
    public long? Chars
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("chars");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("chars", value);
        }
    }

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

    public long? MaxChars
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("max_chars");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("max_chars", value);
        }
    }

    public DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Chars;
        _ = this.Count;
        _ = this.MaxChars;
        _ = this.UpdatedAt;
    }

    public Meta() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Meta(Meta meta)
        : base(meta) { }
#pragma warning restore CS8618

    public Meta(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Meta(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MetaFromRaw.FromRawUnchecked"/>
    public static Meta FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MetaFromRaw : IFromRawJson<Meta>
{
    /// <inheritdoc/>
    public Meta FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Meta.FromRawUnchecked(rawData);
}
