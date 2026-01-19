using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;

namespace CaseDev.Models.Vault.Objects;

[JsonConverter(typeof(JsonModelConverter<ObjectRetrieveResponse, ObjectRetrieveResponseFromRaw>))]
public sealed record class ObjectRetrieveResponse : JsonModel
{
    /// <summary>
    /// Object ID
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
    /// Number of text chunks created
    /// </summary>
    public long? ChunkCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("chunkCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("chunkCount", value);
        }
    }

    /// <summary>
    /// MIME type
    /// </summary>
    public string? ContentType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("contentType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("contentType", value);
        }
    }

    /// <summary>
    /// Upload timestamp
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
    /// Presigned S3 download URL
    /// </summary>
    public string? DownloadUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("downloadUrl");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("downloadUrl", value);
        }
    }

    /// <summary>
    /// URL expiration time in seconds
    /// </summary>
    public long? ExpiresIn
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("expiresIn");
        }
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
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("filename");
        }
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
    /// Processing status (pending, processing, completed, failed)
    /// </summary>
    public string? IngestionStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("ingestionStatus");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("ingestionStatus", value);
        }
    }

    /// <summary>
    /// Additional metadata
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
    /// Number of pages (for documents)
    /// </summary>
    public long? PageCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("pageCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("pageCount", value);
        }
    }

    /// <summary>
    /// Optional folder path for hierarchy preservation
    /// </summary>
    public string? Path
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("path");
        }
        init { this._rawData.Set("path", value); }
    }

    /// <summary>
    /// File size in bytes
    /// </summary>
    public long? SizeBytes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("sizeBytes");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("sizeBytes", value);
        }
    }

    /// <summary>
    /// Length of extracted text
    /// </summary>
    public long? TextLength
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("textLength");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("textLength", value);
        }
    }

    /// <summary>
    /// Vault ID
    /// </summary>
    public string? VaultID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("vaultId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("vaultId", value);
        }
    }

    /// <summary>
    /// Number of embedding vectors generated
    /// </summary>
    public long? VectorCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("vectorCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("vectorCount", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.ChunkCount;
        _ = this.ContentType;
        _ = this.CreatedAt;
        _ = this.DownloadUrl;
        _ = this.ExpiresIn;
        _ = this.Filename;
        _ = this.IngestionStatus;
        _ = this.Metadata;
        _ = this.PageCount;
        _ = this.Path;
        _ = this.SizeBytes;
        _ = this.TextLength;
        _ = this.VaultID;
        _ = this.VectorCount;
    }

    public ObjectRetrieveResponse() { }

    public ObjectRetrieveResponse(ObjectRetrieveResponse objectRetrieveResponse)
        : base(objectRetrieveResponse) { }

    public ObjectRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ObjectRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ObjectRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static ObjectRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ObjectRetrieveResponseFromRaw : IFromRawJson<ObjectRetrieveResponse>
{
    /// <inheritdoc/>
    public ObjectRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ObjectRetrieveResponse.FromRawUnchecked(rawData);
}
