using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using CaseDev.Core;

namespace CaseDev.Models.Voice.Transcription;

/// <summary>
/// Creates an asynchronous transcription job for audio files. Supports various audio
/// formats and advanced features like speaker identification, content moderation,
/// and automatic highlights. Returns a job ID for checking transcription status and
/// retrieving results.
/// </summary>
public sealed record class TranscriptionCreateParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// URL of the audio file to transcribe
    /// </summary>
    public required string AudioURL
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawBodyData, "audio_url"); }
        init { ModelBase.Set(this._rawBodyData, "audio_url", value); }
    }

    /// <summary>
    /// Automatically extract key phrases and topics
    /// </summary>
    public bool? AutoHighlights
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawBodyData, "auto_highlights"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "auto_highlights", value);
        }
    }

    /// <summary>
    /// Enable content moderation and safety labeling
    /// </summary>
    public bool? ContentSafetyLabels
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawBodyData, "content_safety_labels"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "content_safety_labels", value);
        }
    }

    /// <summary>
    /// Format text with proper capitalization
    /// </summary>
    public bool? FormatText
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawBodyData, "format_text"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "format_text", value);
        }
    }

    /// <summary>
    /// Language code (e.g., 'en_us', 'es', 'fr'). If not specified, language will
    /// be auto-detected
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
    /// Enable automatic language detection
    /// </summary>
    public bool? LanguageDetection
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawBodyData, "language_detection"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "language_detection", value);
        }
    }

    /// <summary>
    /// Add punctuation to the transcript
    /// </summary>
    public bool? Punctuate
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawBodyData, "punctuate"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "punctuate", value);
        }
    }

    /// <summary>
    /// Enable speaker identification and labeling
    /// </summary>
    public bool? SpeakerLabels
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawBodyData, "speaker_labels"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "speaker_labels", value);
        }
    }

    public TranscriptionCreateParams() { }

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
