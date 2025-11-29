using System.Threading.Tasks;

namespace CaseDev.Tests.Services.Voice.V1;

public class SpeakServiceTest : TestBase
{
    [Fact(Skip = "Prism doesn't support audio/mpeg responses")]
    public async Task Create_Works()
    {
        await this.client.Voice.V1.Speak.Create(new() { Text = "text" });
    }

    [Fact(Skip = "Prism doesn't support audio/mpeg responses")]
    public async Task Stream_Works()
    {
        await this.client.Voice.V1.Speak.Stream(new() { Text = "text" });
    }
}
