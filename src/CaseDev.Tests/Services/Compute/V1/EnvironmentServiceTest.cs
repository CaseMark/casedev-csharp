using System.Threading.Tasks;

namespace CaseDev.Tests.Services.Compute.V1;

public class EnvironmentServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Create_Works()
    {
        var environment = await this.client.Compute.V1.Environments.Create(
            new() { Name = "document-review-prod" }
        );
        environment.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        await this.client.Compute.V1.Environments.Retrieve("name");
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        await this.client.Compute.V1.Environments.List();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Delete_Works()
    {
        var environment = await this.client.Compute.V1.Environments.Delete("litigation-processing");
        environment.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task SetDefault_Works()
    {
        await this.client.Compute.V1.Environments.SetDefault("prod-legal-docs");
    }
}
