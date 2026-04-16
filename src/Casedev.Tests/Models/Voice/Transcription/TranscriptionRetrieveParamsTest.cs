using System;
using System.Text.Json;
using Casedev.Core;
using Casedev.Exceptions;
using Casedev.Models.Voice.Transcription;

namespace Casedev.Tests.Models.Voice.Transcription;

public class TranscriptionRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TranscriptionRetrieveParams
        {
            ID = "tr_abc123def456",
            IncludeText = IncludeText.True,
        };

        string expectedID = "tr_abc123def456";
        ApiEnum<string, IncludeText> expectedIncludeText = IncludeText.True;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedIncludeText, parameters.IncludeText);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TranscriptionRetrieveParams { ID = "tr_abc123def456" };

        Assert.Null(parameters.IncludeText);
        Assert.False(parameters.RawQueryData.ContainsKey("include_text"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new TranscriptionRetrieveParams
        {
            ID = "tr_abc123def456",

            // Null should be interpreted as omitted for these properties
            IncludeText = null,
        };

        Assert.Null(parameters.IncludeText);
        Assert.False(parameters.RawQueryData.ContainsKey("include_text"));
    }

    [Fact]
    public void Url_Works()
    {
        TranscriptionRetrieveParams parameters = new()
        {
            ID = "tr_abc123def456",
            IncludeText = IncludeText.True,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.case.dev/voice/transcription/tr_abc123def456?include_text=true"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TranscriptionRetrieveParams
        {
            ID = "tr_abc123def456",
            IncludeText = IncludeText.True,
        };

        TranscriptionRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class IncludeTextTest : TestBase
{
    [Theory]
    [InlineData(IncludeText.True)]
    [InlineData(IncludeText.False)]
    public void Validation_Works(IncludeText rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, IncludeText> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, IncludeText>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(IncludeText.True)]
    [InlineData(IncludeText.False)]
    public void SerializationRoundtrip_Works(IncludeText rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, IncludeText> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, IncludeText>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, IncludeText>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, IncludeText>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
