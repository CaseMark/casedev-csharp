using System.Threading.Tasks;
using CaseDev.Models.Ocr.V1;

namespace CaseDev.Tests.Services.Ocr;

public class V1ServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        await this.client.Ocr.V1.Retrieve("id", new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Download_Works()
    {
        await this.client.Ocr.V1.Download(
            Type.Text,
            new() { ID = "id" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Process_Works()
    {
        var response = await this.client.Ocr.V1.Process(
            new() { DocumentURL = "https://example.com/contract.pdf" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
