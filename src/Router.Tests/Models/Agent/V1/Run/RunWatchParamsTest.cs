using System;
using Router.Models.Agent.V1.Run;

namespace Router.Tests.Models.Agent.V1.Run;

public class RunWatchParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new RunWatchParams { ID = "id", CallbackUrl = "https://example.com" };

        string expectedID = "id";
        string expectedCallbackUrl = "https://example.com";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedCallbackUrl, parameters.CallbackUrl);
    }

    [Fact]
    public void Url_Works()
    {
        RunWatchParams parameters = new() { ID = "id", CallbackUrl = "https://example.com" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/agent/v1/run/id/watch"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new RunWatchParams { ID = "id", CallbackUrl = "https://example.com" };

        RunWatchParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
