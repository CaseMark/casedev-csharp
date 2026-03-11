using System;
using System.Collections.Generic;
using System.Text.Json;
using Casedev.Core;
using Casedev.Exceptions;
using Casedev.Models.Agent.V1.Chat;

namespace Casedev.Tests.Models.Agent.V1.Chat;

public class ChatSendMessageParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ChatSendMessageParams
        {
            ID = "id",
            Parts = [new() { Text = "text", Type = ChatSendMessageParamsPartType.Text }],
        };

        string expectedID = "id";
        List<ChatSendMessageParamsPart> expectedParts =
        [
            new() { Text = "text", Type = ChatSendMessageParamsPartType.Text },
        ];

        Assert.Equal(expectedID, parameters.ID);
        Assert.NotNull(parameters.Parts);
        Assert.Equal(expectedParts.Count, parameters.Parts.Count);
        for (int i = 0; i < expectedParts.Count; i++)
        {
            Assert.Equal(expectedParts[i], parameters.Parts[i]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ChatSendMessageParams { ID = "id" };

        Assert.Null(parameters.Parts);
        Assert.False(parameters.RawBodyData.ContainsKey("parts"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ChatSendMessageParams
        {
            ID = "id",

            // Null should be interpreted as omitted for these properties
            Parts = null,
        };

        Assert.Null(parameters.Parts);
        Assert.False(parameters.RawBodyData.ContainsKey("parts"));
    }

    [Fact]
    public void Url_Works()
    {
        ChatSendMessageParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/agent/v1/chat/id/message"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ChatSendMessageParams
        {
            ID = "id",
            Parts = [new() { Text = "text", Type = ChatSendMessageParamsPartType.Text }],
        };

        ChatSendMessageParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ChatSendMessageParamsPartTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChatSendMessageParamsPart
        {
            Text = "text",
            Type = ChatSendMessageParamsPartType.Text,
        };

        string expectedText = "text";
        ApiEnum<string, ChatSendMessageParamsPartType> expectedType =
            ChatSendMessageParamsPartType.Text;

        Assert.Equal(expectedText, model.Text);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChatSendMessageParamsPart
        {
            Text = "text",
            Type = ChatSendMessageParamsPartType.Text,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatSendMessageParamsPart>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChatSendMessageParamsPart
        {
            Text = "text",
            Type = ChatSendMessageParamsPartType.Text,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatSendMessageParamsPart>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedText = "text";
        ApiEnum<string, ChatSendMessageParamsPartType> expectedType =
            ChatSendMessageParamsPartType.Text;

        Assert.Equal(expectedText, deserialized.Text);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChatSendMessageParamsPart
        {
            Text = "text",
            Type = ChatSendMessageParamsPartType.Text,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChatSendMessageParamsPart
        {
            Text = "text",
            Type = ChatSendMessageParamsPartType.Text,
        };

        ChatSendMessageParamsPart copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChatSendMessageParamsPartTypeTest : TestBase
{
    [Theory]
    [InlineData(ChatSendMessageParamsPartType.Text)]
    public void Validation_Works(ChatSendMessageParamsPartType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChatSendMessageParamsPartType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ChatSendMessageParamsPartType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ChatSendMessageParamsPartType.Text)]
    public void SerializationRoundtrip_Works(ChatSendMessageParamsPartType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChatSendMessageParamsPartType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChatSendMessageParamsPartType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ChatSendMessageParamsPartType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChatSendMessageParamsPartType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
