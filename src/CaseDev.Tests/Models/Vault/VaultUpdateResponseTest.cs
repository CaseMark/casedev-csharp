using System;
using System.Text.Json;
using CaseDev.Core;
using CaseDev.Models.Vault;

namespace CaseDev.Tests.Models.Vault;

public class VaultUpdateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VaultUpdateResponse
        {
            ID = "id",
            ChunkStrategy = JsonSerializer.Deserialize<JsonElement>("{}"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            EnableGraph = true,
            FilesBucket = "filesBucket",
            IndexName = "indexName",
            KmsKeyID = "kmsKeyId",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "name",
            Region = "region",
            TotalBytes = 0,
            TotalObjects = 0,
            TotalVectors = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VectorBucket = "vectorBucket",
        };

        string expectedID = "id";
        JsonElement expectedChunkStrategy = JsonSerializer.Deserialize<JsonElement>("{}");
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        bool expectedEnableGraph = true;
        string expectedFilesBucket = "filesBucket";
        string expectedIndexName = "indexName";
        string expectedKmsKeyID = "kmsKeyId";
        JsonElement expectedMetadata = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedName = "name";
        string expectedRegion = "region";
        long expectedTotalBytes = 0;
        long expectedTotalObjects = 0;
        long expectedTotalVectors = 0;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedVectorBucket = "vectorBucket";

        Assert.Equal(expectedID, model.ID);
        Assert.NotNull(model.ChunkStrategy);
        Assert.True(JsonElement.DeepEquals(expectedChunkStrategy, model.ChunkStrategy.Value));
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedEnableGraph, model.EnableGraph);
        Assert.Equal(expectedFilesBucket, model.FilesBucket);
        Assert.Equal(expectedIndexName, model.IndexName);
        Assert.Equal(expectedKmsKeyID, model.KmsKeyID);
        Assert.NotNull(model.Metadata);
        Assert.True(JsonElement.DeepEquals(expectedMetadata, model.Metadata.Value));
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedRegion, model.Region);
        Assert.Equal(expectedTotalBytes, model.TotalBytes);
        Assert.Equal(expectedTotalObjects, model.TotalObjects);
        Assert.Equal(expectedTotalVectors, model.TotalVectors);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedVectorBucket, model.VectorBucket);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VaultUpdateResponse
        {
            ID = "id",
            ChunkStrategy = JsonSerializer.Deserialize<JsonElement>("{}"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            EnableGraph = true,
            FilesBucket = "filesBucket",
            IndexName = "indexName",
            KmsKeyID = "kmsKeyId",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "name",
            Region = "region",
            TotalBytes = 0,
            TotalObjects = 0,
            TotalVectors = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VectorBucket = "vectorBucket",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VaultUpdateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VaultUpdateResponse
        {
            ID = "id",
            ChunkStrategy = JsonSerializer.Deserialize<JsonElement>("{}"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            EnableGraph = true,
            FilesBucket = "filesBucket",
            IndexName = "indexName",
            KmsKeyID = "kmsKeyId",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "name",
            Region = "region",
            TotalBytes = 0,
            TotalObjects = 0,
            TotalVectors = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VectorBucket = "vectorBucket",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VaultUpdateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        JsonElement expectedChunkStrategy = JsonSerializer.Deserialize<JsonElement>("{}");
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        bool expectedEnableGraph = true;
        string expectedFilesBucket = "filesBucket";
        string expectedIndexName = "indexName";
        string expectedKmsKeyID = "kmsKeyId";
        JsonElement expectedMetadata = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedName = "name";
        string expectedRegion = "region";
        long expectedTotalBytes = 0;
        long expectedTotalObjects = 0;
        long expectedTotalVectors = 0;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedVectorBucket = "vectorBucket";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.NotNull(deserialized.ChunkStrategy);
        Assert.True(
            JsonElement.DeepEquals(expectedChunkStrategy, deserialized.ChunkStrategy.Value)
        );
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedEnableGraph, deserialized.EnableGraph);
        Assert.Equal(expectedFilesBucket, deserialized.FilesBucket);
        Assert.Equal(expectedIndexName, deserialized.IndexName);
        Assert.Equal(expectedKmsKeyID, deserialized.KmsKeyID);
        Assert.NotNull(deserialized.Metadata);
        Assert.True(JsonElement.DeepEquals(expectedMetadata, deserialized.Metadata.Value));
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedRegion, deserialized.Region);
        Assert.Equal(expectedTotalBytes, deserialized.TotalBytes);
        Assert.Equal(expectedTotalObjects, deserialized.TotalObjects);
        Assert.Equal(expectedTotalVectors, deserialized.TotalVectors);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedVectorBucket, deserialized.VectorBucket);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VaultUpdateResponse
        {
            ID = "id",
            ChunkStrategy = JsonSerializer.Deserialize<JsonElement>("{}"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            EnableGraph = true,
            FilesBucket = "filesBucket",
            IndexName = "indexName",
            KmsKeyID = "kmsKeyId",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "name",
            Region = "region",
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
        var model = new VaultUpdateResponse
        {
            Description = "description",
            VectorBucket = "vectorBucket",
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.ChunkStrategy);
        Assert.False(model.RawData.ContainsKey("chunkStrategy"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.EnableGraph);
        Assert.False(model.RawData.ContainsKey("enableGraph"));
        Assert.Null(model.FilesBucket);
        Assert.False(model.RawData.ContainsKey("filesBucket"));
        Assert.Null(model.IndexName);
        Assert.False(model.RawData.ContainsKey("indexName"));
        Assert.Null(model.KmsKeyID);
        Assert.False(model.RawData.ContainsKey("kmsKeyId"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Region);
        Assert.False(model.RawData.ContainsKey("region"));
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
        var model = new VaultUpdateResponse
        {
            Description = "description",
            VectorBucket = "vectorBucket",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new VaultUpdateResponse
        {
            Description = "description",
            VectorBucket = "vectorBucket",

            // Null should be interpreted as omitted for these properties
            ID = null,
            ChunkStrategy = null,
            CreatedAt = null,
            EnableGraph = null,
            FilesBucket = null,
            IndexName = null,
            KmsKeyID = null,
            Metadata = null,
            Name = null,
            Region = null,
            TotalBytes = null,
            TotalObjects = null,
            TotalVectors = null,
            UpdatedAt = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.ChunkStrategy);
        Assert.False(model.RawData.ContainsKey("chunkStrategy"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.EnableGraph);
        Assert.False(model.RawData.ContainsKey("enableGraph"));
        Assert.Null(model.FilesBucket);
        Assert.False(model.RawData.ContainsKey("filesBucket"));
        Assert.Null(model.IndexName);
        Assert.False(model.RawData.ContainsKey("indexName"));
        Assert.Null(model.KmsKeyID);
        Assert.False(model.RawData.ContainsKey("kmsKeyId"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Region);
        Assert.False(model.RawData.ContainsKey("region"));
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
        var model = new VaultUpdateResponse
        {
            Description = "description",
            VectorBucket = "vectorBucket",

            // Null should be interpreted as omitted for these properties
            ID = null,
            ChunkStrategy = null,
            CreatedAt = null,
            EnableGraph = null,
            FilesBucket = null,
            IndexName = null,
            KmsKeyID = null,
            Metadata = null,
            Name = null,
            Region = null,
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
        var model = new VaultUpdateResponse
        {
            ID = "id",
            ChunkStrategy = JsonSerializer.Deserialize<JsonElement>("{}"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EnableGraph = true,
            FilesBucket = "filesBucket",
            IndexName = "indexName",
            KmsKeyID = "kmsKeyId",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "name",
            Region = "region",
            TotalBytes = 0,
            TotalObjects = 0,
            TotalVectors = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.VectorBucket);
        Assert.False(model.RawData.ContainsKey("vectorBucket"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new VaultUpdateResponse
        {
            ID = "id",
            ChunkStrategy = JsonSerializer.Deserialize<JsonElement>("{}"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EnableGraph = true,
            FilesBucket = "filesBucket",
            IndexName = "indexName",
            KmsKeyID = "kmsKeyId",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "name",
            Region = "region",
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
        var model = new VaultUpdateResponse
        {
            ID = "id",
            ChunkStrategy = JsonSerializer.Deserialize<JsonElement>("{}"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EnableGraph = true,
            FilesBucket = "filesBucket",
            IndexName = "indexName",
            KmsKeyID = "kmsKeyId",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "name",
            Region = "region",
            TotalBytes = 0,
            TotalObjects = 0,
            TotalVectors = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            Description = null,
            VectorBucket = null,
        };

        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
        Assert.Null(model.VectorBucket);
        Assert.True(model.RawData.ContainsKey("vectorBucket"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VaultUpdateResponse
        {
            ID = "id",
            ChunkStrategy = JsonSerializer.Deserialize<JsonElement>("{}"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EnableGraph = true,
            FilesBucket = "filesBucket",
            IndexName = "indexName",
            KmsKeyID = "kmsKeyId",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "name",
            Region = "region",
            TotalBytes = 0,
            TotalObjects = 0,
            TotalVectors = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            Description = null,
            VectorBucket = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VaultUpdateResponse
        {
            ID = "id",
            ChunkStrategy = JsonSerializer.Deserialize<JsonElement>("{}"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            EnableGraph = true,
            FilesBucket = "filesBucket",
            IndexName = "indexName",
            KmsKeyID = "kmsKeyId",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "name",
            Region = "region",
            TotalBytes = 0,
            TotalObjects = 0,
            TotalVectors = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VectorBucket = "vectorBucket",
        };

        VaultUpdateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
