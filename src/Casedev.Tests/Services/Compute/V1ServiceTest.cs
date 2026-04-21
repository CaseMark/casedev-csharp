using System.Threading.Tasks;

namespace Casedev.Tests.Services.Compute;

public class V1ServiceTest : TestBase
{
    [Fact]
    public async Task GetUsage_Works()
    {
        var response = await this.client.Compute.V1.GetUsage(
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
