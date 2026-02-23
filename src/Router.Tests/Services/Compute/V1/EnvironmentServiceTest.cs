using System.Threading.Tasks;

namespace Router.Tests.Services.Compute.V1;

public class EnvironmentServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var environment = await this.client.Compute.V1.Environments.Create(
            new() { Name = "document-review-prod" },
            TestContext.Current.CancellationToken
        );
        environment.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var environment = await this.client.Compute.V1.Environments.Retrieve(
            "name",
            new(),
            TestContext.Current.CancellationToken
        );
        environment.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var environments = await this.client.Compute.V1.Environments.List(
            new(),
            TestContext.Current.CancellationToken
        );
        environments.Validate();
    }

    [Fact]
    public async Task Delete_Works()
    {
        var environment = await this.client.Compute.V1.Environments.Delete(
            "litigation-processing",
            new(),
            TestContext.Current.CancellationToken
        );
        environment.Validate();
    }

    [Fact]
    public async Task SetDefault_Works()
    {
        var response = await this.client.Compute.V1.Environments.SetDefault(
            "prod-legal-docs",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
