using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Casedev.Core;

namespace Casedev.Models.Vault;

[JsonConverter(typeof(JsonModelConverter<VaultRetrieveResponse, VaultRetrieveResponseFromRaw>))]
public sealed record class VaultRetrieveResponse : JsonModel
{
    /// <summary>
    /// Vault identifier
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Vault creation timestamp
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("createdAt");
        }
        init { this._rawData.Set("createdAt", value); }
    }

    /// <summary>
    /// S3 bucket for document storage
    /// </summary>
    public required string FilesBucket
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("filesBucket");
        }
        init { this._rawData.Set("filesBucket", value); }
    }

    /// <summary>
    /// Vault name
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// AWS region
    /// </summary>
    public required string Region
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("region");
        }
        init { this._rawData.Set("region", value); }
    }

    /// <summary>
    /// Document chunking strategy configuration
    /// </summary>
    public ChunkStrategy? ChunkStrategy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChunkStrategy>("chunkStrategy");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("chunkStrategy", value);
        }
    }

    /// <summary>
    /// Vault description
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    /// <summary>
    /// Whether GraphRAG is enabled
    /// </summary>
    public bool? EnableGraph
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("enableGraph");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("enableGraph", value);
        }
    }

    /// <summary>
    /// Search index name
    /// </summary>
    public string? IndexName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("indexName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("indexName", value);
        }
    }

    /// <summary>
    /// KMS key for encryption
    /// </summary>
    public string? KmsKeyID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("kmsKeyId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("kmsKeyId", value);
        }
    }

    /// <summary>
    /// Additional vault metadata
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
    /// Total storage size in bytes
    /// </summary>
    public long? TotalBytes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("totalBytes");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("totalBytes", value);
        }
    }

    /// <summary>
    /// Number of stored documents
    /// </summary>
    public long? TotalObjects
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("totalObjects");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("totalObjects", value);
        }
    }

    /// <summary>
    /// Number of vector embeddings
    /// </summary>
    public long? TotalVectors
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("totalVectors");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("totalVectors", value);
        }
    }

    /// <summary>
    /// Last update timestamp
    /// </summary>
    public DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("updatedAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("updatedAt", value);
        }
    }

    /// <summary>
    /// S3 bucket for vector embeddings
    /// </summary>
    public string? VectorBucket
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("vectorBucket");
        }
        init { this._rawData.Set("vectorBucket", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.FilesBucket;
        _ = this.Name;
        _ = this.Region;
        this.ChunkStrategy?.Validate();
        _ = this.Description;
        _ = this.EnableGraph;
        _ = this.IndexName;
        _ = this.KmsKeyID;
        _ = this.Metadata;
        _ = this.TotalBytes;
        _ = this.TotalObjects;
        _ = this.TotalVectors;
        _ = this.UpdatedAt;
        _ = this.VectorBucket;
    }

    public VaultRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VaultRetrieveResponse(VaultRetrieveResponse vaultRetrieveResponse)
        : base(vaultRetrieveResponse) { }
#pragma warning restore CS8618

    public VaultRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VaultRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VaultRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static VaultRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VaultRetrieveResponseFromRaw : IFromRawJson<VaultRetrieveResponse>
{
    /// <inheritdoc/>
    public VaultRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VaultRetrieveResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Document chunking strategy configuration
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ChunkStrategy, ChunkStrategyFromRaw>))]
public sealed record class ChunkStrategy : JsonModel
{
    /// <summary>
    /// Target size for each chunk in tokens
    /// </summary>
    public long? ChunkSize
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("chunkSize");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("chunkSize", value);
        }
    }

    /// <summary>
    /// Chunking method (e.g., 'semantic', 'fixed')
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
    /// Minimum chunk size in tokens
    /// </summary>
    public long? MinChunkSize
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("minChunkSize");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("minChunkSize", value);
        }
    }

    /// <summary>
    /// Number of overlapping tokens between chunks
    /// </summary>
    public long? Overlap
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("overlap");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("overlap", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ChunkSize;
        _ = this.Method;
        _ = this.MinChunkSize;
        _ = this.Overlap;
    }

    public ChunkStrategy() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChunkStrategy(ChunkStrategy chunkStrategy)
        : base(chunkStrategy) { }
#pragma warning restore CS8618

    public ChunkStrategy(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChunkStrategy(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChunkStrategyFromRaw.FromRawUnchecked"/>
    public static ChunkStrategy FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChunkStrategyFromRaw : IFromRawJson<ChunkStrategy>
{
    /// <inheritdoc/>
    public ChunkStrategy FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ChunkStrategy.FromRawUnchecked(rawData);
}
