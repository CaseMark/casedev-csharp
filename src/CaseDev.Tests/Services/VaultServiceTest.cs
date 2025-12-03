using System.Threading.Tasks;

namespace CaseDev.Tests.Services;

public class VaultServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Create_Works()
    {
        var vault = await this.client.Vault.Create(new() { Name = "Contract Review Archive" });
        vault.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        await this.client.Vault.Retrieve("vault_abc123");
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        var vaults = await this.client.Vault.List();
        vaults.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Ingest_Works()
    {
        var response = await this.client.Vault.Ingest("objectId", new() { ID = "id" });
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Search_Works()
    {
        var response = await this.client.Vault.Search("id", new() { Query = "query" });
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Upload_Works()
    {
        var response = await this.client.Vault.Upload(
            "id",
            new() { ContentType = "contentType", Filename = "filename" }
        );
        response.Validate();
    }
}
