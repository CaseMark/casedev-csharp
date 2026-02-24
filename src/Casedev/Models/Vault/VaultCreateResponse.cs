using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Casedev.Core;

namespace Casedev.Models.Vault;

[JsonConverter(typeof(JsonModelConverter<VaultCreateResponse, VaultCreateResponseFromRaw>))]
public sealed record class VaultCreateResponse : JsonModel
{
    /// <summary>
    /// Unique vault identifier
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
    /// Whether vector indexing is enabled for this vault
    /// </summary>
    public bool? EnableIndexing
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("enableIndexing");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("enableIndexing", value);
        }
    }

    /// <summary>
    /// S3 bucket name for document storage
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
    /// Vector search index name. Null for storage-only vaults.
    /// </summary>
    public string? IndexName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("indexName");
        }
        init { this._rawData.Set("indexName", value); }
    }

    /// <summary>
    /// Vault display name
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
    /// AWS region for storage
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
    /// S3 bucket name for vector embeddings. Null for storage-only vaults.
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
        _ = this.Description;
        _ = this.EnableIndexing;
        _ = this.FilesBucket;
        _ = this.IndexName;
        _ = this.Name;
        _ = this.Region;
        _ = this.VectorBucket;
    }

    public VaultCreateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VaultCreateResponse(VaultCreateResponse vaultCreateResponse)
        : base(vaultCreateResponse) { }
#pragma warning restore CS8618

    public VaultCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VaultCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VaultCreateResponseFromRaw.FromRawUnchecked"/>
    public static VaultCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VaultCreateResponseFromRaw : IFromRawJson<VaultCreateResponse>
{
    /// <inheritdoc/>
    public VaultCreateResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        VaultCreateResponse.FromRawUnchecked(rawData);
}
