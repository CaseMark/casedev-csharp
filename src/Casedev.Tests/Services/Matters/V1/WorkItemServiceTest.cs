using System.Threading.Tasks;
using Casedev.Models.Matters.V1.WorkItems;

namespace Casedev.Tests.Services.Matters.V1;

public class WorkItemServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        await this.client.Matters.V1.WorkItems.Create(
            "id",
            new() { Title = "title" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        await this.client.Matters.V1.WorkItems.Retrieve(
            "workItemId",
            new() { ID = "id" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task Update_Works()
    {
        await this.client.Matters.V1.WorkItems.Update(
            "workItemId",
            new() { ID = "id" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task List_Works()
    {
        await this.client.Matters.V1.WorkItems.List(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task Decide_Works()
    {
        await this.client.Matters.V1.WorkItems.Decide(
            "workItemId",
            new() { ID = "id", Decision = Decision.Approve },
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task ListExecutions_Works()
    {
        await this.client.Matters.V1.WorkItems.ListExecutions(
            "workItemId",
            new() { ID = "id" },
            TestContext.Current.CancellationToken
        );
    }
}
