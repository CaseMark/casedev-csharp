using System.Threading.Tasks;

namespace CaseDev.Tests.Services.Compute;

public class V1ServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task GetPricing_Works()
    {
        await this.client.Compute.V1.GetPricing(new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task GetUsage_Works()
    {
        await this.client.Compute.V1.GetUsage(new(), TestContext.Current.CancellationToken);
    }
}
