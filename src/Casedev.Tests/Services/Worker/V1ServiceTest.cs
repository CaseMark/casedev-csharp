using System.Threading.Tasks;

namespace Casedev.Tests.Services.Worker;

public class V1ServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        await this.client.Worker.V1.Create(new(), TestContext.Current.CancellationToken);
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        await this.client.Worker.V1.Retrieve("id", new(), TestContext.Current.CancellationToken);
    }

    [Fact]
    public async Task Delete_Works()
    {
        await this.client.Worker.V1.Delete("id", new(), TestContext.Current.CancellationToken);
    }

    [Fact]
    public async Task Boot_Works()
    {
        await this.client.Worker.V1.Boot("id", new(), TestContext.Current.CancellationToken);
    }

    [Fact]
    public async Task ProxyDelete_Works()
    {
        await this.client.Worker.V1.ProxyDelete(
            "workerPath",
            new() { ID = "id" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task ProxyGet_Works()
    {
        await this.client.Worker.V1.ProxyGet(
            "workerPath",
            new() { ID = "id" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task ProxyPatch_Works()
    {
        await this.client.Worker.V1.ProxyPatch(
            "workerPath",
            new() { ID = "id" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task ProxyPost_Works()
    {
        await this.client.Worker.V1.ProxyPost(
            "workerPath",
            new() { ID = "id" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task ProxyPut_Works()
    {
        await this.client.Worker.V1.ProxyPut(
            "workerPath",
            new() { ID = "id" },
            TestContext.Current.CancellationToken
        );
    }
}
