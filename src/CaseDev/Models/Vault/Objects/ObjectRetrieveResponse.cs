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
    /// MIME type
    /// </summary>
    public required string ContentType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("contentType");
        }
        init { this._rawData.Set("contentType", value); }
    }

    /// <summary>
    /// Upload timestamp
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
    /// Presigned S3 download URL
    /// </summary>
    public required string DownloadUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("downloadUrl");
        }
        init { this._rawData.Set("downloadUrl", value); }
    }

    /// <summary>
    /// URL expiration time in seconds
    /// </summary>
    public required long ExpiresIn
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("expiresIn");
        }
        init { this._rawData.Set("expiresIn", value); }
    }

    /// <summary>
    /// Original filename
    /// </summary>
    public required string Filename
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("filename");
        }
        init { this._rawData.Set("filename", value); }
    }

    /// <summary>
    /// Processing status (pending, processing, completed, failed)
    /// </summary>
    public required string IngestionStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("ingestionStatus");
        }
        init { this._rawData.Set("ingestionStatus", value); }
    }

    /// <summary>
    /// Vault ID
    /// </summary>
    public required string VaultID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("vaultId");
        }
        init { this._rawData.Set("vaultId", value); }
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
        _ = this.ContentType;
        _ = this.CreatedAt;
        _ = this.DownloadUrl;
        _ = this.ExpiresIn;
        _ = this.Filename;
        _ = this.IngestionStatus;
        _ = this.VaultID;
        _ = this.ChunkCount;
        _ = this.Metadata;
        _ = this.PageCount;
        _ = this.Path;
        _ = this.SizeBytes;
        _ = this.TextLength;
        _ = this.VectorCount;
    }

    public ObjectRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ObjectRetrieveResponse(ObjectRetrieveResponse objectRetrieveResponse)
        : base(objectRetrieveResponse) { }
#pragma warning restore CS8618

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
