using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Router.Core;

namespace Router.Models.Voice.Streaming;

[JsonConverter(typeof(JsonModelConverter<StreamingGetUrlResponse, StreamingGetUrlResponseFromRaw>))]
public sealed record class StreamingGetUrlResponse : JsonModel
{
    public AudioFormat? AudioFormat
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AudioFormat>("audio_format");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("audio_format", value);
        }
    }

    /// <summary>
    /// Complete WebSocket URL with authentication token
    /// </summary>
    public string? ConnectUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("connect_url");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("connect_url", value);
        }
    }

    public Pricing? Pricing
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Pricing>("pricing");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("pricing", value);
        }
    }

    /// <summary>
    /// Connection protocol
    /// </summary>
    public string? Protocol
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("protocol");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("protocol", value);
        }
    }

    /// <summary>
    /// Base WebSocket URL for streaming transcription
    /// </summary>
    public string? Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("url");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("url", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.AudioFormat?.Validate();
        _ = this.ConnectUrl;
        this.Pricing?.Validate();
        _ = this.Protocol;
        _ = this.Url;
    }

    public StreamingGetUrlResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public StreamingGetUrlResponse(StreamingGetUrlResponse streamingGetUrlResponse)
        : base(streamingGetUrlResponse) { }
#pragma warning restore CS8618

    public StreamingGetUrlResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    StreamingGetUrlResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="StreamingGetUrlResponseFromRaw.FromRawUnchecked"/>
    public static StreamingGetUrlResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class StreamingGetUrlResponseFromRaw : IFromRawJson<StreamingGetUrlResponse>
{
    /// <inheritdoc/>
    public StreamingGetUrlResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => StreamingGetUrlResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<AudioFormat, AudioFormatFromRaw>))]
public sealed record class AudioFormat : JsonModel
{
    /// <summary>
    /// Number of audio channels
    /// </summary>
    public long? Channels
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("channels");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("channels", value);
        }
    }

    /// <summary>
    /// Required audio encoding format
    /// </summary>
    public string? Encoding
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("encoding");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("encoding", value);
        }
    }

    /// <summary>
    /// Required audio sample rate in Hz
    /// </summary>
    public long? SampleRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("sample_rate");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("sample_rate", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Channels;
        _ = this.Encoding;
        _ = this.SampleRate;
    }

    public AudioFormat() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AudioFormat(AudioFormat audioFormat)
        : base(audioFormat) { }
#pragma warning restore CS8618

    public AudioFormat(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AudioFormat(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AudioFormatFromRaw.FromRawUnchecked"/>
    public static AudioFormat FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AudioFormatFromRaw : IFromRawJson<AudioFormat>
{
    /// <inheritdoc/>
    public AudioFormat FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AudioFormat.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Pricing, PricingFromRaw>))]
public sealed record class Pricing : JsonModel
{
    /// <summary>
    /// Currency for pricing
    /// </summary>
    public string? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("currency");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("currency", value);
        }
    }

    /// <summary>
    /// Cost per hour of transcription
    /// </summary>
    public double? PerHour
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("per_hour");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("per_hour", value);
        }
    }

    /// <summary>
    /// Cost per minute of transcription
    /// </summary>
    public double? PerMinute
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("per_minute");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("per_minute", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Currency;
        _ = this.PerHour;
        _ = this.PerMinute;
    }

    public Pricing() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Pricing(Pricing pricing)
        : base(pricing) { }
#pragma warning restore CS8618

    public Pricing(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Pricing(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PricingFromRaw.FromRawUnchecked"/>
    public static Pricing FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PricingFromRaw : IFromRawJson<Pricing>
{
    /// <inheritdoc/>
    public Pricing FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Pricing.FromRawUnchecked(rawData);
}
