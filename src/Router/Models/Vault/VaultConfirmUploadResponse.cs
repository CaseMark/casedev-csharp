using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Router.Core;
using Router.Exceptions;

namespace Router.Models.Vault;

[JsonConverter(
    typeof(JsonModelConverter<VaultConfirmUploadResponse, VaultConfirmUploadResponseFromRaw>)
)]
public sealed record class VaultConfirmUploadResponse : JsonModel
{
    public bool? AlreadyConfirmed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("alreadyConfirmed");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("alreadyConfirmed", value);
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

    public ApiEnum<string, Status>? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Status>>("status");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("status", value);
        }
    }

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
        _ = this.AlreadyConfirmed;
        _ = this.ObjectID;
        this.Status?.Validate();
        _ = this.VaultID;
    }

    public VaultConfirmUploadResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VaultConfirmUploadResponse(VaultConfirmUploadResponse vaultConfirmUploadResponse)
        : base(vaultConfirmUploadResponse) { }
#pragma warning restore CS8618

    public VaultConfirmUploadResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VaultConfirmUploadResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VaultConfirmUploadResponseFromRaw.FromRawUnchecked"/>
    public static VaultConfirmUploadResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VaultConfirmUploadResponseFromRaw : IFromRawJson<VaultConfirmUploadResponse>
{
    /// <inheritdoc/>
    public VaultConfirmUploadResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VaultConfirmUploadResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Completed,
    Failed,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "completed" => Status.Completed,
            "failed" => Status.Failed,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Completed => "completed",
                Status.Failed => "failed",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
