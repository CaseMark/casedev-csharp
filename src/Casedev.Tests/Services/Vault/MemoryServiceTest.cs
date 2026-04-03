using System.Threading.Tasks;
using Casedev.Models.Vault.Memory;

namespace Casedev.Tests.Services.Vault;

public class MemoryServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var memory = await this.client.Vault.Memory.Create(
            "id",
            new() { Content = "content", Type = Type.Fact },
            TestContext.Current.CancellationToken
        );
        memory.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        await this.client.Vault.Memory.Update(
            "entryId",
            new() { ID = "id" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task List_Works()
    {
        var memories = await this.client.Vault.Memory.List(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        memories.Validate();
    }

    [Fact]
    public async Task Delete_Works()
    {
        await this.client.Vault.Memory.Delete(
            "entryId",
            new() { ID = "id" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task Search_Works()
    {
        var response = await this.client.Vault.Memory.Search(
            "id",
            new() { Query = "query" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
