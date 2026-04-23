using System.Threading.Tasks;

namespace Casedev.Tests.Services.Webhooks.V1;

public class DeliveryServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        await this.client.Webhooks.V1.Deliveries.Retrieve(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task List_Works()
    {
        await this.client.Webhooks.V1.Deliveries.List(new(), TestContext.Current.CancellationToken);
    }

    [Fact]
    public async Task Replay_Works()
    {
        await this.client.Webhooks.V1.Deliveries.Replay(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
    }
}
