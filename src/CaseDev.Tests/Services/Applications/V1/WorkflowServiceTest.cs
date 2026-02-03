using System.Threading.Tasks;

namespace CaseDev.Tests.Services.Applications.V1;

public class WorkflowServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task GetStatus_Works()
    {
        await this.client.Applications.V1.Workflows.GetStatus(
            "id",
            new() { ProjectID = "projectId" },
            TestContext.Current.CancellationToken
        );
    }
}
