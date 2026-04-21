using System;
using System.Text.Json;
using Casedev.Core;
using Casedev.Models.Vault;

namespace Casedev.Tests.Models.Vault;

public class VaultCreateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VaultCreateResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            EmbeddingProfile = new()
            {
                Dimensions = 0,
                Model = "model",
                Provider = "provider",
            },
            EnableIndexing = true,
            FilesBucket = "filesBucket",
            IndexName = "indexName",
            Name = "name",
            Region = "region",
            VectorBucket = "vectorBucket",
        };

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        EmbeddingProfile expectedEmbeddingProfile = new()
        {
            Dimensions = 0,
            Model = "model",
            Provider = "provider",
        };
        bool expectedEnableIndexing = true;
        string expectedFilesBucket = "filesBucket";
        string expectedIndexName = "indexName";
        string expectedName = "name";
        string expectedRegion = "region";
        string expectedVectorBucket = "vectorBucket";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedEmbeddingProfile, model.EmbeddingProfile);
        Assert.Equal(expectedEnableIndexing, model.EnableIndexing);
        Assert.Equal(expectedFilesBucket, model.FilesBucket);
        Assert.Equal(expectedIndexName, model.IndexName);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedRegion, model.Region);
        Assert.Equal(expectedVectorBucket, model.VectorBucket);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VaultCreateResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            EmbeddingProfile = new()
            {
                Dimensions = 0,
                Model = "model",
                Provider = "provider",
            },
            EnableIndexing = true,
            FilesBucket = "filesBucket",
            IndexName = "indexName",
            Name = "name",
            Region = "region",
            VectorBucket = "vectorBucket",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VaultCreateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VaultCreateResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            EmbeddingProfile = new()
            {
                Dimensions = 0,
                Model = "model",
                Provider = "provider",
            },
            EnableIndexing = true,
            FilesBucket = "filesBucket",
            IndexName = "indexName",
            Name = "name",
            Region = "region",
            VectorBucket = "vectorBucket",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VaultCreateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        EmbeddingProfile expectedEmbeddingProfile = new()
        {
            Dimensions = 0,
            Model = "model",
            Provider = "provider",
        };
        bool expectedEnableIndexing = true;
        string expectedFilesBucket = "filesBucket";
        string expectedIndexName = "indexName";
        string expectedName = "name";
        string expectedRegion = "region";
        string expectedVectorBucket = "vectorBucket";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedEmbeddingProfile, deserialized.EmbeddingProfile);
        Assert.Equal(expectedEnableIndexing, deserialized.EnableIndexing);
        Assert.Equal(expectedFilesBucket, deserialized.FilesBucket);
        Assert.Equal(expectedIndexName, deserialized.IndexName);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedRegion, deserialized.Region);
        Assert.Equal(expectedVectorBucket, deserialized.VectorBucket);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VaultCreateResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            EmbeddingProfile = new()
            {
                Dimensions = 0,
                Model = "model",
                Provider = "provider",
            },
            EnableIndexing = true,
            FilesBucket = "filesBucket",
            IndexName = "indexName",
            Name = "name",
            Region = "region",
            VectorBucket = "vectorBucket",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VaultCreateResponse
        {
            EmbeddingProfile = new()
            {
                Dimensions = 0,
                Model = "model",
                Provider = "provider",
            },
            IndexName = "indexName",
            VectorBucket = "vectorBucket",
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.EnableIndexing);
        Assert.False(model.RawData.ContainsKey("enableIndexing"));
        Assert.Null(model.FilesBucket);
        Assert.False(model.RawData.ContainsKey("filesBucket"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Region);
        Assert.False(model.RawData.ContainsKey("region"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new VaultCreateResponse
        {
            EmbeddingProfile = new()
            {
                Dimensions = 0,
                Model = "model",
                Provider = "provider",
            },
            IndexName = "indexName",
            VectorBucket = "vectorBucket",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new VaultCreateResponse
        {
            EmbeddingProfile = new()
            {
                Dimensions = 0,
                Model = "model",
                Provider = "provider",
            },
            IndexName = "indexName",
            VectorBucket = "vectorBucket",

            // Null should be interpreted as omitted for these properties
            ID = null,
            CreatedAt = null,
            Description = null,
            EnableIndexing = null,
            FilesBucket = null,
            Name = null,
            Region = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.EnableIndexing);
        Assert.False(model.RawData.ContainsKey("enableIndexing"));
        Assert.Null(model.FilesBucket);
        Assert.False(model.RawData.ContainsKey("filesBucket"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Region);
        Assert.False(model.RawData.ContainsKey("region"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VaultCreateResponse
        {
            EmbeddingProfile = new()
            {
                Dimensions = 0,
                Model = "model",
                Provider = "provider",
            },
            IndexName = "indexName",
            VectorBucket = "vectorBucket",

            // Null should be interpreted as omitted for these properties
            ID = null,
            CreatedAt = null,
            Description = null,
            EnableIndexing = null,
            FilesBucket = null,
            Name = null,
            Region = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VaultCreateResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            EnableIndexing = true,
            FilesBucket = "filesBucket",
            Name = "name",
            Region = "region",
        };

        Assert.Null(model.EmbeddingProfile);
        Assert.False(model.RawData.ContainsKey("embeddingProfile"));
        Assert.Null(model.IndexName);
        Assert.False(model.RawData.ContainsKey("indexName"));
        Assert.Null(model.VectorBucket);
        Assert.False(model.RawData.ContainsKey("vectorBucket"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new VaultCreateResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            EnableIndexing = true,
            FilesBucket = "filesBucket",
            Name = "name",
            Region = "region",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new VaultCreateResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            EnableIndexing = true,
            FilesBucket = "filesBucket",
            Name = "name",
            Region = "region",

            EmbeddingProfile = null,
            IndexName = null,
            VectorBucket = null,
        };

        Assert.Null(model.EmbeddingProfile);
        Assert.True(model.RawData.ContainsKey("embeddingProfile"));
        Assert.Null(model.IndexName);
        Assert.True(model.RawData.ContainsKey("indexName"));
        Assert.Null(model.VectorBucket);
        Assert.True(model.RawData.ContainsKey("vectorBucket"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VaultCreateResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            EnableIndexing = true,
            FilesBucket = "filesBucket",
            Name = "name",
            Region = "region",

            EmbeddingProfile = null,
            IndexName = null,
            VectorBucket = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VaultCreateResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            EmbeddingProfile = new()
            {
                Dimensions = 0,
                Model = "model",
                Provider = "provider",
            },
            EnableIndexing = true,
            FilesBucket = "filesBucket",
            IndexName = "indexName",
            Name = "name",
            Region = "region",
            VectorBucket = "vectorBucket",
        };

        VaultCreateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EmbeddingProfileTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EmbeddingProfile
        {
            Dimensions = 0,
            Model = "model",
            Provider = "provider",
        };

        long expectedDimensions = 0;
        string expectedModel = "model";
        string expectedProvider = "provider";

        Assert.Equal(expectedDimensions, model.Dimensions);
        Assert.Equal(expectedModel, model.Model);
        Assert.Equal(expectedProvider, model.Provider);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EmbeddingProfile
        {
            Dimensions = 0,
            Model = "model",
            Provider = "provider",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EmbeddingProfile>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EmbeddingProfile
        {
            Dimensions = 0,
            Model = "model",
            Provider = "provider",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EmbeddingProfile>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedDimensions = 0;
        string expectedModel = "model";
        string expectedProvider = "provider";

        Assert.Equal(expectedDimensions, deserialized.Dimensions);
        Assert.Equal(expectedModel, deserialized.Model);
        Assert.Equal(expectedProvider, deserialized.Provider);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EmbeddingProfile
        {
            Dimensions = 0,
            Model = "model",
            Provider = "provider",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new EmbeddingProfile { };

        Assert.Null(model.Dimensions);
        Assert.False(model.RawData.ContainsKey("dimensions"));
        Assert.Null(model.Model);
        Assert.False(model.RawData.ContainsKey("model"));
        Assert.Null(model.Provider);
        Assert.False(model.RawData.ContainsKey("provider"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new EmbeddingProfile { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new EmbeddingProfile
        {
            // Null should be interpreted as omitted for these properties
            Dimensions = null,
            Model = null,
            Provider = null,
        };

        Assert.Null(model.Dimensions);
        Assert.False(model.RawData.ContainsKey("dimensions"));
        Assert.Null(model.Model);
        Assert.False(model.RawData.ContainsKey("model"));
        Assert.Null(model.Provider);
        Assert.False(model.RawData.ContainsKey("provider"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new EmbeddingProfile
        {
            // Null should be interpreted as omitted for these properties
            Dimensions = null,
            Model = null,
            Provider = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EmbeddingProfile
        {
            Dimensions = 0,
            Model = "model",
            Provider = "provider",
        };

        EmbeddingProfile copied = new(model);

        Assert.Equal(model, copied);
    }
}
