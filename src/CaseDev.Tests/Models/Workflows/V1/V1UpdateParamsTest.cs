using System.Text.Json;
using CaseDev.Core;
using CaseDev.Exceptions;
using CaseDev.Models.Workflows.V1;

namespace CaseDev.Tests.Models.Workflows.V1;

public class V1UpdateParamsTriggerTypeTest : TestBase
{
    [Theory]
    [InlineData(V1UpdateParamsTriggerType.Manual)]
    [InlineData(V1UpdateParamsTriggerType.Webhook)]
    [InlineData(V1UpdateParamsTriggerType.Schedule)]
    [InlineData(V1UpdateParamsTriggerType.VaultUpload)]
    public void Validation_Works(V1UpdateParamsTriggerType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, V1UpdateParamsTriggerType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, V1UpdateParamsTriggerType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(V1UpdateParamsTriggerType.Manual)]
    [InlineData(V1UpdateParamsTriggerType.Webhook)]
    [InlineData(V1UpdateParamsTriggerType.Schedule)]
    [InlineData(V1UpdateParamsTriggerType.VaultUpload)]
    public void SerializationRoundtrip_Works(V1UpdateParamsTriggerType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, V1UpdateParamsTriggerType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, V1UpdateParamsTriggerType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, V1UpdateParamsTriggerType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, V1UpdateParamsTriggerType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class V1UpdateParamsVisibilityTest : TestBase
{
    [Theory]
    [InlineData(V1UpdateParamsVisibility.Private)]
    [InlineData(V1UpdateParamsVisibility.Org)]
    [InlineData(V1UpdateParamsVisibility.Public)]
    public void Validation_Works(V1UpdateParamsVisibility rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, V1UpdateParamsVisibility> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, V1UpdateParamsVisibility>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(V1UpdateParamsVisibility.Private)]
    [InlineData(V1UpdateParamsVisibility.Org)]
    [InlineData(V1UpdateParamsVisibility.Public)]
    public void SerializationRoundtrip_Works(V1UpdateParamsVisibility rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, V1UpdateParamsVisibility> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, V1UpdateParamsVisibility>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, V1UpdateParamsVisibility>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, V1UpdateParamsVisibility>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
