using System;
using CaseDev.Models.Applications.V1.Projects;

namespace CaseDev.Tests.Models.Applications.V1.Projects;

public class ProjectCreateDomainParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ProjectCreateDomainParams
        {
            ID = "id",
            Domain = "domain",
            GitBranch = "gitBranch",
        };

        string expectedID = "id";
        string expectedDomain = "domain";
        string expectedGitBranch = "gitBranch";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedDomain, parameters.Domain);
        Assert.Equal(expectedGitBranch, parameters.GitBranch);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ProjectCreateDomainParams { ID = "id", Domain = "domain" };

        Assert.Null(parameters.GitBranch);
        Assert.False(parameters.RawBodyData.ContainsKey("gitBranch"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ProjectCreateDomainParams
        {
            ID = "id",
            Domain = "domain",

            // Null should be interpreted as omitted for these properties
            GitBranch = null,
        };

        Assert.Null(parameters.GitBranch);
        Assert.False(parameters.RawBodyData.ContainsKey("gitBranch"));
    }

    [Fact]
    public void Url_Works()
    {
        ProjectCreateDomainParams parameters = new() { ID = "id", Domain = "domain" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/applications/v1/projects/id/domains"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ProjectCreateDomainParams
        {
            ID = "id",
            Domain = "domain",
            GitBranch = "gitBranch",
        };

        ProjectCreateDomainParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
