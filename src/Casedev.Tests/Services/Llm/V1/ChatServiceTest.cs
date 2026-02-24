using System.Threading.Tasks;
using Casedev.Models.Llm.V1.Chat;

namespace Casedev.Tests.Services.Llm.V1;

public class ChatServiceTest : TestBase
{
    [Fact]
    public async Task CreateCompletion_Works()
    {
        var response = await this.client.Llm.V1.Chat.CreateCompletion(
            new() { Messages = [new() { Content = "content", Role = Role.System }] },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
