using System.Threading.Tasks;

namespace CaseDev.Tests.Services.Voice;

public class StreamingServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task GetURL_Works()
    {
        await this.client.Voice.Streaming.GetURL(new(), TestContext.Current.CancellationToken);
    }
}
