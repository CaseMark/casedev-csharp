using System.Threading.Tasks;

namespace CaseDev.Tests.Services.Webhooks;

public class V1ServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Create_Works()
    {
        var v1 = await this.client.Webhooks.V1.Create(
            new()
            {
                Events = ["document.processed", "vault.updated"],
                URL = "https://api.lawfirm.com/webhooks/case-dev",
            },
            TestContext.Current.CancellationToken
        );
        v1.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        await this.client.Webhooks.V1.Retrieve("id", new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        await this.client.Webhooks.V1.List(new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Webhooks.V1.Delete(
            "wh_abc123xyz789",
            new(),
            TestContext.Current.CancellationToken
        );
    }
}
