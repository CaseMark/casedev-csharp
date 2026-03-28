using System.Threading.Tasks;

namespace Casedev.Tests.Services.Agent.V2;

public class ExecuteServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var execute = await this.client.Agent.V2.Execute.Create(
            new() { Prompt = "prompt" },
            TestContext.Current.CancellationToken
        );
        execute.Validate();
    }
}
