using System.Threading.Tasks;

namespace CaseDev.Tests.Services;

public class LlmServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task GetConfig_Works()
    {
        await this.client.Llm.GetConfig();
    }
}
