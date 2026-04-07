using System.Threading.Tasks;

namespace Casedev.Tests.Services.Usage;

public class V1ServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        await this.client.Usage.V1.Retrieve(new(), TestContext.Current.CancellationToken);
    }
}
