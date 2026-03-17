using System;
using Casedev.Models.Mail.V1.Inboxes;

namespace Casedev.Tests.Models.Mail.V1.Inboxes;

public class InboxReplyParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new InboxReplyParams { InboxID = "inboxId", MessageID = "messageId" };

        string expectedInboxID = "inboxId";
        string expectedMessageID = "messageId";

        Assert.Equal(expectedInboxID, parameters.InboxID);
        Assert.Equal(expectedMessageID, parameters.MessageID);
    }

    [Fact]
    public void Url_Works()
    {
        InboxReplyParams parameters = new() { InboxID = "inboxId", MessageID = "messageId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.case.dev/mail/v1/inboxes/inboxId/messages/messageId/reply"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new InboxReplyParams { InboxID = "inboxId", MessageID = "messageId" };

        InboxReplyParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
