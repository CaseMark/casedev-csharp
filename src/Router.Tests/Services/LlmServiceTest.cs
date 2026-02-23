using System.Threading.Tasks;

namespace Router.Tests.Services;

public class LlmServiceTest : TestBase
{
    [Fact]
    public async Task GetConfig_Works()
    {
        var response = await this.client.Llm.GetConfig(
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
