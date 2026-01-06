using System;
using System.Collections.Generic;
using System.Text.Json;
using CaseDev.Core;
using CaseDev.Exceptions;
using Templates = CaseDev.Models.Format.V1.Templates;

namespace CaseDev.Tests.Models.Format.V1.Templates;

public class TemplateCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new Templates::TemplateCreateParams
        {
            Content = "content",
            Name = "name",
            Type = Templates::Type.Caption,
            Description = "description",
            Styles = JsonSerializer.Deserialize<JsonElement>("{}"),
            Tags = ["string"],
            Variables = ["string"],
        };

        string expectedContent = "content";
        string expectedName = "name";
        ApiEnum<string, Templates::Type> expectedType = Templates::Type.Caption;
        string expectedDescription = "description";
        JsonElement expectedStyles = JsonSerializer.Deserialize<JsonElement>("{}");
        List<string> expectedTags = ["string"];
        List<string> expectedVariables = ["string"];

        Assert.Equal(expectedContent, parameters.Content);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedType, parameters.Type);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.NotNull(parameters.Styles);
        Assert.True(JsonElement.DeepEquals(expectedStyles, parameters.Styles.Value));
        Assert.NotNull(parameters.Tags);
        Assert.Equal(expectedTags.Count, parameters.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], parameters.Tags[i]);
        }
        Assert.NotNull(parameters.Variables);
        Assert.Equal(expectedVariables.Count, parameters.Variables.Count);
        for (int i = 0; i < expectedVariables.Count; i++)
        {
            Assert.Equal(expectedVariables[i], parameters.Variables[i]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new Templates::TemplateCreateParams
        {
            Content = "content",
            Name = "name",
            Type = Templates::Type.Caption,
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Styles);
        Assert.False(parameters.RawBodyData.ContainsKey("styles"));
        Assert.Null(parameters.Tags);
        Assert.False(parameters.RawBodyData.ContainsKey("tags"));
        Assert.Null(parameters.Variables);
        Assert.False(parameters.RawBodyData.ContainsKey("variables"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new Templates::TemplateCreateParams
        {
            Content = "content",
            Name = "name",
            Type = Templates::Type.Caption,

            // Null should be interpreted as omitted for these properties
            Description = null,
            Styles = null,
            Tags = null,
            Variables = null,
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Styles);
        Assert.False(parameters.RawBodyData.ContainsKey("styles"));
        Assert.Null(parameters.Tags);
        Assert.False(parameters.RawBodyData.ContainsKey("tags"));
        Assert.Null(parameters.Variables);
        Assert.False(parameters.RawBodyData.ContainsKey("variables"));
    }

    [Fact]
    public void Url_Works()
    {
        Templates::TemplateCreateParams parameters = new()
        {
            Content = "content",
            Name = "name",
            Type = Templates::Type.Caption,
        };

        var url = parameters.Url(new() { APIKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/format/v1/templates"), url);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Templates::Type.Caption)]
    [InlineData(Templates::Type.Signature)]
    [InlineData(Templates::Type.Letterhead)]
    [InlineData(Templates::Type.Certificate)]
    [InlineData(Templates::Type.Footer)]
    [InlineData(Templates::Type.Custom)]
    public void Validation_Works(Templates::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Templates::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Templates::Type>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Templates::Type.Caption)]
    [InlineData(Templates::Type.Signature)]
    [InlineData(Templates::Type.Letterhead)]
    [InlineData(Templates::Type.Certificate)]
    [InlineData(Templates::Type.Footer)]
    [InlineData(Templates::Type.Custom)]
    public void SerializationRoundtrip_Works(Templates::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Templates::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Templates::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Templates::Type>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Templates::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
