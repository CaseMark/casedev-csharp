using System.Threading.Tasks;

namespace Router.Tests.Services.Privilege;

public class V1ServiceTest : TestBase
{
    [Fact]
    public async Task Detect_Works()
    {
        var response = await this.client.Privilege.V1.Detect(
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
