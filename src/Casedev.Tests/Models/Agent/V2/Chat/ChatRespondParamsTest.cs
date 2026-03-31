using System;
using System.Collections.Generic;
using System.Text.Json;
using Casedev.Core;
using Casedev.Exceptions;
using Chat = Casedev.Models.Agent.V2.Chat;

namespace Casedev.Tests.Models.Agent.V2.Chat;

public class ChatRespondParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new Chat::ChatRespondParams
        {
            ID = "id",
            Parts = [new() { Text = "text", Type = Chat::Type.Text }],
        };

        string expectedID = "id";
        List<Chat::Part> expectedParts = [new() { Text = "text", Type = Chat::Type.Text }];

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
        var parameters = new Chat::ChatRespondParams { ID = "id" };

        Assert.Null(parameters.Parts);
        Assert.False(parameters.RawBodyData.ContainsKey("parts"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new Chat::ChatRespondParams
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
        Chat::ChatRespondParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/agent/v2/chat/id/respond"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new Chat::ChatRespondParams
        {
            ID = "id",
            Parts = [new() { Text = "text", Type = Chat::Type.Text }],
        };

        Chat::ChatRespondParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class PartTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Chat::Part { Text = "text", Type = Chat::Type.Text };

        string expectedText = "text";
        ApiEnum<string, Chat::Type> expectedType = Chat::Type.Text;

        Assert.Equal(expectedText, model.Text);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Chat::Part { Text = "text", Type = Chat::Type.Text };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Chat::Part>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Chat::Part { Text = "text", Type = Chat::Type.Text };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Chat::Part>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedText = "text";
        ApiEnum<string, Chat::Type> expectedType = Chat::Type.Text;

        Assert.Equal(expectedText, deserialized.Text);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Chat::Part { Text = "text", Type = Chat::Type.Text };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Chat::Part { Text = "text", Type = Chat::Type.Text };

        Chat::Part copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Chat::Type.Text)]
    public void Validation_Works(Chat::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Chat::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Chat::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Chat::Type.Text)]
    public void SerializationRoundtrip_Works(Chat::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Chat::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Chat::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Chat::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Chat::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
