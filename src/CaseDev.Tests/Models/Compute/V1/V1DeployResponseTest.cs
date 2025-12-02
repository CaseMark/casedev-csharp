using System;
using CaseDev.Models.Compute.V1;

namespace CaseDev.Tests.Models.Compute.V1;

public class V1DeployResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new V1DeployResponse
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeploymentID = "deploymentId",
            Environment = "environment",
            Runtime = "runtime",
            Status = "status",
            URL = "url",
        };

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDeploymentID = "deploymentId";
        string expectedEnvironment = "environment";
        string expectedRuntime = "runtime";
        string expectedStatus = "status";
        string expectedURL = "url";

        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDeploymentID, model.DeploymentID);
        Assert.Equal(expectedEnvironment, model.Environment);
        Assert.Equal(expectedRuntime, model.Runtime);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedURL, model.URL);
    }
}
