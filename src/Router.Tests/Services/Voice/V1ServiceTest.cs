using System.Threading.Tasks;

namespace Router.Tests.Services.Voice;

public class V1ServiceTest : TestBase
{
    [Fact]
    public async Task ListVoices_Works()
    {
        var response = await this.client.Voice.V1.ListVoices(
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
