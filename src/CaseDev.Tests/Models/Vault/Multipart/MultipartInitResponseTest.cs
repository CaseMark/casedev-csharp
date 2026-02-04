using System.Text.Json;
using CaseDev.Core;
using CaseDev.Models.Vault.Multipart;

namespace CaseDev.Tests.Models.Vault.Multipart;

public class MultipartInitResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MultipartInitResponse
        {
            NextStep = "next_step",
            ObjectID = "objectId",
            PartCount = 0,
            PartSizeBytes = 0,
            S3Key = "s3Key",
            UploadID = "uploadId",
        };

        string expectedNextStep = "next_step";
        string expectedObjectID = "objectId";
        long expectedPartCount = 0;
        long expectedPartSizeBytes = 0;
        string expectedS3Key = "s3Key";
        string expectedUploadID = "uploadId";

        Assert.Equal(expectedNextStep, model.NextStep);
        Assert.Equal(expectedObjectID, model.ObjectID);
        Assert.Equal(expectedPartCount, model.PartCount);
        Assert.Equal(expectedPartSizeBytes, model.PartSizeBytes);
        Assert.Equal(expectedS3Key, model.S3Key);
        Assert.Equal(expectedUploadID, model.UploadID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MultipartInitResponse
        {
            NextStep = "next_step",
            ObjectID = "objectId",
            PartCount = 0,
            PartSizeBytes = 0,
            S3Key = "s3Key",
            UploadID = "uploadId",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MultipartInitResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MultipartInitResponse
        {
            NextStep = "next_step",
            ObjectID = "objectId",
            PartCount = 0,
            PartSizeBytes = 0,
            S3Key = "s3Key",
            UploadID = "uploadId",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MultipartInitResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedNextStep = "next_step";
        string expectedObjectID = "objectId";
        long expectedPartCount = 0;
        long expectedPartSizeBytes = 0;
        string expectedS3Key = "s3Key";
        string expectedUploadID = "uploadId";

        Assert.Equal(expectedNextStep, deserialized.NextStep);
        Assert.Equal(expectedObjectID, deserialized.ObjectID);
        Assert.Equal(expectedPartCount, deserialized.PartCount);
        Assert.Equal(expectedPartSizeBytes, deserialized.PartSizeBytes);
        Assert.Equal(expectedS3Key, deserialized.S3Key);
        Assert.Equal(expectedUploadID, deserialized.UploadID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MultipartInitResponse
        {
            NextStep = "next_step",
            ObjectID = "objectId",
            PartCount = 0,
            PartSizeBytes = 0,
            S3Key = "s3Key",
            UploadID = "uploadId",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new MultipartInitResponse { };

        Assert.Null(model.NextStep);
        Assert.False(model.RawData.ContainsKey("next_step"));
        Assert.Null(model.ObjectID);
        Assert.False(model.RawData.ContainsKey("objectId"));
        Assert.Null(model.PartCount);
        Assert.False(model.RawData.ContainsKey("partCount"));
        Assert.Null(model.PartSizeBytes);
        Assert.False(model.RawData.ContainsKey("partSizeBytes"));
        Assert.Null(model.S3Key);
        Assert.False(model.RawData.ContainsKey("s3Key"));
        Assert.Null(model.UploadID);
        Assert.False(model.RawData.ContainsKey("uploadId"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new MultipartInitResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new MultipartInitResponse
        {
            // Null should be interpreted as omitted for these properties
            NextStep = null,
            ObjectID = null,
            PartCount = null,
            PartSizeBytes = null,
            S3Key = null,
            UploadID = null,
        };

        Assert.Null(model.NextStep);
        Assert.False(model.RawData.ContainsKey("next_step"));
        Assert.Null(model.ObjectID);
        Assert.False(model.RawData.ContainsKey("objectId"));
        Assert.Null(model.PartCount);
        Assert.False(model.RawData.ContainsKey("partCount"));
        Assert.Null(model.PartSizeBytes);
        Assert.False(model.RawData.ContainsKey("partSizeBytes"));
        Assert.Null(model.S3Key);
        Assert.False(model.RawData.ContainsKey("s3Key"));
        Assert.Null(model.UploadID);
        Assert.False(model.RawData.ContainsKey("uploadId"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new MultipartInitResponse
        {
            // Null should be interpreted as omitted for these properties
            NextStep = null,
            ObjectID = null,
            PartCount = null,
            PartSizeBytes = null,
            S3Key = null,
            UploadID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MultipartInitResponse
        {
            NextStep = "next_step",
            ObjectID = "objectId",
            PartCount = 0,
            PartSizeBytes = 0,
            S3Key = "s3Key",
            UploadID = "uploadId",
        };

        MultipartInitResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
