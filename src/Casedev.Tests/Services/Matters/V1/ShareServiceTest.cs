using System.Threading.Tasks;

namespace Casedev.Tests.Services.Matters.V1;

public class ShareServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        await this.client.Matters.V1.Shares.Create(
            "id",
            new() { TargetOrgID = "target_org_id" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task List_Works()
    {
        await this.client.Matters.V1.Shares.List(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task Delete_Works()
    {
        await this.client.Matters.V1.Shares.Delete(
            "shareId",
            new() { ID = "id" },
            TestContext.Current.CancellationToken
        );
    }
}
