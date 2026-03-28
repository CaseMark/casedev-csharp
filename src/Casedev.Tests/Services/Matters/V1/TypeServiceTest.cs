using System.Threading.Tasks;

namespace Casedev.Tests.Services.Matters.V1;

public class TypeServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        await this.client.Matters.V1.Types.Create(
            new() { Name = "name" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        await this.client.Matters.V1.Types.Retrieve(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task Update_Works()
    {
        await this.client.Matters.V1.Types.Update(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task List_Works()
    {
        await this.client.Matters.V1.Types.List(new(), TestContext.Current.CancellationToken);
    }
}
