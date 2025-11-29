using System.Threading.Tasks;

namespace CaseDev.Tests.Services.Compute.V1;

public class FunctionServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        await this.client.Compute.V1.Functions.List();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task GetLogs_Works()
    {
        await this.client.Compute.V1.Functions.GetLogs("id");
    }
}
