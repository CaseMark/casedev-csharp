using System;
using CaseDev.Models.Applications.V1.Deployments;

namespace CaseDev.Tests.Models.Applications.V1.Deployments;

public class DeploymentRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DeploymentRetrieveParams
        {
            ID = "id",
            ProjectID = "projectId",
            IncludeLogs = true,
        };

        string expectedID = "id";
        string expectedProjectID = "projectId";
        bool expectedIncludeLogs = true;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedProjectID, parameters.ProjectID);
        Assert.Equal(expectedIncludeLogs, parameters.IncludeLogs);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new DeploymentRetrieveParams { ID = "id", ProjectID = "projectId" };

        Assert.Null(parameters.IncludeLogs);
        Assert.False(parameters.RawQueryData.ContainsKey("includeLogs"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new DeploymentRetrieveParams
        {
            ID = "id",
            ProjectID = "projectId",

            // Null should be interpreted as omitted for these properties
            IncludeLogs = null,
        };

        Assert.Null(parameters.IncludeLogs);
        Assert.False(parameters.RawQueryData.ContainsKey("includeLogs"));
    }

    [Fact]
    public void Url_Works()
    {
        DeploymentRetrieveParams parameters = new()
        {
            ID = "id",
            ProjectID = "projectId",
            IncludeLogs = true,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.case.dev/applications/v1/deployments/id?projectId=projectId&includeLogs=true"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new DeploymentRetrieveParams
        {
            ID = "id",
            ProjectID = "projectId",
            IncludeLogs = true,
        };

        DeploymentRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
