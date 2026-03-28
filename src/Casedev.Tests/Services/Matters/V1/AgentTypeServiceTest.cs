using System.Threading.Tasks;

namespace Casedev.Tests.Services.Matters.V1;

public class AgentTypeServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        await this.client.Matters.V1.AgentTypes.Create(
            new() { Instructions = "instructions", Name = "name" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task List_Works()
    {
        await this.client.Matters.V1.AgentTypes.List(new(), TestContext.Current.CancellationToken);
    }
}
