using System;
using System.Collections.Generic;
using System.Text.Json;
using CaseDev.Core;
using CaseDev.Models.Memory.V1;

namespace CaseDev.Tests.Models.Memory.V1;

public class V1SearchResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new V1SearchResponse
        {
            Results =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Memory = "memory",
                    Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Score = 0,
                    Tags = new()
                    {
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
                    },
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        List<V1SearchResponseResult> expectedResults =
        [
            new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Memory = "memory",
                Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                Score = 0,
                Tags = new()
                {
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
                },
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];

        Assert.NotNull(model.Results);
        Assert.Equal(expectedResults.Count, model.Results.Count);
        for (int i = 0; i < expectedResults.Count; i++)
        {
            Assert.Equal(expectedResults[i], model.Results[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new V1SearchResponse
        {
            Results =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Memory = "memory",
                    Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Score = 0,
                    Tags = new()
                    {
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
                    },
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1SearchResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new V1SearchResponse
        {
            Results =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Memory = "memory",
                    Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Score = 0,
                    Tags = new()
                    {
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
                    },
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1SearchResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<V1SearchResponseResult> expectedResults =
        [
            new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Memory = "memory",
                Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                Score = 0,
                Tags = new()
                {
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
                },
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];

        Assert.NotNull(deserialized.Results);
        Assert.Equal(expectedResults.Count, deserialized.Results.Count);
        for (int i = 0; i < expectedResults.Count; i++)
        {
            Assert.Equal(expectedResults[i], deserialized.Results[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new V1SearchResponse
        {
            Results =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Memory = "memory",
                    Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Score = 0,
                    Tags = new()
                    {
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
                    },
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new V1SearchResponse { };

        Assert.Null(model.Results);
        Assert.False(model.RawData.ContainsKey("results"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new V1SearchResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new V1SearchResponse
        {
            // Null should be interpreted as omitted for these properties
            Results = null,
        };

        Assert.Null(model.Results);
        Assert.False(model.RawData.ContainsKey("results"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new V1SearchResponse
        {
            // Null should be interpreted as omitted for these properties
            Results = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new V1SearchResponse
        {
            Results =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Memory = "memory",
                    Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Score = 0,
                    Tags = new()
                    {
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
                    },
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        V1SearchResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class V1SearchResponseResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new V1SearchResponseResult
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Memory = "memory",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Score = 0,
            Tags = new()
            {
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
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedMemory = "memory";
        JsonElement expectedMetadata = JsonSerializer.Deserialize<JsonElement>("{}");
        double expectedScore = 0;
        Tags expectedTags = new()
        {
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
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedMemory, model.Memory);
        Assert.NotNull(model.Metadata);
        Assert.True(JsonElement.DeepEquals(expectedMetadata, model.Metadata.Value));
        Assert.Equal(expectedScore, model.Score);
        Assert.Equal(expectedTags, model.Tags);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new V1SearchResponseResult
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Memory = "memory",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Score = 0,
            Tags = new()
            {
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
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1SearchResponseResult>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new V1SearchResponseResult
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Memory = "memory",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Score = 0,
            Tags = new()
            {
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
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1SearchResponseResult>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedMemory = "memory";
        JsonElement expectedMetadata = JsonSerializer.Deserialize<JsonElement>("{}");
        double expectedScore = 0;
        Tags expectedTags = new()
        {
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
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedMemory, deserialized.Memory);
        Assert.NotNull(deserialized.Metadata);
        Assert.True(JsonElement.DeepEquals(expectedMetadata, deserialized.Metadata.Value));
        Assert.Equal(expectedScore, deserialized.Score);
        Assert.Equal(expectedTags, deserialized.Tags);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new V1SearchResponseResult
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Memory = "memory",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Score = 0,
            Tags = new()
            {
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
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new V1SearchResponseResult { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.Memory);
        Assert.False(model.RawData.ContainsKey("memory"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.Score);
        Assert.False(model.RawData.ContainsKey("score"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new V1SearchResponseResult { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new V1SearchResponseResult
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            CreatedAt = null,
            Memory = null,
            Metadata = null,
            Score = null,
            Tags = null,
            UpdatedAt = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.Memory);
        Assert.False(model.RawData.ContainsKey("memory"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.Score);
        Assert.False(model.RawData.ContainsKey("score"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new V1SearchResponseResult
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            CreatedAt = null,
            Memory = null,
            Metadata = null,
            Score = null,
            Tags = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new V1SearchResponseResult
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Memory = "memory",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Score = 0,
            Tags = new()
            {
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
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        V1SearchResponseResult copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TagsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Tags
        {
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

        Assert.Equal(expectedTag1, model.Tag1);
        Assert.Equal(expectedTag10, model.Tag10);
        Assert.Equal(expectedTag11, model.Tag11);
        Assert.Equal(expectedTag12, model.Tag12);
        Assert.Equal(expectedTag2, model.Tag2);
        Assert.Equal(expectedTag3, model.Tag3);
        Assert.Equal(expectedTag4, model.Tag4);
        Assert.Equal(expectedTag5, model.Tag5);
        Assert.Equal(expectedTag6, model.Tag6);
        Assert.Equal(expectedTag7, model.Tag7);
        Assert.Equal(expectedTag8, model.Tag8);
        Assert.Equal(expectedTag9, model.Tag9);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Tags
        {
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Tags>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Tags
        {
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Tags>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

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

        Assert.Equal(expectedTag1, deserialized.Tag1);
        Assert.Equal(expectedTag10, deserialized.Tag10);
        Assert.Equal(expectedTag11, deserialized.Tag11);
        Assert.Equal(expectedTag12, deserialized.Tag12);
        Assert.Equal(expectedTag2, deserialized.Tag2);
        Assert.Equal(expectedTag3, deserialized.Tag3);
        Assert.Equal(expectedTag4, deserialized.Tag4);
        Assert.Equal(expectedTag5, deserialized.Tag5);
        Assert.Equal(expectedTag6, deserialized.Tag6);
        Assert.Equal(expectedTag7, deserialized.Tag7);
        Assert.Equal(expectedTag8, deserialized.Tag8);
        Assert.Equal(expectedTag9, deserialized.Tag9);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Tags
        {
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Tags { };

        Assert.Null(model.Tag1);
        Assert.False(model.RawData.ContainsKey("tag_1"));
        Assert.Null(model.Tag10);
        Assert.False(model.RawData.ContainsKey("tag_10"));
        Assert.Null(model.Tag11);
        Assert.False(model.RawData.ContainsKey("tag_11"));
        Assert.Null(model.Tag12);
        Assert.False(model.RawData.ContainsKey("tag_12"));
        Assert.Null(model.Tag2);
        Assert.False(model.RawData.ContainsKey("tag_2"));
        Assert.Null(model.Tag3);
        Assert.False(model.RawData.ContainsKey("tag_3"));
        Assert.Null(model.Tag4);
        Assert.False(model.RawData.ContainsKey("tag_4"));
        Assert.Null(model.Tag5);
        Assert.False(model.RawData.ContainsKey("tag_5"));
        Assert.Null(model.Tag6);
        Assert.False(model.RawData.ContainsKey("tag_6"));
        Assert.Null(model.Tag7);
        Assert.False(model.RawData.ContainsKey("tag_7"));
        Assert.Null(model.Tag8);
        Assert.False(model.RawData.ContainsKey("tag_8"));
        Assert.Null(model.Tag9);
        Assert.False(model.RawData.ContainsKey("tag_9"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Tags { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Tags
        {
            // Null should be interpreted as omitted for these properties
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

        Assert.Null(model.Tag1);
        Assert.False(model.RawData.ContainsKey("tag_1"));
        Assert.Null(model.Tag10);
        Assert.False(model.RawData.ContainsKey("tag_10"));
        Assert.Null(model.Tag11);
        Assert.False(model.RawData.ContainsKey("tag_11"));
        Assert.Null(model.Tag12);
        Assert.False(model.RawData.ContainsKey("tag_12"));
        Assert.Null(model.Tag2);
        Assert.False(model.RawData.ContainsKey("tag_2"));
        Assert.Null(model.Tag3);
        Assert.False(model.RawData.ContainsKey("tag_3"));
        Assert.Null(model.Tag4);
        Assert.False(model.RawData.ContainsKey("tag_4"));
        Assert.Null(model.Tag5);
        Assert.False(model.RawData.ContainsKey("tag_5"));
        Assert.Null(model.Tag6);
        Assert.False(model.RawData.ContainsKey("tag_6"));
        Assert.Null(model.Tag7);
        Assert.False(model.RawData.ContainsKey("tag_7"));
        Assert.Null(model.Tag8);
        Assert.False(model.RawData.ContainsKey("tag_8"));
        Assert.Null(model.Tag9);
        Assert.False(model.RawData.ContainsKey("tag_9"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Tags
        {
            // Null should be interpreted as omitted for these properties
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

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Tags
        {
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

        Tags copied = new(model);

        Assert.Equal(model, copied);
    }
}
