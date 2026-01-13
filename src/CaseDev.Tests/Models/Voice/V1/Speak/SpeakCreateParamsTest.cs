using System;
using System.Text.Json;
using CaseDev.Core;
using CaseDev.Exceptions;
using CaseDev.Models.Voice.V1.Speak;

namespace CaseDev.Tests.Models.Voice.V1.Speak;

public class SpeakCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SpeakCreateParams
        {
            Text = "text",
            ApplyTextNormalization = true,
            EnableLogging = true,
            LanguageCode = "en",
            ModelID = ModelID.ElevenMultilingualV2,
            NextText = "next_text",
            OptimizeStreamingLatency = 0,
            OutputFormat = OutputFormat.Mp3_44100_128,
            PreviousText = "previous_text",
            Seed = 0,
            VoiceID = "voice_id",
            VoiceSettings = new()
            {
                SimilarityBoost = 0,
                Stability = 0,
                Style = 0,
                UseSpeakerBoost = true,
            },
        };

        string expectedText = "text";
        bool expectedApplyTextNormalization = true;
        bool expectedEnableLogging = true;
        string expectedLanguageCode = "en";
        ApiEnum<string, ModelID> expectedModelID = ModelID.ElevenMultilingualV2;
        string expectedNextText = "next_text";
        long expectedOptimizeStreamingLatency = 0;
        ApiEnum<string, OutputFormat> expectedOutputFormat = OutputFormat.Mp3_44100_128;
        string expectedPreviousText = "previous_text";
        long expectedSeed = 0;
        string expectedVoiceID = "voice_id";
        VoiceSettings expectedVoiceSettings = new()
        {
            SimilarityBoost = 0,
            Stability = 0,
            Style = 0,
            UseSpeakerBoost = true,
        };

        Assert.Equal(expectedText, parameters.Text);
        Assert.Equal(expectedApplyTextNormalization, parameters.ApplyTextNormalization);
        Assert.Equal(expectedEnableLogging, parameters.EnableLogging);
        Assert.Equal(expectedLanguageCode, parameters.LanguageCode);
        Assert.Equal(expectedModelID, parameters.ModelID);
        Assert.Equal(expectedNextText, parameters.NextText);
        Assert.Equal(expectedOptimizeStreamingLatency, parameters.OptimizeStreamingLatency);
        Assert.Equal(expectedOutputFormat, parameters.OutputFormat);
        Assert.Equal(expectedPreviousText, parameters.PreviousText);
        Assert.Equal(expectedSeed, parameters.Seed);
        Assert.Equal(expectedVoiceID, parameters.VoiceID);
        Assert.Equal(expectedVoiceSettings, parameters.VoiceSettings);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SpeakCreateParams { Text = "text" };

        Assert.Null(parameters.ApplyTextNormalization);
        Assert.False(parameters.RawBodyData.ContainsKey("apply_text_normalization"));
        Assert.Null(parameters.EnableLogging);
        Assert.False(parameters.RawBodyData.ContainsKey("enable_logging"));
        Assert.Null(parameters.LanguageCode);
        Assert.False(parameters.RawBodyData.ContainsKey("language_code"));
        Assert.Null(parameters.ModelID);
        Assert.False(parameters.RawBodyData.ContainsKey("model_id"));
        Assert.Null(parameters.NextText);
        Assert.False(parameters.RawBodyData.ContainsKey("next_text"));
        Assert.Null(parameters.OptimizeStreamingLatency);
        Assert.False(parameters.RawBodyData.ContainsKey("optimize_streaming_latency"));
        Assert.Null(parameters.OutputFormat);
        Assert.False(parameters.RawBodyData.ContainsKey("output_format"));
        Assert.Null(parameters.PreviousText);
        Assert.False(parameters.RawBodyData.ContainsKey("previous_text"));
        Assert.Null(parameters.Seed);
        Assert.False(parameters.RawBodyData.ContainsKey("seed"));
        Assert.Null(parameters.VoiceID);
        Assert.False(parameters.RawBodyData.ContainsKey("voice_id"));
        Assert.Null(parameters.VoiceSettings);
        Assert.False(parameters.RawBodyData.ContainsKey("voice_settings"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new SpeakCreateParams
        {
            Text = "text",

            // Null should be interpreted as omitted for these properties
            ApplyTextNormalization = null,
            EnableLogging = null,
            LanguageCode = null,
            ModelID = null,
            NextText = null,
            OptimizeStreamingLatency = null,
            OutputFormat = null,
            PreviousText = null,
            Seed = null,
            VoiceID = null,
            VoiceSettings = null,
        };

        Assert.Null(parameters.ApplyTextNormalization);
        Assert.False(parameters.RawBodyData.ContainsKey("apply_text_normalization"));
        Assert.Null(parameters.EnableLogging);
        Assert.False(parameters.RawBodyData.ContainsKey("enable_logging"));
        Assert.Null(parameters.LanguageCode);
        Assert.False(parameters.RawBodyData.ContainsKey("language_code"));
        Assert.Null(parameters.ModelID);
        Assert.False(parameters.RawBodyData.ContainsKey("model_id"));
        Assert.Null(parameters.NextText);
        Assert.False(parameters.RawBodyData.ContainsKey("next_text"));
        Assert.Null(parameters.OptimizeStreamingLatency);
        Assert.False(parameters.RawBodyData.ContainsKey("optimize_streaming_latency"));
        Assert.Null(parameters.OutputFormat);
        Assert.False(parameters.RawBodyData.ContainsKey("output_format"));
        Assert.Null(parameters.PreviousText);
        Assert.False(parameters.RawBodyData.ContainsKey("previous_text"));
        Assert.Null(parameters.Seed);
        Assert.False(parameters.RawBodyData.ContainsKey("seed"));
        Assert.Null(parameters.VoiceID);
        Assert.False(parameters.RawBodyData.ContainsKey("voice_id"));
        Assert.Null(parameters.VoiceSettings);
        Assert.False(parameters.RawBodyData.ContainsKey("voice_settings"));
    }

    [Fact]
    public void Url_Works()
    {
        SpeakCreateParams parameters = new() { Text = "text" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/voice/v1/speak"), url);
    }
}

public class ModelIDTest : TestBase
{
    [Theory]
    [InlineData(ModelID.ElevenMultilingualV2)]
    [InlineData(ModelID.ElevenTurboV2)]
    [InlineData(ModelID.ElevenMonolingualV1)]
    public void Validation_Works(ModelID rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ModelID> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ModelID>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ModelID.ElevenMultilingualV2)]
    [InlineData(ModelID.ElevenTurboV2)]
    [InlineData(ModelID.ElevenMonolingualV1)]
    public void SerializationRoundtrip_Works(ModelID rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ModelID> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ModelID>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ModelID>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ModelID>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class OutputFormatTest : TestBase
{
    [Theory]
    [InlineData(OutputFormat.Mp3_44100_128)]
    [InlineData(OutputFormat.Mp3_44100_192)]
    [InlineData(OutputFormat.Pcm16000)]
    [InlineData(OutputFormat.Pcm22050)]
    [InlineData(OutputFormat.Pcm24000)]
    [InlineData(OutputFormat.Pcm44100)]
    public void Validation_Works(OutputFormat rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OutputFormat> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, OutputFormat>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(OutputFormat.Mp3_44100_128)]
    [InlineData(OutputFormat.Mp3_44100_192)]
    [InlineData(OutputFormat.Pcm16000)]
    [InlineData(OutputFormat.Pcm22050)]
    [InlineData(OutputFormat.Pcm24000)]
    [InlineData(OutputFormat.Pcm44100)]
    public void SerializationRoundtrip_Works(OutputFormat rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OutputFormat> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, OutputFormat>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, OutputFormat>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, OutputFormat>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class VoiceSettingsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VoiceSettings
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
        var model = new VoiceSettings
        {
            SimilarityBoost = 0,
            Stability = 0,
            Style = 0,
            UseSpeakerBoost = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<VoiceSettings>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VoiceSettings
        {
            SimilarityBoost = 0,
            Stability = 0,
            Style = 0,
            UseSpeakerBoost = true,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<VoiceSettings>(element);
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
        var model = new VoiceSettings
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
        var model = new VoiceSettings { };

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
        var model = new VoiceSettings { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new VoiceSettings
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
        var model = new VoiceSettings
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
