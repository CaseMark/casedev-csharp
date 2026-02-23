using System.Threading.Tasks;
using Router.Models.Superdoc.V1;

namespace Router.Tests.Services.Superdoc;

public class V1ServiceTest : TestBase
{
    [Fact(Skip = "Mock server doesn't support application/pdf responses")]
    public async Task Annotate_Works()
    {
        await this.client.Superdoc.V1.Annotate(
            new()
            {
                Document = new() { Base64 = "base64", Url = "url" },
                Fields =
                [
                    new()
                    {
                        Type = Type.Text,
                        Value = "string",
                        ID = "id",
                        Group = "group",
                        Options = new() { Height = 0, Width = 0 },
                    },
                ],
            },
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server doesn't support application/pdf responses")]
    public async Task Convert_Works()
    {
        await this.client.Superdoc.V1.Convert(
            new() { From = From.Docx },
            TestContext.Current.CancellationToken
        );
    }
}
