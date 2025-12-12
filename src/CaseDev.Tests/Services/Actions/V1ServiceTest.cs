using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace CaseDev.Tests.Services.Actions;

public class V1ServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Create_Works()
    {
        var v1 = await this.client.Actions.V1.Create(
            new() { Definition = "string", Name = "name" },
            TestContext.Current.CancellationToken
        );
        v1.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        await this.client.Actions.V1.Retrieve("id", new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        await this.client.Actions.V1.List(new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Actions.V1.Delete("id", new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Execute_Works()
    {
        var response = await this.client.Actions.V1.Execute(
            "id",
            new()
            {
                Input = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task RetrieveExecution_Works()
    {
        await this.client.Actions.V1.RetrieveExecution(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
    }
}
