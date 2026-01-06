using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;
using CaseDev.Exceptions;

namespace CaseDev.Models.Voice.Transcription;

/// <summary>
/// Creates an asynchronous transcription job for audio files. Supports two modes:
///
/// <para>**Vault-based (recommended)**: Pass `vault_id` and `object_id` to transcribe
/// audio from your vault. The transcript will automatically be saved back to the
/// vault when complete.</para>
///
/// <para>**Direct URL (legacy)**: Pass `audio_url` for direct transcription without
/// automatic storage.</para>
/// </summary>
public sealed record class TranscriptionCreateParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// URL of the audio file to transcribe (legacy mode, no auto-storage)
    /// </summary>
    public string? AudioUrl
    {
        get { return JsonModel.GetNullableClass<string>(this.RawBodyData, "audio_url"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawBodyData, "audio_url", value);
        }
    }

    /// <summary>
    /// Automatically extract key phrases and topics
    /// </summary>
    public bool? AutoHighlights
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawBodyData, "auto_highlights"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawBodyData, "auto_highlights", value);
        }
    }

    /// <summary>
    /// How much to boost custom vocabulary
    /// </summary>
    public ApiEnum<string, BoostParam>? BoostParam
    {
        get
        {
            return JsonModel.GetNullableClass<ApiEnum<string, BoostParam>>(
                this.RawBodyData,
                "boost_param"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawBodyData, "boost_param", value);
        }
    }

    /// <summary>
    /// Enable content moderation and safety labeling
    /// </summary>
    public bool? ContentSafetyLabels
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawBodyData, "content_safety_labels"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawBodyData, "content_safety_labels", value);
        }
    }

    /// <summary>
    /// Output format for the transcript when using vault mode
    /// </summary>
    public ApiEnum<string, TranscriptionCreateParamsFormat>? Format
    {
        get
        {
            return JsonModel.GetNullableClass<ApiEnum<string, TranscriptionCreateParamsFormat>>(
                this.RawBodyData,
                "format"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawBodyData, "format", value);
        }
    }

    /// <summary>
    /// Format text with proper capitalization
    /// </summary>
    public bool? FormatText
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawBodyData, "format_text"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawBodyData, "format_text", value);
        }
    }

    /// <summary>
    /// Language code (e.g., 'en_us', 'es', 'fr'). If not specified, language will
    /// be auto-detected
    /// </summary>
    public string? LanguageCode
    {
        get { return JsonModel.GetNullableClass<string>(this.RawBodyData, "language_code"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawBodyData, "language_code", value);
        }
    }

    /// <summary>
    /// Enable automatic language detection
    /// </summary>
    public bool? LanguageDetection
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawBodyData, "language_detection"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawBodyData, "language_detection", value);
        }
    }

    /// <summary>
    /// Object ID of the audio file in the vault (use with vault_id)
    /// </summary>
    public string? ObjectID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawBodyData, "object_id"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawBodyData, "object_id", value);
        }
    }

    /// <summary>
    /// Add punctuation to the transcript
    /// </summary>
    public bool? Punctuate
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawBodyData, "punctuate"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawBodyData, "punctuate", value);
        }
    }

    /// <summary>
    /// Enable speaker identification and labeling
    /// </summary>
    public bool? SpeakerLabels
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawBodyData, "speaker_labels"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawBodyData, "speaker_labels", value);
        }
    }

    /// <summary>
    /// Expected number of speakers (improves accuracy when known)
    /// </summary>
    public long? SpeakersExpected
    {
        get { return JsonModel.GetNullableStruct<long>(this.RawBodyData, "speakers_expected"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawBodyData, "speakers_expected", value);
        }
    }

    /// <summary>
    /// Vault ID containing the audio file (use with object_id)
    /// </summary>
    public string? VaultID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawBodyData, "vault_id"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawBodyData, "vault_id", value);
        }
    }

    /// <summary>
    /// Custom vocabulary words to boost (e.g., legal terms)
    /// </summary>
    public IReadOnlyList<string>? WordBoost
    {
        get { return JsonModel.GetNullableClass<List<string>>(this.RawBodyData, "word_boost"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawBodyData, "word_boost", value);
        }
    }

    public TranscriptionCreateParams() { }

    public TranscriptionCreateParams(TranscriptionCreateParams transcriptionCreateParams)
        : base(transcriptionCreateParams)
    {
        this._rawBodyData = [.. transcriptionCreateParams._rawBodyData];
    }

    public TranscriptionCreateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TranscriptionCreateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static TranscriptionCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/voice/transcription")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}

/// <summary>
/// How much to boost custom vocabulary
/// </summary>
[JsonConverter(typeof(BoostParamConverter))]
public enum BoostParam
{
    Low,
    Default,
    High,
}

sealed class BoostParamConverter : JsonConverter<BoostParam>
{
    public override BoostParam Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "low" => BoostParam.Low,
            "default" => BoostParam.Default,
            "high" => BoostParam.High,
            _ => (BoostParam)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BoostParam value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BoostParam.Low => "low",
                BoostParam.Default => "default",
                BoostParam.High => "high",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Output format for the transcript when using vault mode
/// </summary>
[JsonConverter(typeof(TranscriptionCreateParamsFormatConverter))]
public enum TranscriptionCreateParamsFormat
{
    Json,
    Text,
}

sealed class TranscriptionCreateParamsFormatConverter
    : JsonConverter<TranscriptionCreateParamsFormat>
{
    public override TranscriptionCreateParamsFormat Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "json" => TranscriptionCreateParamsFormat.Json,
            "text" => TranscriptionCreateParamsFormat.Text,
            _ => (TranscriptionCreateParamsFormat)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TranscriptionCreateParamsFormat value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TranscriptionCreateParamsFormat.Json => "json",
                TranscriptionCreateParamsFormat.Text => "text",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
