using System.Threading.Tasks;

namespace Casedev.Tests.Services.Agent.V2;

public class ChatServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var chat = await this.client.Agent.V2.Chat.Create(
            new(),
            TestContext.Current.CancellationToken
        );
        chat.Validate();
    }

    [Fact]
    public async Task Delete_Works()
    {
        var chat = await this.client.Agent.V2.Chat.Delete(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        chat.Validate();
    }

    [Fact]
    public async Task Cancel_Works()
    {
        var response = await this.client.Agent.V2.Chat.Cancel(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact]
    public async Task ReplyToQuestion_Works()
    {
        await this.client.Agent.V2.Chat.ReplyToQuestion(
            "requestID",
            new()
            {
                ID = "id",
                Answers =
                [
                    ["string"],
                ],
            },
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server doesn't support text/event-stream responses")]
    public async Task RespondStreaming_Works()
    {
        var stream = this.client.Agent.V2.Chat.RespondStreaming(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );

        await foreach (var response in stream) { }
    }

    [Fact]
    public async Task SendMessage_Works()
    {
        await this.client.Agent.V2.Chat.SendMessage(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server doesn't support text/event-stream responses")]
    public async Task StreamStreaming_Works()
    {
        var stream = this.client.Agent.V2.Chat.StreamStreaming(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );

        await foreach (var response in stream) { }
    }
}
