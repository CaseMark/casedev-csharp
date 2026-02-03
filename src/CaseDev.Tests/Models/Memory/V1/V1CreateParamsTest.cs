using System;
using System.Collections.Generic;
using System.Text.Json;
using CaseDev.Core;
using CaseDev.Exceptions;
using CaseDev.Models.Memory.V1;

namespace CaseDev.Tests.Models.Memory.V1;

public class V1CreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new V1CreateParams
        {
            Messages = [new() { Content = "content", Role = Role.User }],
            Category = "category",
            ExtractionPrompt = "extraction_prompt",
            Infer = true,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Tag1 = "tag_1",
            Tag10 = "tag_10",
            Tag11 = "tag_11",
            Tag12 = "tag_12",
            Tag2 = "tag_2",
            Tag3 = "tag_3",
            Tag4 = "tag_4",
            Tag5 = "tag_5",
            Tag6 = "tag_6",
            Tag7 = "tag_7",
            Tag8 = "tag_8",
            Tag9 = "tag_9",
        };

        List<Message> expectedMessages = [new() { Content = "content", Role = Role.User }];
        string expectedCategory = "category";
        string expectedExtractionPrompt = "extraction_prompt";
        bool expectedInfer = true;
        Dictionary<string, JsonElement> expectedMetadata = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedTag1 = "tag_1";
        string expectedTag10 = "tag_10";
        string expectedTag11 = "tag_11";
        string expectedTag12 = "tag_12";
        string expectedTag2 = "tag_2";
        string expectedTag3 = "tag_3";
        string expectedTag4 = "tag_4";
        string expectedTag5 = "tag_5";
        string expectedTag6 = "tag_6";
        string expectedTag7 = "tag_7";
        string expectedTag8 = "tag_8";
        string expectedTag9 = "tag_9";

        Assert.Equal(expectedMessages.Count, parameters.Messages.Count);
        for (int i = 0; i < expectedMessages.Count; i++)
        {
            Assert.Equal(expectedMessages[i], parameters.Messages[i]);
        }
        Assert.Equal(expectedCategory, parameters.Category);
        Assert.Equal(expectedExtractionPrompt, parameters.ExtractionPrompt);
        Assert.Equal(expectedInfer, parameters.Infer);
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, parameters.Metadata[item.Key]));
        }
        Assert.Equal(expectedTag1, parameters.Tag1);
        Assert.Equal(expectedTag10, parameters.Tag10);
        Assert.Equal(expectedTag11, parameters.Tag11);
        Assert.Equal(expectedTag12, parameters.Tag12);
        Assert.Equal(expectedTag2, parameters.Tag2);
        Assert.Equal(expectedTag3, parameters.Tag3);
        Assert.Equal(expectedTag4, parameters.Tag4);
        Assert.Equal(expectedTag5, parameters.Tag5);
        Assert.Equal(expectedTag6, parameters.Tag6);
        Assert.Equal(expectedTag7, parameters.Tag7);
        Assert.Equal(expectedTag8, parameters.Tag8);
        Assert.Equal(expectedTag9, parameters.Tag9);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new V1CreateParams
        {
            Messages = [new() { Content = "content", Role = Role.User }],
        };

        Assert.Null(parameters.Category);
        Assert.False(parameters.RawBodyData.ContainsKey("category"));
        Assert.Null(parameters.ExtractionPrompt);
        Assert.False(parameters.RawBodyData.ContainsKey("extraction_prompt"));
        Assert.Null(parameters.Infer);
        Assert.False(parameters.RawBodyData.ContainsKey("infer"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Tag1);
        Assert.False(parameters.RawBodyData.ContainsKey("tag_1"));
        Assert.Null(parameters.Tag10);
        Assert.False(parameters.RawBodyData.ContainsKey("tag_10"));
        Assert.Null(parameters.Tag11);
        Assert.False(parameters.RawBodyData.ContainsKey("tag_11"));
        Assert.Null(parameters.Tag12);
        Assert.False(parameters.RawBodyData.ContainsKey("tag_12"));
        Assert.Null(parameters.Tag2);
        Assert.False(parameters.RawBodyData.ContainsKey("tag_2"));
        Assert.Null(parameters.Tag3);
        Assert.False(parameters.RawBodyData.ContainsKey("tag_3"));
        Assert.Null(parameters.Tag4);
        Assert.False(parameters.RawBodyData.ContainsKey("tag_4"));
        Assert.Null(parameters.Tag5);
        Assert.False(parameters.RawBodyData.ContainsKey("tag_5"));
        Assert.Null(parameters.Tag6);
        Assert.False(parameters.RawBodyData.ContainsKey("tag_6"));
        Assert.Null(parameters.Tag7);
        Assert.False(parameters.RawBodyData.ContainsKey("tag_7"));
        Assert.Null(parameters.Tag8);
        Assert.False(parameters.RawBodyData.ContainsKey("tag_8"));
        Assert.Null(parameters.Tag9);
        Assert.False(parameters.RawBodyData.ContainsKey("tag_9"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new V1CreateParams
        {
            Messages = [new() { Content = "content", Role = Role.User }],

            // Null should be interpreted as omitted for these properties
            Category = null,
            ExtractionPrompt = null,
            Infer = null,
            Metadata = null,
            Tag1 = null,
            Tag10 = null,
            Tag11 = null,
            Tag12 = null,
            Tag2 = null,
            Tag3 = null,
            Tag4 = null,
            Tag5 = null,
            Tag6 = null,
            Tag7 = null,
            Tag8 = null,
            Tag9 = null,
        };

        Assert.Null(parameters.Category);
        Assert.False(parameters.RawBodyData.ContainsKey("category"));
        Assert.Null(parameters.ExtractionPrompt);
        Assert.False(parameters.RawBodyData.ContainsKey("extraction_prompt"));
        Assert.Null(parameters.Infer);
        Assert.False(parameters.RawBodyData.ContainsKey("infer"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Tag1);
        Assert.False(parameters.RawBodyData.ContainsKey("tag_1"));
        Assert.Null(parameters.Tag10);
        Assert.False(parameters.RawBodyData.ContainsKey("tag_10"));
        Assert.Null(parameters.Tag11);
        Assert.False(parameters.RawBodyData.ContainsKey("tag_11"));
        Assert.Null(parameters.Tag12);
        Assert.False(parameters.RawBodyData.ContainsKey("tag_12"));
        Assert.Null(parameters.Tag2);
        Assert.False(parameters.RawBodyData.ContainsKey("tag_2"));
        Assert.Null(parameters.Tag3);
        Assert.False(parameters.RawBodyData.ContainsKey("tag_3"));
        Assert.Null(parameters.Tag4);
        Assert.False(parameters.RawBodyData.ContainsKey("tag_4"));
        Assert.Null(parameters.Tag5);
        Assert.False(parameters.RawBodyData.ContainsKey("tag_5"));
        Assert.Null(parameters.Tag6);
        Assert.False(parameters.RawBodyData.ContainsKey("tag_6"));
        Assert.Null(parameters.Tag7);
        Assert.False(parameters.RawBodyData.ContainsKey("tag_7"));
        Assert.Null(parameters.Tag8);
        Assert.False(parameters.RawBodyData.ContainsKey("tag_8"));
        Assert.Null(parameters.Tag9);
        Assert.False(parameters.RawBodyData.ContainsKey("tag_9"));
    }

    [Fact]
    public void Url_Works()
    {
        V1CreateParams parameters = new()
        {
            Messages = [new() { Content = "content", Role = Role.User }],
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/memory/v1"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new V1CreateParams
        {
            Messages = [new() { Content = "content", Role = Role.User }],
            Category = "category",
            ExtractionPrompt = "extraction_prompt",
            Infer = true,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Tag1 = "tag_1",
            Tag10 = "tag_10",
            Tag11 = "tag_11",
            Tag12 = "tag_12",
            Tag2 = "tag_2",
            Tag3 = "tag_3",
            Tag4 = "tag_4",
            Tag5 = "tag_5",
            Tag6 = "tag_6",
            Tag7 = "tag_7",
            Tag8 = "tag_8",
            Tag9 = "tag_9",
        };

        V1CreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class MessageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Message { Content = "content", Role = Role.User };

        string expectedContent = "content";
        ApiEnum<string, Role> expectedRole = Role.User;

        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedRole, model.Role);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Message { Content = "content", Role = Role.User };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Message>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Message { Content = "content", Role = Role.User };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Message>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedContent = "content";
        ApiEnum<string, Role> expectedRole = Role.User;

        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedRole, deserialized.Role);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Message { Content = "content", Role = Role.User };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Message { Content = "content", Role = Role.User };

        Message copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RoleTest : TestBase
{
    [Theory]
    [InlineData(Role.User)]
    [InlineData(Role.Assistant)]
    [InlineData(Role.System)]
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
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Role.User)]
    [InlineData(Role.Assistant)]
    [InlineData(Role.System)]
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
            JsonSerializer.SerializeToElement("invalid value"),
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
