using System;
using Casedev.Models.Vault.Multipart;

namespace Casedev.Tests.Models.Vault.Multipart;

public class MultipartAbortParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MultipartAbortParams
        {
            ID = "id",
            ObjectID = "objectId",
            UploadID = "uploadId",
        };

        string expectedID = "id";
        string expectedObjectID = "objectId";
        string expectedUploadID = "uploadId";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedObjectID, parameters.ObjectID);
        Assert.Equal(expectedUploadID, parameters.UploadID);
    }

    [Fact]
    public void Url_Works()
    {
        MultipartAbortParams parameters = new()
        {
            ID = "id",
            ObjectID = "objectId",
            UploadID = "uploadId",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/vault/id/multipart/abort"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new MultipartAbortParams
        {
            ID = "id",
            ObjectID = "objectId",
            UploadID = "uploadId",
        };

        MultipartAbortParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
