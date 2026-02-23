using System.Threading.Tasks;
using Router.Models.Ocr.V1;

namespace Router.Tests.Services.Ocr;

public class V1ServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var v1 = await this.client.Ocr.V1.Retrieve(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        v1.Validate();
    }

    [Fact(Skip = "Mock server doesn't support application/octet-stream responses")]
    public async Task Download_Works()
    {
        await this.client.Ocr.V1.Download(
            Type.Text,
            new() { ID = "id" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task Process_Works()
    {
        var response = await this.client.Ocr.V1.Process(
            new() { DocumentUrl = "https://example.com/contract.pdf" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
