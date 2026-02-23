using System;
using Router.Models.Database.V1.Projects;

namespace Router.Tests.Models.Database.V1.Projects;

public class ProjectGetConnectionParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ProjectGetConnectionParams
        {
            ID = "id",
            Branch = "branch",
            Pooled = true,
        };

        string expectedID = "id";
        string expectedBranch = "branch";
        bool expectedPooled = true;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedBranch, parameters.Branch);
        Assert.Equal(expectedPooled, parameters.Pooled);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ProjectGetConnectionParams { ID = "id" };

        Assert.Null(parameters.Branch);
        Assert.False(parameters.RawQueryData.ContainsKey("branch"));
        Assert.Null(parameters.Pooled);
        Assert.False(parameters.RawQueryData.ContainsKey("pooled"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ProjectGetConnectionParams
        {
            ID = "id",

            // Null should be interpreted as omitted for these properties
            Branch = null,
            Pooled = null,
        };

        Assert.Null(parameters.Branch);
        Assert.False(parameters.RawQueryData.ContainsKey("branch"));
        Assert.Null(parameters.Pooled);
        Assert.False(parameters.RawQueryData.ContainsKey("pooled"));
    }

    [Fact]
    public void Url_Works()
    {
        ProjectGetConnectionParams parameters = new()
        {
            ID = "id",
            Branch = "branch",
            Pooled = true,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.case.dev/database/v1/projects/id/connection?branch=branch&pooled=true"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ProjectGetConnectionParams
        {
            ID = "id",
            Branch = "branch",
            Pooled = true,
        };

        ProjectGetConnectionParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
