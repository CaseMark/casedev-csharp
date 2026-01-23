using System.Collections.Generic;
using System.Text.Json;
using CaseDev.Core;
using CaseDev.Exceptions;
using CaseDev.Models.Voice.Transcription;

namespace CaseDev.Tests.Models.Voice.Transcription;

public class TranscriptionRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TranscriptionRetrieveResponse
        {
            ID = "id",
            Status = TranscriptionRetrieveResponseStatus.Queued,
            AudioDuration = 0,
            Confidence = 0,
            Error = "error",
            ResultObjectID = "result_object_id",
            SourceObjectID = "source_object_id",
            Text = "text",
            VaultID = "vault_id",
            WordCount = 0,
            Words = [JsonSerializer.Deserialize<JsonElement>("{}")],
        };

        string expectedID = "id";
        ApiEnum<string, TranscriptionRetrieveResponseStatus> expectedStatus =
            TranscriptionRetrieveResponseStatus.Queued;
        double expectedAudioDuration = 0;
        double expectedConfidence = 0;
        string expectedError = "error";
        string expectedResultObjectID = "result_object_id";
        string expectedSourceObjectID = "source_object_id";
        string expectedText = "text";
        string expectedVaultID = "vault_id";
        long expectedWordCount = 0;
        List<JsonElement> expectedWords = [JsonSerializer.Deserialize<JsonElement>("{}")];

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedAudioDuration, model.AudioDuration);
        Assert.Equal(expectedConfidence, model.Confidence);
        Assert.Equal(expectedError, model.Error);
        Assert.Equal(expectedResultObjectID, model.ResultObjectID);
        Assert.Equal(expectedSourceObjectID, model.SourceObjectID);
        Assert.Equal(expectedText, model.Text);
        Assert.Equal(expectedVaultID, model.VaultID);
        Assert.Equal(expectedWordCount, model.WordCount);
        Assert.NotNull(model.Words);
        Assert.Equal(expectedWords.Count, model.Words.Count);
        for (int i = 0; i < expectedWords.Count; i++)
        {
            Assert.True(JsonElement.DeepEquals(expectedWords[i], model.Words[i]));
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TranscriptionRetrieveResponse
        {
            ID = "id",
            Status = TranscriptionRetrieveResponseStatus.Queued,
            AudioDuration = 0,
            Confidence = 0,
            Error = "error",
            ResultObjectID = "result_object_id",
            SourceObjectID = "source_object_id",
            Text = "text",
            VaultID = "vault_id",
            WordCount = 0,
            Words = [JsonSerializer.Deserialize<JsonElement>("{}")],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TranscriptionRetrieveResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TranscriptionRetrieveResponse
        {
            ID = "id",
            Status = TranscriptionRetrieveResponseStatus.Queued,
            AudioDuration = 0,
            Confidence = 0,
            Error = "error",
            ResultObjectID = "result_object_id",
            SourceObjectID = "source_object_id",
            Text = "text",
            VaultID = "vault_id",
            WordCount = 0,
            Words = [JsonSerializer.Deserialize<JsonElement>("{}")],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TranscriptionRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        ApiEnum<string, TranscriptionRetrieveResponseStatus> expectedStatus =
            TranscriptionRetrieveResponseStatus.Queued;
        double expectedAudioDuration = 0;
        double expectedConfidence = 0;
        string expectedError = "error";
        string expectedResultObjectID = "result_object_id";
        string expectedSourceObjectID = "source_object_id";
        string expectedText = "text";
        string expectedVaultID = "vault_id";
        long expectedWordCount = 0;
        List<JsonElement> expectedWords = [JsonSerializer.Deserialize<JsonElement>("{}")];

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedAudioDuration, deserialized.AudioDuration);
        Assert.Equal(expectedConfidence, deserialized.Confidence);
        Assert.Equal(expectedError, deserialized.Error);
        Assert.Equal(expectedResultObjectID, deserialized.ResultObjectID);
        Assert.Equal(expectedSourceObjectID, deserialized.SourceObjectID);
        Assert.Equal(expectedText, deserialized.Text);
        Assert.Equal(expectedVaultID, deserialized.VaultID);
        Assert.Equal(expectedWordCount, deserialized.WordCount);
        Assert.NotNull(deserialized.Words);
        Assert.Equal(expectedWords.Count, deserialized.Words.Count);
        for (int i = 0; i < expectedWords.Count; i++)
        {
            Assert.True(JsonElement.DeepEquals(expectedWords[i], deserialized.Words[i]));
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TranscriptionRetrieveResponse
        {
            ID = "id",
            Status = TranscriptionRetrieveResponseStatus.Queued,
            AudioDuration = 0,
            Confidence = 0,
            Error = "error",
            ResultObjectID = "result_object_id",
            SourceObjectID = "source_object_id",
            Text = "text",
            VaultID = "vault_id",
            WordCount = 0,
            Words = [JsonSerializer.Deserialize<JsonElement>("{}")],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TranscriptionRetrieveResponse
        {
            ID = "id",
            Status = TranscriptionRetrieveResponseStatus.Queued,
        };

        Assert.Null(model.AudioDuration);
        Assert.False(model.RawData.ContainsKey("audio_duration"));
        Assert.Null(model.Confidence);
        Assert.False(model.RawData.ContainsKey("confidence"));
        Assert.Null(model.Error);
        Assert.False(model.RawData.ContainsKey("error"));
        Assert.Null(model.ResultObjectID);
        Assert.False(model.RawData.ContainsKey("result_object_id"));
        Assert.Null(model.SourceObjectID);
        Assert.False(model.RawData.ContainsKey("source_object_id"));
        Assert.Null(model.Text);
        Assert.False(model.RawData.ContainsKey("text"));
        Assert.Null(model.VaultID);
        Assert.False(model.RawData.ContainsKey("vault_id"));
        Assert.Null(model.WordCount);
        Assert.False(model.RawData.ContainsKey("word_count"));
        Assert.Null(model.Words);
        Assert.False(model.RawData.ContainsKey("words"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new TranscriptionRetrieveResponse
        {
            ID = "id",
            Status = TranscriptionRetrieveResponseStatus.Queued,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TranscriptionRetrieveResponse
        {
            ID = "id",
            Status = TranscriptionRetrieveResponseStatus.Queued,

            // Null should be interpreted as omitted for these properties
            AudioDuration = null,
            Confidence = null,
            Error = null,
            ResultObjectID = null,
            SourceObjectID = null,
            Text = null,
            VaultID = null,
            WordCount = null,
            Words = null,
        };

        Assert.Null(model.AudioDuration);
        Assert.False(model.RawData.ContainsKey("audio_duration"));
        Assert.Null(model.Confidence);
        Assert.False(model.RawData.ContainsKey("confidence"));
        Assert.Null(model.Error);
        Assert.False(model.RawData.ContainsKey("error"));
        Assert.Null(model.ResultObjectID);
        Assert.False(model.RawData.ContainsKey("result_object_id"));
        Assert.Null(model.SourceObjectID);
        Assert.False(model.RawData.ContainsKey("source_object_id"));
        Assert.Null(model.Text);
        Assert.False(model.RawData.ContainsKey("text"));
        Assert.Null(model.VaultID);
        Assert.False(model.RawData.ContainsKey("vault_id"));
        Assert.Null(model.WordCount);
        Assert.False(model.RawData.ContainsKey("word_count"));
        Assert.Null(model.Words);
        Assert.False(model.RawData.ContainsKey("words"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TranscriptionRetrieveResponse
        {
            ID = "id",
            Status = TranscriptionRetrieveResponseStatus.Queued,

            // Null should be interpreted as omitted for these properties
            AudioDuration = null,
            Confidence = null,
            Error = null,
            ResultObjectID = null,
            SourceObjectID = null,
            Text = null,
            VaultID = null,
            WordCount = null,
            Words = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TranscriptionRetrieveResponse
        {
            ID = "id",
            Status = TranscriptionRetrieveResponseStatus.Queued,
            AudioDuration = 0,
            Confidence = 0,
            Error = "error",
            ResultObjectID = "result_object_id",
            SourceObjectID = "source_object_id",
            Text = "text",
            VaultID = "vault_id",
            WordCount = 0,
            Words = [JsonSerializer.Deserialize<JsonElement>("{}")],
        };

        TranscriptionRetrieveResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TranscriptionRetrieveResponseStatusTest : TestBase
{
    [Theory]
    [InlineData(TranscriptionRetrieveResponseStatus.Queued)]
    [InlineData(TranscriptionRetrieveResponseStatus.Processing)]
    [InlineData(TranscriptionRetrieveResponseStatus.Completed)]
    [InlineData(TranscriptionRetrieveResponseStatus.Failed)]
    public void Validation_Works(TranscriptionRetrieveResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TranscriptionRetrieveResponseStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, TranscriptionRetrieveResponseStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TranscriptionRetrieveResponseStatus.Queued)]
    [InlineData(TranscriptionRetrieveResponseStatus.Processing)]
    [InlineData(TranscriptionRetrieveResponseStatus.Completed)]
    [InlineData(TranscriptionRetrieveResponseStatus.Failed)]
    public void SerializationRoundtrip_Works(TranscriptionRetrieveResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TranscriptionRetrieveResponseStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, TranscriptionRetrieveResponseStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, TranscriptionRetrieveResponseStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, TranscriptionRetrieveResponseStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
