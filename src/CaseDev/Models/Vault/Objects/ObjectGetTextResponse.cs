using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;

namespace CaseDev.Models.Vault.Objects;

[JsonConverter(typeof(JsonModelConverter<ObjectGetTextResponse, ObjectGetTextResponseFromRaw>))]
public sealed record class ObjectGetTextResponse : JsonModel
{
    public ObjectGetTextResponseMetadata? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ObjectGetTextResponseMetadata>("metadata");
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
    /// Full concatenated text content from all chunks
    /// </summary>
    public string? Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("text");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("text", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Metadata?.Validate();
        _ = this.Text;
    }

    public ObjectGetTextResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ObjectGetTextResponse(ObjectGetTextResponse objectGetTextResponse)
        : base(objectGetTextResponse) { }
#pragma warning restore CS8618

    public ObjectGetTextResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ObjectGetTextResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ObjectGetTextResponseFromRaw.FromRawUnchecked"/>
    public static ObjectGetTextResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ObjectGetTextResponseFromRaw : IFromRawJson<ObjectGetTextResponse>
{
    /// <inheritdoc/>
    public ObjectGetTextResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ObjectGetTextResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<ObjectGetTextResponseMetadata, ObjectGetTextResponseMetadataFromRaw>)
)]
public sealed record class ObjectGetTextResponseMetadata : JsonModel
{
    /// <summary>
    /// Number of text chunks the document was split into
    /// </summary>
    public long? ChunkCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("chunk_count");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("chunk_count", value);
        }
    }

    /// <summary>
    /// Original filename of the document
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
    /// When the document processing completed
    /// </summary>
    public DateTimeOffset? IngestionCompletedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("ingestion_completed_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("ingestion_completed_at", value);
        }
    }

    /// <summary>
    /// Total character count of the extracted text
    /// </summary>
    public long? Length
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("length");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("length", value);
        }
    }

    /// <summary>
    /// The object ID
    /// </summary>
    public string? ObjectID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("object_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("object_id", value);
        }
    }

    /// <summary>
    /// The vault ID
    /// </summary>
    public string? VaultID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("vault_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("vault_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ChunkCount;
        _ = this.Filename;
        _ = this.IngestionCompletedAt;
        _ = this.Length;
        _ = this.ObjectID;
        _ = this.VaultID;
    }

    public ObjectGetTextResponseMetadata() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ObjectGetTextResponseMetadata(
        ObjectGetTextResponseMetadata objectGetTextResponseMetadata
    )
        : base(objectGetTextResponseMetadata) { }
#pragma warning restore CS8618

    public ObjectGetTextResponseMetadata(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ObjectGetTextResponseMetadata(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ObjectGetTextResponseMetadataFromRaw.FromRawUnchecked"/>
    public static ObjectGetTextResponseMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ObjectGetTextResponseMetadataFromRaw : IFromRawJson<ObjectGetTextResponseMetadata>
{
    /// <inheritdoc/>
    public ObjectGetTextResponseMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ObjectGetTextResponseMetadata.FromRawUnchecked(rawData);
}
