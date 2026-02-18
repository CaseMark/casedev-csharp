using System.Threading.Tasks;

namespace CaseDev.Tests.Services;

public class SystemServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task ListServices_Works()
    {
        var response = await this.client.System.ListServices(
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
