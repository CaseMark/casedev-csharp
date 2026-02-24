using System;
using Casedev.Models.Vault.Objects;

namespace Casedev.Tests.Models.Vault.Objects;

public class ObjectRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ObjectRetrieveParams { ID = "id", ObjectID = "objectId" };

        string expectedID = "id";
        string expectedObjectID = "objectId";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedObjectID, parameters.ObjectID);
    }

    [Fact]
    public void Url_Works()
    {
        ObjectRetrieveParams parameters = new() { ID = "id", ObjectID = "objectId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/vault/id/objects/objectId"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ObjectRetrieveParams { ID = "id", ObjectID = "objectId" };

        ObjectRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
