using System;
using Router.Models.Vault.Objects;

namespace Router.Tests.Models.Vault.Objects;

public class ObjectDownloadParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ObjectDownloadParams { ID = "id", ObjectID = "objectId" };

        string expectedID = "id";
        string expectedObjectID = "objectId";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedObjectID, parameters.ObjectID);
    }

    [Fact]
    public void Url_Works()
    {
        ObjectDownloadParams parameters = new() { ID = "id", ObjectID = "objectId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/vault/id/objects/objectId/download"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ObjectDownloadParams { ID = "id", ObjectID = "objectId" };

        ObjectDownloadParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
