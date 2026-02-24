using System.Threading.Tasks;
using Casedev.Models.Vault;

namespace Casedev.Tests.Services;

public class VaultServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var vault = await this.client.Vault.Create(
            new() { Name = "Contract Review Archive" },
            TestContext.Current.CancellationToken
        );
        vault.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var vault = await this.client.Vault.Retrieve(
            "vault_abc123",
            new(),
            TestContext.Current.CancellationToken
        );
        vault.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var vault = await this.client.Vault.Update(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        vault.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var vaults = await this.client.Vault.List(new(), TestContext.Current.CancellationToken);
        vaults.Validate();
    }

    [Fact]
    public async Task Delete_Works()
    {
        var vault = await this.client.Vault.Delete(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        vault.Validate();
    }

    [Fact]
    public async Task ConfirmUpload_Works()
    {
        var response = await this.client.Vault.ConfirmUpload(
            "objectId",
            new()
            {
                ID = "id",
                Body = new VaultConfirmUploadSuccess()
                {
                    SizeBytes = 1,
                    Success = Success.True,
                    Etag = "etag",
                },
            },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact]
    public async Task Ingest_Works()
    {
        var response = await this.client.Vault.Ingest(
            "objectId",
            new() { ID = "id" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact]
    public async Task Search_Works()
    {
        var response = await this.client.Vault.Search(
            "id",
            new() { Query = "query" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact]
    public async Task Upload_Works()
    {
        var response = await this.client.Vault.Upload(
            "id",
            new() { ContentType = "contentType", Filename = "filename" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
