using System;
using Casedev.Models.Mail.V1.Inboxes;

namespace Casedev.Tests.Models.Mail.V1.Inboxes;

public class InboxSendParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new InboxSendParams { InboxID = "inboxId" };

        string expectedInboxID = "inboxId";

        Assert.Equal(expectedInboxID, parameters.InboxID);
    }

    [Fact]
    public void Url_Works()
    {
        InboxSendParams parameters = new() { InboxID = "inboxId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/mail/v1/inboxes/inboxId/messages/send"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new InboxSendParams { InboxID = "inboxId" };

        InboxSendParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
