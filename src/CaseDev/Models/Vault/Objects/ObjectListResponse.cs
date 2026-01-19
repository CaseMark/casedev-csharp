using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;

namespace CaseDev.Models.Vault.Objects;

[JsonConverter(typeof(JsonModelConverter<ObjectListResponse, ObjectListResponseFromRaw>))]
public sealed record class ObjectListResponse : JsonModel
{
    /// <summary>
    /// Total number of objects in the vault
    /// </summary>
    public double? Count
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("count");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("count", value);
        }
    }

    public IReadOnlyList<global::CaseDev.Models.Vault.Objects.Object>? Objects
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<global::CaseDev.Models.Vault.Objects.Object>
            >("objects");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<global::CaseDev.Models.Vault.Objects.Object>?>(
                "objects",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The ID of the vault
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Count;
        foreach (var item in this.Objects ?? [])
        {
            item.Validate();
        }
        _ = this.VaultID;
    }

    public ObjectListResponse() { }

    public ObjectListResponse(ObjectListResponse objectListResponse)
        : base(objectListResponse) { }

    public ObjectListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ObjectListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ObjectListResponseFromRaw.FromRawUnchecked"/>
    public static ObjectListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ObjectListResponseFromRaw : IFromRawJson<ObjectListResponse>
{
    /// <inheritdoc/>
    public ObjectListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ObjectListResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<global::CaseDev.Models.Vault.Objects.Object, ObjectFromRaw>)
)]
public sealed record class Object : JsonModel
{
    /// <summary>
    /// Unique object identifier
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
    /// Number of text chunks created for vectorization
    /// </summary>
    public double? ChunkCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("chunkCount");
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
    /// MIME type of the document
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
    /// Document upload timestamp
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
    /// Original filename of the uploaded document
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
    /// Processing completion timestamp
    /// </summary>
    public DateTimeOffset? IngestionCompletedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("ingestionCompletedAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("ingestionCompletedAt", value);
        }
    }

    /// <summary>
    /// Processing status of the document
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
    /// Custom metadata associated with the document
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
    /// Number of pages in the document
    /// </summary>
    public double? PageCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("pageCount");
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
    /// Optional folder path for hierarchy preservation from source systems
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
    public double? SizeBytes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("sizeBytes");
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
    /// Custom tags associated with the document
    /// </summary>
    public IReadOnlyList<string>? Tags
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("tags");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "tags",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Total character count of extracted text
    /// </summary>
    public double? TextLength
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("textLength");
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
    /// Number of vectors generated for semantic search
    /// </summary>
    public double? VectorCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("vectorCount");
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
        _ = this.Filename;
        _ = this.IngestionCompletedAt;
        _ = this.IngestionStatus;
        _ = this.Metadata;
        _ = this.PageCount;
        _ = this.Path;
        _ = this.SizeBytes;
        _ = this.Tags;
        _ = this.TextLength;
        _ = this.VectorCount;
    }

    public Object() { }

    public Object(global::CaseDev.Models.Vault.Objects.Object object_)
        : base(object_) { }

    public Object(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Object(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ObjectFromRaw.FromRawUnchecked"/>
    public static global::CaseDev.Models.Vault.Objects.Object FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ObjectFromRaw : IFromRawJson<global::CaseDev.Models.Vault.Objects.Object>
{
    /// <inheritdoc/>
    public global::CaseDev.Models.Vault.Objects.Object FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::CaseDev.Models.Vault.Objects.Object.FromRawUnchecked(rawData);
}
