using System.Text.Json;
using CaseDev.Core;
using CaseDev.Exceptions;
using CaseDev.Models.Compute.V1.Invoke;

namespace CaseDev.Tests.Models.Compute.V1.Invoke;

public class FunctionSuffixTest : TestBase
{
    [Theory]
    [InlineData(FunctionSuffix._Modal)]
    [InlineData(FunctionSuffix._Task)]
    [InlineData(FunctionSuffix._Web)]
    [InlineData(FunctionSuffix._Server)]
    public void Validation_Works(FunctionSuffix rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FunctionSuffix> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FunctionSuffix>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FunctionSuffix._Modal)]
    [InlineData(FunctionSuffix._Task)]
    [InlineData(FunctionSuffix._Web)]
    [InlineData(FunctionSuffix._Server)]
    public void SerializationRoundtrip_Works(FunctionSuffix rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FunctionSuffix> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FunctionSuffix>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FunctionSuffix>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FunctionSuffix>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
