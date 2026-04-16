using System;
using Casedev.Models.Agent.V2.Chat;

namespace Casedev.Tests.Models.Agent.V2.Chat;

public class ChatStreamParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ChatStreamParams
        {
            ID = "id",
            Token = "token",
            LastEventID = 0,
        };

        string expectedID = "id";
        string expectedToken = "token";
        long expectedLastEventID = 0;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedToken, parameters.Token);
        Assert.Equal(expectedLastEventID, parameters.LastEventID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ChatStreamParams { ID = "id" };

        Assert.Null(parameters.Token);
        Assert.False(parameters.RawQueryData.ContainsKey("token"));
        Assert.Null(parameters.LastEventID);
        Assert.False(parameters.RawQueryData.ContainsKey("lastEventId"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ChatStreamParams
        {
            ID = "id",

            // Null should be interpreted as omitted for these properties
            Token = null,
            LastEventID = null,
        };

        Assert.Null(parameters.Token);
        Assert.False(parameters.RawQueryData.ContainsKey("token"));
        Assert.Null(parameters.LastEventID);
        Assert.False(parameters.RawQueryData.ContainsKey("lastEventId"));
    }

    [Fact]
    public void Url_Works()
    {
        ChatStreamParams parameters = new()
        {
            ID = "id",
            Token = "token",
            LastEventID = 0,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.case.dev/agent/v2/chat/id/stream?token=token&lastEventId=0"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ChatStreamParams
        {
            ID = "id",
            Token = "token",
            LastEventID = 0,
        };

        ChatStreamParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
