using System.Collections.Generic;
using System.Threading.Tasks;

namespace CaseDev.Tests.Services.Compute.V1;

public class SecretServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Create_Works()
    {
        var secret = await this.client.Compute.V1.Secrets.Create(
            new() { Name = "name" },
            TestContext.Current.CancellationToken
        );
        secret.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        await this.client.Compute.V1.Secrets.List(new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task DeleteGroup_Works()
    {
        await this.client.Compute.V1.Secrets.DeleteGroup(
            "group",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task RetrieveGroup_Works()
    {
        await this.client.Compute.V1.Secrets.RetrieveGroup(
            "group",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task UpdateGroup_Works()
    {
        await this.client.Compute.V1.Secrets.UpdateGroup(
            "litigation-apis",
            new() { Secrets = new Dictionary<string, string>() { { "foo", "string" } } },
            TestContext.Current.CancellationToken
        );
    }
}
