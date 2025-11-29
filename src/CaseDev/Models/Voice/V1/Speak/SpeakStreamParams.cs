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
        get
        {
            if (!this._rawBodyData.TryGetValue("text", out JsonElement element))
                throw new CasedevInvalidDataException(
                    "'text' cannot be null",
                    new ArgumentOutOfRangeException("text", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CasedevInvalidDataException(
                    "'text' cannot be null",
                    new ArgumentNullException("text")
                );
        }
        init
        {
            this._rawBodyData["text"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Apply text normalization
    /// </summary>
    public bool? ApplyTextNormalization
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("apply_text_normalization", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData["apply_text_normalization"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Enable request logging
    /// </summary>
    public bool? EnableLogging
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("enable_logging", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData["enable_logging"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Language code (e.g., 'en', 'es', 'fr')
    /// </summary>
    public string? LanguageCode
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("language_code", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData["language_code"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// TTS model to use
    /// </summary>
    public ApiEnum<string, ModelIDModel>? ModelID
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("model_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, ModelIDModel>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData["model_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Next text for context
    /// </summary>
    public string? NextText
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("next_text", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData["next_text"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Optimize for streaming latency (0-4)
    /// </summary>
    public long? OptimizeStreamingLatency
    {
        get
        {
            if (
                !this._rawBodyData.TryGetValue(
                    "optimize_streaming_latency",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData["optimize_streaming_latency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Audio output format
    /// </summary>
    public ApiEnum<string, OutputFormatModel>? OutputFormat
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("output_format", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, OutputFormatModel>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData["output_format"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Previous text for context
    /// </summary>
    public string? PreviousText
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("previous_text", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData["previous_text"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Random seed for reproducible generation
    /// </summary>
    public long? Seed
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("seed", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData["seed"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// ElevenLabs voice ID (defaults to Rachel for professional clarity)
    /// </summary>
    public string? VoiceID
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("voice_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData["voice_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public VoiceSettingsModel? VoiceSettings
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("voice_settings", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<VoiceSettingsModel?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData["voice_settings"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
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
[JsonConverter(typeof(ModelIDModelConverter))]
public enum ModelIDModel
{
    ElevenMonolingualV1,
    ElevenMultilingualV1,
    ElevenMultilingualV2,
    ElevenTurboV2,
}

sealed class ModelIDModelConverter : JsonConverter<ModelIDModel>
{
    public override ModelIDModel Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "eleven_monolingual_v1" => ModelIDModel.ElevenMonolingualV1,
            "eleven_multilingual_v1" => ModelIDModel.ElevenMultilingualV1,
            "eleven_multilingual_v2" => ModelIDModel.ElevenMultilingualV2,
            "eleven_turbo_v2" => ModelIDModel.ElevenTurboV2,
            _ => (ModelIDModel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ModelIDModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ModelIDModel.ElevenMonolingualV1 => "eleven_monolingual_v1",
                ModelIDModel.ElevenMultilingualV1 => "eleven_multilingual_v1",
                ModelIDModel.ElevenMultilingualV2 => "eleven_multilingual_v2",
                ModelIDModel.ElevenTurboV2 => "eleven_turbo_v2",
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
[JsonConverter(typeof(OutputFormatModelConverter))]
public enum OutputFormatModel
{
    MP3_44100_128,
    MP3_22050_32,
    Pcm16000,
    Pcm22050,
    Pcm24000,
    Pcm44100,
}

sealed class OutputFormatModelConverter : JsonConverter<OutputFormatModel>
{
    public override OutputFormatModel Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "mp3_44100_128" => OutputFormatModel.MP3_44100_128,
            "mp3_22050_32" => OutputFormatModel.MP3_22050_32,
            "pcm_16000" => OutputFormatModel.Pcm16000,
            "pcm_22050" => OutputFormatModel.Pcm22050,
            "pcm_24000" => OutputFormatModel.Pcm24000,
            "pcm_44100" => OutputFormatModel.Pcm44100,
            _ => (OutputFormatModel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        OutputFormatModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                OutputFormatModel.MP3_44100_128 => "mp3_44100_128",
                OutputFormatModel.MP3_22050_32 => "mp3_22050_32",
                OutputFormatModel.Pcm16000 => "pcm_16000",
                OutputFormatModel.Pcm22050 => "pcm_22050",
                OutputFormatModel.Pcm24000 => "pcm_24000",
                OutputFormatModel.Pcm44100 => "pcm_44100",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ModelConverter<VoiceSettingsModel, VoiceSettingsModelFromRaw>))]
public sealed record class VoiceSettingsModel : ModelBase
{
    /// <summary>
    /// Similarity boost (0-1)
    /// </summary>
    public double? SimilarityBoost
    {
        get
        {
            if (!this._rawData.TryGetValue("similarity_boost", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["similarity_boost"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Voice stability (0-1)
    /// </summary>
    public double? Stability
    {
        get
        {
            if (!this._rawData.TryGetValue("stability", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["stability"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Style exaggeration (0-1)
    /// </summary>
    public double? Style
    {
        get
        {
            if (!this._rawData.TryGetValue("style", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["style"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Enable speaker boost
    /// </summary>
    public bool? UseSpeakerBoost
    {
        get
        {
            if (!this._rawData.TryGetValue("use_speaker_boost", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["use_speaker_boost"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.SimilarityBoost;
        _ = this.Stability;
        _ = this.Style;
        _ = this.UseSpeakerBoost;
    }

    public VoiceSettingsModel() { }

    public VoiceSettingsModel(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VoiceSettingsModel(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static VoiceSettingsModel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VoiceSettingsModelFromRaw : IFromRaw<VoiceSettingsModel>
{
    public VoiceSettingsModel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        VoiceSettingsModel.FromRawUnchecked(rawData);
}
