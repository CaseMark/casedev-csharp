using System.Threading.Tasks;

namespace Router.Tests.Services.Vault;

public class ObjectServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var object_ = await this.client.Vault.Objects.Retrieve(
            "objectId",
            new() { ID = "id" },
            TestContext.Current.CancellationToken
        );
        object_.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var object_ = await this.client.Vault.Objects.Update(
            "objectId",
            new() { ID = "id" },
            TestContext.Current.CancellationToken
        );
        object_.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var objects = await this.client.Vault.Objects.List(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        objects.Validate();
    }

    [Fact]
    public async Task Delete_Works()
    {
        var object_ = await this.client.Vault.Objects.Delete(
            "objectId",
            new() { ID = "id" },
            TestContext.Current.CancellationToken
        );
        object_.Validate();
    }

    [Fact]
    public async Task CreatePresignedUrl_Works()
    {
        var response = await this.client.Vault.Objects.CreatePresignedUrl(
            "objectId",
            new() { ID = "id" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server doesn't support application/octet-stream responses")]
    public async Task Download_Works()
    {
        await this.client.Vault.Objects.Download(
            "objectId",
            new() { ID = "id" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task GetOcrWords_Works()
    {
        var response = await this.client.Vault.Objects.GetOcrWords(
            "objectId",
            new() { ID = "id" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact]
    public async Task GetSummarizeJob_Works()
    {
        var response = await this.client.Vault.Objects.GetSummarizeJob(
            "jobId",
            new() { ID = "id", ObjectID = "objectId" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact]
    public async Task GetText_Works()
    {
        var response = await this.client.Vault.Objects.GetText(
            "objectId",
            new() { ID = "id" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
