using System;
using System.Text.Json;
using CaseDev.Core;
using CaseDev.Models.Vault;

namespace CaseDev.Tests.Models.Vault;

public class VaultRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VaultRetrieveResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FilesBucket = "filesBucket",
            Name = "name",
            Region = "region",
            ChunkStrategy = new()
            {
                ChunkSize = 0,
                Method = "method",
                MinChunkSize = 0,
                Overlap = 0,
            },
            Description = "description",
            EnableGraph = true,
            IndexName = "indexName",
            KmsKeyID = "kmsKeyId",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            TotalBytes = 0,
            TotalObjects = 0,
            TotalVectors = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VectorBucket = "vectorBucket",
        };

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedFilesBucket = "filesBucket";
        string expectedName = "name";
        string expectedRegion = "region";
        ChunkStrategy expectedChunkStrategy = new()
        {
            ChunkSize = 0,
            Method = "method",
            MinChunkSize = 0,
            Overlap = 0,
        };
        string expectedDescription = "description";
        bool expectedEnableGraph = true;
        string expectedIndexName = "indexName";
        string expectedKmsKeyID = "kmsKeyId";
        JsonElement expectedMetadata = JsonSerializer.Deserialize<JsonElement>("{}");
        long expectedTotalBytes = 0;
        long expectedTotalObjects = 0;
        long expectedTotalVectors = 0;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedVectorBucket = "vectorBucket";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedFilesBucket, model.FilesBucket);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedRegion, model.Region);
        Assert.Equal(expectedChunkStrategy, model.ChunkStrategy);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedEnableGraph, model.EnableGraph);
        Assert.Equal(expectedIndexName, model.IndexName);
        Assert.Equal(expectedKmsKeyID, model.KmsKeyID);
        Assert.NotNull(model.Metadata);
        Assert.True(JsonElement.DeepEquals(expectedMetadata, model.Metadata.Value));
        Assert.Equal(expectedTotalBytes, model.TotalBytes);
        Assert.Equal(expectedTotalObjects, model.TotalObjects);
        Assert.Equal(expectedTotalVectors, model.TotalVectors);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedVectorBucket, model.VectorBucket);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VaultRetrieveResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FilesBucket = "filesBucket",
            Name = "name",
            Region = "region",
            ChunkStrategy = new()
            {
                ChunkSize = 0,
                Method = "method",
                MinChunkSize = 0,
                Overlap = 0,
            },
            Description = "description",
            EnableGraph = true,
            IndexName = "indexName",
            KmsKeyID = "kmsKeyId",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            TotalBytes = 0,
            TotalObjects = 0,
            TotalVectors = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VectorBucket = "vectorBucket",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VaultRetrieveResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VaultRetrieveResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FilesBucket = "filesBucket",
            Name = "name",
            Region = "region",
            ChunkStrategy = new()
            {
                ChunkSize = 0,
                Method = "method",
                MinChunkSize = 0,
                Overlap = 0,
            },
            Description = "description",
            EnableGraph = true,
            IndexName = "indexName",
            KmsKeyID = "kmsKeyId",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            TotalBytes = 0,
            TotalObjects = 0,
            TotalVectors = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VectorBucket = "vectorBucket",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VaultRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedFilesBucket = "filesBucket";
        string expectedName = "name";
        string expectedRegion = "region";
        ChunkStrategy expectedChunkStrategy = new()
        {
            ChunkSize = 0,
            Method = "method",
            MinChunkSize = 0,
            Overlap = 0,
        };
        string expectedDescription = "description";
        bool expectedEnableGraph = true;
        string expectedIndexName = "indexName";
        string expectedKmsKeyID = "kmsKeyId";
        JsonElement expectedMetadata = JsonSerializer.Deserialize<JsonElement>("{}");
        long expectedTotalBytes = 0;
        long expectedTotalObjects = 0;
        long expectedTotalVectors = 0;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedVectorBucket = "vectorBucket";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedFilesBucket, deserialized.FilesBucket);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedRegion, deserialized.Region);
        Assert.Equal(expectedChunkStrategy, deserialized.ChunkStrategy);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedEnableGraph, deserialized.EnableGraph);
        Assert.Equal(expectedIndexName, deserialized.IndexName);
        Assert.Equal(expectedKmsKeyID, deserialized.KmsKeyID);
        Assert.NotNull(deserialized.Metadata);
        Assert.True(JsonElement.DeepEquals(expectedMetadata, deserialized.Metadata.Value));
        Assert.Equal(expectedTotalBytes, deserialized.TotalBytes);
        Assert.Equal(expectedTotalObjects, deserialized.TotalObjects);
        Assert.Equal(expectedTotalVectors, deserialized.TotalVectors);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedVectorBucket, deserialized.VectorBucket);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VaultRetrieveResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FilesBucket = "filesBucket",
            Name = "name",
            Region = "region",
            ChunkStrategy = new()
            {
                ChunkSize = 0,
                Method = "method",
                MinChunkSize = 0,
                Overlap = 0,
            },
            Description = "description",
            EnableGraph = true,
            IndexName = "indexName",
            KmsKeyID = "kmsKeyId",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            TotalBytes = 0,
            TotalObjects = 0,
            TotalVectors = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VectorBucket = "vectorBucket",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VaultRetrieveResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FilesBucket = "filesBucket",
            Name = "name",
            Region = "region",
            VectorBucket = "vectorBucket",
        };

        Assert.Null(model.ChunkStrategy);
        Assert.False(model.RawData.ContainsKey("chunkStrategy"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.EnableGraph);
        Assert.False(model.RawData.ContainsKey("enableGraph"));
        Assert.Null(model.IndexName);
        Assert.False(model.RawData.ContainsKey("indexName"));
        Assert.Null(model.KmsKeyID);
        Assert.False(model.RawData.ContainsKey("kmsKeyId"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.TotalBytes);
        Assert.False(model.RawData.ContainsKey("totalBytes"));
        Assert.Null(model.TotalObjects);
        Assert.False(model.RawData.ContainsKey("totalObjects"));
        Assert.Null(model.TotalVectors);
        Assert.False(model.RawData.ContainsKey("totalVectors"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updatedAt"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new VaultRetrieveResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FilesBucket = "filesBucket",
            Name = "name",
            Region = "region",
            VectorBucket = "vectorBucket",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new VaultRetrieveResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FilesBucket = "filesBucket",
            Name = "name",
            Region = "region",
            VectorBucket = "vectorBucket",

            // Null should be interpreted as omitted for these properties
            ChunkStrategy = null,
            Description = null,
            EnableGraph = null,
            IndexName = null,
            KmsKeyID = null,
            Metadata = null,
            TotalBytes = null,
            TotalObjects = null,
            TotalVectors = null,
            UpdatedAt = null,
        };

        Assert.Null(model.ChunkStrategy);
        Assert.False(model.RawData.ContainsKey("chunkStrategy"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.EnableGraph);
        Assert.False(model.RawData.ContainsKey("enableGraph"));
        Assert.Null(model.IndexName);
        Assert.False(model.RawData.ContainsKey("indexName"));
        Assert.Null(model.KmsKeyID);
        Assert.False(model.RawData.ContainsKey("kmsKeyId"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.TotalBytes);
        Assert.False(model.RawData.ContainsKey("totalBytes"));
        Assert.Null(model.TotalObjects);
        Assert.False(model.RawData.ContainsKey("totalObjects"));
        Assert.Null(model.TotalVectors);
        Assert.False(model.RawData.ContainsKey("totalVectors"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updatedAt"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VaultRetrieveResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FilesBucket = "filesBucket",
            Name = "name",
            Region = "region",
            VectorBucket = "vectorBucket",

            // Null should be interpreted as omitted for these properties
            ChunkStrategy = null,
            Description = null,
            EnableGraph = null,
            IndexName = null,
            KmsKeyID = null,
            Metadata = null,
            TotalBytes = null,
            TotalObjects = null,
            TotalVectors = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VaultRetrieveResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FilesBucket = "filesBucket",
            Name = "name",
            Region = "region",
            ChunkStrategy = new()
            {
                ChunkSize = 0,
                Method = "method",
                MinChunkSize = 0,
                Overlap = 0,
            },
            Description = "description",
            EnableGraph = true,
            IndexName = "indexName",
            KmsKeyID = "kmsKeyId",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            TotalBytes = 0,
            TotalObjects = 0,
            TotalVectors = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.VectorBucket);
        Assert.False(model.RawData.ContainsKey("vectorBucket"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new VaultRetrieveResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FilesBucket = "filesBucket",
            Name = "name",
            Region = "region",
            ChunkStrategy = new()
            {
                ChunkSize = 0,
                Method = "method",
                MinChunkSize = 0,
                Overlap = 0,
            },
            Description = "description",
            EnableGraph = true,
            IndexName = "indexName",
            KmsKeyID = "kmsKeyId",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            TotalBytes = 0,
            TotalObjects = 0,
            TotalVectors = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new VaultRetrieveResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FilesBucket = "filesBucket",
            Name = "name",
            Region = "region",
            ChunkStrategy = new()
            {
                ChunkSize = 0,
                Method = "method",
                MinChunkSize = 0,
                Overlap = 0,
            },
            Description = "description",
            EnableGraph = true,
            IndexName = "indexName",
            KmsKeyID = "kmsKeyId",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            TotalBytes = 0,
            TotalObjects = 0,
            TotalVectors = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            VectorBucket = null,
        };

        Assert.Null(model.VectorBucket);
        Assert.True(model.RawData.ContainsKey("vectorBucket"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VaultRetrieveResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FilesBucket = "filesBucket",
            Name = "name",
            Region = "region",
            ChunkStrategy = new()
            {
                ChunkSize = 0,
                Method = "method",
                MinChunkSize = 0,
                Overlap = 0,
            },
            Description = "description",
            EnableGraph = true,
            IndexName = "indexName",
            KmsKeyID = "kmsKeyId",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            TotalBytes = 0,
            TotalObjects = 0,
            TotalVectors = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            VectorBucket = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VaultRetrieveResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FilesBucket = "filesBucket",
            Name = "name",
            Region = "region",
            ChunkStrategy = new()
            {
                ChunkSize = 0,
                Method = "method",
                MinChunkSize = 0,
                Overlap = 0,
            },
            Description = "description",
            EnableGraph = true,
            IndexName = "indexName",
            KmsKeyID = "kmsKeyId",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            TotalBytes = 0,
            TotalObjects = 0,
            TotalVectors = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VectorBucket = "vectorBucket",
        };

        VaultRetrieveResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChunkStrategyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChunkStrategy
        {
            ChunkSize = 0,
            Method = "method",
            MinChunkSize = 0,
            Overlap = 0,
        };

        long expectedChunkSize = 0;
        string expectedMethod = "method";
        long expectedMinChunkSize = 0;
        long expectedOverlap = 0;

        Assert.Equal(expectedChunkSize, model.ChunkSize);
        Assert.Equal(expectedMethod, model.Method);
        Assert.Equal(expectedMinChunkSize, model.MinChunkSize);
        Assert.Equal(expectedOverlap, model.Overlap);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChunkStrategy
        {
            ChunkSize = 0,
            Method = "method",
            MinChunkSize = 0,
            Overlap = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChunkStrategy>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChunkStrategy
        {
            ChunkSize = 0,
            Method = "method",
            MinChunkSize = 0,
            Overlap = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChunkStrategy>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedChunkSize = 0;
        string expectedMethod = "method";
        long expectedMinChunkSize = 0;
        long expectedOverlap = 0;

        Assert.Equal(expectedChunkSize, deserialized.ChunkSize);
        Assert.Equal(expectedMethod, deserialized.Method);
        Assert.Equal(expectedMinChunkSize, deserialized.MinChunkSize);
        Assert.Equal(expectedOverlap, deserialized.Overlap);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChunkStrategy
        {
            ChunkSize = 0,
            Method = "method",
            MinChunkSize = 0,
            Overlap = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ChunkStrategy { };

        Assert.Null(model.ChunkSize);
        Assert.False(model.RawData.ContainsKey("chunkSize"));
        Assert.Null(model.Method);
        Assert.False(model.RawData.ContainsKey("method"));
        Assert.Null(model.MinChunkSize);
        Assert.False(model.RawData.ContainsKey("minChunkSize"));
        Assert.Null(model.Overlap);
        Assert.False(model.RawData.ContainsKey("overlap"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ChunkStrategy { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ChunkStrategy
        {
            // Null should be interpreted as omitted for these properties
            ChunkSize = null,
            Method = null,
            MinChunkSize = null,
            Overlap = null,
        };

        Assert.Null(model.ChunkSize);
        Assert.False(model.RawData.ContainsKey("chunkSize"));
        Assert.Null(model.Method);
        Assert.False(model.RawData.ContainsKey("method"));
        Assert.Null(model.MinChunkSize);
        Assert.False(model.RawData.ContainsKey("minChunkSize"));
        Assert.Null(model.Overlap);
        Assert.False(model.RawData.ContainsKey("overlap"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ChunkStrategy
        {
            // Null should be interpreted as omitted for these properties
            ChunkSize = null,
            Method = null,
            MinChunkSize = null,
            Overlap = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChunkStrategy
        {
            ChunkSize = 0,
            Method = "method",
            MinChunkSize = 0,
            Overlap = 0,
        };

        ChunkStrategy copied = new(model);

        Assert.Equal(model, copied);
    }
}
