using System;
using Casedev.Models.Applications.V1.Projects;

namespace Casedev.Tests.Models.Applications.V1.Projects;

public class ProjectDeleteEnvParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ProjectDeleteEnvParams { ID = "id", EnvID = "envId" };

        string expectedID = "id";
        string expectedEnvID = "envId";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedEnvID, parameters.EnvID);
    }

    [Fact]
    public void Url_Works()
    {
        ProjectDeleteEnvParams parameters = new() { ID = "id", EnvID = "envId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/applications/v1/projects/id/env/envId"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ProjectDeleteEnvParams { ID = "id", EnvID = "envId" };

        ProjectDeleteEnvParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
