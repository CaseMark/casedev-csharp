using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;

namespace CaseDev.Models.Vault;

[JsonConverter(typeof(JsonModelConverter<VaultUploadResponse, VaultUploadResponseFromRaw>))]
public sealed record class VaultUploadResponse : JsonModel
{
    /// <summary>
    /// Whether the file will be automatically indexed
    /// </summary>
    public bool? AutoIndex
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("auto_index");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("auto_index", value);
        }
    }

    /// <summary>
    /// Whether the vault supports indexing. False for storage-only vaults.
    /// </summary>
    public bool? EnableIndexing
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("enableIndexing");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("enableIndexing", value);
        }
    }

    /// <summary>
    /// URL expiration time in seconds
    /// </summary>
    public double? ExpiresIn
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("expiresIn");
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

    public Instructions? Instructions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Instructions>("instructions");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("instructions", value);
        }
    }

    /// <summary>
    /// Next API endpoint to call for processing
    /// </summary>
    public string? NextStep
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("next_step");
        }
        init { this._rawData.Set("next_step", value); }
    }

    /// <summary>
    /// Unique identifier for the uploaded object
    /// </summary>
    public string? ObjectID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("objectId");
        }
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
    /// Folder path for hierarchy if provided
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
    /// S3 object key for the file
    /// </summary>
    public string? S3Key
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("s3Key");
        }
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
    /// Presigned URL for uploading the file
    /// </summary>
    public string? UploadUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("uploadUrl");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("uploadUrl", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AutoIndex;
        _ = this.EnableIndexing;
        _ = this.ExpiresIn;
        this.Instructions?.Validate();
        _ = this.NextStep;
        _ = this.ObjectID;
        _ = this.Path;
        _ = this.S3Key;
        _ = this.UploadUrl;
    }

    public VaultUploadResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VaultUploadResponse(VaultUploadResponse vaultUploadResponse)
        : base(vaultUploadResponse) { }
#pragma warning restore CS8618

    public VaultUploadResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VaultUploadResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VaultUploadResponseFromRaw.FromRawUnchecked"/>
    public static VaultUploadResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VaultUploadResponseFromRaw : IFromRawJson<VaultUploadResponse>
{
    /// <inheritdoc/>
    public VaultUploadResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        VaultUploadResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Instructions, InstructionsFromRaw>))]
public sealed record class Instructions : JsonModel
{
    public JsonElement? Headers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("headers");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("headers", value);
        }
    }

    public string? Method
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("method");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("method", value);
        }
    }

    public string? Note
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("note");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("note", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Headers;
        _ = this.Method;
        _ = this.Note;
    }

    public Instructions() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Instructions(Instructions instructions)
        : base(instructions) { }
#pragma warning restore CS8618

    public Instructions(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Instructions(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InstructionsFromRaw.FromRawUnchecked"/>
    public static Instructions FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InstructionsFromRaw : IFromRawJson<Instructions>
{
    /// <inheritdoc/>
    public Instructions FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Instructions.FromRawUnchecked(rawData);
}
