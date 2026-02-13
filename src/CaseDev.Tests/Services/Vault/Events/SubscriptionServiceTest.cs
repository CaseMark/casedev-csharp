using System.Threading.Tasks;

namespace CaseDev.Tests.Services.Vault.Events;

public class SubscriptionServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Create_Works()
    {
        await this.client.Vault.Events.Subscriptions.Create(
            "id",
            new() { CallbackUrl = "https://example.com" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Update_Works()
    {
        await this.client.Vault.Events.Subscriptions.Update(
            "subscriptionId",
            new() { ID = "id" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        await this.client.Vault.Events.Subscriptions.List(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Vault.Events.Subscriptions.Delete(
            "subscriptionId",
            new() { ID = "id" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Test_Works()
    {
        await this.client.Vault.Events.Subscriptions.Test(
            "subscriptionId",
            new() { ID = "id" },
            TestContext.Current.CancellationToken
        );
    }
}
