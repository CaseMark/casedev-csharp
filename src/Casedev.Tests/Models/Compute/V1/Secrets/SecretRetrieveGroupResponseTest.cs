using System;
using System.Collections.Generic;
using System.Text.Json;
using Casedev.Core;
using Casedev.Models.Compute.V1.Secrets;

namespace Casedev.Tests.Models.Compute.V1.Secrets;

public class SecretRetrieveGroupResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SecretRetrieveGroupResponse
        {
            Group = new()
            {
                ID = "id",
                Description = "description",
                Name = "name",
            },
            Keys =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    KeyValue = "key",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        SecretRetrieveGroupResponseGroup expectedGroup = new()
        {
            ID = "id",
            Description = "description",
            Name = "name",
        };
        List<Key> expectedKeys =
        [
            new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                KeyValue = "key",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];

        Assert.Equal(expectedGroup, model.Group);
        Assert.NotNull(model.Keys);
        Assert.Equal(expectedKeys.Count, model.Keys.Count);
        for (int i = 0; i < expectedKeys.Count; i++)
        {
            Assert.Equal(expectedKeys[i], model.Keys[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SecretRetrieveGroupResponse
        {
            Group = new()
            {
                ID = "id",
                Description = "description",
                Name = "name",
            },
            Keys =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    KeyValue = "key",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SecretRetrieveGroupResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SecretRetrieveGroupResponse
        {
            Group = new()
            {
                ID = "id",
                Description = "description",
                Name = "name",
            },
            Keys =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    KeyValue = "key",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SecretRetrieveGroupResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        SecretRetrieveGroupResponseGroup expectedGroup = new()
        {
            ID = "id",
            Description = "description",
            Name = "name",
        };
        List<Key> expectedKeys =
        [
            new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                KeyValue = "key",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];

        Assert.Equal(expectedGroup, deserialized.Group);
        Assert.NotNull(deserialized.Keys);
        Assert.Equal(expectedKeys.Count, deserialized.Keys.Count);
        for (int i = 0; i < expectedKeys.Count; i++)
        {
            Assert.Equal(expectedKeys[i], deserialized.Keys[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SecretRetrieveGroupResponse
        {
            Group = new()
            {
                ID = "id",
                Description = "description",
                Name = "name",
            },
            Keys =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    KeyValue = "key",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SecretRetrieveGroupResponse { };

        Assert.Null(model.Group);
        Assert.False(model.RawData.ContainsKey("group"));
        Assert.Null(model.Keys);
        Assert.False(model.RawData.ContainsKey("keys"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SecretRetrieveGroupResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SecretRetrieveGroupResponse
        {
            // Null should be interpreted as omitted for these properties
            Group = null,
            Keys = null,
        };

        Assert.Null(model.Group);
        Assert.False(model.RawData.ContainsKey("group"));
        Assert.Null(model.Keys);
        Assert.False(model.RawData.ContainsKey("keys"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SecretRetrieveGroupResponse
        {
            // Null should be interpreted as omitted for these properties
            Group = null,
            Keys = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SecretRetrieveGroupResponse
        {
            Group = new()
            {
                ID = "id",
                Description = "description",
                Name = "name",
            },
            Keys =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    KeyValue = "key",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        SecretRetrieveGroupResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SecretRetrieveGroupResponseGroupTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SecretRetrieveGroupResponseGroup
        {
            ID = "id",
            Description = "description",
            Name = "name",
        };

        string expectedID = "id";
        string expectedDescription = "description";
        string expectedName = "name";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SecretRetrieveGroupResponseGroup
        {
            ID = "id",
            Description = "description",
            Name = "name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SecretRetrieveGroupResponseGroup>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SecretRetrieveGroupResponseGroup
        {
            ID = "id",
            Description = "description",
            Name = "name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SecretRetrieveGroupResponseGroup>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedDescription = "description";
        string expectedName = "name";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SecretRetrieveGroupResponseGroup
        {
            ID = "id",
            Description = "description",
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SecretRetrieveGroupResponseGroup { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SecretRetrieveGroupResponseGroup { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SecretRetrieveGroupResponseGroup
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            Description = null,
            Name = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SecretRetrieveGroupResponseGroup
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            Description = null,
            Name = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SecretRetrieveGroupResponseGroup
        {
            ID = "id",
            Description = "description",
            Name = "name",
        };

        SecretRetrieveGroupResponseGroup copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class KeyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Key
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            KeyValue = "key",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedKeyValue = "key";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedKeyValue, model.KeyValue);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Key
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            KeyValue = "key",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Key>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Key
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            KeyValue = "key",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Key>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedKeyValue = "key";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedKeyValue, deserialized.KeyValue);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Key
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            KeyValue = "key",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Key { };

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.KeyValue);
        Assert.False(model.RawData.ContainsKey("key"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updatedAt"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Key { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Key
        {
            // Null should be interpreted as omitted for these properties
            CreatedAt = null,
            KeyValue = null,
            UpdatedAt = null,
        };

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.KeyValue);
        Assert.False(model.RawData.ContainsKey("key"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updatedAt"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Key
        {
            // Null should be interpreted as omitted for these properties
            CreatedAt = null,
            KeyValue = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Key
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            KeyValue = "key",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Key copied = new(model);

        Assert.Equal(model, copied);
    }
}
