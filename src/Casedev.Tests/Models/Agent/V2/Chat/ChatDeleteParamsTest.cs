using System;
using Casedev.Models.Agent.V2.Chat;

namespace Casedev.Tests.Models.Agent.V2.Chat;

public class ChatDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ChatDeleteParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        ChatDeleteParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.case.dev/agent/v2/chat/id"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ChatDeleteParams { ID = "id" };

        ChatDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
