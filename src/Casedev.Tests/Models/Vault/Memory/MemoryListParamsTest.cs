using System;
using Casedev.Models.Vault.Memory;

namespace Casedev.Tests.Models.Vault.Memory;

public class MemoryListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MemoryListParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        MemoryListParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.case.dev/vault/id/memory"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new MemoryListParams { ID = "id" };

        MemoryListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
