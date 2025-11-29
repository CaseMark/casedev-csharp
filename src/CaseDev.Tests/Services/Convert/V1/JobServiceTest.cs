using System.Threading.Tasks;

namespace CaseDev.Tests.Services.Convert.V1;

public class JobServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        await this.client.Convert.V1.Jobs.Retrieve("id");
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Convert.V1.Jobs.Delete("id");
    }
}
