using System.Threading.Tasks;

namespace CaseDev.Tests.Services.Voice;

public class TranscriptionServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Create_Works()
    {
        var transcription = await this.client.Voice.Transcription.Create(
            new(),
            TestContext.Current.CancellationToken
        );
        transcription.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        var transcription = await this.client.Voice.Transcription.Retrieve(
            "tr_abc123def456",
            new(),
            TestContext.Current.CancellationToken
        );
        transcription.Validate();
    }
}
