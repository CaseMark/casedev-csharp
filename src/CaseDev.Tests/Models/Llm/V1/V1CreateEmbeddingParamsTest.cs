using System.Text.Json;
using CaseDev.Core;
using CaseDev.Exceptions;
using CaseDev.Models.Llm.V1;

namespace CaseDev.Tests.Models.Llm.V1;

public class InputTest : TestBase
{
    [Fact]
    public void stringValidation_Works()
    {
        Input value = new("string");
        value.Validate();
    }

    [Fact]
    public void stringsValidation_Works()
    {
        Input value = new(["string"]);
        value.Validate();
    }

    [Fact]
    public void stringSerializationRoundtrip_Works()
    {
        Input value = new("string");
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Input>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void stringsSerializationRoundtrip_Works()
    {
        Input value = new(["string"]);
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Input>(json);

        Assert.Equal(value, deserialized);
    }
}

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
