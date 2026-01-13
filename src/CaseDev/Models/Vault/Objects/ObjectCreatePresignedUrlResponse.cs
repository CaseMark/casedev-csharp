using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;

namespace CaseDev.Models.Vault.Objects;

[JsonConverter(
    typeof(JsonModelConverter<
        ObjectCreatePresignedUrlResponse,
        ObjectCreatePresignedUrlResponseFromRaw
    >)
)]
public sealed record class ObjectCreatePresignedUrlResponse : JsonModel
{
    /// <summary>
    /// URL expiration timestamp
    /// </summary>
    public DateTimeOffset? ExpiresAt
    {
        get { return this._rawData.GetNullableStruct<DateTimeOffset>("expiresAt"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("expiresAt", value);
        }
    }

    /// <summary>
    /// URL expiration time in seconds
    /// </summary>
    public long? ExpiresIn
    {
        get { return this._rawData.GetNullableStruct<long>("expiresIn"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("expiresIn", value);
        }
    }

    /// <summary>
    /// Original filename
    /// </summary>
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

    /// <summary>
    /// Usage instructions and examples
    /// </summary>
    public JsonElement? Instructions
    {
        get { return this._rawData.GetNullableStruct<JsonElement>("instructions"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("instructions", value);
        }
    }

    public Metadata? Metadata
    {
        get { return this._rawData.GetNullableClass<Metadata>("metadata"); }
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
    /// The object identifier
    /// </summary>
    public string? ObjectID
    {
        get { return this._rawData.GetNullableClass<string>("objectId"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("objectId", value);
        }
    }

    /// <summary>
    /// The operation type
    /// </summary>
    public string? Operation
    {
        get { return this._rawData.GetNullableClass<string>("operation"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("operation", value);
        }
    }

    /// <summary>
    /// The presigned URL for direct S3 access
    /// </summary>
    public string? PresignedUrl
    {
        get { return this._rawData.GetNullableClass<string>("presignedUrl"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("presignedUrl", value);
        }
    }

    /// <summary>
    /// S3 object key
    /// </summary>
    public string? S3Key
    {
        get { return this._rawData.GetNullableClass<string>("s3Key"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("s3Key", value);
        }
    }

    /// <summary>
    /// The vault identifier
    /// </summary>
    public string? VaultID
    {
        get { return this._rawData.GetNullableClass<string>("vaultId"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("vaultId", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ExpiresAt;
        _ = this.ExpiresIn;
        _ = this.Filename;
        _ = this.Instructions;
        this.Metadata?.Validate();
        _ = this.ObjectID;
        _ = this.Operation;
        _ = this.PresignedUrl;
        _ = this.S3Key;
        _ = this.VaultID;
    }

    public ObjectCreatePresignedUrlResponse() { }

    public ObjectCreatePresignedUrlResponse(
        ObjectCreatePresignedUrlResponse objectCreatePresignedUrlResponse
    )
        : base(objectCreatePresignedUrlResponse) { }

    public ObjectCreatePresignedUrlResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ObjectCreatePresignedUrlResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ObjectCreatePresignedUrlResponseFromRaw.FromRawUnchecked"/>
    public static ObjectCreatePresignedUrlResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ObjectCreatePresignedUrlResponseFromRaw : IFromRawJson<ObjectCreatePresignedUrlResponse>
{
    /// <inheritdoc/>
    public ObjectCreatePresignedUrlResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ObjectCreatePresignedUrlResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Metadata, MetadataFromRaw>))]
public sealed record class Metadata : JsonModel
{
    public string? Bucket
    {
        get { return this._rawData.GetNullableClass<string>("bucket"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("bucket", value);
        }
    }

    public string? ContentType
    {
        get { return this._rawData.GetNullableClass<string>("contentType"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("contentType", value);
        }
    }

    public string? Region
    {
        get { return this._rawData.GetNullableClass<string>("region"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("region", value);
        }
    }

    public long? SizeBytes
    {
        get { return this._rawData.GetNullableStruct<long>("sizeBytes"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("sizeBytes", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Bucket;
        _ = this.ContentType;
        _ = this.Region;
        _ = this.SizeBytes;
    }

    public Metadata() { }

    public Metadata(Metadata metadata)
        : base(metadata) { }

    public Metadata(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Metadata(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MetadataFromRaw.FromRawUnchecked"/>
    public static Metadata FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MetadataFromRaw : IFromRawJson<Metadata>
{
    /// <inheritdoc/>
    public Metadata FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Metadata.FromRawUnchecked(rawData);
}
