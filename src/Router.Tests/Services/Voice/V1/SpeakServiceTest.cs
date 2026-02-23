using System.Threading.Tasks;

namespace Router.Tests.Services.Voice.V1;

public class SpeakServiceTest : TestBase
{
    [Fact(Skip = "Mock server doesn't support audio/mpeg responses")]
    public async Task Create_Works()
    {
        await this.client.Voice.V1.Speak.Create(
            new() { Text = "text" },
            TestContext.Current.CancellationToken
        );
    }
}
