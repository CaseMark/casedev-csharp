using System.Threading.Tasks;

namespace Casedev.Tests.Services.Matters.V1.Events;

public class SubscriptionServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        await this.client.Matters.V1.Events.Subscriptions.Create(
            "id",
            new() { CallbackUrl = "https://example.com" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task List_Works()
    {
        await this.client.Matters.V1.Events.Subscriptions.List(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task Delete_Works()
    {
        await this.client.Matters.V1.Events.Subscriptions.Delete(
            "subscriptionId",
            new() { ID = "id" },
            TestContext.Current.CancellationToken
        );
    }
}
