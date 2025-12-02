using System;
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
}
