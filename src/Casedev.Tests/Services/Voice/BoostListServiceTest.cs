using System.Threading.Tasks;

namespace Casedev.Tests.Services.Voice;

public class BoostListServiceTest : TestBase
{
    [Fact]
    public async Task Extract_Works()
    {
        var response = await this.client.Voice.BoostList.Extract(
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact]
    public async Task Generate_Works()
    {
        var response = await this.client.Voice.BoostList.Generate(
            new() { TranscriptionJobID = "transcription_job_id" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
