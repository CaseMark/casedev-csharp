using System;
using CaseDev.Models.Vault.Graphrag;

namespace CaseDev.Tests.Models.Vault.Graphrag;

public class GraphragProcessObjectParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new GraphragProcessObjectParams { ID = "id", ObjectID = "objectId" };

        string expectedID = "id";
        string expectedObjectID = "objectId";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedObjectID, parameters.ObjectID);
    }

    [Fact]
    public void Url_Works()
    {
        GraphragProcessObjectParams parameters = new() { ID = "id", ObjectID = "objectId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/vault/id/graphrag/objectId"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new GraphragProcessObjectParams { ID = "id", ObjectID = "objectId" };

        GraphragProcessObjectParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
