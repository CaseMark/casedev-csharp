using System.Threading.Tasks;

namespace Casedev.Tests.Services.Agent.V1;

public class RunServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var run = await this.client.Agent.V1.Run.Create(
            new() { AgentID = "agentId", Prompt = "prompt" },
            TestContext.Current.CancellationToken
        );
        run.Validate();
    }

    [Fact]
    public async Task Cancel_Works()
    {
        var response = await this.client.Agent.V1.Run.Cancel(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact]
    public async Task Exec_Works()
    {
        var response = await this.client.Agent.V1.Run.Exec(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact]
    public async Task GetDetails_Works()
    {
        var response = await this.client.Agent.V1.Run.GetDetails(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact]
    public async Task GetStatus_Works()
    {
        var response = await this.client.Agent.V1.Run.GetStatus(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact]
    public async Task Watch_Works()
    {
        var response = await this.client.Agent.V1.Run.Watch(
            "id",
            new() { CallbackUrl = "https://example.com" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
