using System.Threading.Tasks;

namespace CaseDev.Tests.Services.Vault;

public class ObjectServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        await this.client.Vault.Objects.Retrieve(
            "objectId",
            new() { ID = "id" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        await this.client.Vault.Objects.List("id", new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task CreatePresignedURL_Works()
    {
        var response = await this.client.Vault.Objects.CreatePresignedURL(
            "objectId",
            new() { ID = "id" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Download_Works()
    {
        await this.client.Vault.Objects.Download(
            "objectId",
            new() { ID = "id" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task GetText_Works()
    {
        await this.client.Vault.Objects.GetText(
            "objectId",
            new() { ID = "id" },
            TestContext.Current.CancellationToken
        );
    }
}
