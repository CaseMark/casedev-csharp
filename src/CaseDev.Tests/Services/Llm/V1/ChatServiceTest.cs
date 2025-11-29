using System.Threading.Tasks;
using CaseDev.Models.Llm.V1.Chat;

namespace CaseDev.Tests.Services.Llm.V1;

public class ChatServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task CreateCompletion_Works()
    {
        var response = await this.client.Llm.V1.Chat.CreateCompletion(
            new() { Messages = [new() { Content = "content", Role = Role.System }] }
        );
        response.Validate();
    }
}
