using System.Threading.Tasks;

namespace Casedev.Tests.Services.Mail.V1;

public class InboxServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        await this.client.Mail.V1.Inboxes.Create(new(), TestContext.Current.CancellationToken);
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        await this.client.Mail.V1.Inboxes.Retrieve(
            "inboxId",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task List_Works()
    {
        await this.client.Mail.V1.Inboxes.List(new(), TestContext.Current.CancellationToken);
    }

    [Fact]
    public async Task Delete_Works()
    {
        await this.client.Mail.V1.Inboxes.Delete(
            "inboxId",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task GetAttachment_Works()
    {
        await this.client.Mail.V1.Inboxes.GetAttachment(
            "attachmentId",
            new() { InboxID = "inboxId", MessageID = "messageId" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task GetMessage_Works()
    {
        await this.client.Mail.V1.Inboxes.GetMessage(
            "messageId",
            new() { InboxID = "inboxId" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task GetPolicy_Works()
    {
        await this.client.Mail.V1.Inboxes.GetPolicy(
            "inboxId",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task ListMessages_Works()
    {
        await this.client.Mail.V1.Inboxes.ListMessages(
            "inboxId",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task Reply_Works()
    {
        await this.client.Mail.V1.Inboxes.Reply(
            "messageId",
            new() { InboxID = "inboxId" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task Send_Works()
    {
        await this.client.Mail.V1.Inboxes.Send(
            "inboxId",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task SetPolicy_Works()
    {
        await this.client.Mail.V1.Inboxes.SetPolicy(
            "inboxId",
            new(),
            TestContext.Current.CancellationToken
        );
    }
}
