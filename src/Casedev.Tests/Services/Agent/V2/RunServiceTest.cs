using System.Threading.Tasks;

namespace Casedev.Tests.Services.Agent.V2;

public class RunServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var run = await this.client.Agent.V2.Run.Create(
            new() { AgentID = "agentId", Prompt = "prompt" },
            TestContext.Current.CancellationToken
        );
        run.Validate();
    }

    [Fact(Skip = "Mock server doesn't support text/event-stream responses")]
    public async Task EventsStreaming_Works()
    {
        var stream = this.client.Agent.V2.Run.EventsStreaming(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );

        await foreach (var response in stream) { }
    }

    [Fact]
    public async Task Exec_Works()
    {
        var response = await this.client.Agent.V2.Run.Exec(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact]
    public async Task GetDetails_Works()
    {
        await this.client.Agent.V2.Run.GetDetails(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task GetStatus_Works()
    {
        var response = await this.client.Agent.V2.Run.GetStatus(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
