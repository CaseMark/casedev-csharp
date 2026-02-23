using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Router.Core;
using Router.Exceptions;

namespace Router.Models.Voice.V1.Speak;

/// <summary>
/// Convert text to natural-sounding audio using ElevenLabs voices. Ideal for creating
/// audio summaries of legal documents, client presentations, or accessibility features.
/// Supports multiple languages and voice customization.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class SpeakCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("text");
        }
        init { this._rawBodyData.Set("text", value); }
    }

    /// <summary>
    /// Apply automatic text normalization
    /// </summary>
    public bool? ApplyTextNormalization
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("apply_text_normalization");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("apply_text_normalization", value);
        }
    }

    /// <summary>
    /// Enable request logging
    /// </summary>
    public bool? EnableLogging
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("enable_logging");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("enable_logging", value);
        }
    }

    /// <summary>
    /// Language code for multilingual models
    /// </summary>
    public string? LanguageCode
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("language_code");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("language_code", value);
        }
    }

    /// <summary>
    /// ElevenLabs model ID
    /// </summary>
    public ApiEnum<string, ModelID>? ModelID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, ModelID>>("model_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("model_id", value);
        }
    }

    /// <summary>
    /// Next context for better pronunciation
    /// </summary>
    public string? NextText
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("next_text");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("next_text", value);
        }
    }

    /// <summary>
    /// Optimize for streaming latency (0-4)
    /// </summary>
    public long? OptimizeStreamingLatency
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("optimize_streaming_latency");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("optimize_streaming_latency", value);
        }
    }

    /// <summary>
    /// Audio output format
    /// </summary>
    public ApiEnum<string, OutputFormat>? OutputFormat
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, OutputFormat>>(
                "output_format"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("output_format", value);
        }
    }

    /// <summary>
    /// Previous context for better pronunciation
    /// </summary>
    public string? PreviousText
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("previous_text");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("previous_text", value);
        }
    }

    /// <summary>
    /// Seed for reproducible generation
    /// </summary>
    public long? Seed
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("seed");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("seed", value);
        }
    }

    /// <summary>
    /// ElevenLabs voice ID (defaults to Rachel - professional, clear)
    /// </summary>
    public string? VoiceID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("voice_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("voice_id", value);
        }
    }

    /// <summary>
    /// Voice customization settings
    /// </summary>
    public VoiceSettings? VoiceSettings
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<VoiceSettings>("voice_settings");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("voice_settings", value);
        }
    }

    public SpeakCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SpeakCreateParams(SpeakCreateParams speakCreateParams)
        : base(speakCreateParams)
    {
        this._rawBodyData = new(speakCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public SpeakCreateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SpeakCreateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
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

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(SpeakCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/voice/v1/speak")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
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

    public override int GetHashCode()
    {
        return 0;
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
    Mp3_44100_128,
    Mp3_44100_192,
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
            "mp3_44100_128" => OutputFormat.Mp3_44100_128,
            "mp3_44100_192" => OutputFormat.Mp3_44100_192,
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
                OutputFormat.Mp3_44100_128 => "mp3_44100_128",
                OutputFormat.Mp3_44100_192 => "mp3_44100_192",
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
[JsonConverter(typeof(JsonModelConverter<VoiceSettings, VoiceSettingsFromRaw>))]
public sealed record class VoiceSettings : JsonModel
{
    /// <summary>
    /// Similarity boost (0-1)
    /// </summary>
    public double? SimilarityBoost
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("similarity_boost");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("similarity_boost", value);
        }
    }

    /// <summary>
    /// Voice stability (0-1)
    /// </summary>
    public double? Stability
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("stability");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("stability", value);
        }
    }

    /// <summary>
    /// Style exaggeration (0-1)
    /// </summary>
    public double? Style
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("style");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("style", value);
        }
    }

    /// <summary>
    /// Enable speaker boost
    /// </summary>
    public bool? UseSpeakerBoost
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("use_speaker_boost");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("use_speaker_boost", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.SimilarityBoost;
        _ = this.Stability;
        _ = this.Style;
        _ = this.UseSpeakerBoost;
    }

    public VoiceSettings() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VoiceSettings(VoiceSettings voiceSettings)
        : base(voiceSettings) { }
#pragma warning restore CS8618

    public VoiceSettings(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VoiceSettings(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VoiceSettingsFromRaw.FromRawUnchecked"/>
    public static VoiceSettings FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VoiceSettingsFromRaw : IFromRawJson<VoiceSettings>
{
    /// <inheritdoc/>
    public VoiceSettings FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        VoiceSettings.FromRawUnchecked(rawData);
}
