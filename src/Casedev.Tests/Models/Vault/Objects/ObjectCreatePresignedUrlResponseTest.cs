using System;
using System.Text.Json;
using Casedev.Core;
using Casedev.Models.Vault.Objects;

namespace Casedev.Tests.Models.Vault.Objects;

public class ObjectCreatePresignedUrlResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ObjectCreatePresignedUrlResponse
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
            PresignedUrl = "presignedUrl",
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
        string expectedPresignedUrl = "presignedUrl";
        string expectedS3Key = "s3Key";
        string expectedVaultID = "vaultId";

        Assert.Equal(expectedExpiresAt, model.ExpiresAt);
        Assert.Equal(expectedExpiresIn, model.ExpiresIn);
        Assert.Equal(expectedFilename, model.Filename);
        Assert.NotNull(model.Instructions);
        Assert.True(JsonElement.DeepEquals(expectedInstructions, model.Instructions.Value));
        Assert.Equal(expectedMetadata, model.Metadata);
        Assert.Equal(expectedObjectID, model.ObjectID);
        Assert.Equal(expectedOperation, model.Operation);
        Assert.Equal(expectedPresignedUrl, model.PresignedUrl);
        Assert.Equal(expectedS3Key, model.S3Key);
        Assert.Equal(expectedVaultID, model.VaultID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ObjectCreatePresignedUrlResponse
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
            PresignedUrl = "presignedUrl",
            S3Key = "s3Key",
            VaultID = "vaultId",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ObjectCreatePresignedUrlResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ObjectCreatePresignedUrlResponse
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
            PresignedUrl = "presignedUrl",
            S3Key = "s3Key",
            VaultID = "vaultId",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ObjectCreatePresignedUrlResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

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
        string expectedPresignedUrl = "presignedUrl";
        string expectedS3Key = "s3Key";
        string expectedVaultID = "vaultId";

        Assert.Equal(expectedExpiresAt, deserialized.ExpiresAt);
        Assert.Equal(expectedExpiresIn, deserialized.ExpiresIn);
        Assert.Equal(expectedFilename, deserialized.Filename);
        Assert.NotNull(deserialized.Instructions);
        Assert.True(JsonElement.DeepEquals(expectedInstructions, deserialized.Instructions.Value));
        Assert.Equal(expectedMetadata, deserialized.Metadata);
        Assert.Equal(expectedObjectID, deserialized.ObjectID);
        Assert.Equal(expectedOperation, deserialized.Operation);
        Assert.Equal(expectedPresignedUrl, deserialized.PresignedUrl);
        Assert.Equal(expectedS3Key, deserialized.S3Key);
        Assert.Equal(expectedVaultID, deserialized.VaultID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ObjectCreatePresignedUrlResponse
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
            PresignedUrl = "presignedUrl",
            S3Key = "s3Key",
            VaultID = "vaultId",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ObjectCreatePresignedUrlResponse { };

        Assert.Null(model.ExpiresAt);
        Assert.False(model.RawData.ContainsKey("expiresAt"));
        Assert.Null(model.ExpiresIn);
        Assert.False(model.RawData.ContainsKey("expiresIn"));
        Assert.Null(model.Filename);
        Assert.False(model.RawData.ContainsKey("filename"));
        Assert.Null(model.Instructions);
        Assert.False(model.RawData.ContainsKey("instructions"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.ObjectID);
        Assert.False(model.RawData.ContainsKey("objectId"));
        Assert.Null(model.Operation);
        Assert.False(model.RawData.ContainsKey("operation"));
        Assert.Null(model.PresignedUrl);
        Assert.False(model.RawData.ContainsKey("presignedUrl"));
        Assert.Null(model.S3Key);
        Assert.False(model.RawData.ContainsKey("s3Key"));
        Assert.Null(model.VaultID);
        Assert.False(model.RawData.ContainsKey("vaultId"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ObjectCreatePresignedUrlResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ObjectCreatePresignedUrlResponse
        {
            // Null should be interpreted as omitted for these properties
            ExpiresAt = null,
            ExpiresIn = null,
            Filename = null,
            Instructions = null,
            Metadata = null,
            ObjectID = null,
            Operation = null,
            PresignedUrl = null,
            S3Key = null,
            VaultID = null,
        };

        Assert.Null(model.ExpiresAt);
        Assert.False(model.RawData.ContainsKey("expiresAt"));
        Assert.Null(model.ExpiresIn);
        Assert.False(model.RawData.ContainsKey("expiresIn"));
        Assert.Null(model.Filename);
        Assert.False(model.RawData.ContainsKey("filename"));
        Assert.Null(model.Instructions);
        Assert.False(model.RawData.ContainsKey("instructions"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.ObjectID);
        Assert.False(model.RawData.ContainsKey("objectId"));
        Assert.Null(model.Operation);
        Assert.False(model.RawData.ContainsKey("operation"));
        Assert.Null(model.PresignedUrl);
        Assert.False(model.RawData.ContainsKey("presignedUrl"));
        Assert.Null(model.S3Key);
        Assert.False(model.RawData.ContainsKey("s3Key"));
        Assert.Null(model.VaultID);
        Assert.False(model.RawData.ContainsKey("vaultId"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ObjectCreatePresignedUrlResponse
        {
            // Null should be interpreted as omitted for these properties
            ExpiresAt = null,
            ExpiresIn = null,
            Filename = null,
            Instructions = null,
            Metadata = null,
            ObjectID = null,
            Operation = null,
            PresignedUrl = null,
            S3Key = null,
            VaultID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ObjectCreatePresignedUrlResponse
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
            PresignedUrl = "presignedUrl",
            S3Key = "s3Key",
            VaultID = "vaultId",
        };

        ObjectCreatePresignedUrlResponse copied = new(model);

        Assert.Equal(model, copied);
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

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Metadata
        {
            Bucket = "bucket",
            ContentType = "contentType",
            Region = "region",
            SizeBytes = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Metadata>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Metadata
        {
            Bucket = "bucket",
            ContentType = "contentType",
            Region = "region",
            SizeBytes = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Metadata>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedBucket = "bucket";
        string expectedContentType = "contentType";
        string expectedRegion = "region";
        long expectedSizeBytes = 0;

        Assert.Equal(expectedBucket, deserialized.Bucket);
        Assert.Equal(expectedContentType, deserialized.ContentType);
        Assert.Equal(expectedRegion, deserialized.Region);
        Assert.Equal(expectedSizeBytes, deserialized.SizeBytes);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Metadata
        {
            Bucket = "bucket",
            ContentType = "contentType",
            Region = "region",
            SizeBytes = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Metadata { };

        Assert.Null(model.Bucket);
        Assert.False(model.RawData.ContainsKey("bucket"));
        Assert.Null(model.ContentType);
        Assert.False(model.RawData.ContainsKey("contentType"));
        Assert.Null(model.Region);
        Assert.False(model.RawData.ContainsKey("region"));
        Assert.Null(model.SizeBytes);
        Assert.False(model.RawData.ContainsKey("sizeBytes"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Metadata { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Metadata
        {
            // Null should be interpreted as omitted for these properties
            Bucket = null,
            ContentType = null,
            Region = null,
            SizeBytes = null,
        };

        Assert.Null(model.Bucket);
        Assert.False(model.RawData.ContainsKey("bucket"));
        Assert.Null(model.ContentType);
        Assert.False(model.RawData.ContainsKey("contentType"));
        Assert.Null(model.Region);
        Assert.False(model.RawData.ContainsKey("region"));
        Assert.Null(model.SizeBytes);
        Assert.False(model.RawData.ContainsKey("sizeBytes"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Metadata
        {
            // Null should be interpreted as omitted for these properties
            Bucket = null,
            ContentType = null,
            Region = null,
            SizeBytes = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Metadata
        {
            Bucket = "bucket",
            ContentType = "contentType",
            Region = "region",
            SizeBytes = 0,
        };

        Metadata copied = new(model);

        Assert.Equal(model, copied);
    }
}
