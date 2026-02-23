using System;
using Router.Models.Applications.V1.Projects;

namespace Router.Tests.Models.Applications.V1.Projects;

public class ProjectGetRuntimeLogsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ProjectGetRuntimeLogsParams { ID = "id", Limit = 0 };

        string expectedID = "id";
        double expectedLimit = 0;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedLimit, parameters.Limit);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ProjectGetRuntimeLogsParams { ID = "id" };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ProjectGetRuntimeLogsParams
        {
            ID = "id",

            // Null should be interpreted as omitted for these properties
            Limit = null,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void Url_Works()
    {
        ProjectGetRuntimeLogsParams parameters = new() { ID = "id", Limit = 0 };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.case.dev/applications/v1/projects/id/runtime-logs?limit=0"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ProjectGetRuntimeLogsParams { ID = "id", Limit = 0 };

        ProjectGetRuntimeLogsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
