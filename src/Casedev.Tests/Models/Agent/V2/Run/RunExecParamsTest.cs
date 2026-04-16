using System;
using Casedev.Models.Agent.V2.Run;

namespace Casedev.Tests.Models.Agent.V2.Run;

public class RunExecParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new RunExecParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        RunExecParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.case.dev/agent/v2/run/id/exec"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new RunExecParams { ID = "id" };

        RunExecParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
