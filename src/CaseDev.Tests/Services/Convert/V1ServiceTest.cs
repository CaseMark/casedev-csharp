using System.Threading.Tasks;
using CaseDev.Models.Convert.V1;

namespace CaseDev.Tests.Services.Convert;

public class V1ServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Download_Works()
    {
        await this.client.Convert.V1.Download("id");
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Process_Works()
    {
        var response = await this.client.Convert.V1.Process(
            new() { InputURL = "https://example.com" }
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Webhook_Works()
    {
        var response = await this.client.Convert.V1.Webhook(
            new() { JobID = "job_id", Status = Status.Completed }
        );
        response.Validate();
    }
}
