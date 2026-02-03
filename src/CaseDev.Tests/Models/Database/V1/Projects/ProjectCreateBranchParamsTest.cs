using System;
using CaseDev.Models.Database.V1.Projects;

namespace CaseDev.Tests.Models.Database.V1.Projects;

public class ProjectCreateBranchParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ProjectCreateBranchParams
        {
            ID = "id",
            Name = "staging",
            ParentBranchID = "branch_main_123",
        };

        string expectedID = "id";
        string expectedName = "staging";
        string expectedParentBranchID = "branch_main_123";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedParentBranchID, parameters.ParentBranchID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ProjectCreateBranchParams { ID = "id", Name = "staging" };

        Assert.Null(parameters.ParentBranchID);
        Assert.False(parameters.RawBodyData.ContainsKey("parentBranchId"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ProjectCreateBranchParams
        {
            ID = "id",
            Name = "staging",

            // Null should be interpreted as omitted for these properties
            ParentBranchID = null,
        };

        Assert.Null(parameters.ParentBranchID);
        Assert.False(parameters.RawBodyData.ContainsKey("parentBranchId"));
    }

    [Fact]
    public void Url_Works()
    {
        ProjectCreateBranchParams parameters = new() { ID = "id", Name = "staging" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/database/v1/projects/id/branches"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ProjectCreateBranchParams
        {
            ID = "id",
            Name = "staging",
            ParentBranchID = "branch_main_123",
        };

        ProjectCreateBranchParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
