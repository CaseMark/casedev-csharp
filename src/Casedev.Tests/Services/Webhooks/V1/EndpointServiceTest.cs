using System.Threading.Tasks;

namespace Casedev.Tests.Services.Webhooks.V1;

public class EndpointServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        await this.client.Webhooks.V1.Endpoints.Create(
            new() { EventTypeFilters = ["string"], UrlValue = "https://example.com" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        await this.client.Webhooks.V1.Endpoints.Retrieve(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task Update_Works()
    {
        await this.client.Webhooks.V1.Endpoints.Update(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task List_Works()
    {
        await this.client.Webhooks.V1.Endpoints.List(new(), TestContext.Current.CancellationToken);
    }

    [Fact]
    public async Task Delete_Works()
    {
        await this.client.Webhooks.V1.Endpoints.Delete(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task RotateSecret_Works()
    {
        await this.client.Webhooks.V1.Endpoints.RotateSecret(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task Test_Works()
    {
        await this.client.Webhooks.V1.Endpoints.Test(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
    }
}
