using System.Text.Json;
using CaseDev.Core;
using CaseDev.Exceptions;
using CaseDev.Models.Voice.V1.Speak;

namespace CaseDev.Tests.Models.Voice.V1.Speak;

public class SpeakStreamParamsModelIDTest : TestBase
{
    [Theory]
    [InlineData(SpeakStreamParamsModelID.ElevenMonolingualV1)]
    [InlineData(SpeakStreamParamsModelID.ElevenMultilingualV1)]
    [InlineData(SpeakStreamParamsModelID.ElevenMultilingualV2)]
    [InlineData(SpeakStreamParamsModelID.ElevenTurboV2)]
    public void Validation_Works(SpeakStreamParamsModelID rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SpeakStreamParamsModelID> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SpeakStreamParamsModelID>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SpeakStreamParamsModelID.ElevenMonolingualV1)]
    [InlineData(SpeakStreamParamsModelID.ElevenMultilingualV1)]
    [InlineData(SpeakStreamParamsModelID.ElevenMultilingualV2)]
    [InlineData(SpeakStreamParamsModelID.ElevenTurboV2)]
    public void SerializationRoundtrip_Works(SpeakStreamParamsModelID rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SpeakStreamParamsModelID> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SpeakStreamParamsModelID>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SpeakStreamParamsModelID>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SpeakStreamParamsModelID>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SpeakStreamParamsOutputFormatTest : TestBase
{
    [Theory]
    [InlineData(SpeakStreamParamsOutputFormat.MP3_44100_128)]
    [InlineData(SpeakStreamParamsOutputFormat.MP3_22050_32)]
    [InlineData(SpeakStreamParamsOutputFormat.Pcm16000)]
    [InlineData(SpeakStreamParamsOutputFormat.Pcm22050)]
    [InlineData(SpeakStreamParamsOutputFormat.Pcm24000)]
    [InlineData(SpeakStreamParamsOutputFormat.Pcm44100)]
    public void Validation_Works(SpeakStreamParamsOutputFormat rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SpeakStreamParamsOutputFormat> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SpeakStreamParamsOutputFormat>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SpeakStreamParamsOutputFormat.MP3_44100_128)]
    [InlineData(SpeakStreamParamsOutputFormat.MP3_22050_32)]
    [InlineData(SpeakStreamParamsOutputFormat.Pcm16000)]
    [InlineData(SpeakStreamParamsOutputFormat.Pcm22050)]
    [InlineData(SpeakStreamParamsOutputFormat.Pcm24000)]
    [InlineData(SpeakStreamParamsOutputFormat.Pcm44100)]
    public void SerializationRoundtrip_Works(SpeakStreamParamsOutputFormat rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SpeakStreamParamsOutputFormat> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SpeakStreamParamsOutputFormat>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SpeakStreamParamsOutputFormat>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SpeakStreamParamsOutputFormat>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SpeakStreamParamsVoiceSettingsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SpeakStreamParamsVoiceSettings
        {
            SimilarityBoost = 0,
            Stability = 0,
            Style = 0,
            UseSpeakerBoost = true,
        };

        double expectedSimilarityBoost = 0;
        double expectedStability = 0;
        double expectedStyle = 0;
        bool expectedUseSpeakerBoost = true;

        Assert.Equal(expectedSimilarityBoost, model.SimilarityBoost);
        Assert.Equal(expectedStability, model.Stability);
        Assert.Equal(expectedStyle, model.Style);
        Assert.Equal(expectedUseSpeakerBoost, model.UseSpeakerBoost);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SpeakStreamParamsVoiceSettings
        {
            SimilarityBoost = 0,
            Stability = 0,
            Style = 0,
            UseSpeakerBoost = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SpeakStreamParamsVoiceSettings>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SpeakStreamParamsVoiceSettings
        {
            SimilarityBoost = 0,
            Stability = 0,
            Style = 0,
            UseSpeakerBoost = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SpeakStreamParamsVoiceSettings>(json);
        Assert.NotNull(deserialized);

        double expectedSimilarityBoost = 0;
        double expectedStability = 0;
        double expectedStyle = 0;
        bool expectedUseSpeakerBoost = true;

        Assert.Equal(expectedSimilarityBoost, deserialized.SimilarityBoost);
        Assert.Equal(expectedStability, deserialized.Stability);
        Assert.Equal(expectedStyle, deserialized.Style);
        Assert.Equal(expectedUseSpeakerBoost, deserialized.UseSpeakerBoost);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SpeakStreamParamsVoiceSettings
        {
            SimilarityBoost = 0,
            Stability = 0,
            Style = 0,
            UseSpeakerBoost = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SpeakStreamParamsVoiceSettings { };

        Assert.Null(model.SimilarityBoost);
        Assert.False(model.RawData.ContainsKey("similarity_boost"));
        Assert.Null(model.Stability);
        Assert.False(model.RawData.ContainsKey("stability"));
        Assert.Null(model.Style);
        Assert.False(model.RawData.ContainsKey("style"));
        Assert.Null(model.UseSpeakerBoost);
        Assert.False(model.RawData.ContainsKey("use_speaker_boost"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SpeakStreamParamsVoiceSettings { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SpeakStreamParamsVoiceSettings
        {
            // Null should be interpreted as omitted for these properties
            SimilarityBoost = null,
            Stability = null,
            Style = null,
            UseSpeakerBoost = null,
        };

        Assert.Null(model.SimilarityBoost);
        Assert.False(model.RawData.ContainsKey("similarity_boost"));
        Assert.Null(model.Stability);
        Assert.False(model.RawData.ContainsKey("stability"));
        Assert.Null(model.Style);
        Assert.False(model.RawData.ContainsKey("style"));
        Assert.Null(model.UseSpeakerBoost);
        Assert.False(model.RawData.ContainsKey("use_speaker_boost"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SpeakStreamParamsVoiceSettings
        {
            // Null should be interpreted as omitted for these properties
            SimilarityBoost = null,
            Stability = null,
            Style = null,
            UseSpeakerBoost = null,
        };

        model.Validate();
    }
}
