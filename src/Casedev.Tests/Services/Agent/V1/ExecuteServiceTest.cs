using System.Threading.Tasks;

namespace Casedev.Tests.Services.Agent.V1;

public class ExecuteServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var execute = await this.client.Agent.V1.Execute.Create(
            new() { Prompt = "prompt" },
            TestContext.Current.CancellationToken
        );
        execute.Validate();
    }
}
