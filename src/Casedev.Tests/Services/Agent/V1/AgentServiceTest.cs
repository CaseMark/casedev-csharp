using System.Threading.Tasks;

namespace Casedev.Tests.Services.Agent.V1;

public class AgentServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var agent = await this.client.Agent.V1.Agents.Create(
            new() { Instructions = "instructions", Name = "name" },
            TestContext.Current.CancellationToken
        );
        agent.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var agent = await this.client.Agent.V1.Agents.Retrieve(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        agent.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var agent = await this.client.Agent.V1.Agents.Update(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        agent.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var agents = await this.client.Agent.V1.Agents.List(
            new(),
            TestContext.Current.CancellationToken
        );
        agents.Validate();
    }

    [Fact]
    public async Task Delete_Works()
    {
        var agent = await this.client.Agent.V1.Agents.Delete(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        agent.Validate();
    }
}
