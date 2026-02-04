using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;

namespace CaseDev.Models.Vault.Multipart;

[JsonConverter(typeof(JsonModelConverter<MultipartInitResponse, MultipartInitResponseFromRaw>))]
public sealed record class MultipartInitResponse : JsonModel
{
    public string? NextStep
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("next_step");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("next_step", value);
        }
    }

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

    public long? PartCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("partCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("partCount", value);
        }
    }

    public long? PartSizeBytes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("partSizeBytes");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("partSizeBytes", value);
        }
    }

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

    public string? UploadID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("uploadId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("uploadId", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.NextStep;
        _ = this.ObjectID;
        _ = this.PartCount;
        _ = this.PartSizeBytes;
        _ = this.S3Key;
        _ = this.UploadID;
    }

    public MultipartInitResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MultipartInitResponse(MultipartInitResponse multipartInitResponse)
        : base(multipartInitResponse) { }
#pragma warning restore CS8618

    public MultipartInitResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MultipartInitResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MultipartInitResponseFromRaw.FromRawUnchecked"/>
    public static MultipartInitResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MultipartInitResponseFromRaw : IFromRawJson<MultipartInitResponse>
{
    /// <inheritdoc/>
    public MultipartInitResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MultipartInitResponse.FromRawUnchecked(rawData);
}
