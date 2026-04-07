using System.Threading.Tasks;

namespace Casedev.Tests.Services.Usage.V1;

public class SubscriptionServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        await this.client.Usage.V1.Subscriptions.Create(
            new() { CallbackUrl = "https://example.com" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task Update_Works()
    {
        await this.client.Usage.V1.Subscriptions.Update(
            "subscriptionId",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task List_Works()
    {
        await this.client.Usage.V1.Subscriptions.List(new(), TestContext.Current.CancellationToken);
    }

    [Fact]
    public async Task Delete_Works()
    {
        await this.client.Usage.V1.Subscriptions.Delete(
            "subscriptionId",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task Test_Works()
    {
        await this.client.Usage.V1.Subscriptions.Test(
            "subscriptionId",
            new(),
            TestContext.Current.CancellationToken
        );
    }
}
