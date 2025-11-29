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
        get
        {
            if (!this._rawData.TryGetValue("chunks", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<Chunk>?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["chunks"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
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
            if (!this._rawData.TryGetValue("method", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["method"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Original search query
    /// </summary>
    public string? Query
    {
        get
        {
            if (!this._rawData.TryGetValue("query", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["query"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// AI-generated answer based on search results (for global/entity methods)
    /// </summary>
    public string? Response
    {
        get
        {
            if (!this._rawData.TryGetValue("response", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["response"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public IReadOnlyList<Source>? Sources
    {
        get
        {
            if (!this._rawData.TryGetValue("sources", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<Source>?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["sources"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
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
            if (!this._rawData.TryGetValue("vault_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["vault_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
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
        get
        {
            if (!this._rawData.TryGetValue("score", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["score"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Source
    {
        get
        {
            if (!this._rawData.TryGetValue("source", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["source"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Text
    {
        get
        {
            if (!this._rawData.TryGetValue("text", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["text"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
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
        get
        {
            if (!this._rawData.TryGetValue("id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public long? ChunkCount
    {
        get
        {
            if (!this._rawData.TryGetValue("chunkCount", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["chunkCount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public DateTimeOffset? CreatedAt
    {
        get
        {
            if (!this._rawData.TryGetValue("createdAt", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTimeOffset?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["createdAt"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Filename
    {
        get
        {
            if (!this._rawData.TryGetValue("filename", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["filename"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public DateTimeOffset? IngestionCompletedAt
    {
        get
        {
            if (!this._rawData.TryGetValue("ingestionCompletedAt", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTimeOffset?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["ingestionCompletedAt"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public long? PageCount
    {
        get
        {
            if (!this._rawData.TryGetValue("pageCount", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["pageCount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public long? TextLength
    {
        get
        {
            if (!this._rawData.TryGetValue("textLength", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["textLength"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
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
