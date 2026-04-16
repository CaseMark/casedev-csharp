using System;
using Casedev.Models.Vault.Memory;

namespace Casedev.Tests.Models.Vault.Memory;

public class MemoryDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MemoryDeleteParams { ID = "id", EntryID = "entryId" };

        string expectedID = "id";
        string expectedEntryID = "entryId";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedEntryID, parameters.EntryID);
    }

    [Fact]
    public void Url_Works()
    {
        MemoryDeleteParams parameters = new() { ID = "id", EntryID = "entryId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.case.dev/vault/id/memory/entryId"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new MemoryDeleteParams { ID = "id", EntryID = "entryId" };

        MemoryDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
