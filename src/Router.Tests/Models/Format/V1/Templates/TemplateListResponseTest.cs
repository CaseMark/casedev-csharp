using System;
using System.Collections.Generic;
using System.Text.Json;
using Router.Core;
using Router.Models.Format.V1.Templates;

namespace Router.Tests.Models.Format.V1.Templates;

public class TemplateListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TemplateListResponse
        {
            Templates =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    Name = "name",
                    Tags = [JsonSerializer.Deserialize<JsonElement>("{}")],
                    Type = "type",
                    UsageCount = 0,
                    Variables = [JsonSerializer.Deserialize<JsonElement>("{}")],
                },
            ],
        };

        List<Template> expectedTemplates =
        [
            new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                Name = "name",
                Tags = [JsonSerializer.Deserialize<JsonElement>("{}")],
                Type = "type",
                UsageCount = 0,
                Variables = [JsonSerializer.Deserialize<JsonElement>("{}")],
            },
        ];

        Assert.NotNull(model.Templates);
        Assert.Equal(expectedTemplates.Count, model.Templates.Count);
        for (int i = 0; i < expectedTemplates.Count; i++)
        {
            Assert.Equal(expectedTemplates[i], model.Templates[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TemplateListResponse
        {
            Templates =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    Name = "name",
                    Tags = [JsonSerializer.Deserialize<JsonElement>("{}")],
                    Type = "type",
                    UsageCount = 0,
                    Variables = [JsonSerializer.Deserialize<JsonElement>("{}")],
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TemplateListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TemplateListResponse
        {
            Templates =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    Name = "name",
                    Tags = [JsonSerializer.Deserialize<JsonElement>("{}")],
                    Type = "type",
                    UsageCount = 0,
                    Variables = [JsonSerializer.Deserialize<JsonElement>("{}")],
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TemplateListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Template> expectedTemplates =
        [
            new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                Name = "name",
                Tags = [JsonSerializer.Deserialize<JsonElement>("{}")],
                Type = "type",
                UsageCount = 0,
                Variables = [JsonSerializer.Deserialize<JsonElement>("{}")],
            },
        ];

        Assert.NotNull(deserialized.Templates);
        Assert.Equal(expectedTemplates.Count, deserialized.Templates.Count);
        for (int i = 0; i < expectedTemplates.Count; i++)
        {
            Assert.Equal(expectedTemplates[i], deserialized.Templates[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TemplateListResponse
        {
            Templates =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    Name = "name",
                    Tags = [JsonSerializer.Deserialize<JsonElement>("{}")],
                    Type = "type",
                    UsageCount = 0,
                    Variables = [JsonSerializer.Deserialize<JsonElement>("{}")],
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TemplateListResponse { };

        Assert.Null(model.Templates);
        Assert.False(model.RawData.ContainsKey("templates"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new TemplateListResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TemplateListResponse
        {
            // Null should be interpreted as omitted for these properties
            Templates = null,
        };

        Assert.Null(model.Templates);
        Assert.False(model.RawData.ContainsKey("templates"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TemplateListResponse
        {
            // Null should be interpreted as omitted for these properties
            Templates = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TemplateListResponse
        {
            Templates =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    Name = "name",
                    Tags = [JsonSerializer.Deserialize<JsonElement>("{}")],
                    Type = "type",
                    UsageCount = 0,
                    Variables = [JsonSerializer.Deserialize<JsonElement>("{}")],
                },
            ],
        };

        TemplateListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TemplateTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Template
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            Name = "name",
            Tags = [JsonSerializer.Deserialize<JsonElement>("{}")],
            Type = "type",
            UsageCount = 0,
            Variables = [JsonSerializer.Deserialize<JsonElement>("{}")],
        };

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        string expectedName = "name";
        List<JsonElement> expectedTags = [JsonSerializer.Deserialize<JsonElement>("{}")];
        string expectedType = "type";
        long expectedUsageCount = 0;
        List<JsonElement> expectedVariables = [JsonSerializer.Deserialize<JsonElement>("{}")];

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedName, model.Name);
        Assert.NotNull(model.Tags);
        Assert.Equal(expectedTags.Count, model.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.True(JsonElement.DeepEquals(expectedTags[i], model.Tags[i]));
        }
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUsageCount, model.UsageCount);
        Assert.NotNull(model.Variables);
        Assert.Equal(expectedVariables.Count, model.Variables.Count);
        for (int i = 0; i < expectedVariables.Count; i++)
        {
            Assert.True(JsonElement.DeepEquals(expectedVariables[i], model.Variables[i]));
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Template
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            Name = "name",
            Tags = [JsonSerializer.Deserialize<JsonElement>("{}")],
            Type = "type",
            UsageCount = 0,
            Variables = [JsonSerializer.Deserialize<JsonElement>("{}")],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Template>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Template
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            Name = "name",
            Tags = [JsonSerializer.Deserialize<JsonElement>("{}")],
            Type = "type",
            UsageCount = 0,
            Variables = [JsonSerializer.Deserialize<JsonElement>("{}")],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Template>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        string expectedName = "name";
        List<JsonElement> expectedTags = [JsonSerializer.Deserialize<JsonElement>("{}")];
        string expectedType = "type";
        long expectedUsageCount = 0;
        List<JsonElement> expectedVariables = [JsonSerializer.Deserialize<JsonElement>("{}")];

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.NotNull(deserialized.Tags);
        Assert.Equal(expectedTags.Count, deserialized.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.True(JsonElement.DeepEquals(expectedTags[i], deserialized.Tags[i]));
        }
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedUsageCount, deserialized.UsageCount);
        Assert.NotNull(deserialized.Variables);
        Assert.Equal(expectedVariables.Count, deserialized.Variables.Count);
        for (int i = 0; i < expectedVariables.Count; i++)
        {
            Assert.True(JsonElement.DeepEquals(expectedVariables[i], deserialized.Variables[i]));
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Template
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            Name = "name",
            Tags = [JsonSerializer.Deserialize<JsonElement>("{}")],
            Type = "type",
            UsageCount = 0,
            Variables = [JsonSerializer.Deserialize<JsonElement>("{}")],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Template { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.UsageCount);
        Assert.False(model.RawData.ContainsKey("usageCount"));
        Assert.Null(model.Variables);
        Assert.False(model.RawData.ContainsKey("variables"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Template { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Template
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            CreatedAt = null,
            Description = null,
            Name = null,
            Tags = null,
            Type = null,
            UsageCount = null,
            Variables = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.UsageCount);
        Assert.False(model.RawData.ContainsKey("usageCount"));
        Assert.Null(model.Variables);
        Assert.False(model.RawData.ContainsKey("variables"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Template
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            CreatedAt = null,
            Description = null,
            Name = null,
            Tags = null,
            Type = null,
            UsageCount = null,
            Variables = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Template
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            Name = "name",
            Tags = [JsonSerializer.Deserialize<JsonElement>("{}")],
            Type = "type",
            UsageCount = 0,
            Variables = [JsonSerializer.Deserialize<JsonElement>("{}")],
        };

        Template copied = new(model);

        Assert.Equal(model, copied);
    }
}
