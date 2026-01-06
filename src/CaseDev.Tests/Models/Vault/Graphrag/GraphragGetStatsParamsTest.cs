using System;
using CaseDev.Models.Vault.Graphrag;

namespace CaseDev.Tests.Models.Vault.Graphrag;

public class GraphragGetStatsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new GraphragGetStatsParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        GraphragGetStatsParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/vault/id/graphrag/stats"), url);
    }
}
