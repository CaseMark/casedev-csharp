using System;
using System.Collections.Generic;
using System.Text.Json;
using CaseDev.Core;
using CaseDev.Exceptions;
using CaseDev.Models.Llm.V1.Chat;

namespace CaseDev.Tests.Models.Llm.V1.Chat;

public class ChatCreateCompletionParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ChatCreateCompletionParams
        {
            Messages = [new() { Content = "content", Role = Role.System }],
            FrequencyPenalty = 0,
            MaxTokens = 1000,
            Model = "gpt-4o",
            PresencePenalty = 0,
            Stream = false,
            Temperature = 0.7,
            TopP = 0,
        };

        List<Message> expectedMessages = [new() { Content = "content", Role = Role.System }];
        double expectedFrequencyPenalty = 0;
        long expectedMaxTokens = 1000;
        string expectedModel = "gpt-4o";
        double expectedPresencePenalty = 0;
        bool expectedStream = false;
        double expectedTemperature = 0.7;
        double expectedTopP = 0;

        Assert.Equal(expectedMessages.Count, parameters.Messages.Count);
        for (int i = 0; i < expectedMessages.Count; i++)
        {
            Assert.Equal(expectedMessages[i], parameters.Messages[i]);
        }
        Assert.Equal(expectedFrequencyPenalty, parameters.FrequencyPenalty);
        Assert.Equal(expectedMaxTokens, parameters.MaxTokens);
        Assert.Equal(expectedModel, parameters.Model);
        Assert.Equal(expectedPresencePenalty, parameters.PresencePenalty);
        Assert.Equal(expectedStream, parameters.Stream);
        Assert.Equal(expectedTemperature, parameters.Temperature);
        Assert.Equal(expectedTopP, parameters.TopP);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ChatCreateCompletionParams
        {
            Messages = [new() { Content = "content", Role = Role.System }],
        };

        Assert.Null(parameters.FrequencyPenalty);
        Assert.False(parameters.RawBodyData.ContainsKey("frequency_penalty"));
        Assert.Null(parameters.MaxTokens);
        Assert.False(parameters.RawBodyData.ContainsKey("max_tokens"));
        Assert.Null(parameters.Model);
        Assert.False(parameters.RawBodyData.ContainsKey("model"));
        Assert.Null(parameters.PresencePenalty);
        Assert.False(parameters.RawBodyData.ContainsKey("presence_penalty"));
        Assert.Null(parameters.Stream);
        Assert.False(parameters.RawBodyData.ContainsKey("stream"));
        Assert.Null(parameters.Temperature);
        Assert.False(parameters.RawBodyData.ContainsKey("temperature"));
        Assert.Null(parameters.TopP);
        Assert.False(parameters.RawBodyData.ContainsKey("top_p"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ChatCreateCompletionParams
        {
            Messages = [new() { Content = "content", Role = Role.System }],

            // Null should be interpreted as omitted for these properties
            FrequencyPenalty = null,
            MaxTokens = null,
            Model = null,
            PresencePenalty = null,
            Stream = null,
            Temperature = null,
            TopP = null,
        };

        Assert.Null(parameters.FrequencyPenalty);
        Assert.False(parameters.RawBodyData.ContainsKey("frequency_penalty"));
        Assert.Null(parameters.MaxTokens);
        Assert.False(parameters.RawBodyData.ContainsKey("max_tokens"));
        Assert.Null(parameters.Model);
        Assert.False(parameters.RawBodyData.ContainsKey("model"));
        Assert.Null(parameters.PresencePenalty);
        Assert.False(parameters.RawBodyData.ContainsKey("presence_penalty"));
        Assert.Null(parameters.Stream);
        Assert.False(parameters.RawBodyData.ContainsKey("stream"));
        Assert.Null(parameters.Temperature);
        Assert.False(parameters.RawBodyData.ContainsKey("temperature"));
        Assert.Null(parameters.TopP);
        Assert.False(parameters.RawBodyData.ContainsKey("top_p"));
    }

    [Fact]
    public void Url_Works()
    {
        ChatCreateCompletionParams parameters = new()
        {
            Messages = [new() { Content = "content", Role = Role.System }],
        };

        var url = parameters.Url(new() { APIKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/llm/v1/chat/completions"), url);
    }
}

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

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Message>(element);
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

        Assert.NotNull(value);
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
