using System;
using CaseDev.Models.Database.V1.Projects;

namespace CaseDev.Tests.Models.Database.V1.Projects;

public class ProjectDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ProjectDeleteParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        ProjectDeleteParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/database/v1/projects/id"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ProjectDeleteParams { ID = "id" };

        ProjectDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
