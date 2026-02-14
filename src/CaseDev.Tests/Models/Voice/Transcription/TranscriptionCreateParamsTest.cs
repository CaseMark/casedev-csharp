using System;
using System.Collections.Generic;
using System.Text.Json;
using CaseDev.Core;
using CaseDev.Exceptions;
using CaseDev.Models.Voice.Transcription;

namespace CaseDev.Tests.Models.Voice.Transcription;

public class TranscriptionCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TranscriptionCreateParams
        {
            AudioUrl = "audio_url",
            AutoHighlights = true,
            BoostParam = BoostParam.Low,
            ContentSafetyLabels = true,
            Format = TranscriptionCreateParamsFormat.Json,
            FormatText = true,
            LanguageCode = "language_code",
            LanguageDetection = true,
            ObjectID = "object_id",
            Punctuate = true,
            SpeakerLabels = true,
            SpeakersExpected = 0,
            SpeechModels = ["string"],
            VaultID = "vault_id",
            WordBoost = ["string"],
        };

        string expectedAudioUrl = "audio_url";
        bool expectedAutoHighlights = true;
        ApiEnum<string, BoostParam> expectedBoostParam = BoostParam.Low;
        bool expectedContentSafetyLabels = true;
        ApiEnum<string, TranscriptionCreateParamsFormat> expectedFormat =
            TranscriptionCreateParamsFormat.Json;
        bool expectedFormatText = true;
        string expectedLanguageCode = "language_code";
        bool expectedLanguageDetection = true;
        string expectedObjectID = "object_id";
        bool expectedPunctuate = true;
        bool expectedSpeakerLabels = true;
        long expectedSpeakersExpected = 0;
        List<string> expectedSpeechModels = ["string"];
        string expectedVaultID = "vault_id";
        List<string> expectedWordBoost = ["string"];

        Assert.Equal(expectedAudioUrl, parameters.AudioUrl);
        Assert.Equal(expectedAutoHighlights, parameters.AutoHighlights);
        Assert.Equal(expectedBoostParam, parameters.BoostParam);
        Assert.Equal(expectedContentSafetyLabels, parameters.ContentSafetyLabels);
        Assert.Equal(expectedFormat, parameters.Format);
        Assert.Equal(expectedFormatText, parameters.FormatText);
        Assert.Equal(expectedLanguageCode, parameters.LanguageCode);
        Assert.Equal(expectedLanguageDetection, parameters.LanguageDetection);
        Assert.Equal(expectedObjectID, parameters.ObjectID);
        Assert.Equal(expectedPunctuate, parameters.Punctuate);
        Assert.Equal(expectedSpeakerLabels, parameters.SpeakerLabels);
        Assert.Equal(expectedSpeakersExpected, parameters.SpeakersExpected);
        Assert.NotNull(parameters.SpeechModels);
        Assert.Equal(expectedSpeechModels.Count, parameters.SpeechModels.Count);
        for (int i = 0; i < expectedSpeechModels.Count; i++)
        {
            Assert.Equal(expectedSpeechModels[i], parameters.SpeechModels[i]);
        }
        Assert.Equal(expectedVaultID, parameters.VaultID);
        Assert.NotNull(parameters.WordBoost);
        Assert.Equal(expectedWordBoost.Count, parameters.WordBoost.Count);
        for (int i = 0; i < expectedWordBoost.Count; i++)
        {
            Assert.Equal(expectedWordBoost[i], parameters.WordBoost[i]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TranscriptionCreateParams { };

        Assert.Null(parameters.AudioUrl);
        Assert.False(parameters.RawBodyData.ContainsKey("audio_url"));
        Assert.Null(parameters.AutoHighlights);
        Assert.False(parameters.RawBodyData.ContainsKey("auto_highlights"));
        Assert.Null(parameters.BoostParam);
        Assert.False(parameters.RawBodyData.ContainsKey("boost_param"));
        Assert.Null(parameters.ContentSafetyLabels);
        Assert.False(parameters.RawBodyData.ContainsKey("content_safety_labels"));
        Assert.Null(parameters.Format);
        Assert.False(parameters.RawBodyData.ContainsKey("format"));
        Assert.Null(parameters.FormatText);
        Assert.False(parameters.RawBodyData.ContainsKey("format_text"));
        Assert.Null(parameters.LanguageCode);
        Assert.False(parameters.RawBodyData.ContainsKey("language_code"));
        Assert.Null(parameters.LanguageDetection);
        Assert.False(parameters.RawBodyData.ContainsKey("language_detection"));
        Assert.Null(parameters.ObjectID);
        Assert.False(parameters.RawBodyData.ContainsKey("object_id"));
        Assert.Null(parameters.Punctuate);
        Assert.False(parameters.RawBodyData.ContainsKey("punctuate"));
        Assert.Null(parameters.SpeakerLabels);
        Assert.False(parameters.RawBodyData.ContainsKey("speaker_labels"));
        Assert.Null(parameters.SpeakersExpected);
        Assert.False(parameters.RawBodyData.ContainsKey("speakers_expected"));
        Assert.Null(parameters.SpeechModels);
        Assert.False(parameters.RawBodyData.ContainsKey("speech_models"));
        Assert.Null(parameters.VaultID);
        Assert.False(parameters.RawBodyData.ContainsKey("vault_id"));
        Assert.Null(parameters.WordBoost);
        Assert.False(parameters.RawBodyData.ContainsKey("word_boost"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new TranscriptionCreateParams
        {
            // Null should be interpreted as omitted for these properties
            AudioUrl = null,
            AutoHighlights = null,
            BoostParam = null,
            ContentSafetyLabels = null,
            Format = null,
            FormatText = null,
            LanguageCode = null,
            LanguageDetection = null,
            ObjectID = null,
            Punctuate = null,
            SpeakerLabels = null,
            SpeakersExpected = null,
            SpeechModels = null,
            VaultID = null,
            WordBoost = null,
        };

        Assert.Null(parameters.AudioUrl);
        Assert.False(parameters.RawBodyData.ContainsKey("audio_url"));
        Assert.Null(parameters.AutoHighlights);
        Assert.False(parameters.RawBodyData.ContainsKey("auto_highlights"));
        Assert.Null(parameters.BoostParam);
        Assert.False(parameters.RawBodyData.ContainsKey("boost_param"));
        Assert.Null(parameters.ContentSafetyLabels);
        Assert.False(parameters.RawBodyData.ContainsKey("content_safety_labels"));
        Assert.Null(parameters.Format);
        Assert.False(parameters.RawBodyData.ContainsKey("format"));
        Assert.Null(parameters.FormatText);
        Assert.False(parameters.RawBodyData.ContainsKey("format_text"));
        Assert.Null(parameters.LanguageCode);
        Assert.False(parameters.RawBodyData.ContainsKey("language_code"));
        Assert.Null(parameters.LanguageDetection);
        Assert.False(parameters.RawBodyData.ContainsKey("language_detection"));
        Assert.Null(parameters.ObjectID);
        Assert.False(parameters.RawBodyData.ContainsKey("object_id"));
        Assert.Null(parameters.Punctuate);
        Assert.False(parameters.RawBodyData.ContainsKey("punctuate"));
        Assert.Null(parameters.SpeakerLabels);
        Assert.False(parameters.RawBodyData.ContainsKey("speaker_labels"));
        Assert.Null(parameters.SpeakersExpected);
        Assert.False(parameters.RawBodyData.ContainsKey("speakers_expected"));
        Assert.Null(parameters.SpeechModels);
        Assert.False(parameters.RawBodyData.ContainsKey("speech_models"));
        Assert.Null(parameters.VaultID);
        Assert.False(parameters.RawBodyData.ContainsKey("vault_id"));
        Assert.Null(parameters.WordBoost);
        Assert.False(parameters.RawBodyData.ContainsKey("word_boost"));
    }

    [Fact]
    public void Url_Works()
    {
        TranscriptionCreateParams parameters = new();

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/voice/transcription"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TranscriptionCreateParams
        {
            AudioUrl = "audio_url",
            AutoHighlights = true,
            BoostParam = BoostParam.Low,
            ContentSafetyLabels = true,
            Format = TranscriptionCreateParamsFormat.Json,
            FormatText = true,
            LanguageCode = "language_code",
            LanguageDetection = true,
            ObjectID = "object_id",
            Punctuate = true,
            SpeakerLabels = true,
            SpeakersExpected = 0,
            SpeechModels = ["string"],
            VaultID = "vault_id",
            WordBoost = ["string"],
        };

        TranscriptionCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class BoostParamTest : TestBase
{
    [Theory]
    [InlineData(BoostParam.Low)]
    [InlineData(BoostParam.Default)]
    [InlineData(BoostParam.High)]
    public void Validation_Works(BoostParam rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BoostParam> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BoostParam>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BoostParam.Low)]
    [InlineData(BoostParam.Default)]
    [InlineData(BoostParam.High)]
    public void SerializationRoundtrip_Works(BoostParam rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BoostParam> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BoostParam>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BoostParam>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BoostParam>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TranscriptionCreateParamsFormatTest : TestBase
{
    [Theory]
    [InlineData(TranscriptionCreateParamsFormat.Json)]
    [InlineData(TranscriptionCreateParamsFormat.Text)]
    public void Validation_Works(TranscriptionCreateParamsFormat rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TranscriptionCreateParamsFormat> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TranscriptionCreateParamsFormat>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TranscriptionCreateParamsFormat.Json)]
    [InlineData(TranscriptionCreateParamsFormat.Text)]
    public void SerializationRoundtrip_Works(TranscriptionCreateParamsFormat rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TranscriptionCreateParamsFormat> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, TranscriptionCreateParamsFormat>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TranscriptionCreateParamsFormat>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, TranscriptionCreateParamsFormat>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
