using System.Text.Json;
using CaseDev.Core;
using CaseDev.Exceptions;
using CaseDev.Models.Llm.V1.Chat;

namespace CaseDev.Tests.Models.Llm.V1.Chat;

public class MessageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Message { Content = "content", Role = Role.System };

        string expectedContent = "content";
        ApiEnum<string, Role> expectedRole = Role.System;

        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedRole, model.Role);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Message { Content = "content", Role = Role.System };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Message>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Message { Content = "content", Role = Role.System };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Message>(json);
        Assert.NotNull(deserialized);

        string expectedContent = "content";
        ApiEnum<string, Role> expectedRole = Role.System;

        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedRole, deserialized.Role);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Message { Content = "content", Role = Role.System };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Message { };

        Assert.Null(model.Content);
        Assert.False(model.RawData.ContainsKey("content"));
        Assert.Null(model.Role);
        Assert.False(model.RawData.ContainsKey("role"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Message { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Message
        {
            // Null should be interpreted as omitted for these properties
            Content = null,
            Role = null,
        };

        Assert.Null(model.Content);
        Assert.False(model.RawData.ContainsKey("content"));
        Assert.Null(model.Role);
        Assert.False(model.RawData.ContainsKey("role"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Message
        {
            // Null should be interpreted as omitted for these properties
            Content = null,
            Role = null,
        };

        model.Validate();
    }
}

public class RoleTest : TestBase
{
    [Theory]
    [InlineData(Role.System)]
    [InlineData(Role.User)]
    [InlineData(Role.Assistant)]
    public void Validation_Works(Role rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Role> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Role>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Role.System)]
    [InlineData(Role.User)]
    [InlineData(Role.Assistant)]
    public void SerializationRoundtrip_Works(Role rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Role> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Role>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Role>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Role>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
