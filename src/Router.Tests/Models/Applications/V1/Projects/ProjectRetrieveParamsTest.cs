using System;
using Router.Models.Applications.V1.Projects;

namespace Router.Tests.Models.Applications.V1.Projects;

public class ProjectRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ProjectRetrieveParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        ProjectRetrieveParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/applications/v1/projects/id"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ProjectRetrieveParams { ID = "id" };

        ProjectRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
