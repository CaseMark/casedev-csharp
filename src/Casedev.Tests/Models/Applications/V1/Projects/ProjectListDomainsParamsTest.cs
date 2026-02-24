using System;
using Casedev.Models.Applications.V1.Projects;

namespace Casedev.Tests.Models.Applications.V1.Projects;

public class ProjectListDomainsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ProjectListDomainsParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        ProjectListDomainsParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/applications/v1/projects/id/domains"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ProjectListDomainsParams { ID = "id" };

        ProjectListDomainsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
