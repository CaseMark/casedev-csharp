using System.Threading.Tasks;
using CaseDev.Models.Memory.V1;

namespace CaseDev.Tests.Services.Memory;

public class V1ServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Create_Works()
    {
        var v1 = await this.client.Memory.V1.Create(
            new() { Messages = [new() { Content = "content", Role = Role.User }] },
            TestContext.Current.CancellationToken
        );
        v1.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        var v1 = await this.client.Memory.V1.Retrieve(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        v1.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        var v1s = await this.client.Memory.V1.List(new(), TestContext.Current.CancellationToken);
        v1s.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Delete_Works()
    {
        var v1 = await this.client.Memory.V1.Delete(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        v1.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task DeleteAll_Works()
    {
        var response = await this.client.Memory.V1.DeleteAll(
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Search_Works()
    {
        var response = await this.client.Memory.V1.Search(
            new() { Query = "query" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
