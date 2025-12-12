using System.Text.Json;
using System.Threading.Tasks;

namespace CaseDev.Tests.Services.Templates;

public class V1ServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        await this.client.Templates.V1.Retrieve("id", new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        await this.client.Templates.V1.List(new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Execute_Works()
    {
        var response = await this.client.Templates.V1.Execute(
            "id",
            new() { Input = JsonSerializer.Deserialize<JsonElement>("{}") },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task RetrieveExecution_Works()
    {
        await this.client.Templates.V1.RetrieveExecution(
            "exec_abc123def456",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Search_Works()
    {
        await this.client.Templates.V1.Search(
            new() { Query = "query" },
            TestContext.Current.CancellationToken
        );
    }
}
