using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;

namespace CaseDev.Models.Vault;

[JsonConverter(typeof(ModelConverter<VaultCreateResponse, VaultCreateResponseFromRaw>))]
public sealed record class VaultCreateResponse : ModelBase
{
    /// <summary>
    /// Unique vault identifier
    /// </summary>
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

    /// <summary>
    /// Vault creation timestamp
    /// </summary>
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

    /// <summary>
    /// Vault description
    /// </summary>
    public string? Description
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "description"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "description", value);
        }
    }

    /// <summary>
    /// S3 bucket name for document storage
    /// </summary>
    public string? FilesBucket
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "filesBucket"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "filesBucket", value);
        }
    }

    /// <summary>
    /// Vector search index name
    /// </summary>
    public string? IndexName
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "indexName"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "indexName", value);
        }
    }

    /// <summary>
    /// Vault display name
    /// </summary>
    public string? Name
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "name"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "name", value);
        }
    }

    /// <summary>
    /// AWS region for storage
    /// </summary>
    public string? Region
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "region"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "region", value);
        }
    }

    /// <summary>
    /// S3 bucket name for vector embeddings
    /// </summary>
    public string? VectorBucket
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "vectorBucket"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "vectorBucket", value);
        }
    }

    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.Description;
        _ = this.FilesBucket;
        _ = this.IndexName;
        _ = this.Name;
        _ = this.Region;
        _ = this.VectorBucket;
    }

    public VaultCreateResponse() { }

    public VaultCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VaultCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static VaultCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VaultCreateResponseFromRaw : IFromRaw<VaultCreateResponse>
{
    public VaultCreateResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        VaultCreateResponse.FromRawUnchecked(rawData);
}
