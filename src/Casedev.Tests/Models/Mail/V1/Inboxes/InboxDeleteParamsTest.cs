using System;
using Casedev.Models.Mail.V1.Inboxes;

namespace Casedev.Tests.Models.Mail.V1.Inboxes;

public class InboxDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new InboxDeleteParams { InboxID = "inboxId" };

        string expectedInboxID = "inboxId";

        Assert.Equal(expectedInboxID, parameters.InboxID);
    }

    [Fact]
    public void Url_Works()
    {
        InboxDeleteParams parameters = new() { InboxID = "inboxId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/mail/v1/inboxes/inboxId"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new InboxDeleteParams { InboxID = "inboxId" };

        InboxDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
