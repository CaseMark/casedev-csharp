using System.Threading.Tasks;

namespace Casedev.Tests.Services.Matters;

public class V1ServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        await this.client.Matters.V1.Create(
            new() { Title = "title" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        await this.client.Matters.V1.Retrieve("id", new(), TestContext.Current.CancellationToken);
    }

    [Fact]
    public async Task Update_Works()
    {
        await this.client.Matters.V1.Update("id", new(), TestContext.Current.CancellationToken);
    }

    [Fact]
    public async Task List_Works()
    {
        await this.client.Matters.V1.List(new(), TestContext.Current.CancellationToken);
    }
}
