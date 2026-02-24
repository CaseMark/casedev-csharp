using System;
using Casedev.Models.Applications.V1.Deployments;

namespace Casedev.Tests.Models.Applications.V1.Deployments;

public class DeploymentGetStatusParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DeploymentGetStatusParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        DeploymentGetStatusParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/applications/v1/deployments/id/status"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new DeploymentGetStatusParams { ID = "id" };

        DeploymentGetStatusParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
