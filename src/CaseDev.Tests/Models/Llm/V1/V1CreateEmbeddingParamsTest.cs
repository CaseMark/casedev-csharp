using System.Text.Json;
using CaseDev.Core;
using CaseDev.Exceptions;
using CaseDev.Models.Llm.V1;

namespace CaseDev.Tests.Models.Llm.V1;

public class EncodingFormatTest : TestBase
{
    [Theory]
    [InlineData(EncodingFormat.Float)]
    [InlineData(EncodingFormat.Base64)]
    public void Validation_Works(EncodingFormat rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EncodingFormat> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EncodingFormat>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EncodingFormat.Float)]
    [InlineData(EncodingFormat.Base64)]
    public void SerializationRoundtrip_Works(EncodingFormat rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EncodingFormat> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EncodingFormat>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EncodingFormat>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EncodingFormat>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
