using System;
using Casedev.Models.Agent.V1.Run;

namespace Casedev.Tests.Models.Agent.V1.Run;

public class RunGetStatusParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new RunGetStatusParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        RunGetStatusParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/agent/v1/run/id/status"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new RunGetStatusParams { ID = "id" };

        RunGetStatusParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
