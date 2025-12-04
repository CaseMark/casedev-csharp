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

namespace CaseDev.Models.Voice.V1.Speak;

/// <summary>
/// Convert text to speech using ElevenLabs AI voices with streaming for real-time
/// playback. Returns audio data as an MP3 stream for immediate playback with minimal
/// latency. Perfect for legal document narration, client presentations, or accessibility features.
/// </summary>
public sealed record class SpeakStreamParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Text to convert to speech
    /// </summary>
    public required string Text
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawBodyData, "text"); }
        init { ModelBase.Set(this._rawBodyData, "text", value); }
    }

    /// <summary>
    /// Apply text normalization
    /// </summary>
    public bool? ApplyTextNormalization
    {
        get
        {
            return ModelBase.GetNullableStruct<bool>(this.RawBodyData, "apply_text_normalization");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "apply_text_normalization", value);
        }
    }

    /// <summary>
    /// Enable request logging
    /// </summary>
    public bool? EnableLogging
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawBodyData, "enable_logging"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "enable_logging", value);
        }
    }

    /// <summary>
    /// Language code (e.g., 'en', 'es', 'fr')
    /// </summary>
    public string? LanguageCode
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "language_code"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "language_code", value);
        }
    }

    /// <summary>
    /// TTS model to use
    /// </summary>
    public ApiEnum<string, SpeakStreamParamsModelID>? ModelID
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<string, SpeakStreamParamsModelID>>(
                this.RawBodyData,
                "model_id"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "model_id", value);
        }
    }

    /// <summary>
    /// Next text for context
    /// </summary>
    public string? NextText
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "next_text"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "next_text", value);
        }
    }

    /// <summary>
    /// Optimize for streaming latency (0-4)
    /// </summary>
    public long? OptimizeStreamingLatency
    {
        get
        {
            return ModelBase.GetNullableStruct<long>(
                this.RawBodyData,
                "optimize_streaming_latency"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "optimize_streaming_latency", value);
        }
    }

    /// <summary>
    /// Audio output format
    /// </summary>
    public ApiEnum<string, SpeakStreamParamsOutputFormat>? OutputFormat
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<string, SpeakStreamParamsOutputFormat>>(
                this.RawBodyData,
                "output_format"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "output_format", value);
        }
    }

    /// <summary>
    /// Previous text for context
    /// </summary>
    public string? PreviousText
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "previous_text"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "previous_text", value);
        }
    }

    /// <summary>
    /// Random seed for reproducible generation
    /// </summary>
    public long? Seed
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawBodyData, "seed"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "seed", value);
        }
    }

    /// <summary>
    /// ElevenLabs voice ID (defaults to Rachel for professional clarity)
    /// </summary>
    public string? VoiceID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "voice_id"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "voice_id", value);
        }
    }

    public SpeakStreamParamsVoiceSettings? VoiceSettings
    {
        get
        {
            return ModelBase.GetNullableClass<SpeakStreamParamsVoiceSettings>(
                this.RawBodyData,
                "voice_settings"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "voice_settings", value);
        }
    }

    public SpeakStreamParams() { }

    public SpeakStreamParams(
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
    SpeakStreamParams(
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

    public static SpeakStreamParams FromRawUnchecked(
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/voice/v1/speak/stream")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override StringContent? BodyContent()
    {
        return new(JsonSerializer.Serialize(this.RawBodyData), Encoding.UTF8, "application/json");
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
/// TTS model to use
/// </summary>
[JsonConverter(typeof(SpeakStreamParamsModelIDConverter))]
public enum SpeakStreamParamsModelID
{
    ElevenMonolingualV1,
    ElevenMultilingualV1,
    ElevenMultilingualV2,
    ElevenTurboV2,
}

sealed class SpeakStreamParamsModelIDConverter : JsonConverter<SpeakStreamParamsModelID>
{
    public override SpeakStreamParamsModelID Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "eleven_monolingual_v1" => SpeakStreamParamsModelID.ElevenMonolingualV1,
            "eleven_multilingual_v1" => SpeakStreamParamsModelID.ElevenMultilingualV1,
            "eleven_multilingual_v2" => SpeakStreamParamsModelID.ElevenMultilingualV2,
            "eleven_turbo_v2" => SpeakStreamParamsModelID.ElevenTurboV2,
            _ => (SpeakStreamParamsModelID)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SpeakStreamParamsModelID value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SpeakStreamParamsModelID.ElevenMonolingualV1 => "eleven_monolingual_v1",
                SpeakStreamParamsModelID.ElevenMultilingualV1 => "eleven_multilingual_v1",
                SpeakStreamParamsModelID.ElevenMultilingualV2 => "eleven_multilingual_v2",
                SpeakStreamParamsModelID.ElevenTurboV2 => "eleven_turbo_v2",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Audio output format
/// </summary>
[JsonConverter(typeof(SpeakStreamParamsOutputFormatConverter))]
public enum SpeakStreamParamsOutputFormat
{
    MP3_44100_128,
    MP3_22050_32,
    Pcm16000,
    Pcm22050,
    Pcm24000,
    Pcm44100,
}

sealed class SpeakStreamParamsOutputFormatConverter : JsonConverter<SpeakStreamParamsOutputFormat>
{
    public override SpeakStreamParamsOutputFormat Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "mp3_44100_128" => SpeakStreamParamsOutputFormat.MP3_44100_128,
            "mp3_22050_32" => SpeakStreamParamsOutputFormat.MP3_22050_32,
            "pcm_16000" => SpeakStreamParamsOutputFormat.Pcm16000,
            "pcm_22050" => SpeakStreamParamsOutputFormat.Pcm22050,
            "pcm_24000" => SpeakStreamParamsOutputFormat.Pcm24000,
            "pcm_44100" => SpeakStreamParamsOutputFormat.Pcm44100,
            _ => (SpeakStreamParamsOutputFormat)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SpeakStreamParamsOutputFormat value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SpeakStreamParamsOutputFormat.MP3_44100_128 => "mp3_44100_128",
                SpeakStreamParamsOutputFormat.MP3_22050_32 => "mp3_22050_32",
                SpeakStreamParamsOutputFormat.Pcm16000 => "pcm_16000",
                SpeakStreamParamsOutputFormat.Pcm22050 => "pcm_22050",
                SpeakStreamParamsOutputFormat.Pcm24000 => "pcm_24000",
                SpeakStreamParamsOutputFormat.Pcm44100 => "pcm_44100",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(ModelConverter<SpeakStreamParamsVoiceSettings, SpeakStreamParamsVoiceSettingsFromRaw>)
)]
public sealed record class SpeakStreamParamsVoiceSettings : ModelBase
{
    /// <summary>
    /// Similarity boost (0-1)
    /// </summary>
    public double? SimilarityBoost
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawData, "similarity_boost"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "similarity_boost", value);
        }
    }

    /// <summary>
    /// Voice stability (0-1)
    /// </summary>
    public double? Stability
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawData, "stability"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "stability", value);
        }
    }

    /// <summary>
    /// Style exaggeration (0-1)
    /// </summary>
    public double? Style
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawData, "style"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "style", value);
        }
    }

    /// <summary>
    /// Enable speaker boost
    /// </summary>
    public bool? UseSpeakerBoost
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "use_speaker_boost"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "use_speaker_boost", value);
        }
    }

    public override void Validate()
    {
        _ = this.SimilarityBoost;
        _ = this.Stability;
        _ = this.Style;
        _ = this.UseSpeakerBoost;
    }

    public SpeakStreamParamsVoiceSettings() { }

    public SpeakStreamParamsVoiceSettings(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SpeakStreamParamsVoiceSettings(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static SpeakStreamParamsVoiceSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SpeakStreamParamsVoiceSettingsFromRaw : IFromRaw<SpeakStreamParamsVoiceSettings>
{
    public SpeakStreamParamsVoiceSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SpeakStreamParamsVoiceSettings.FromRawUnchecked(rawData);
}
