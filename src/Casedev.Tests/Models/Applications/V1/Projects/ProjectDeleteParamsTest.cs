using System;
using Casedev.Models.Applications.V1.Projects;

namespace Casedev.Tests.Models.Applications.V1.Projects;

public class ProjectDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ProjectDeleteParams { ID = "id", DeleteFromHosting = true };

        string expectedID = "id";
        bool expectedDeleteFromHosting = true;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedDeleteFromHosting, parameters.DeleteFromHosting);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ProjectDeleteParams { ID = "id" };

        Assert.Null(parameters.DeleteFromHosting);
        Assert.False(parameters.RawQueryData.ContainsKey("deleteFromHosting"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ProjectDeleteParams
        {
            ID = "id",

            // Null should be interpreted as omitted for these properties
            DeleteFromHosting = null,
        };

        Assert.Null(parameters.DeleteFromHosting);
        Assert.False(parameters.RawQueryData.ContainsKey("deleteFromHosting"));
    }

    [Fact]
    public void Url_Works()
    {
        ProjectDeleteParams parameters = new() { ID = "id", DeleteFromHosting = true };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.case.dev/applications/v1/projects/id?deleteFromHosting=true"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ProjectDeleteParams { ID = "id", DeleteFromHosting = true };

        ProjectDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
