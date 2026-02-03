using System;
using CaseDev.Models.Applications.V1.Deployments;

namespace CaseDev.Tests.Models.Applications.V1.Deployments;

public class DeploymentGetLogsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DeploymentGetLogsParams { ID = "id", ProjectID = "projectId" };

        string expectedID = "id";
        string expectedProjectID = "projectId";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedProjectID, parameters.ProjectID);
    }

    [Fact]
    public void Url_Works()
    {
        DeploymentGetLogsParams parameters = new() { ID = "id", ProjectID = "projectId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.case.dev/applications/v1/deployments/id/logs?projectId=projectId"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new DeploymentGetLogsParams { ID = "id", ProjectID = "projectId" };

        DeploymentGetLogsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
