using System.Threading.Tasks;
using CaseDev.Models.Projects.V1;

namespace CaseDev.Tests.Services.Projects;

public class V1ServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Create_Works()
    {
        await this.client.Projects.V1.Create(
            new() { Name = "name", SourceType = SourceType.GitHub },
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        await this.client.Projects.V1.Retrieve("id", new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        var v1s = await this.client.Projects.V1.List(new(), TestContext.Current.CancellationToken);
        v1s.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Delete_Works()
    {
        var v1 = await this.client.Projects.V1.Delete(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        v1.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task CreateEnvVars_Works()
    {
        await this.client.Projects.V1.CreateEnvVars(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task ListEnvVars_Works()
    {
        await this.client.Projects.V1.ListEnvVars(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
    }
}
