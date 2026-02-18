using System.Threading.Tasks;

namespace CaseDev.Tests.Services.Vault;

public class GroupServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Create_Works()
    {
        await this.client.Vault.Groups.Create(new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Update_Works()
    {
        await this.client.Vault.Groups.Update(
            "groupId",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        await this.client.Vault.Groups.List(new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Vault.Groups.Delete(
            "groupId",
            new(),
            TestContext.Current.CancellationToken
        );
    }
}
