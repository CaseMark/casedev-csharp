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
            Status = Status.Queued,
            AudioDuration = 0,
            Confidence = 0,
            Error = "error",
            Text = "text",
            Words =
            [
                new()
                {
                    Confidence = 0,
                    End = 0,
                    Start = 0,
                    Text = "text",
                },
            ],
        };

        string expectedID = "id";
        ApiEnum<string, Status> expectedStatus = Status.Queued;
        double expectedAudioDuration = 0;
        double expectedConfidence = 0;
        string expectedError = "error";
        string expectedText = "text";
        List<Word> expectedWords =
        [
            new()
            {
                Confidence = 0,
                End = 0,
                Start = 0,
                Text = "text",
            },
        ];

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedAudioDuration, model.AudioDuration);
        Assert.Equal(expectedConfidence, model.Confidence);
        Assert.Equal(expectedError, model.Error);
        Assert.Equal(expectedText, model.Text);
        Assert.NotNull(model.Words);
        Assert.Equal(expectedWords.Count, model.Words.Count);
        for (int i = 0; i < expectedWords.Count; i++)
        {
            Assert.Equal(expectedWords[i], model.Words[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TranscriptionRetrieveResponse
        {
            ID = "id",
            Status = Status.Queued,
            AudioDuration = 0,
            Confidence = 0,
            Error = "error",
            Text = "text",
            Words =
            [
                new()
                {
                    Confidence = 0,
                    End = 0,
                    Start = 0,
                    Text = "text",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<TranscriptionRetrieveResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TranscriptionRetrieveResponse
        {
            ID = "id",
            Status = Status.Queued,
            AudioDuration = 0,
            Confidence = 0,
            Error = "error",
            Text = "text",
            Words =
            [
                new()
                {
                    Confidence = 0,
                    End = 0,
                    Start = 0,
                    Text = "text",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<TranscriptionRetrieveResponse>(element);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        ApiEnum<string, Status> expectedStatus = Status.Queued;
        double expectedAudioDuration = 0;
        double expectedConfidence = 0;
        string expectedError = "error";
        string expectedText = "text";
        List<Word> expectedWords =
        [
            new()
            {
                Confidence = 0,
                End = 0,
                Start = 0,
                Text = "text",
            },
        ];

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedAudioDuration, deserialized.AudioDuration);
        Assert.Equal(expectedConfidence, deserialized.Confidence);
        Assert.Equal(expectedError, deserialized.Error);
        Assert.Equal(expectedText, deserialized.Text);
        Assert.NotNull(deserialized.Words);
        Assert.Equal(expectedWords.Count, deserialized.Words.Count);
        for (int i = 0; i < expectedWords.Count; i++)
        {
            Assert.Equal(expectedWords[i], deserialized.Words[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TranscriptionRetrieveResponse
        {
            ID = "id",
            Status = Status.Queued,
            AudioDuration = 0,
            Confidence = 0,
            Error = "error",
            Text = "text",
            Words =
            [
                new()
                {
                    Confidence = 0,
                    End = 0,
                    Start = 0,
                    Text = "text",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TranscriptionRetrieveResponse { ID = "id", Status = Status.Queued };

        Assert.Null(model.AudioDuration);
        Assert.False(model.RawData.ContainsKey("audio_duration"));
        Assert.Null(model.Confidence);
        Assert.False(model.RawData.ContainsKey("confidence"));
        Assert.Null(model.Error);
        Assert.False(model.RawData.ContainsKey("error"));
        Assert.Null(model.Text);
        Assert.False(model.RawData.ContainsKey("text"));
        Assert.Null(model.Words);
        Assert.False(model.RawData.ContainsKey("words"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new TranscriptionRetrieveResponse { ID = "id", Status = Status.Queued };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TranscriptionRetrieveResponse
        {
            ID = "id",
            Status = Status.Queued,

            // Null should be interpreted as omitted for these properties
            AudioDuration = null,
            Confidence = null,
            Error = null,
            Text = null,
            Words = null,
        };

        Assert.Null(model.AudioDuration);
        Assert.False(model.RawData.ContainsKey("audio_duration"));
        Assert.Null(model.Confidence);
        Assert.False(model.RawData.ContainsKey("confidence"));
        Assert.Null(model.Error);
        Assert.False(model.RawData.ContainsKey("error"));
        Assert.Null(model.Text);
        Assert.False(model.RawData.ContainsKey("text"));
        Assert.Null(model.Words);
        Assert.False(model.RawData.ContainsKey("words"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TranscriptionRetrieveResponse
        {
            ID = "id",
            Status = Status.Queued,

            // Null should be interpreted as omitted for these properties
            AudioDuration = null,
            Confidence = null,
            Error = null,
            Text = null,
            Words = null,
        };

        model.Validate();
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Queued)]
    [InlineData(Status.Processing)]
    [InlineData(Status.Completed)]
    [InlineData(Status.Error)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.Queued)]
    [InlineData(Status.Processing)]
    [InlineData(Status.Completed)]
    [InlineData(Status.Error)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class WordTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Word
        {
            Confidence = 0,
            End = 0,
            Start = 0,
            Text = "text",
        };

        double expectedConfidence = 0;
        double expectedEnd = 0;
        double expectedStart = 0;
        string expectedText = "text";

        Assert.Equal(expectedConfidence, model.Confidence);
        Assert.Equal(expectedEnd, model.End);
        Assert.Equal(expectedStart, model.Start);
        Assert.Equal(expectedText, model.Text);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Word
        {
            Confidence = 0,
            End = 0,
            Start = 0,
            Text = "text",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Word>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Word
        {
            Confidence = 0,
            End = 0,
            Start = 0,
            Text = "text",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Word>(element);
        Assert.NotNull(deserialized);

        double expectedConfidence = 0;
        double expectedEnd = 0;
        double expectedStart = 0;
        string expectedText = "text";

        Assert.Equal(expectedConfidence, deserialized.Confidence);
        Assert.Equal(expectedEnd, deserialized.End);
        Assert.Equal(expectedStart, deserialized.Start);
        Assert.Equal(expectedText, deserialized.Text);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Word
        {
            Confidence = 0,
            End = 0,
            Start = 0,
            Text = "text",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Word { };

        Assert.Null(model.Confidence);
        Assert.False(model.RawData.ContainsKey("confidence"));
        Assert.Null(model.End);
        Assert.False(model.RawData.ContainsKey("end"));
        Assert.Null(model.Start);
        Assert.False(model.RawData.ContainsKey("start"));
        Assert.Null(model.Text);
        Assert.False(model.RawData.ContainsKey("text"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Word { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Word
        {
            // Null should be interpreted as omitted for these properties
            Confidence = null,
            End = null,
            Start = null,
            Text = null,
        };

        Assert.Null(model.Confidence);
        Assert.False(model.RawData.ContainsKey("confidence"));
        Assert.Null(model.End);
        Assert.False(model.RawData.ContainsKey("end"));
        Assert.Null(model.Start);
        Assert.False(model.RawData.ContainsKey("start"));
        Assert.Null(model.Text);
        Assert.False(model.RawData.ContainsKey("text"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Word
        {
            // Null should be interpreted as omitted for these properties
            Confidence = null,
            End = null,
            Start = null,
            Text = null,
        };

        model.Validate();
    }
}
