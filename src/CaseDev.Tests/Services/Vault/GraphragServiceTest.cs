using System.Threading.Tasks;

namespace CaseDev.Tests.Services.Vault;

public class GraphragServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task GetStats_Works()
    {
        var response = await this.client.Vault.Graphrag.GetStats(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Init_Works()
    {
        var response = await this.client.Vault.Graphrag.Init(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task ProcessObject_Works()
    {
        var response = await this.client.Vault.Graphrag.ProcessObject(
            "objectId",
            new() { ID = "id" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
