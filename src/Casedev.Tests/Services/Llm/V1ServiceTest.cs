using System.Threading.Tasks;

namespace Casedev.Tests.Services.Llm;

public class V1ServiceTest : TestBase
{
    [Fact]
    public async Task CreateEmbedding_Works()
    {
        var response = await this.client.Llm.V1.CreateEmbedding(
            new() { Input = "string", Model = "model" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact]
    public async Task ListModels_Works()
    {
        var response = await this.client.Llm.V1.ListModels(
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
