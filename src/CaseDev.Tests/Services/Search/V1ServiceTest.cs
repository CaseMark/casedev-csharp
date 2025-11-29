using System.Threading.Tasks;

namespace CaseDev.Tests.Services.Search;

public class V1ServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Answer_Works()
    {
        var response = await this.client.Search.V1.Answer(new() { Query = "query" });
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Contents_Works()
    {
        var response = await this.client.Search.V1.Contents(
            new() { URLs = ["https://example.com"] }
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Research_Works()
    {
        var response = await this.client.Search.V1.Research(
            new() { Instructions = "instructions" }
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task RetrieveResearch_Works()
    {
        await this.client.Search.V1.RetrieveResearch("id");
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Search_Works()
    {
        var response = await this.client.Search.V1.Search(new() { Query = "query" });
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Similar_Works()
    {
        var response = await this.client.Search.V1.Similar(new() { URL = "https://example.com" });
        response.Validate();
    }
}
