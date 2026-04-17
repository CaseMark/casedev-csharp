using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Casedev.Core;

namespace Casedev.Models.Vault.Objects;

[JsonConverter(typeof(JsonModelConverter<ObjectGetChunksResponse, ObjectGetChunksResponseFromRaw>))]
public sealed record class ObjectGetChunksResponse : JsonModel
{
    /// <summary>
    /// Full chunk objects for the requested range
    /// </summary>
    public required IReadOnlyList<Chunk> Chunks
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Chunk>>("chunks");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Chunk>>(
                "chunks",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The object ID
    /// </summary>
    public required string ObjectID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("object_id");
        }
        init { this._rawData.Set("object_id", value); }
    }

    /// <summary>
    /// Total number of chunks stored for the object
    /// </summary>
    public required long TotalChunks
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("total_chunks");
        }
        init { this._rawData.Set("total_chunks", value); }
    }

    /// <summary>
    /// The vault ID
    /// </summary>
    public required string VaultID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("vault_id");
        }
        init { this._rawData.Set("vault_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Chunks)
        {
            item.Validate();
        }
        _ = this.ObjectID;
        _ = this.TotalChunks;
        _ = this.VaultID;
    }

    public ObjectGetChunksResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ObjectGetChunksResponse(ObjectGetChunksResponse objectGetChunksResponse)
        : base(objectGetChunksResponse) { }
#pragma warning restore CS8618

    public ObjectGetChunksResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ObjectGetChunksResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ObjectGetChunksResponseFromRaw.FromRawUnchecked"/>
    public static ObjectGetChunksResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ObjectGetChunksResponseFromRaw : IFromRawJson<ObjectGetChunksResponse>
{
    /// <inheritdoc/>
    public ObjectGetChunksResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ObjectGetChunksResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Chunk, ChunkFromRaw>))]
public sealed record class Chunk : JsonModel
{
    /// <summary>
    /// Chunk index within the document
    /// </summary>
    public required long Index
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("index");
        }
        init { this._rawData.Set("index", value); }
    }

    /// <summary>
    /// Last page covered by the chunk, if page mapping is available
    /// </summary>
    public required long? PageEnd
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("page_end");
        }
        init { this._rawData.Set("page_end", value); }
    }

    /// <summary>
    /// First page covered by the chunk, if page mapping is available
    /// </summary>
    public required long? PageStart
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("page_start");
        }
        init { this._rawData.Set("page_start", value); }
    }

    /// <summary>
    /// Full text for the chunk
    /// </summary>
    public required string Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("text");
        }
        init { this._rawData.Set("text", value); }
    }

    /// <summary>
    /// Last OCR word index covered by the chunk, if available
    /// </summary>
    public required long? WordEndIndex
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("word_end_index");
        }
        init { this._rawData.Set("word_end_index", value); }
    }

    /// <summary>
    /// First OCR word index covered by the chunk, if available
    /// </summary>
    public required long? WordStartIndex
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("word_start_index");
        }
        init { this._rawData.Set("word_start_index", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Index;
        _ = this.PageEnd;
        _ = this.PageStart;
        _ = this.Text;
        _ = this.WordEndIndex;
        _ = this.WordStartIndex;
    }

    public Chunk() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Chunk(Chunk chunk)
        : base(chunk) { }
#pragma warning restore CS8618

    public Chunk(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Chunk(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChunkFromRaw.FromRawUnchecked"/>
    public static Chunk FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChunkFromRaw : IFromRawJson<Chunk>
{
    /// <inheritdoc/>
    public Chunk FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Chunk.FromRawUnchecked(rawData);
}
