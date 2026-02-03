using System.Threading.Tasks;

namespace CaseDev.Tests.Services.Database.V1;

public class ProjectServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Create_Works()
    {
        var project = await this.client.Database.V1.Projects.Create(
            new() { Name = "litigation-docs-db" },
            TestContext.Current.CancellationToken
        );
        project.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        var project = await this.client.Database.V1.Projects.Retrieve(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        project.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        var projects = await this.client.Database.V1.Projects.List(
            new(),
            TestContext.Current.CancellationToken
        );
        projects.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Delete_Works()
    {
        var project = await this.client.Database.V1.Projects.Delete(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        project.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task CreateBranch_Works()
    {
        var response = await this.client.Database.V1.Projects.CreateBranch(
            "id",
            new() { Name = "staging" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task GetConnection_Works()
    {
        var response = await this.client.Database.V1.Projects.GetConnection(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task ListBranches_Works()
    {
        var response = await this.client.Database.V1.Projects.ListBranches(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
