using System.Threading.Tasks;

namespace CaseDev.Tests.Services.Voice;

public class StreamingServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task GetUrl_Works()
    {
        var response = await this.client.Voice.Streaming.GetUrl(
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
