using System;
using System.Collections.Generic;
using System.Text.Json;
using Router.Core;
using Router.Models.Vault.Multipart;

namespace Router.Tests.Models.Vault.Multipart;

public class MultipartGetPartUrlsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MultipartGetPartUrlsParams
        {
            ID = "id",
            ObjectID = "objectId",
            Parts = [new() { PartNumber = 1, SizeBytes = 1 }],
            UploadID = "uploadId",
        };

        string expectedID = "id";
        string expectedObjectID = "objectId";
        List<Part> expectedParts = [new() { PartNumber = 1, SizeBytes = 1 }];
        string expectedUploadID = "uploadId";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedObjectID, parameters.ObjectID);
        Assert.Equal(expectedParts.Count, parameters.Parts.Count);
        for (int i = 0; i < expectedParts.Count; i++)
        {
            Assert.Equal(expectedParts[i], parameters.Parts[i]);
        }
        Assert.Equal(expectedUploadID, parameters.UploadID);
    }

    [Fact]
    public void Url_Works()
    {
        MultipartGetPartUrlsParams parameters = new()
        {
            ID = "id",
            ObjectID = "objectId",
            Parts = [new() { PartNumber = 1, SizeBytes = 1 }],
            UploadID = "uploadId",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/vault/id/multipart/part-urls"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new MultipartGetPartUrlsParams
        {
            ID = "id",
            ObjectID = "objectId",
            Parts = [new() { PartNumber = 1, SizeBytes = 1 }],
            UploadID = "uploadId",
        };

        MultipartGetPartUrlsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class PartTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Part { PartNumber = 1, SizeBytes = 1 };

        long expectedPartNumber = 1;
        long expectedSizeBytes = 1;

        Assert.Equal(expectedPartNumber, model.PartNumber);
        Assert.Equal(expectedSizeBytes, model.SizeBytes);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Part { PartNumber = 1, SizeBytes = 1 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Part>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Part { PartNumber = 1, SizeBytes = 1 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Part>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        long expectedPartNumber = 1;
        long expectedSizeBytes = 1;

        Assert.Equal(expectedPartNumber, deserialized.PartNumber);
        Assert.Equal(expectedSizeBytes, deserialized.SizeBytes);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Part { PartNumber = 1, SizeBytes = 1 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Part { PartNumber = 1, SizeBytes = 1 };

        Part copied = new(model);

        Assert.Equal(model, copied);
    }
}
