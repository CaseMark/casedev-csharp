using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;
using CaseDev.Exceptions;

namespace CaseDev.Models.Voice.Transcription;

[JsonConverter(
    typeof(JsonModelConverter<TranscriptionCreateResponse, TranscriptionCreateResponseFromRaw>)
)]
public sealed record class TranscriptionCreateResponse : JsonModel
{
    /// <summary>
    /// Unique transcription job ID
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
    /// Source audio object ID (only for vault-based transcription)
    /// </summary>
    public string? SourceObjectID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("source_object_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("source_object_id", value);
        }
    }

    /// <summary>
    /// Current status of the transcription job
    /// </summary>
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

    /// <summary>
    /// Vault ID (only for vault-based transcription)
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
        _ = this.ID;
        _ = this.SourceObjectID;
        this.Status?.Validate();
        _ = this.VaultID;
    }

    public TranscriptionCreateResponse() { }

    public TranscriptionCreateResponse(TranscriptionCreateResponse transcriptionCreateResponse)
        : base(transcriptionCreateResponse) { }

    public TranscriptionCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TranscriptionCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TranscriptionCreateResponseFromRaw.FromRawUnchecked"/>
    public static TranscriptionCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TranscriptionCreateResponseFromRaw : IFromRawJson<TranscriptionCreateResponse>
{
    /// <inheritdoc/>
    public TranscriptionCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TranscriptionCreateResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Current status of the transcription job
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Queued,
    Processing,
    Completed,
    Error,
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
            "queued" => Status.Queued,
            "processing" => Status.Processing,
            "completed" => Status.Completed,
            "error" => Status.Error,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Queued => "queued",
                Status.Processing => "processing",
                Status.Completed => "completed",
                Status.Error => "error",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
