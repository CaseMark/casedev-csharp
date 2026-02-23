using System.Threading.Tasks;

namespace Router.Tests.Services.Voice;

public class StreamingServiceTest : TestBase
{
    [Fact]
    public async Task GetUrl_Works()
    {
        var response = await this.client.Voice.Streaming.GetUrl(
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
