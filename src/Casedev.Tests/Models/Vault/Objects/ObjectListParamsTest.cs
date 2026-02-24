using System;
using Casedev.Models.Vault.Objects;

namespace Casedev.Tests.Models.Vault.Objects;

public class ObjectListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ObjectListParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        ObjectListParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/vault/id/objects"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ObjectListParams { ID = "id" };

        ObjectListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
