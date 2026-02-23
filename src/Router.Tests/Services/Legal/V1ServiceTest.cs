using System.Threading.Tasks;

namespace Router.Tests.Services.Legal;

public class V1ServiceTest : TestBase
{
    [Fact]
    public async Task Find_Works()
    {
        var response = await this.client.Legal.V1.Find(
            new() { Query = "xxx" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact]
    public async Task GetCitations_Works()
    {
        var response = await this.client.Legal.V1.GetCitations(
            new() { Text = "text" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact]
    public async Task GetCitationsFromUrl_Works()
    {
        var response = await this.client.Legal.V1.GetCitationsFromUrl(
            new() { UrlValue = "https://example.com" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact]
    public async Task GetFullText_Works()
    {
        var response = await this.client.Legal.V1.GetFullText(
            new() { UrlValue = "https://example.com" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact]
    public async Task ListJurisdictions_Works()
    {
        var response = await this.client.Legal.V1.ListJurisdictions(
            new() { Name = "xx" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact]
    public async Task PatentSearch_Works()
    {
        var response = await this.client.Legal.V1.PatentSearch(
            new() { Query = "x" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact]
    public async Task Research_Works()
    {
        var response = await this.client.Legal.V1.Research(
            new() { Query = "xxx" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact]
    public async Task Similar_Works()
    {
        var response = await this.client.Legal.V1.Similar(
            new() { UrlValue = "https://example.com" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact]
    public async Task TrademarkSearch_Works()
    {
        var response = await this.client.Legal.V1.TrademarkSearch(
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact]
    public async Task Verify_Works()
    {
        var response = await this.client.Legal.V1.Verify(
            new() { Text = "text" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
