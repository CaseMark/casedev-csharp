using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;

namespace CaseDev.Models.Vault;

[JsonConverter(typeof(ModelConverter<VaultUploadResponse, VaultUploadResponseFromRaw>))]
public sealed record class VaultUploadResponse : ModelBase
{
    /// <summary>
    /// Whether the file will be automatically indexed
    /// </summary>
    public bool? AutoIndex
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "auto_index"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "auto_index", value);
        }
    }

    /// <summary>
    /// URL expiration time in seconds
    /// </summary>
    public double? ExpiresIn
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawData, "expiresIn"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "expiresIn", value);
        }
    }

    public Instructions? Instructions
    {
        get { return ModelBase.GetNullableClass<Instructions>(this.RawData, "instructions"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "instructions", value);
        }
    }

    /// <summary>
    /// Next API endpoint to call for processing
    /// </summary>
    public string? NextStep
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "next_step"); }
        init { ModelBase.Set(this._rawData, "next_step", value); }
    }

    /// <summary>
    /// Unique identifier for the uploaded object
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
    /// S3 object key for the file
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
    /// Presigned URL for uploading the file
    /// </summary>
    public string? UploadURL
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "uploadUrl"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "uploadUrl", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AutoIndex;
        _ = this.ExpiresIn;
        this.Instructions?.Validate();
        _ = this.NextStep;
        _ = this.ObjectID;
        _ = this.S3Key;
        _ = this.UploadURL;
    }

    public VaultUploadResponse() { }

    public VaultUploadResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VaultUploadResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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

class VaultUploadResponseFromRaw : IFromRaw<VaultUploadResponse>
{
    /// <inheritdoc/>
    public VaultUploadResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        VaultUploadResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<Instructions, InstructionsFromRaw>))]
public sealed record class Instructions : ModelBase
{
    public JsonElement? Headers
    {
        get { return ModelBase.GetNullableStruct<JsonElement>(this.RawData, "headers"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "headers", value);
        }
    }

    public string? Method
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "method"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "method", value);
        }
    }

    public string? Note
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "note"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "note", value);
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

    public Instructions(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Instructions(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InstructionsFromRaw.FromRawUnchecked"/>
    public static Instructions FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InstructionsFromRaw : IFromRaw<Instructions>
{
    /// <inheritdoc/>
    public Instructions FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Instructions.FromRawUnchecked(rawData);
}
