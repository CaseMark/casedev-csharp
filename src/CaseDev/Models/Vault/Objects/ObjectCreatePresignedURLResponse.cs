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
        get
        {
            if (!this._rawData.TryGetValue("expiresAt", out JsonElement element))
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

            this._rawData["expiresAt"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// URL expiration time in seconds
    /// </summary>
    public long? ExpiresIn
    {
        get
        {
            if (!this._rawData.TryGetValue("expiresIn", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["expiresIn"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Original filename
    /// </summary>
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

    /// <summary>
    /// Usage instructions and examples
    /// </summary>
    public JsonElement? Instructions
    {
        get
        {
            if (!this._rawData.TryGetValue("instructions", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<JsonElement?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["instructions"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public Metadata? Metadata
    {
        get
        {
            if (!this._rawData.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Metadata?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["metadata"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The object identifier
    /// </summary>
    public string? ObjectID
    {
        get
        {
            if (!this._rawData.TryGetValue("objectId", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["objectId"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The operation type
    /// </summary>
    public string? Operation
    {
        get
        {
            if (!this._rawData.TryGetValue("operation", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["operation"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The presigned URL for direct S3 access
    /// </summary>
    public string? PresignedURL
    {
        get
        {
            if (!this._rawData.TryGetValue("presignedUrl", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["presignedUrl"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// S3 object key
    /// </summary>
    public string? S3Key
    {
        get
        {
            if (!this._rawData.TryGetValue("s3Key", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["s3Key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The vault identifier
    /// </summary>
    public string? VaultID
    {
        get
        {
            if (!this._rawData.TryGetValue("vaultId", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["vaultId"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
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
        get
        {
            if (!this._rawData.TryGetValue("bucket", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["bucket"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? ContentType
    {
        get
        {
            if (!this._rawData.TryGetValue("contentType", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["contentType"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Region
    {
        get
        {
            if (!this._rawData.TryGetValue("region", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["region"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public long? SizeBytes
    {
        get
        {
            if (!this._rawData.TryGetValue("sizeBytes", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["sizeBytes"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
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
