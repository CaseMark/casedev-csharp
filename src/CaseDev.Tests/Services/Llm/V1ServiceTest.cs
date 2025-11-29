using System.Threading.Tasks;

namespace CaseDev.Tests.Services.Llm;

public class V1ServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task CreateEmbedding_Works()
    {
        await this.client.Llm.V1.CreateEmbedding(new() { Input = "string", Model = "model" });
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task ListModels_Works()
    {
        await this.client.Llm.V1.ListModels();
    }
}
