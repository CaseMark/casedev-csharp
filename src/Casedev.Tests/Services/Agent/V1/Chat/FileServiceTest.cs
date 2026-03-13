using System.Threading.Tasks;

namespace Casedev.Tests.Services.Agent.V1.Chat;

public class FileServiceTest : TestBase
{
    [Fact]
    public async Task List_Works()
    {
        var files = await this.client.Agent.V1.Chat.Files.List(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        files.Validate();
    }

    [Fact(Skip = "Mock server doesn't support application/octet-stream responses")]
    public async Task Download_Works()
    {
        await this.client.Agent.V1.Chat.Files.Download(
            "path",
            new() { ID = "id" },
            TestContext.Current.CancellationToken
        );
    }
}
