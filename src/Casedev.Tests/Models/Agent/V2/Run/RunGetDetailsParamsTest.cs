using System;
using Casedev.Models.Agent.V2.Run;

namespace Casedev.Tests.Models.Agent.V2.Run;

public class RunGetDetailsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new RunGetDetailsParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        RunGetDetailsParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.case.dev/agent/v2/run/id/details"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new RunGetDetailsParams { ID = "id" };

        RunGetDetailsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
