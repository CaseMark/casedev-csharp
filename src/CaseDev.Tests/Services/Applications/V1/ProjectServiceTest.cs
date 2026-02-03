using System.Threading.Tasks;
using CaseDev.Models.Applications.V1.Projects;

namespace CaseDev.Tests.Services.Applications.V1;

public class ProjectServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Create_Works()
    {
        await this.client.Applications.V1.Projects.Create(
            new() { GitRepo = "gitRepo", Name = "name" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        await this.client.Applications.V1.Projects.Retrieve(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        var projects = await this.client.Applications.V1.Projects.List(
            new(),
            TestContext.Current.CancellationToken
        );
        projects.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Applications.V1.Projects.Delete(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task CreateDeployment_Works()
    {
        await this.client.Applications.V1.Projects.CreateDeployment(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task CreateDomain_Works()
    {
        await this.client.Applications.V1.Projects.CreateDomain(
            "id",
            new() { Domain = "domain" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task CreateEnv_Works()
    {
        await this.client.Applications.V1.Projects.CreateEnv(
            "id",
            new()
            {
                Key = "key",
                Target = [ProjectCreateEnvParamsTarget.Production],
                Value = "value",
            },
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task DeleteDomain_Works()
    {
        await this.client.Applications.V1.Projects.DeleteDomain(
            "domain",
            new() { ID = "id" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task DeleteEnv_Works()
    {
        await this.client.Applications.V1.Projects.DeleteEnv(
            "envId",
            new() { ID = "id" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task GetRuntimeLogs_Works()
    {
        await this.client.Applications.V1.Projects.GetRuntimeLogs(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task ListDeployments_Works()
    {
        await this.client.Applications.V1.Projects.ListDeployments(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task ListDomains_Works()
    {
        await this.client.Applications.V1.Projects.ListDomains(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task ListEnv_Works()
    {
        await this.client.Applications.V1.Projects.ListEnv(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
    }
}
