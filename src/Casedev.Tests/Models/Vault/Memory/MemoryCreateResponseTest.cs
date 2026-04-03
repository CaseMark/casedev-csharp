using System;
using System.Collections.Generic;
using System.Text.Json;
using Casedev.Core;
using Casedev.Models.Vault.Memory;

namespace Casedev.Tests.Models.Vault.Memory;

public class MemoryCreateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MemoryCreateResponse
        {
            Entry = new()
            {
                ID = "id",
                Content = "content",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreatedBy = "created_by",
                Source = "source",
                Tags = ["string"],
                Type = "type",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        Entry expectedEntry = new()
        {
            ID = "id",
            Content = "content",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedBy = "created_by",
            Source = "source",
            Tags = ["string"],
            Type = "type",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Equal(expectedEntry, model.Entry);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MemoryCreateResponse
        {
            Entry = new()
            {
                ID = "id",
                Content = "content",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreatedBy = "created_by",
                Source = "source",
                Tags = ["string"],
                Type = "type",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MemoryCreateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MemoryCreateResponse
        {
            Entry = new()
            {
                ID = "id",
                Content = "content",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreatedBy = "created_by",
                Source = "source",
                Tags = ["string"],
                Type = "type",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MemoryCreateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Entry expectedEntry = new()
        {
            ID = "id",
            Content = "content",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedBy = "created_by",
            Source = "source",
            Tags = ["string"],
            Type = "type",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Equal(expectedEntry, deserialized.Entry);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MemoryCreateResponse
        {
            Entry = new()
            {
                ID = "id",
                Content = "content",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreatedBy = "created_by",
                Source = "source",
                Tags = ["string"],
                Type = "type",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new MemoryCreateResponse { };

        Assert.Null(model.Entry);
        Assert.False(model.RawData.ContainsKey("entry"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new MemoryCreateResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new MemoryCreateResponse
        {
            // Null should be interpreted as omitted for these properties
            Entry = null,
        };

        Assert.Null(model.Entry);
        Assert.False(model.RawData.ContainsKey("entry"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new MemoryCreateResponse
        {
            // Null should be interpreted as omitted for these properties
            Entry = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MemoryCreateResponse
        {
            Entry = new()
            {
                ID = "id",
                Content = "content",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreatedBy = "created_by",
                Source = "source",
                Tags = ["string"],
                Type = "type",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        MemoryCreateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Entry
        {
            ID = "id",
            Content = "content",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedBy = "created_by",
            Source = "source",
            Tags = ["string"],
            Type = "type",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "id";
        string expectedContent = "content";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCreatedBy = "created_by";
        string expectedSource = "source";
        List<string> expectedTags = ["string"];
        string expectedType = "type";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCreatedBy, model.CreatedBy);
        Assert.Equal(expectedSource, model.Source);
        Assert.NotNull(model.Tags);
        Assert.Equal(expectedTags.Count, model.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], model.Tags[i]);
        }
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Entry
        {
            ID = "id",
            Content = "content",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedBy = "created_by",
            Source = "source",
            Tags = ["string"],
            Type = "type",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entry>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Entry
        {
            ID = "id",
            Content = "content",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedBy = "created_by",
            Source = "source",
            Tags = ["string"],
            Type = "type",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entry>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedContent = "content";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCreatedBy = "created_by";
        string expectedSource = "source";
        List<string> expectedTags = ["string"];
        string expectedType = "type";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCreatedBy, deserialized.CreatedBy);
        Assert.Equal(expectedSource, deserialized.Source);
        Assert.NotNull(deserialized.Tags);
        Assert.Equal(expectedTags.Count, deserialized.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], deserialized.Tags[i]);
        }
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Entry
        {
            ID = "id",
            Content = "content",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedBy = "created_by",
            Source = "source",
            Tags = ["string"],
            Type = "type",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Entry { CreatedBy = "created_by", Source = "source" };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Content);
        Assert.False(model.RawData.ContainsKey("content"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Entry { CreatedBy = "created_by", Source = "source" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Entry
        {
            CreatedBy = "created_by",
            Source = "source",

            // Null should be interpreted as omitted for these properties
            ID = null,
            Content = null,
            CreatedAt = null,
            Tags = null,
            Type = null,
            UpdatedAt = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Content);
        Assert.False(model.RawData.ContainsKey("content"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Entry
        {
            CreatedBy = "created_by",
            Source = "source",

            // Null should be interpreted as omitted for these properties
            ID = null,
            Content = null,
            CreatedAt = null,
            Tags = null,
            Type = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Entry
        {
            ID = "id",
            Content = "content",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Tags = ["string"],
            Type = "type",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.CreatedBy);
        Assert.False(model.RawData.ContainsKey("created_by"));
        Assert.Null(model.Source);
        Assert.False(model.RawData.ContainsKey("source"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Entry
        {
            ID = "id",
            Content = "content",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Tags = ["string"],
            Type = "type",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Entry
        {
            ID = "id",
            Content = "content",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Tags = ["string"],
            Type = "type",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            CreatedBy = null,
            Source = null,
        };

        Assert.Null(model.CreatedBy);
        Assert.True(model.RawData.ContainsKey("created_by"));
        Assert.Null(model.Source);
        Assert.True(model.RawData.ContainsKey("source"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Entry
        {
            ID = "id",
            Content = "content",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Tags = ["string"],
            Type = "type",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            CreatedBy = null,
            Source = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Entry
        {
            ID = "id",
            Content = "content",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedBy = "created_by",
            Source = "source",
            Tags = ["string"],
            Type = "type",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Entry copied = new(model);

        Assert.Equal(model, copied);
    }
}
