using System;
using System.Collections.Generic;
using System.Text.Json;
using CaseDev.Core;
using CaseDev.Models.Vault.Multipart;

namespace CaseDev.Tests.Models.Vault.Multipart;

public class MultipartCompleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MultipartCompleteParams
        {
            ID = "id",
            ObjectID = "objectId",
            Parts = [new() { Etag = "etag", PartNumber = 1 }],
            SizeBytes = 1,
            UploadID = "uploadId",
        };

        string expectedID = "id";
        string expectedObjectID = "objectId";
        List<Part> expectedParts = [new() { Etag = "etag", PartNumber = 1 }];
        long expectedSizeBytes = 1;
        string expectedUploadID = "uploadId";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedObjectID, parameters.ObjectID);
        Assert.Equal(expectedParts.Count, parameters.Parts.Count);
        for (int i = 0; i < expectedParts.Count; i++)
        {
            Assert.Equal(expectedParts[i], parameters.Parts[i]);
        }
        Assert.Equal(expectedSizeBytes, parameters.SizeBytes);
        Assert.Equal(expectedUploadID, parameters.UploadID);
    }

    [Fact]
    public void Url_Works()
    {
        MultipartCompleteParams parameters = new()
        {
            ID = "id",
            ObjectID = "objectId",
            Parts = [new() { Etag = "etag", PartNumber = 1 }],
            SizeBytes = 1,
            UploadID = "uploadId",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/vault/id/multipart/complete"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new MultipartCompleteParams
        {
            ID = "id",
            ObjectID = "objectId",
            Parts = [new() { Etag = "etag", PartNumber = 1 }],
            SizeBytes = 1,
            UploadID = "uploadId",
        };

        MultipartCompleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class PartTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Part { Etag = "etag", PartNumber = 1 };

        string expectedEtag = "etag";
        long expectedPartNumber = 1;

        Assert.Equal(expectedEtag, model.Etag);
        Assert.Equal(expectedPartNumber, model.PartNumber);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Part { Etag = "etag", PartNumber = 1 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Part>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Part { Etag = "etag", PartNumber = 1 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Part>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedEtag = "etag";
        long expectedPartNumber = 1;

        Assert.Equal(expectedEtag, deserialized.Etag);
        Assert.Equal(expectedPartNumber, deserialized.PartNumber);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Part { Etag = "etag", PartNumber = 1 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Part { Etag = "etag", PartNumber = 1 };

        Part copied = new(model);

        Assert.Equal(model, copied);
    }
}
