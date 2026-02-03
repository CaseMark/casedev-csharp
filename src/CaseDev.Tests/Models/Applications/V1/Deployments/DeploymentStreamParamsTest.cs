using System;
using CaseDev.Models.Applications.V1.Deployments;

namespace CaseDev.Tests.Models.Applications.V1.Deployments;

public class DeploymentStreamParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DeploymentStreamParams
        {
            ID = "id",
            ProjectID = "projectId",
            StartIndex = 0,
        };

        string expectedID = "id";
        string expectedProjectID = "projectId";
        double expectedStartIndex = 0;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedProjectID, parameters.ProjectID);
        Assert.Equal(expectedStartIndex, parameters.StartIndex);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new DeploymentStreamParams { ID = "id", ProjectID = "projectId" };

        Assert.Null(parameters.StartIndex);
        Assert.False(parameters.RawQueryData.ContainsKey("startIndex"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new DeploymentStreamParams
        {
            ID = "id",
            ProjectID = "projectId",

            // Null should be interpreted as omitted for these properties
            StartIndex = null,
        };

        Assert.Null(parameters.StartIndex);
        Assert.False(parameters.RawQueryData.ContainsKey("startIndex"));
    }

    [Fact]
    public void Url_Works()
    {
        DeploymentStreamParams parameters = new()
        {
            ID = "id",
            ProjectID = "projectId",
            StartIndex = 0,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.case.dev/applications/v1/deployments/id/stream?projectId=projectId&startIndex=0"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new DeploymentStreamParams
        {
            ID = "id",
            ProjectID = "projectId",
            StartIndex = 0,
        };

        DeploymentStreamParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
