using System;
using Casedev.Models.Mail.V1.Inboxes;

namespace Casedev.Tests.Models.Mail.V1.Inboxes;

public class InboxGetAttachmentParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new InboxGetAttachmentParams
        {
            InboxID = "inboxId",
            MessageID = "messageId",
            AttachmentID = "attachmentId",
        };

        string expectedInboxID = "inboxId";
        string expectedMessageID = "messageId";
        string expectedAttachmentID = "attachmentId";

        Assert.Equal(expectedInboxID, parameters.InboxID);
        Assert.Equal(expectedMessageID, parameters.MessageID);
        Assert.Equal(expectedAttachmentID, parameters.AttachmentID);
    }

    [Fact]
    public void Url_Works()
    {
        InboxGetAttachmentParams parameters = new()
        {
            InboxID = "inboxId",
            MessageID = "messageId",
            AttachmentID = "attachmentId",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.case.dev/mail/v1/inboxes/inboxId/messages/messageId/attachments/attachmentId"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new InboxGetAttachmentParams
        {
            InboxID = "inboxId",
            MessageID = "messageId",
            AttachmentID = "attachmentId",
        };

        InboxGetAttachmentParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
