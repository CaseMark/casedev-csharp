using System;
using Casedev.Models.Applications.V1.Deployments;

namespace Casedev.Tests.Models.Applications.V1.Deployments;

public class DeploymentCancelParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DeploymentCancelParams { ID = "id", ProjectID = "projectId" };

        string expectedID = "id";
        string expectedProjectID = "projectId";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedProjectID, parameters.ProjectID);
    }

    [Fact]
    public void Url_Works()
    {
        DeploymentCancelParams parameters = new() { ID = "id", ProjectID = "projectId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/applications/v1/deployments/id/cancel"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new DeploymentCancelParams { ID = "id", ProjectID = "projectId" };

        DeploymentCancelParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
