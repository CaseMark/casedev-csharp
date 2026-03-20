using System.Threading.Tasks;

namespace Casedev.Tests.Services.Voice.V1;

public class SpeakServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        await this.client.Voice.V1.Speak.Create(
            new() { Text = "text" },
            TestContext.Current.CancellationToken
        );
    }
}
