using System.Threading.Tasks;

namespace CaseDev.Tests.Services.Privilege;

public class V1ServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Detect_Works()
    {
        var response = await this.client.Privilege.V1.Detect(
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
