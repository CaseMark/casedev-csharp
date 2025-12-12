using System.Threading.Tasks;

namespace CaseDev.Tests.Services.Voice;

public class TranscriptionServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Create_Works()
    {
        await this.client.Voice.Transcription.Create(
            new() { AudioURL = "audio_url" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        var transcription = await this.client.Voice.Transcription.Retrieve(
            "5551902f-fc65-4a61-81b2-e002d4e464e5",
            new(),
            TestContext.Current.CancellationToken
        );
        transcription.Validate();
    }
}
