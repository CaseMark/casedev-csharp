using System;
using System.Collections.Generic;
using System.Text.Json;
using CaseDev.Core;
using CaseDev.Models.Memory.V1;

namespace CaseDev.Tests.Models.Memory.V1;

public class V1ListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new V1ListResponse
        {
            Count = 0,
            Results =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Memory = "memory",
                    Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Tags = JsonSerializer.Deserialize<JsonElement>("{}"),
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        long expectedCount = 0;
        List<V1ListResponseResult> expectedResults =
        [
            new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Memory = "memory",
                Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                Tags = JsonSerializer.Deserialize<JsonElement>("{}"),
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];

        Assert.Equal(expectedCount, model.Count);
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
        var model = new V1ListResponse
        {
            Count = 0,
            Results =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Memory = "memory",
                    Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Tags = JsonSerializer.Deserialize<JsonElement>("{}"),
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1ListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new V1ListResponse
        {
            Count = 0,
            Results =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Memory = "memory",
                    Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Tags = JsonSerializer.Deserialize<JsonElement>("{}"),
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1ListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedCount = 0;
        List<V1ListResponseResult> expectedResults =
        [
            new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Memory = "memory",
                Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                Tags = JsonSerializer.Deserialize<JsonElement>("{}"),
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];

        Assert.Equal(expectedCount, deserialized.Count);
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
        var model = new V1ListResponse
        {
            Count = 0,
            Results =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Memory = "memory",
                    Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Tags = JsonSerializer.Deserialize<JsonElement>("{}"),
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new V1ListResponse { };

        Assert.Null(model.Count);
        Assert.False(model.RawData.ContainsKey("count"));
        Assert.Null(model.Results);
        Assert.False(model.RawData.ContainsKey("results"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new V1ListResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new V1ListResponse
        {
            // Null should be interpreted as omitted for these properties
            Count = null,
            Results = null,
        };

        Assert.Null(model.Count);
        Assert.False(model.RawData.ContainsKey("count"));
        Assert.Null(model.Results);
        Assert.False(model.RawData.ContainsKey("results"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new V1ListResponse
        {
            // Null should be interpreted as omitted for these properties
            Count = null,
            Results = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new V1ListResponse
        {
            Count = 0,
            Results =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Memory = "memory",
                    Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Tags = JsonSerializer.Deserialize<JsonElement>("{}"),
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        V1ListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class V1ListResponseResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new V1ListResponseResult
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Memory = "memory",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Tags = JsonSerializer.Deserialize<JsonElement>("{}"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedMemory = "memory";
        JsonElement expectedMetadata = JsonSerializer.Deserialize<JsonElement>("{}");
        JsonElement expectedTags = JsonSerializer.Deserialize<JsonElement>("{}");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedMemory, model.Memory);
        Assert.NotNull(model.Metadata);
        Assert.True(JsonElement.DeepEquals(expectedMetadata, model.Metadata.Value));
        Assert.NotNull(model.Tags);
        Assert.True(JsonElement.DeepEquals(expectedTags, model.Tags.Value));
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new V1ListResponseResult
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Memory = "memory",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Tags = JsonSerializer.Deserialize<JsonElement>("{}"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1ListResponseResult>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new V1ListResponseResult
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Memory = "memory",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Tags = JsonSerializer.Deserialize<JsonElement>("{}"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1ListResponseResult>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedMemory = "memory";
        JsonElement expectedMetadata = JsonSerializer.Deserialize<JsonElement>("{}");
        JsonElement expectedTags = JsonSerializer.Deserialize<JsonElement>("{}");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedMemory, deserialized.Memory);
        Assert.NotNull(deserialized.Metadata);
        Assert.True(JsonElement.DeepEquals(expectedMetadata, deserialized.Metadata.Value));
        Assert.NotNull(deserialized.Tags);
        Assert.True(JsonElement.DeepEquals(expectedTags, deserialized.Tags.Value));
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new V1ListResponseResult
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Memory = "memory",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Tags = JsonSerializer.Deserialize<JsonElement>("{}"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new V1ListResponseResult { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.Memory);
        Assert.False(model.RawData.ContainsKey("memory"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new V1ListResponseResult { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new V1ListResponseResult
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            CreatedAt = null,
            Memory = null,
            Metadata = null,
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
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new V1ListResponseResult
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            CreatedAt = null,
            Memory = null,
            Metadata = null,
            Tags = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new V1ListResponseResult
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Memory = "memory",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Tags = JsonSerializer.Deserialize<JsonElement>("{}"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        V1ListResponseResult copied = new(model);

        Assert.Equal(model, copied);
    }
}
