using System;
using System.Text.Json;
using CaseDev.Models.Vault;

namespace CaseDev.Tests.Models.Vault;

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
            FilesBucket = "filesBucket",
            IndexName = "indexName",
            Name = "name",
            Region = "region",
            VectorBucket = "vectorBucket",
        };

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        string expectedFilesBucket = "filesBucket";
        string expectedIndexName = "indexName";
        string expectedName = "name";
        string expectedRegion = "region";
        string expectedVectorBucket = "vectorBucket";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDescription, model.Description);
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
            FilesBucket = "filesBucket",
            IndexName = "indexName",
            Name = "name",
            Region = "region",
            VectorBucket = "vectorBucket",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<VaultCreateResponse>(json);

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
            FilesBucket = "filesBucket",
            IndexName = "indexName",
            Name = "name",
            Region = "region",
            VectorBucket = "vectorBucket",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<VaultCreateResponse>(element);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        string expectedFilesBucket = "filesBucket";
        string expectedIndexName = "indexName";
        string expectedName = "name";
        string expectedRegion = "region";
        string expectedVectorBucket = "vectorBucket";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDescription, deserialized.Description);
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
        var model = new VaultCreateResponse { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.FilesBucket);
        Assert.False(model.RawData.ContainsKey("filesBucket"));
        Assert.Null(model.IndexName);
        Assert.False(model.RawData.ContainsKey("indexName"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Region);
        Assert.False(model.RawData.ContainsKey("region"));
        Assert.Null(model.VectorBucket);
        Assert.False(model.RawData.ContainsKey("vectorBucket"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new VaultCreateResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new VaultCreateResponse
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            CreatedAt = null,
            Description = null,
            FilesBucket = null,
            IndexName = null,
            Name = null,
            Region = null,
            VectorBucket = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.FilesBucket);
        Assert.False(model.RawData.ContainsKey("filesBucket"));
        Assert.Null(model.IndexName);
        Assert.False(model.RawData.ContainsKey("indexName"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Region);
        Assert.False(model.RawData.ContainsKey("region"));
        Assert.Null(model.VectorBucket);
        Assert.False(model.RawData.ContainsKey("vectorBucket"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VaultCreateResponse
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            CreatedAt = null,
            Description = null,
            FilesBucket = null,
            IndexName = null,
            Name = null,
            Region = null,
            VectorBucket = null,
        };

        model.Validate();
    }
}
