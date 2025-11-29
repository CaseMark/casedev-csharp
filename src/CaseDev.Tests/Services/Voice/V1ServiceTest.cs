using System.Threading.Tasks;

namespace CaseDev.Tests.Services.Voice;

public class V1ServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task ListVoices_Works()
    {
        await this.client.Voice.V1.ListVoices();
    }
}
