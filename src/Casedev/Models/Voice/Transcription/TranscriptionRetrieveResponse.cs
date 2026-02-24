using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Casedev.Core;
using Casedev.Exceptions;

namespace Casedev.Models.Voice.Transcription;

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
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Current status of the transcription job
    /// </summary>
    public required ApiEnum<string, TranscriptionRetrieveResponseStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, TranscriptionRetrieveResponseStatus>
            >("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Duration of the audio file in seconds
    /// </summary>
    public double? AudioDuration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("audio_duration");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("audio_duration", value);
        }
    }

    /// <summary>
    /// Overall confidence score (0-100)
    /// </summary>
    public double? Confidence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("confidence");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("confidence", value);
        }
    }

    /// <summary>
    /// Error message (only present when status is failed)
    /// </summary>
    public string? Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("error");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("error", value);
        }
    }

    /// <summary>
    /// Result transcript object ID (vault-based jobs, when completed)
    /// </summary>
    public string? ResultObjectID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("result_object_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("result_object_id", value);
        }
    }

    /// <summary>
    /// Source audio object ID (vault-based jobs only)
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
    /// Full transcription text (legacy direct URL jobs only)
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

    /// <summary>
    /// Vault ID (vault-based jobs only)
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

    /// <summary>
    /// Number of words in the transcript
    /// </summary>
    public long? WordCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("word_count");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("word_count", value);
        }
    }

    /// <summary>
    /// Word-level timestamps (legacy direct URL jobs only)
    /// </summary>
    public IReadOnlyList<JsonElement>? Words
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<JsonElement>>("words");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<JsonElement>?>(
                "words",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TranscriptionRetrieveResponse(
        TranscriptionRetrieveResponse transcriptionRetrieveResponse
    )
        : base(transcriptionRetrieveResponse) { }
#pragma warning restore CS8618

    public TranscriptionRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TranscriptionRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
[JsonConverter(typeof(TranscriptionRetrieveResponseStatusConverter))]
public enum TranscriptionRetrieveResponseStatus
{
    Queued,
    Processing,
    Completed,
    Failed,
}

sealed class TranscriptionRetrieveResponseStatusConverter
    : JsonConverter<TranscriptionRetrieveResponseStatus>
{
    public override TranscriptionRetrieveResponseStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "queued" => TranscriptionRetrieveResponseStatus.Queued,
            "processing" => TranscriptionRetrieveResponseStatus.Processing,
            "completed" => TranscriptionRetrieveResponseStatus.Completed,
            "failed" => TranscriptionRetrieveResponseStatus.Failed,
            _ => (TranscriptionRetrieveResponseStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TranscriptionRetrieveResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TranscriptionRetrieveResponseStatus.Queued => "queued",
                TranscriptionRetrieveResponseStatus.Processing => "processing",
                TranscriptionRetrieveResponseStatus.Completed => "completed",
                TranscriptionRetrieveResponseStatus.Failed => "failed",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
