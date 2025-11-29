using System.Threading.Tasks;

namespace CaseDev.Tests.Services.Vault;

public class GraphragServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task GetStats_Works()
    {
        await this.client.Vault.Graphrag.GetStats("id");
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Init_Works()
    {
        await this.client.Vault.Graphrag.Init("id");
    }
}
