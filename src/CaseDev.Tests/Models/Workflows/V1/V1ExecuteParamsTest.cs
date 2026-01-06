using System;
using System.Text.Json;
using CaseDev.Models.Workflows.V1;

namespace CaseDev.Tests.Models.Workflows.V1;

public class V1ExecuteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new V1ExecuteParams
        {
            ID = "id",
            CallbackHeaders = JsonSerializer.Deserialize<JsonElement>("{}"),
            CallbackUrl = "callbackUrl",
            Input = JsonSerializer.Deserialize<JsonElement>("{}"),
            Timeout = "timeout",
            Wait = true,
        };

        string expectedID = "id";
        JsonElement expectedCallbackHeaders = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedCallbackUrl = "callbackUrl";
        JsonElement expectedInput = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedTimeout = "timeout";
        bool expectedWait = true;

        Assert.Equal(expectedID, parameters.ID);
        Assert.NotNull(parameters.CallbackHeaders);
        Assert.True(
            JsonElement.DeepEquals(expectedCallbackHeaders, parameters.CallbackHeaders.Value)
        );
        Assert.Equal(expectedCallbackUrl, parameters.CallbackUrl);
        Assert.NotNull(parameters.Input);
        Assert.True(JsonElement.DeepEquals(expectedInput, parameters.Input.Value));
        Assert.Equal(expectedTimeout, parameters.Timeout);
        Assert.Equal(expectedWait, parameters.Wait);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new V1ExecuteParams { ID = "id" };

        Assert.Null(parameters.CallbackHeaders);
        Assert.False(parameters.RawBodyData.ContainsKey("callbackHeaders"));
        Assert.Null(parameters.CallbackUrl);
        Assert.False(parameters.RawBodyData.ContainsKey("callbackUrl"));
        Assert.Null(parameters.Input);
        Assert.False(parameters.RawBodyData.ContainsKey("input"));
        Assert.Null(parameters.Timeout);
        Assert.False(parameters.RawBodyData.ContainsKey("timeout"));
        Assert.Null(parameters.Wait);
        Assert.False(parameters.RawBodyData.ContainsKey("wait"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new V1ExecuteParams
        {
            ID = "id",

            // Null should be interpreted as omitted for these properties
            CallbackHeaders = null,
            CallbackUrl = null,
            Input = null,
            Timeout = null,
            Wait = null,
        };

        Assert.Null(parameters.CallbackHeaders);
        Assert.False(parameters.RawBodyData.ContainsKey("callbackHeaders"));
        Assert.Null(parameters.CallbackUrl);
        Assert.False(parameters.RawBodyData.ContainsKey("callbackUrl"));
        Assert.Null(parameters.Input);
        Assert.False(parameters.RawBodyData.ContainsKey("input"));
        Assert.Null(parameters.Timeout);
        Assert.False(parameters.RawBodyData.ContainsKey("timeout"));
        Assert.Null(parameters.Wait);
        Assert.False(parameters.RawBodyData.ContainsKey("wait"));
    }

    [Fact]
    public void Url_Works()
    {
        V1ExecuteParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/workflows/v1/id/execute"), url);
    }
}
