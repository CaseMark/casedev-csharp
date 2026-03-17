using System;
using System.Collections.Generic;
using System.Text.Json;
using Casedev.Core;
using Casedev.Models.Skills.Custom;

namespace Casedev.Tests.Models.Skills.Custom;

public class CustomListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomListResponse
        {
            HasMore = true,
            NextCursor = "next_cursor",
            Skills =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Name = "name",
                    Slug = "slug",
                    Summary = "summary",
                    Tags = ["string"],
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Version = 0,
                },
            ],
        };

        bool expectedHasMore = true;
        string expectedNextCursor = "next_cursor";
        List<Skill> expectedSkills =
        [
            new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                Name = "name",
                Slug = "slug",
                Summary = "summary",
                Tags = ["string"],
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = 0,
            },
        ];

        Assert.Equal(expectedHasMore, model.HasMore);
        Assert.Equal(expectedNextCursor, model.NextCursor);
        Assert.NotNull(model.Skills);
        Assert.Equal(expectedSkills.Count, model.Skills.Count);
        for (int i = 0; i < expectedSkills.Count; i++)
        {
            Assert.Equal(expectedSkills[i], model.Skills[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CustomListResponse
        {
            HasMore = true,
            NextCursor = "next_cursor",
            Skills =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Name = "name",
                    Slug = "slug",
                    Summary = "summary",
                    Tags = ["string"],
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Version = 0,
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CustomListResponse
        {
            HasMore = true,
            NextCursor = "next_cursor",
            Skills =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Name = "name",
                    Slug = "slug",
                    Summary = "summary",
                    Tags = ["string"],
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Version = 0,
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedHasMore = true;
        string expectedNextCursor = "next_cursor";
        List<Skill> expectedSkills =
        [
            new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                Name = "name",
                Slug = "slug",
                Summary = "summary",
                Tags = ["string"],
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = 0,
            },
        ];

        Assert.Equal(expectedHasMore, deserialized.HasMore);
        Assert.Equal(expectedNextCursor, deserialized.NextCursor);
        Assert.NotNull(deserialized.Skills);
        Assert.Equal(expectedSkills.Count, deserialized.Skills.Count);
        for (int i = 0; i < expectedSkills.Count; i++)
        {
            Assert.Equal(expectedSkills[i], deserialized.Skills[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CustomListResponse
        {
            HasMore = true,
            NextCursor = "next_cursor",
            Skills =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Name = "name",
                    Slug = "slug",
                    Summary = "summary",
                    Tags = ["string"],
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Version = 0,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CustomListResponse { NextCursor = "next_cursor" };

        Assert.Null(model.HasMore);
        Assert.False(model.RawData.ContainsKey("has_more"));
        Assert.Null(model.Skills);
        Assert.False(model.RawData.ContainsKey("skills"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CustomListResponse { NextCursor = "next_cursor" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CustomListResponse
        {
            NextCursor = "next_cursor",

            // Null should be interpreted as omitted for these properties
            HasMore = null,
            Skills = null,
        };

        Assert.Null(model.HasMore);
        Assert.False(model.RawData.ContainsKey("has_more"));
        Assert.Null(model.Skills);
        Assert.False(model.RawData.ContainsKey("skills"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CustomListResponse
        {
            NextCursor = "next_cursor",

            // Null should be interpreted as omitted for these properties
            HasMore = null,
            Skills = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CustomListResponse
        {
            HasMore = true,
            Skills =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Name = "name",
                    Slug = "slug",
                    Summary = "summary",
                    Tags = ["string"],
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Version = 0,
                },
            ],
        };

        Assert.Null(model.NextCursor);
        Assert.False(model.RawData.ContainsKey("next_cursor"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CustomListResponse
        {
            HasMore = true,
            Skills =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Name = "name",
                    Slug = "slug",
                    Summary = "summary",
                    Tags = ["string"],
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Version = 0,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CustomListResponse
        {
            HasMore = true,
            Skills =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Name = "name",
                    Slug = "slug",
                    Summary = "summary",
                    Tags = ["string"],
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Version = 0,
                },
            ],

            NextCursor = null,
        };

        Assert.Null(model.NextCursor);
        Assert.True(model.RawData.ContainsKey("next_cursor"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CustomListResponse
        {
            HasMore = true,
            Skills =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Name = "name",
                    Slug = "slug",
                    Summary = "summary",
                    Tags = ["string"],
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Version = 0,
                },
            ],

            NextCursor = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CustomListResponse
        {
            HasMore = true,
            NextCursor = "next_cursor",
            Skills =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Name = "name",
                    Slug = "slug",
                    Summary = "summary",
                    Tags = ["string"],
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Version = 0,
                },
            ],
        };

        CustomListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SkillTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Skill
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "name",
            Slug = "slug",
            Summary = "summary",
            Tags = ["string"],
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Version = 0,
        };

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        JsonElement expectedMetadata = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedName = "name";
        string expectedSlug = "slug";
        string expectedSummary = "summary";
        List<string> expectedTags = ["string"];
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedVersion = 0;

        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.NotNull(model.Metadata);
        Assert.True(JsonElement.DeepEquals(expectedMetadata, model.Metadata.Value));
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedSlug, model.Slug);
        Assert.Equal(expectedSummary, model.Summary);
        Assert.NotNull(model.Tags);
        Assert.Equal(expectedTags.Count, model.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], model.Tags[i]);
        }
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedVersion, model.Version);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Skill
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "name",
            Slug = "slug",
            Summary = "summary",
            Tags = ["string"],
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Version = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Skill>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Skill
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "name",
            Slug = "slug",
            Summary = "summary",
            Tags = ["string"],
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Version = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Skill>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        JsonElement expectedMetadata = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedName = "name";
        string expectedSlug = "slug";
        string expectedSummary = "summary";
        List<string> expectedTags = ["string"];
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedVersion = 0;

        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.NotNull(deserialized.Metadata);
        Assert.True(JsonElement.DeepEquals(expectedMetadata, deserialized.Metadata.Value));
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedSlug, deserialized.Slug);
        Assert.Equal(expectedSummary, deserialized.Summary);
        Assert.NotNull(deserialized.Tags);
        Assert.Equal(expectedTags.Count, deserialized.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], deserialized.Tags[i]);
        }
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedVersion, deserialized.Version);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Skill
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "name",
            Slug = "slug",
            Summary = "summary",
            Tags = ["string"],
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Version = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Skill { Summary = "summary" };

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Slug);
        Assert.False(model.RawData.ContainsKey("slug"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
        Assert.Null(model.Version);
        Assert.False(model.RawData.ContainsKey("version"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Skill { Summary = "summary" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Skill
        {
            Summary = "summary",

            // Null should be interpreted as omitted for these properties
            CreatedAt = null,
            Metadata = null,
            Name = null,
            Slug = null,
            Tags = null,
            UpdatedAt = null,
            Version = null,
        };

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Slug);
        Assert.False(model.RawData.ContainsKey("slug"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
        Assert.Null(model.Version);
        Assert.False(model.RawData.ContainsKey("version"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Skill
        {
            Summary = "summary",

            // Null should be interpreted as omitted for these properties
            CreatedAt = null,
            Metadata = null,
            Name = null,
            Slug = null,
            Tags = null,
            UpdatedAt = null,
            Version = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Skill
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "name",
            Slug = "slug",
            Tags = ["string"],
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Version = 0,
        };

        Assert.Null(model.Summary);
        Assert.False(model.RawData.ContainsKey("summary"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Skill
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "name",
            Slug = "slug",
            Tags = ["string"],
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Version = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Skill
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "name",
            Slug = "slug",
            Tags = ["string"],
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Version = 0,

            Summary = null,
        };

        Assert.Null(model.Summary);
        Assert.True(model.RawData.ContainsKey("summary"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Skill
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "name",
            Slug = "slug",
            Tags = ["string"],
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Version = 0,

            Summary = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Skill
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "name",
            Slug = "slug",
            Summary = "summary",
            Tags = ["string"],
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Version = 0,
        };

        Skill copied = new(model);

        Assert.Equal(model, copied);
    }
}
