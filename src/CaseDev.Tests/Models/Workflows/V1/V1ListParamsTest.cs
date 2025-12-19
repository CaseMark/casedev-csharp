using System.Text.Json;
using CaseDev.Core;
using CaseDev.Exceptions;
using CaseDev.Models.Workflows.V1;

namespace CaseDev.Tests.Models.Workflows.V1;

public class V1ListParamsVisibilityTest : TestBase
{
    [Theory]
    [InlineData(V1ListParamsVisibility.Private)]
    [InlineData(V1ListParamsVisibility.Org)]
    [InlineData(V1ListParamsVisibility.Public)]
    public void Validation_Works(V1ListParamsVisibility rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, V1ListParamsVisibility> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, V1ListParamsVisibility>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(V1ListParamsVisibility.Private)]
    [InlineData(V1ListParamsVisibility.Org)]
    [InlineData(V1ListParamsVisibility.Public)]
    public void SerializationRoundtrip_Works(V1ListParamsVisibility rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, V1ListParamsVisibility> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, V1ListParamsVisibility>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, V1ListParamsVisibility>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, V1ListParamsVisibility>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
