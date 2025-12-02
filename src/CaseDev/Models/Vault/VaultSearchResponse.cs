using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;

namespace CaseDev.Models.Vault;

[JsonConverter(typeof(ModelConverter<VaultSearchResponse, VaultSearchResponseFromRaw>))]
public sealed record class VaultSearchResponse : ModelBase
{
    /// <summary>
    /// Relevant text chunks with similarity scores
    /// </summary>
    public IReadOnlyList<Chunk>? Chunks
    {
        get { return ModelBase.GetNullableClass<List<Chunk>>(this.RawData, "chunks"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "chunks", value);
        }
    }

    /// <summary>
    /// Search method used
    /// </summary>
    public string? Method
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "method"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "method", value);
        }
    }

    /// <summary>
    /// Original search query
    /// </summary>
    public string? Query
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "query"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "query", value);
        }
    }

    /// <summary>
    /// AI-generated answer based on search results (for global/entity methods)
    /// </summary>
    public string? Response
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "response"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "response", value);
        }
    }

    public IReadOnlyList<Source>? Sources
    {
        get { return ModelBase.GetNullableClass<List<Source>>(this.RawData, "sources"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "sources", value);
        }
    }

    /// <summary>
    /// ID of the searched vault
    /// </summary>
    public string? VaultID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "vault_id"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "vault_id", value);
        }
    }

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

    public VaultSearchResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VaultSearchResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static VaultSearchResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VaultSearchResponseFromRaw : IFromRaw<VaultSearchResponse>
{
    public VaultSearchResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        VaultSearchResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<Chunk, ChunkFromRaw>))]
public sealed record class Chunk : ModelBase
{
    public double? Score
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawData, "score"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "score", value);
        }
    }

    public string? Source
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "source"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "source", value);
        }
    }

    public string? Text
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "text"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "text", value);
        }
    }

    public override void Validate()
    {
        _ = this.Score;
        _ = this.Source;
        _ = this.Text;
    }

    public Chunk() { }

    public Chunk(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Chunk(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Chunk FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChunkFromRaw : IFromRaw<Chunk>
{
    public Chunk FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Chunk.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<Source, SourceFromRaw>))]
public sealed record class Source : ModelBase
{
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

    public long? ChunkCount
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "chunkCount"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "chunkCount", value);
        }
    }

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

    public string? Filename
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "filename"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "filename", value);
        }
    }

    public DateTimeOffset? IngestionCompletedAt
    {
        get
        {
            return ModelBase.GetNullableStruct<DateTimeOffset>(
                this.RawData,
                "ingestionCompletedAt"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "ingestionCompletedAt", value);
        }
    }

    public long? PageCount
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "pageCount"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "pageCount", value);
        }
    }

    public long? TextLength
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "textLength"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "textLength", value);
        }
    }

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

    public Source(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Source(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Source FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SourceFromRaw : IFromRaw<Source>
{
    public Source FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Source.FromRawUnchecked(rawData);
}
