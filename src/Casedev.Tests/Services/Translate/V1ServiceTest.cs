using System.Threading.Tasks;

namespace Casedev.Tests.Services.Translate;

public class V1ServiceTest : TestBase
{
    [Fact]
    public async Task Detect_Works()
    {
        var response = await this.client.Translate.V1.Detect(
            new() { Q = "string" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact]
    public async Task ListLanguages_Works()
    {
        var response = await this.client.Translate.V1.ListLanguages(
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact]
    public async Task Translate_Works()
    {
        var response = await this.client.Translate.V1.Translate(
            new() { Q = "string", Target = "es" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
