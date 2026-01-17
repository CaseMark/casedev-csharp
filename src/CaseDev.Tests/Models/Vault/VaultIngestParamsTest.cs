using System;
using CaseDev.Models.Vault;

namespace CaseDev.Tests.Models.Vault;

public class VaultIngestParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new VaultIngestParams { ID = "id", ObjectID = "objectId" };

        string expectedID = "id";
        string expectedObjectID = "objectId";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedObjectID, parameters.ObjectID);
    }

    [Fact]
    public void Url_Works()
    {
        VaultIngestParams parameters = new() { ID = "id", ObjectID = "objectId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/vault/id/ingest/objectId"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new VaultIngestParams { ID = "id", ObjectID = "objectId" };

        VaultIngestParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
