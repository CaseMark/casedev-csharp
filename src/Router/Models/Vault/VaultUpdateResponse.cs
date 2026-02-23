using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Router.Core;

namespace Router.Models.Vault;

[JsonConverter(typeof(JsonModelConverter<VaultUpdateResponse, VaultUpdateResponseFromRaw>))]
public sealed record class VaultUpdateResponse : JsonModel
{
    /// <summary>
    /// Vault identifier
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

    /// <summary>
    /// Document chunking strategy configuration
    /// </summary>
    public JsonElement? ChunkStrategy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("chunkStrategy");
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
    /// Vault creation timestamp
    /// </summary>
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
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// Whether GraphRAG is enabled for future uploads
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
    /// S3 bucket for document storage
    /// </summary>
    public string? FilesBucket
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("filesBucket");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("filesBucket", value);
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
    /// Vault name
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <summary>
    /// AWS region
    /// </summary>
    public string? Region
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("region");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("region", value);
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
        _ = this.ChunkStrategy;
        _ = this.CreatedAt;
        _ = this.Description;
        _ = this.EnableGraph;
        _ = this.FilesBucket;
        _ = this.IndexName;
        _ = this.KmsKeyID;
        _ = this.Metadata;
        _ = this.Name;
        _ = this.Region;
        _ = this.TotalBytes;
        _ = this.TotalObjects;
        _ = this.TotalVectors;
        _ = this.UpdatedAt;
        _ = this.VectorBucket;
    }

    public VaultUpdateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VaultUpdateResponse(VaultUpdateResponse vaultUpdateResponse)
        : base(vaultUpdateResponse) { }
#pragma warning restore CS8618

    public VaultUpdateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VaultUpdateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VaultUpdateResponseFromRaw.FromRawUnchecked"/>
    public static VaultUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VaultUpdateResponseFromRaw : IFromRawJson<VaultUpdateResponse>
{
    /// <inheritdoc/>
    public VaultUpdateResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        VaultUpdateResponse.FromRawUnchecked(rawData);
}
