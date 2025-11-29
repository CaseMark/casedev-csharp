using System.Threading.Tasks;
using CaseDev.Models.Compute.V1;

namespace CaseDev.Tests.Services.Compute;

public class V1ServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Deploy_Works()
    {
        var response = await this.client.Compute.V1.Deploy(
            new() { EntrypointName = "entrypointName", Type = Type.Task }
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task GetPricing_Works()
    {
        await this.client.Compute.V1.GetPricing();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task GetUsage_Works()
    {
        await this.client.Compute.V1.GetUsage();
    }
}
