using System.Threading.Tasks;

namespace Casedev.Tests.Services.Voice;

public class TranscriptionServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var transcription = await this.client.Voice.Transcription.Create(
            new(),
            TestContext.Current.CancellationToken
        );
        transcription.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var transcription = await this.client.Voice.Transcription.Retrieve(
            "tr_abc123def456",
            new(),
            TestContext.Current.CancellationToken
        );
        transcription.Validate();
    }

    [Fact]
    public async Task Delete_Works()
    {
        await this.client.Voice.Transcription.Delete(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
    }
}
