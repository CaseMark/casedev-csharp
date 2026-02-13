using System.Threading.Tasks;

namespace CaseDev.Tests.Services.Legal;

public class V1ServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Find_Works()
    {
        var response = await this.client.Legal.V1.Find(
            new() { Query = "xxx" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task GetCitations_Works()
    {
        var response = await this.client.Legal.V1.GetCitations(
            new() { Text = "text" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task GetCitationsFromUrl_Works()
    {
        var response = await this.client.Legal.V1.GetCitationsFromUrl(
            new() { UrlValue = "https://example.com" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task GetFullText_Works()
    {
        var response = await this.client.Legal.V1.GetFullText(
            new() { UrlValue = "https://example.com" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task ListJurisdictions_Works()
    {
        var response = await this.client.Legal.V1.ListJurisdictions(
            new() { Name = "xx" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task PatentSearch_Works()
    {
        var response = await this.client.Legal.V1.PatentSearch(
            new() { Query = "x" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Research_Works()
    {
        var response = await this.client.Legal.V1.Research(
            new() { Query = "xxx" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Similar_Works()
    {
        var response = await this.client.Legal.V1.Similar(
            new() { UrlValue = "https://example.com" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Verify_Works()
    {
        var response = await this.client.Legal.V1.Verify(
            new() { Text = "text" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
