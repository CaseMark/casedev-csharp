using System.Threading.Tasks;

namespace CaseDev.Tests.Services;

public class LlmServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task GetConfig_Works()
    {
        var response = await this.client.Llm.GetConfig(
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
