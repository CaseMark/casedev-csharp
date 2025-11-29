using System.Threading.Tasks;

namespace CaseDev.Tests.Services.Compute.V1;

public class RunServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        await this.client.Compute.V1.Runs.Retrieve("id");
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        await this.client.Compute.V1.Runs.List();
    }
}
