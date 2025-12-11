using System.Text.Json;
using CaseDev.Core;
using CaseDev.Exceptions;
using CaseDev.Models.Workflows.V1;

namespace CaseDev.Tests.Models.Workflows.V1;

public class TriggerTypeTest : TestBase
{
    [Theory]
    [InlineData(TriggerType.Manual)]
    [InlineData(TriggerType.Webhook)]
    [InlineData(TriggerType.Schedule)]
    [InlineData(TriggerType.VaultUpload)]
    public void Validation_Works(TriggerType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TriggerType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TriggerType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TriggerType.Manual)]
    [InlineData(TriggerType.Webhook)]
    [InlineData(TriggerType.Schedule)]
    [InlineData(TriggerType.VaultUpload)]
    public void SerializationRoundtrip_Works(TriggerType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TriggerType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TriggerType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TriggerType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TriggerType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class VisibilityTest : TestBase
{
    [Theory]
    [InlineData(Visibility.Private)]
    [InlineData(Visibility.Org)]
    [InlineData(Visibility.Public)]
    public void Validation_Works(Visibility rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Visibility> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Visibility>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Visibility.Private)]
    [InlineData(Visibility.Org)]
    [InlineData(Visibility.Public)]
    public void SerializationRoundtrip_Works(Visibility rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Visibility> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Visibility>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Visibility>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Visibility>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
