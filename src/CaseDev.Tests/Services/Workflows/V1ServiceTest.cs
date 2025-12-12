using System.Threading.Tasks;

namespace CaseDev.Tests.Services.Workflows;

public class V1ServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Create_Works()
    {
        var v1 = await this.client.Workflows.V1.Create(
            new() { Name = "Document Processor" },
            TestContext.Current.CancellationToken
        );
        v1.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        var v1 = await this.client.Workflows.V1.Retrieve(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        v1.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Update_Works()
    {
        var v1 = await this.client.Workflows.V1.Update(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        v1.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        var v1s = await this.client.Workflows.V1.List(new(), TestContext.Current.CancellationToken);
        v1s.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Delete_Works()
    {
        var v1 = await this.client.Workflows.V1.Delete(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        v1.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Deploy_Works()
    {
        var response = await this.client.Workflows.V1.Deploy(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Execute_Works()
    {
        var response = await this.client.Workflows.V1.Execute(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task ListExecutions_Works()
    {
        var response = await this.client.Workflows.V1.ListExecutions(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task RetrieveExecution_Works()
    {
        var response = await this.client.Workflows.V1.RetrieveExecution(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Undeploy_Works()
    {
        var response = await this.client.Workflows.V1.Undeploy(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
