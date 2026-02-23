using System;
using Router.Models.Applications.V1.Projects;

namespace Router.Tests.Models.Applications.V1.Projects;

public class ProjectDeleteDomainParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ProjectDeleteDomainParams { ID = "id", Domain = "domain" };

        string expectedID = "id";
        string expectedDomain = "domain";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedDomain, parameters.Domain);
    }

    [Fact]
    public void Url_Works()
    {
        ProjectDeleteDomainParams parameters = new() { ID = "id", Domain = "domain" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.case.dev/applications/v1/projects/id/domains/domain"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ProjectDeleteDomainParams { ID = "id", Domain = "domain" };

        ProjectDeleteDomainParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
