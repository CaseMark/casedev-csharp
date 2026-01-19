using System.Threading.Tasks;

namespace CaseDev.Tests.Services.Search;

public class V1ServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Answer_Works()
    {
        var response = await this.client.Search.V1.Answer(
            new() { Query = "query" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Contents_Works()
    {
        var response = await this.client.Search.V1.Contents(
            new() { Urls = ["https://example.com"] },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Research_Works()
    {
        var response = await this.client.Search.V1.Research(
            new() { Instructions = "instructions" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task RetrieveResearch_Works()
    {
        var response = await this.client.Search.V1.RetrieveResearch(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Search_Works()
    {
        var response = await this.client.Search.V1.Search(
            new() { Query = "query" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Similar_Works()
    {
        var response = await this.client.Search.V1.Similar(
            new() { UrlValue = "https://example.com" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
