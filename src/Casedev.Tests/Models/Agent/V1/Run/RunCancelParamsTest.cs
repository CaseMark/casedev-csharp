using System;
using Casedev.Models.Agent.V1.Run;

namespace Casedev.Tests.Models.Agent.V1.Run;

public class RunCancelParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new RunCancelParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        RunCancelParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/agent/v1/run/id/cancel"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new RunCancelParams { ID = "id" };

        RunCancelParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
