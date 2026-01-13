using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;

namespace CaseDev.Models.Vault;

[JsonConverter(typeof(JsonModelConverter<VaultSearchResponse, VaultSearchResponseFromRaw>))]
public sealed record class VaultSearchResponse : JsonModel
{
    /// <summary>
    /// Relevant text chunks with similarity scores
    /// </summary>
    public IReadOnlyList<Chunk>? Chunks
    {
        get { return this._rawData.GetNullableStruct<ImmutableArray<Chunk>>("chunks"); }
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
        get { return this._rawData.GetNullableClass<string>("method"); }
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
        get { return this._rawData.GetNullableClass<string>("query"); }
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
        get { return this._rawData.GetNullableClass<string>("response"); }
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
        get { return this._rawData.GetNullableStruct<ImmutableArray<Source>>("sources"); }
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
        get { return this._rawData.GetNullableClass<string>("vault_id"); }
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

    public VaultSearchResponse(VaultSearchResponse vaultSearchResponse)
        : base(vaultSearchResponse) { }

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
    public double? Score
    {
        get { return this._rawData.GetNullableStruct<double>("score"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("score", value);
        }
    }

    public string? Source
    {
        get { return this._rawData.GetNullableClass<string>("source"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("source", value);
        }
    }

    public string? Text
    {
        get { return this._rawData.GetNullableClass<string>("text"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("text", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Score;
        _ = this.Source;
        _ = this.Text;
    }

    public Chunk() { }

    public Chunk(Chunk chunk)
        : base(chunk) { }

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
        get { return this._rawData.GetNullableClass<string>("id"); }
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
        get { return this._rawData.GetNullableStruct<long>("chunkCount"); }
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
        get { return this._rawData.GetNullableStruct<DateTimeOffset>("createdAt"); }
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
        get { return this._rawData.GetNullableClass<string>("filename"); }
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
        get { return this._rawData.GetNullableStruct<DateTimeOffset>("ingestionCompletedAt"); }
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
        get { return this._rawData.GetNullableStruct<long>("pageCount"); }
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
        get { return this._rawData.GetNullableStruct<long>("textLength"); }
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

    public Source(Source source)
        : base(source) { }

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
