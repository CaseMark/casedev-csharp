using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Casedev.Core;

namespace Casedev.Models.Vault;

[JsonConverter(typeof(JsonModelConverter<VaultSearchResponse, VaultSearchResponseFromRaw>))]
public sealed record class VaultSearchResponse : JsonModel
{
    /// <summary>
    /// Relevant text chunks with similarity scores and page locations
    /// </summary>
    public IReadOnlyList<Chunk>? Chunks
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Chunk>>("chunks");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Chunk>?>(
                "chunks",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Search method used
    /// </summary>
    public string? Method
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("method");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("method", value);
        }
    }

    /// <summary>
    /// Original search query
    /// </summary>
    public string? Query
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("query");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("query", value);
        }
    }

    /// <summary>
    /// AI-generated answer based on search results (for global/entity methods)
    /// </summary>
    public string? Response
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("response");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("response", value);
        }
    }

    public IReadOnlyList<Source>? Sources
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Source>>("sources");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Source>?>(
                "sources",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// ID of the searched vault
    /// </summary>
    public string? VaultID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("vault_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("vault_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Chunks ?? [])
        {
            item.Validate();
        }
        _ = this.Method;
        _ = this.Query;
        _ = this.Response;
        foreach (var item in this.Sources ?? [])
        {
            item.Validate();
        }
        _ = this.VaultID;
    }

    public VaultSearchResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VaultSearchResponse(VaultSearchResponse vaultSearchResponse)
        : base(vaultSearchResponse) { }
#pragma warning restore CS8618

    public VaultSearchResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VaultSearchResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VaultSearchResponseFromRaw.FromRawUnchecked"/>
    public static VaultSearchResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VaultSearchResponseFromRaw : IFromRawJson<VaultSearchResponse>
{
    /// <inheritdoc/>
    public VaultSearchResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        VaultSearchResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Chunk, ChunkFromRaw>))]
public sealed record class Chunk : JsonModel
{
    /// <summary>
    /// Index of the chunk within the document (0-based)
    /// </summary>
    public long? ChunkIndex
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("chunk_index");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("chunk_index", value);
        }
    }

    /// <summary>
    /// Vector similarity distance (lower is more similar)
    /// </summary>
    public double? Distance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("distance");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("distance", value);
        }
    }

    /// <summary>
    /// ID of the source document
    /// </summary>
    public string? ObjectID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("object_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("object_id", value);
        }
    }

    /// <summary>
    /// PDF page number where the chunk ends (1-indexed). Null for non-PDF documents
    /// or documents ingested before page tracking was added.
    /// </summary>
    public long? PageEnd
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("page_end");
        }
        init { this._rawData.Set("page_end", value); }
    }

    /// <summary>
    /// PDF page number where the chunk begins (1-indexed). Null for non-PDF documents
    /// or documents ingested before page tracking was added.
    /// </summary>
    public long? PageStart
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("page_start");
        }
        init { this._rawData.Set("page_start", value); }
    }

    /// <summary>
    /// Relevance score (deprecated, use distance or hybridScore)
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
    /// Source identifier (deprecated, use object_id)
    /// </summary>
    public string? Source
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("source");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("source", value);
        }
    }

    /// <summary>
    /// Preview of the chunk text (up to 500 characters)
    /// </summary>
    public string? Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("text");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("text", value);
        }
    }

    /// <summary>
    /// Ending word index (0-based) in the OCR word list. Use with GET /vault/:id/objects/:objectId/ocr-words
    /// to retrieve bounding boxes for highlighting.
    /// </summary>
    public long? WordEndIndex
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("word_end_index");
        }
        init { this._rawData.Set("word_end_index", value); }
    }

    /// <summary>
    /// Starting word index (0-based) in the OCR word list. Use with GET /vault/:id/objects/:objectId/ocr-words
    /// to retrieve bounding boxes for highlighting.
    /// </summary>
    public long? WordStartIndex
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
        _ = this.ChunkIndex;
        _ = this.Distance;
        _ = this.ObjectID;
        _ = this.PageEnd;
        _ = this.PageStart;
        _ = this.Score;
        _ = this.Source;
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

[JsonConverter(typeof(JsonModelConverter<Source, SourceFromRaw>))]
public sealed record class Source : JsonModel
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

    public long? ChunkCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("chunkCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("chunkCount", value);
        }
    }

    public DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("createdAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("createdAt", value);
        }
    }

    public string? Filename
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("filename");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("filename", value);
        }
    }

    public DateTimeOffset? IngestionCompletedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("ingestionCompletedAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("ingestionCompletedAt", value);
        }
    }

    public long? PageCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("pageCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("pageCount", value);
        }
    }

    public long? TextLength
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("textLength");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("textLength", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.ChunkCount;
        _ = this.CreatedAt;
        _ = this.Filename;
        _ = this.IngestionCompletedAt;
        _ = this.PageCount;
        _ = this.TextLength;
    }

    public Source() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Source(Source source)
        : base(source) { }
#pragma warning restore CS8618

    public Source(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Source(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SourceFromRaw.FromRawUnchecked"/>
    public static Source FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SourceFromRaw : IFromRawJson<Source>
{
    /// <inheritdoc/>
    public Source FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Source.FromRawUnchecked(rawData);
}
