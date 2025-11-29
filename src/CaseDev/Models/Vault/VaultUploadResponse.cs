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
        get
        {
            if (!this._rawData.TryGetValue("auto_index", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["auto_index"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// URL expiration time in seconds
    /// </summary>
    public double? ExpiresIn
    {
        get
        {
            if (!this._rawData.TryGetValue("expiresIn", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
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

    public Instructions? Instructions
    {
        get
        {
            if (!this._rawData.TryGetValue("instructions", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Instructions?>(element, ModelBase.SerializerOptions);
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

    /// <summary>
    /// Next API endpoint to call for processing
    /// </summary>
    public string? NextStep
    {
        get
        {
            if (!this._rawData.TryGetValue("next_step", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["next_step"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Unique identifier for the uploaded object
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
    /// S3 object key for the file
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
    /// Presigned URL for uploading the file
    /// </summary>
    public string? UploadURL
    {
        get
        {
            if (!this._rawData.TryGetValue("uploadUrl", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["uploadUrl"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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

    public static VaultUploadResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VaultUploadResponseFromRaw : IFromRaw<VaultUploadResponse>
{
    public VaultUploadResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        VaultUploadResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<Instructions, InstructionsFromRaw>))]
public sealed record class Instructions : ModelBase
{
    public JsonElement? Headers
    {
        get
        {
            if (!this._rawData.TryGetValue("headers", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<JsonElement?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["headers"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Method
    {
        get
        {
            if (!this._rawData.TryGetValue("method", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["method"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Note
    {
        get
        {
            if (!this._rawData.TryGetValue("note", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["note"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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

    public static Instructions FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InstructionsFromRaw : IFromRaw<Instructions>
{
    public Instructions FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Instructions.FromRawUnchecked(rawData);
}
