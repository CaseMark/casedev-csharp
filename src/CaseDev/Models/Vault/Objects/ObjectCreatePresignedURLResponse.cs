using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;

namespace CaseDev.Models.Vault.Objects;

[JsonConverter(
    typeof(ModelConverter<
        ObjectCreatePresignedURLResponse,
        ObjectCreatePresignedURLResponseFromRaw
    >)
)]
public sealed record class ObjectCreatePresignedURLResponse : ModelBase
{
    /// <summary>
    /// URL expiration timestamp
    /// </summary>
    public DateTimeOffset? ExpiresAt
    {
        get { return ModelBase.GetNullableStruct<DateTimeOffset>(this.RawData, "expiresAt"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "expiresAt", value);
        }
    }

    /// <summary>
    /// URL expiration time in seconds
    /// </summary>
    public long? ExpiresIn
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "expiresIn"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "expiresIn", value);
        }
    }

    /// <summary>
    /// Original filename
    /// </summary>
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

    /// <summary>
    /// Usage instructions and examples
    /// </summary>
    public JsonElement? Instructions
    {
        get { return ModelBase.GetNullableStruct<JsonElement>(this.RawData, "instructions"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "instructions", value);
        }
    }

    public Metadata? Metadata
    {
        get { return ModelBase.GetNullableClass<Metadata>(this.RawData, "metadata"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "metadata", value);
        }
    }

    /// <summary>
    /// The object identifier
    /// </summary>
    public string? ObjectID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "objectId"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "objectId", value);
        }
    }

    /// <summary>
    /// The operation type
    /// </summary>
    public string? Operation
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "operation"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "operation", value);
        }
    }

    /// <summary>
    /// The presigned URL for direct S3 access
    /// </summary>
    public string? PresignedURL
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "presignedUrl"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "presignedUrl", value);
        }
    }

    /// <summary>
    /// S3 object key
    /// </summary>
    public string? S3Key
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "s3Key"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "s3Key", value);
        }
    }

    /// <summary>
    /// The vault identifier
    /// </summary>
    public string? VaultID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "vaultId"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "vaultId", value);
        }
    }

    public override void Validate()
    {
        _ = this.ExpiresAt;
        _ = this.ExpiresIn;
        _ = this.Filename;
        _ = this.Instructions;
        this.Metadata?.Validate();
        _ = this.ObjectID;
        _ = this.Operation;
        _ = this.PresignedURL;
        _ = this.S3Key;
        _ = this.VaultID;
    }

    public ObjectCreatePresignedURLResponse() { }

    public ObjectCreatePresignedURLResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ObjectCreatePresignedURLResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static ObjectCreatePresignedURLResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ObjectCreatePresignedURLResponseFromRaw : IFromRaw<ObjectCreatePresignedURLResponse>
{
    public ObjectCreatePresignedURLResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ObjectCreatePresignedURLResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<Metadata, MetadataFromRaw>))]
public sealed record class Metadata : ModelBase
{
    public string? Bucket
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "bucket"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "bucket", value);
        }
    }

    public string? ContentType
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "contentType"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "contentType", value);
        }
    }

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

    public long? SizeBytes
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "sizeBytes"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "sizeBytes", value);
        }
    }

    public override void Validate()
    {
        _ = this.Bucket;
        _ = this.ContentType;
        _ = this.Region;
        _ = this.SizeBytes;
    }

    public Metadata() { }

    public Metadata(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Metadata(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Metadata FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MetadataFromRaw : IFromRaw<Metadata>
{
    public Metadata FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Metadata.FromRawUnchecked(rawData);
}
