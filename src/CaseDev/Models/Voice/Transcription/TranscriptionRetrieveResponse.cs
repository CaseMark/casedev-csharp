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
    typeof(JsonModelConverter<TranscriptionRetrieveResponse, TranscriptionRetrieveResponseFromRaw>)
)]
public sealed record class TranscriptionRetrieveResponse : JsonModel
{
    /// <summary>
    /// Unique transcription job ID
    /// </summary>
    public required string ID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "id"); }
        init { JsonModel.Set(this._rawData, "id", value); }
    }

    /// <summary>
    /// Current status of the transcription job
    /// </summary>
    public required ApiEnum<string, Status> Status
    {
        get { return JsonModel.GetNotNullClass<ApiEnum<string, Status>>(this.RawData, "status"); }
        init { JsonModel.Set(this._rawData, "status", value); }
    }

    /// <summary>
    /// Duration of the audio file in seconds
    /// </summary>
    public double? AudioDuration
    {
        get { return JsonModel.GetNullableStruct<double>(this.RawData, "audio_duration"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "audio_duration", value);
        }
    }

    /// <summary>
    /// Overall confidence score (0-100)
    /// </summary>
    public double? Confidence
    {
        get { return JsonModel.GetNullableStruct<double>(this.RawData, "confidence"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "confidence", value);
        }
    }

    /// <summary>
    /// Error message (only present when status is failed)
    /// </summary>
    public string? Error
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "error"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "error", value);
        }
    }

    /// <summary>
    /// Result transcript object ID (vault-based jobs, when completed)
    /// </summary>
    public string? ResultObjectID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "result_object_id"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "result_object_id", value);
        }
    }

    /// <summary>
    /// Source audio object ID (vault-based jobs only)
    /// </summary>
    public string? SourceObjectID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "source_object_id"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "source_object_id", value);
        }
    }

    /// <summary>
    /// Full transcription text (legacy direct URL jobs only)
    /// </summary>
    public string? Text
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "text"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "text", value);
        }
    }

    /// <summary>
    /// Vault ID (vault-based jobs only)
    /// </summary>
    public string? VaultID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "vault_id"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "vault_id", value);
        }
    }

    /// <summary>
    /// Number of words in the transcript
    /// </summary>
    public long? WordCount
    {
        get { return JsonModel.GetNullableStruct<long>(this.RawData, "word_count"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "word_count", value);
        }
    }

    /// <summary>
    /// Word-level timestamps (legacy direct URL jobs only)
    /// </summary>
    public IReadOnlyList<JsonElement>? Words
    {
        get { return JsonModel.GetNullableClass<List<JsonElement>>(this.RawData, "words"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "words", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Status.Validate();
        _ = this.AudioDuration;
        _ = this.Confidence;
        _ = this.Error;
        _ = this.ResultObjectID;
        _ = this.SourceObjectID;
        _ = this.Text;
        _ = this.VaultID;
        _ = this.WordCount;
        _ = this.Words;
    }

    public TranscriptionRetrieveResponse() { }

    public TranscriptionRetrieveResponse(
        TranscriptionRetrieveResponse transcriptionRetrieveResponse
    )
        : base(transcriptionRetrieveResponse) { }

    public TranscriptionRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TranscriptionRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TranscriptionRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static TranscriptionRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TranscriptionRetrieveResponseFromRaw : IFromRawJson<TranscriptionRetrieveResponse>
{
    /// <inheritdoc/>
    public TranscriptionRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TranscriptionRetrieveResponse.FromRawUnchecked(rawData);
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
            "queued" => Status.Queued,
            "processing" => Status.Processing,
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
                Status.Queued => "queued",
                Status.Processing => "processing",
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
