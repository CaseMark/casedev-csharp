using System.Threading.Tasks;

namespace Router.Tests.Services.Applications.V1;

public class DeploymentServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        await this.client.Applications.V1.Deployments.Create(
            new() { ProjectID = "projectId" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        await this.client.Applications.V1.Deployments.Retrieve(
            "id",
            new() { ProjectID = "projectId" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task List_Works()
    {
        await this.client.Applications.V1.Deployments.List(
            new() { ProjectID = "projectId" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task Cancel_Works()
    {
        await this.client.Applications.V1.Deployments.Cancel(
            "id",
            new() { ProjectID = "projectId" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task CreateFromFiles_Works()
    {
        await this.client.Applications.V1.Deployments.CreateFromFiles(
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task GetLogs_Works()
    {
        await this.client.Applications.V1.Deployments.GetLogs(
            "id",
            new() { ProjectID = "projectId" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task GetStatus_Works()
    {
        await this.client.Applications.V1.Deployments.GetStatus(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task Stream_Works()
    {
        await this.client.Applications.V1.Deployments.Stream(
            "id",
            new() { ProjectID = "projectId" },
            TestContext.Current.CancellationToken
        );
    }
}
