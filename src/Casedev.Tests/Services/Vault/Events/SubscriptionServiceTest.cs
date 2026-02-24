using System.Threading.Tasks;

namespace Casedev.Tests.Services.Vault.Events;

public class SubscriptionServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        await this.client.Vault.Events.Subscriptions.Create(
            "id",
            new() { CallbackUrl = "https://example.com" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task Update_Works()
    {
        await this.client.Vault.Events.Subscriptions.Update(
            "subscriptionId",
            new() { ID = "id" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task List_Works()
    {
        await this.client.Vault.Events.Subscriptions.List(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task Delete_Works()
    {
        await this.client.Vault.Events.Subscriptions.Delete(
            "subscriptionId",
            new() { ID = "id" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task Test_Works()
    {
        await this.client.Vault.Events.Subscriptions.Test(
            "subscriptionId",
            new() { ID = "id" },
            TestContext.Current.CancellationToken
        );
    }
}
