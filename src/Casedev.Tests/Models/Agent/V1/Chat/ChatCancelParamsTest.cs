using System;
using Casedev.Models.Agent.V1.Chat;

namespace Casedev.Tests.Models.Agent.V1.Chat;

public class ChatCancelParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ChatCancelParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        ChatCancelParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/agent/v1/chat/id/cancel"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ChatCancelParams { ID = "id" };

        ChatCancelParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
