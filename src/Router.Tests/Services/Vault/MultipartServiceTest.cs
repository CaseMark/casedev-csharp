using System.Threading.Tasks;

namespace Router.Tests.Services.Vault;

public class MultipartServiceTest : TestBase
{
    [Fact]
    public async Task Abort_Works()
    {
        await this.client.Vault.Multipart.Abort(
            "id",
            new() { ObjectID = "objectId", UploadID = "uploadId" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task GetPartUrls_Works()
    {
        var response = await this.client.Vault.Multipart.GetPartUrls(
            "id",
            new()
            {
                ObjectID = "objectId",
                Parts = [new() { PartNumber = 1, SizeBytes = 1 }],
                UploadID = "uploadId",
            },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
