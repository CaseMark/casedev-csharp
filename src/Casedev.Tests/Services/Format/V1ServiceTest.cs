using System.Threading.Tasks;
using Casedev.Models.Format.V1;

namespace Casedev.Tests.Services.Format;

public class V1ServiceTest : TestBase
{
    [Fact(Skip = "Mock server doesn't support application/pdf responses")]
    public async Task CreateDocument_Works()
    {
        await this.client.Format.V1.CreateDocument(
            new() { Content = "content", OutputFormat = OutputFormat.Pdf },
            TestContext.Current.CancellationToken
        );
    }
}
