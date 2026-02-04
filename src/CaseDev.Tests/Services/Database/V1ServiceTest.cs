using System.Threading.Tasks;

namespace CaseDev.Tests.Services.Database;

public class V1ServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task GetUsage_Works()
    {
        var response = await this.client.Database.V1.GetUsage(
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
