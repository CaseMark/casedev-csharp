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
/// Convert text to natural-sounding audio using ElevenLabs voices. Ideal for creating
/// audio summaries of legal documents, client presentations, or accessibility features.
/// Supports multiple languages and voice customization.
/// </summary>
public sealed record class SpeakCreateParams : ParamsBase
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
    /// Apply automatic text normalization
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
    /// Language code for multilingual models
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
    /// ElevenLabs model ID
    /// </summary>
    public ApiEnum<string, ModelID>? ModelID
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("model_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, ModelID>?>(
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
    /// Next context for better pronunciation
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
    public ApiEnum<string, OutputFormat>? OutputFormat
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("output_format", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, OutputFormat>?>(
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
    /// Previous context for better pronunciation
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
    /// Seed for reproducible generation
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
    /// ElevenLabs voice ID (defaults to Rachel - professional, clear)
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

    /// <summary>
    /// Voice customization settings
    /// </summary>
    public VoiceSettings? VoiceSettings
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("voice_settings", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<VoiceSettings?>(element, ModelBase.SerializerOptions);
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

    public SpeakCreateParams() { }

    public SpeakCreateParams(
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
    SpeakCreateParams(
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

    public static SpeakCreateParams FromRawUnchecked(
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/voice/v1/speak")
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
/// ElevenLabs model ID
/// </summary>
[JsonConverter(typeof(ModelIDConverter))]
public enum ModelID
{
    ElevenMultilingualV2,
    ElevenTurboV2,
    ElevenMonolingualV1,
}

sealed class ModelIDConverter : JsonConverter<ModelID>
{
    public override ModelID Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "eleven_multilingual_v2" => ModelID.ElevenMultilingualV2,
            "eleven_turbo_v2" => ModelID.ElevenTurboV2,
            "eleven_monolingual_v1" => ModelID.ElevenMonolingualV1,
            _ => (ModelID)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, ModelID value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ModelID.ElevenMultilingualV2 => "eleven_multilingual_v2",
                ModelID.ElevenTurboV2 => "eleven_turbo_v2",
                ModelID.ElevenMonolingualV1 => "eleven_monolingual_v1",
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
[JsonConverter(typeof(OutputFormatConverter))]
public enum OutputFormat
{
    MP3_44100_128,
    MP3_44100_192,
    Pcm16000,
    Pcm22050,
    Pcm24000,
    Pcm44100,
}

sealed class OutputFormatConverter : JsonConverter<OutputFormat>
{
    public override OutputFormat Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "mp3_44100_128" => OutputFormat.MP3_44100_128,
            "mp3_44100_192" => OutputFormat.MP3_44100_192,
            "pcm_16000" => OutputFormat.Pcm16000,
            "pcm_22050" => OutputFormat.Pcm22050,
            "pcm_24000" => OutputFormat.Pcm24000,
            "pcm_44100" => OutputFormat.Pcm44100,
            _ => (OutputFormat)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        OutputFormat value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                OutputFormat.MP3_44100_128 => "mp3_44100_128",
                OutputFormat.MP3_44100_192 => "mp3_44100_192",
                OutputFormat.Pcm16000 => "pcm_16000",
                OutputFormat.Pcm22050 => "pcm_22050",
                OutputFormat.Pcm24000 => "pcm_24000",
                OutputFormat.Pcm44100 => "pcm_44100",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Voice customization settings
/// </summary>
[JsonConverter(typeof(ModelConverter<VoiceSettings, VoiceSettingsFromRaw>))]
public sealed record class VoiceSettings : ModelBase
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

    public VoiceSettings() { }

    public VoiceSettings(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VoiceSettings(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static VoiceSettings FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VoiceSettingsFromRaw : IFromRaw<VoiceSettings>
{
    public VoiceSettings FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        VoiceSettings.FromRawUnchecked(rawData);
}
