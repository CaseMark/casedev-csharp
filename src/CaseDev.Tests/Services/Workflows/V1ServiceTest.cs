using System.Threading.Tasks;

namespace CaseDev.Tests.Services.Workflows;

public class V1ServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Create_Works()
    {
        var v1 = await this.client.Workflows.V1.Create(new() { Name = "Document Processor" });
        v1.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        var v1 = await this.client.Workflows.V1.Retrieve("id");
        v1.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Update_Works()
    {
        var v1 = await this.client.Workflows.V1.Update("id");
        v1.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        var v1s = await this.client.Workflows.V1.List();
        v1s.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Delete_Works()
    {
        var v1 = await this.client.Workflows.V1.Delete("id");
        v1.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Deploy_Works()
    {
        var response = await this.client.Workflows.V1.Deploy("id");
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Execute_Works()
    {
        var response = await this.client.Workflows.V1.Execute("id");
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task ListExecutions_Works()
    {
        var response = await this.client.Workflows.V1.ListExecutions("id");
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task RetrieveExecution_Works()
    {
        var response = await this.client.Workflows.V1.RetrieveExecution("id");
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Undeploy_Works()
    {
        var response = await this.client.Workflows.V1.Undeploy("id");
        response.Validate();
    }
}
