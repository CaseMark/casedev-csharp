using System;
using Casedev.Models.Agent.V2.Chat;

namespace Casedev.Tests.Models.Agent.V2.Chat;

public class ChatCreateStreamTokenParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ChatCreateStreamTokenParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        ChatCreateStreamTokenParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.case.dev/agent/v2/chat/id/stream-token"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ChatCreateStreamTokenParams { ID = "id" };

        ChatCreateStreamTokenParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
