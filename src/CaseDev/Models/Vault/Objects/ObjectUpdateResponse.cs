using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;

namespace CaseDev.Models.Vault.Objects;

[JsonConverter(typeof(JsonModelConverter<ObjectUpdateResponse, ObjectUpdateResponseFromRaw>))]
public sealed record class ObjectUpdateResponse : JsonModel
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
    /// Updated filename
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
    /// Processing status
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
    /// Full metadata object
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
    /// Folder path for hierarchy preservation
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
    /// Last update timestamp
    /// </summary>
    public DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("updatedAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("updatedAt", value);
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.ContentType;
        _ = this.Filename;
        _ = this.IngestionStatus;
        _ = this.Metadata;
        _ = this.Path;
        _ = this.SizeBytes;
        _ = this.UpdatedAt;
        _ = this.VaultID;
    }

    public ObjectUpdateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ObjectUpdateResponse(ObjectUpdateResponse objectUpdateResponse)
        : base(objectUpdateResponse) { }
#pragma warning restore CS8618

    public ObjectUpdateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ObjectUpdateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ObjectUpdateResponseFromRaw.FromRawUnchecked"/>
    public static ObjectUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ObjectUpdateResponseFromRaw : IFromRawJson<ObjectUpdateResponse>
{
    /// <inheritdoc/>
    public ObjectUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ObjectUpdateResponse.FromRawUnchecked(rawData);
}
