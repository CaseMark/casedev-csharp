using System;
using Casedev.Models.Applications.V1.Projects;

namespace Casedev.Tests.Models.Applications.V1.Projects;

public class ProjectListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ProjectListParams { Enrich = true, Limit = 0 };

        bool expectedEnrich = true;
        double expectedLimit = 0;

        Assert.Equal(expectedEnrich, parameters.Enrich);
        Assert.Equal(expectedLimit, parameters.Limit);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ProjectListParams { };

        Assert.Null(parameters.Enrich);
        Assert.False(parameters.RawQueryData.ContainsKey("enrich"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ProjectListParams
        {
            // Null should be interpreted as omitted for these properties
            Enrich = null,
            Limit = null,
        };

        Assert.Null(parameters.Enrich);
        Assert.False(parameters.RawQueryData.ContainsKey("enrich"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void Url_Works()
    {
        ProjectListParams parameters = new() { Enrich = true, Limit = 0 };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.case.dev/applications/v1/projects?enrich=true&limit=0"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ProjectListParams { Enrich = true, Limit = 0 };

        ProjectListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
