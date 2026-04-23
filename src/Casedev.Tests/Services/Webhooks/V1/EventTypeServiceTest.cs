using System.Threading.Tasks;

namespace Casedev.Tests.Services.Webhooks.V1;

public class EventTypeServiceTest : TestBase
{
    [Fact]
    public async Task List_Works()
    {
        await this.client.Webhooks.V1.EventTypes.List(new(), TestContext.Current.CancellationToken);
    }
}
