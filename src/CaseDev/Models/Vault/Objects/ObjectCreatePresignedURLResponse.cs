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
        ObjectCreatePresignedURLResponse,
        ObjectCreatePresignedURLResponseFromRaw
    >)
)]
public sealed record class ObjectCreatePresignedURLResponse : JsonModel
{
    /// <summary>
    /// URL expiration timestamp
    /// </summary>
    public DateTimeOffset? ExpiresAt
    {
        get { return JsonModel.GetNullableStruct<DateTimeOffset>(this.RawData, "expiresAt"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "expiresAt", value);
        }
    }

    /// <summary>
    /// URL expiration time in seconds
    /// </summary>
    public long? ExpiresIn
    {
        get { return JsonModel.GetNullableStruct<long>(this.RawData, "expiresIn"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "expiresIn", value);
        }
    }

    /// <summary>
    /// Original filename
    /// </summary>
    public string? Filename
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "filename"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "filename", value);
        }
    }

    /// <summary>
    /// Usage instructions and examples
    /// </summary>
    public JsonElement? Instructions
    {
        get { return JsonModel.GetNullableStruct<JsonElement>(this.RawData, "instructions"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "instructions", value);
        }
    }

    public Metadata? Metadata
    {
        get { return JsonModel.GetNullableClass<Metadata>(this.RawData, "metadata"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "metadata", value);
        }
    }

    /// <summary>
    /// The object identifier
    /// </summary>
    public string? ObjectID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "objectId"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "objectId", value);
        }
    }

    /// <summary>
    /// The operation type
    /// </summary>
    public string? Operation
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "operation"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "operation", value);
        }
    }

    /// <summary>
    /// The presigned URL for direct S3 access
    /// </summary>
    public string? PresignedURL
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "presignedUrl"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "presignedUrl", value);
        }
    }

    /// <summary>
    /// S3 object key
    /// </summary>
    public string? S3Key
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "s3Key"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "s3Key", value);
        }
    }

    /// <summary>
    /// The vault identifier
    /// </summary>
    public string? VaultID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "vaultId"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "vaultId", value);
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
        _ = this.PresignedURL;
        _ = this.S3Key;
        _ = this.VaultID;
    }

    public ObjectCreatePresignedURLResponse() { }

    public ObjectCreatePresignedURLResponse(
        ObjectCreatePresignedURLResponse objectCreatePresignedURLResponse
    )
        : base(objectCreatePresignedURLResponse) { }

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

    /// <inheritdoc cref="ObjectCreatePresignedURLResponseFromRaw.FromRawUnchecked"/>
    public static ObjectCreatePresignedURLResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ObjectCreatePresignedURLResponseFromRaw : IFromRawJson<ObjectCreatePresignedURLResponse>
{
    /// <inheritdoc/>
    public ObjectCreatePresignedURLResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ObjectCreatePresignedURLResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Metadata, MetadataFromRaw>))]
public sealed record class Metadata : JsonModel
{
    public string? Bucket
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "bucket"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "bucket", value);
        }
    }

    public string? ContentType
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "contentType"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "contentType", value);
        }
    }

    public string? Region
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "region"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "region", value);
        }
    }

    public long? SizeBytes
    {
        get { return JsonModel.GetNullableStruct<long>(this.RawData, "sizeBytes"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "sizeBytes", value);
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
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Metadata(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
