using System.Text.Json;
using System.Threading.Tasks;

namespace CaseDev.Tests.Services.Workflows;

public class V1ServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        await this.client.Workflows.V1.Retrieve("id");
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        await this.client.Workflows.V1.List();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Execute_Works()
    {
        var response = await this.client.Workflows.V1.Execute(
            "id",
            new() { Input = JsonSerializer.Deserialize<JsonElement>("{}") }
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task RetrieveExecution_Works()
    {
        await this.client.Workflows.V1.RetrieveExecution("exec_abc123def456");
    }
}
