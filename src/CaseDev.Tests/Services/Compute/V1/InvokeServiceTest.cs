using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace CaseDev.Tests.Services.Compute.V1;

public class InvokeServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Run_Works()
    {
        var response = await this.client.Compute.V1.Invoke.Run(
            "func_abc123 or document-analyzer",
            new()
            {
                Input = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            }
        );
        response.Validate();
    }
}
