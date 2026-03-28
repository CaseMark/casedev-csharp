using System.Threading.Tasks;

namespace Casedev.Tests.Services.Matters.V1;

public class LogServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        await this.client.Matters.V1.Log.Create(
            "id",
            new() { Summary = "summary" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task List_Works()
    {
        await this.client.Matters.V1.Log.List("id", new(), TestContext.Current.CancellationToken);
    }

    [Fact]
    public async Task Export_Works()
    {
        var response = await this.client.Matters.V1.Log.Export(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
