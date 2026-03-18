using System;
using System.Collections.Generic;
using Casedev.Models.Mail.V1.Inboxes;

namespace Casedev.Tests.Models.Mail.V1.Inboxes;

public class InboxSetPolicyParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new InboxSetPolicyParams
        {
            InboxID = "inboxId",
            AllowedSenderPatterns = ["string"],
            EnforceSenderAllowlist = true,
            ReadAccessRules = ["string"],
            ReplyAccessRules = ["string"],
            SendAccessRules = ["string"],
        };

        string expectedInboxID = "inboxId";
        List<string> expectedAllowedSenderPatterns = ["string"];
        bool expectedEnforceSenderAllowlist = true;
        List<string> expectedReadAccessRules = ["string"];
        List<string> expectedReplyAccessRules = ["string"];
        List<string> expectedSendAccessRules = ["string"];

        Assert.Equal(expectedInboxID, parameters.InboxID);
        Assert.NotNull(parameters.AllowedSenderPatterns);
        Assert.Equal(expectedAllowedSenderPatterns.Count, parameters.AllowedSenderPatterns.Count);
        for (int i = 0; i < expectedAllowedSenderPatterns.Count; i++)
        {
            Assert.Equal(expectedAllowedSenderPatterns[i], parameters.AllowedSenderPatterns[i]);
        }
        Assert.Equal(expectedEnforceSenderAllowlist, parameters.EnforceSenderAllowlist);
        Assert.NotNull(parameters.ReadAccessRules);
        Assert.Equal(expectedReadAccessRules.Count, parameters.ReadAccessRules.Count);
        for (int i = 0; i < expectedReadAccessRules.Count; i++)
        {
            Assert.Equal(expectedReadAccessRules[i], parameters.ReadAccessRules[i]);
        }
        Assert.NotNull(parameters.ReplyAccessRules);
        Assert.Equal(expectedReplyAccessRules.Count, parameters.ReplyAccessRules.Count);
        for (int i = 0; i < expectedReplyAccessRules.Count; i++)
        {
            Assert.Equal(expectedReplyAccessRules[i], parameters.ReplyAccessRules[i]);
        }
        Assert.NotNull(parameters.SendAccessRules);
        Assert.Equal(expectedSendAccessRules.Count, parameters.SendAccessRules.Count);
        for (int i = 0; i < expectedSendAccessRules.Count; i++)
        {
            Assert.Equal(expectedSendAccessRules[i], parameters.SendAccessRules[i]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new InboxSetPolicyParams { InboxID = "inboxId" };

        Assert.Null(parameters.AllowedSenderPatterns);
        Assert.False(parameters.RawBodyData.ContainsKey("allowedSenderPatterns"));
        Assert.Null(parameters.EnforceSenderAllowlist);
        Assert.False(parameters.RawBodyData.ContainsKey("enforceSenderAllowlist"));
        Assert.Null(parameters.ReadAccessRules);
        Assert.False(parameters.RawBodyData.ContainsKey("readAccessRules"));
        Assert.Null(parameters.ReplyAccessRules);
        Assert.False(parameters.RawBodyData.ContainsKey("replyAccessRules"));
        Assert.Null(parameters.SendAccessRules);
        Assert.False(parameters.RawBodyData.ContainsKey("sendAccessRules"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new InboxSetPolicyParams
        {
            InboxID = "inboxId",

            // Null should be interpreted as omitted for these properties
            AllowedSenderPatterns = null,
            EnforceSenderAllowlist = null,
            ReadAccessRules = null,
            ReplyAccessRules = null,
            SendAccessRules = null,
        };

        Assert.Null(parameters.AllowedSenderPatterns);
        Assert.False(parameters.RawBodyData.ContainsKey("allowedSenderPatterns"));
        Assert.Null(parameters.EnforceSenderAllowlist);
        Assert.False(parameters.RawBodyData.ContainsKey("enforceSenderAllowlist"));
        Assert.Null(parameters.ReadAccessRules);
        Assert.False(parameters.RawBodyData.ContainsKey("readAccessRules"));
        Assert.Null(parameters.ReplyAccessRules);
        Assert.False(parameters.RawBodyData.ContainsKey("replyAccessRules"));
        Assert.Null(parameters.SendAccessRules);
        Assert.False(parameters.RawBodyData.ContainsKey("sendAccessRules"));
    }

    [Fact]
    public void Url_Works()
    {
        InboxSetPolicyParams parameters = new() { InboxID = "inboxId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/mail/v1/inboxes/inboxId/policy"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new InboxSetPolicyParams
        {
            InboxID = "inboxId",
            AllowedSenderPatterns = ["string"],
            EnforceSenderAllowlist = true,
            ReadAccessRules = ["string"],
            ReplyAccessRules = ["string"],
            SendAccessRules = ["string"],
        };

        InboxSetPolicyParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
