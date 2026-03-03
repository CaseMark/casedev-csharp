using System;
using System.Text.Json;
using Casedev.Models.Agent.V1.Chat;

namespace Casedev.Tests.Models.Agent.V1.Chat;

public class ChatSendMessageParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ChatSendMessageParams
        {
            ID = "id",
            Body = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string expectedID = "id";
        JsonElement expectedBody = JsonSerializer.Deserialize<JsonElement>("{}");

        Assert.Equal(expectedID, parameters.ID);
        Assert.True(JsonElement.DeepEquals(expectedBody, parameters.Body));
    }

    [Fact]
    public void Url_Works()
    {
        ChatSendMessageParams parameters = new()
        {
            ID = "id",
            Body = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/agent/v1/chat/id/message"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ChatSendMessageParams
        {
            ID = "id",
            Body = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        ChatSendMessageParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
