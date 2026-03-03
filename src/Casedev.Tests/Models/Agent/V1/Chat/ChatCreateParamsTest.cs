using System;
using Casedev.Models.Agent.V1.Chat;

namespace Casedev.Tests.Models.Agent.V1.Chat;

public class ChatCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ChatCreateParams
        {
            IdleTimeoutMs = 0,
            Model = "model",
            Title = "title",
        };

        long expectedIdleTimeoutMs = 0;
        string expectedModel = "model";
        string expectedTitle = "title";

        Assert.Equal(expectedIdleTimeoutMs, parameters.IdleTimeoutMs);
        Assert.Equal(expectedModel, parameters.Model);
        Assert.Equal(expectedTitle, parameters.Title);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ChatCreateParams { IdleTimeoutMs = 0, Model = "model" };

        Assert.Null(parameters.Title);
        Assert.False(parameters.RawBodyData.ContainsKey("title"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ChatCreateParams
        {
            IdleTimeoutMs = 0,
            Model = "model",

            // Null should be interpreted as omitted for these properties
            Title = null,
        };

        Assert.Null(parameters.Title);
        Assert.False(parameters.RawBodyData.ContainsKey("title"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ChatCreateParams { Title = "title" };

        Assert.Null(parameters.IdleTimeoutMs);
        Assert.False(parameters.RawBodyData.ContainsKey("idleTimeoutMs"));
        Assert.Null(parameters.Model);
        Assert.False(parameters.RawBodyData.ContainsKey("model"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new ChatCreateParams
        {
            Title = "title",

            IdleTimeoutMs = null,
            Model = null,
        };

        Assert.Null(parameters.IdleTimeoutMs);
        Assert.True(parameters.RawBodyData.ContainsKey("idleTimeoutMs"));
        Assert.Null(parameters.Model);
        Assert.True(parameters.RawBodyData.ContainsKey("model"));
    }

    [Fact]
    public void Url_Works()
    {
        ChatCreateParams parameters = new();

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/agent/v1/chat"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ChatCreateParams
        {
            IdleTimeoutMs = 0,
            Model = "model",
            Title = "title",
        };

        ChatCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
