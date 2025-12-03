using System;
using System.Text.Json;
using CaseDev.Models.Vault.Objects;

namespace CaseDev.Tests.Models.Vault.Objects;

public class ObjectCreatePresignedURLResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ObjectCreatePresignedURLResponse
        {
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExpiresIn = 0,
            Filename = "filename",
            Instructions = JsonSerializer.Deserialize<JsonElement>("{}"),
            Metadata = new()
            {
                Bucket = "bucket",
                ContentType = "contentType",
                Region = "region",
                SizeBytes = 0,
            },
            ObjectID = "objectId",
            Operation = "operation",
            PresignedURL = "presignedUrl",
            S3Key = "s3Key",
            VaultID = "vaultId",
        };

        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedExpiresIn = 0;
        string expectedFilename = "filename";
        JsonElement expectedInstructions = JsonSerializer.Deserialize<JsonElement>("{}");
        Metadata expectedMetadata = new()
        {
            Bucket = "bucket",
            ContentType = "contentType",
            Region = "region",
            SizeBytes = 0,
        };
        string expectedObjectID = "objectId";
        string expectedOperation = "operation";
        string expectedPresignedURL = "presignedUrl";
        string expectedS3Key = "s3Key";
        string expectedVaultID = "vaultId";

        Assert.Equal(expectedExpiresAt, model.ExpiresAt);
        Assert.Equal(expectedExpiresIn, model.ExpiresIn);
        Assert.Equal(expectedFilename, model.Filename);
        Assert.True(
            model.Instructions.HasValue
                && JsonElement.DeepEquals(expectedInstructions, model.Instructions.Value)
        );
        Assert.Equal(expectedMetadata, model.Metadata);
        Assert.Equal(expectedObjectID, model.ObjectID);
        Assert.Equal(expectedOperation, model.Operation);
        Assert.Equal(expectedPresignedURL, model.PresignedURL);
        Assert.Equal(expectedS3Key, model.S3Key);
        Assert.Equal(expectedVaultID, model.VaultID);
    }
}

public class MetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Metadata
        {
            Bucket = "bucket",
            ContentType = "contentType",
            Region = "region",
            SizeBytes = 0,
        };

        string expectedBucket = "bucket";
        string expectedContentType = "contentType";
        string expectedRegion = "region";
        long expectedSizeBytes = 0;

        Assert.Equal(expectedBucket, model.Bucket);
        Assert.Equal(expectedContentType, model.ContentType);
        Assert.Equal(expectedRegion, model.Region);
        Assert.Equal(expectedSizeBytes, model.SizeBytes);
    }
}
