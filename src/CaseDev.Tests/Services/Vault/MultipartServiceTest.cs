using System.Threading.Tasks;

namespace CaseDev.Tests.Services.Vault;

public class MultipartServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Abort_Works()
    {
        await this.client.Vault.Multipart.Abort(
            "id",
            new() { ObjectID = "objectId", UploadID = "uploadId" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
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
