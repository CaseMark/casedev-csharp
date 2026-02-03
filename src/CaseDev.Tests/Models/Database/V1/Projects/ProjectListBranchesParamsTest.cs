using System;
using CaseDev.Models.Database.V1.Projects;

namespace CaseDev.Tests.Models.Database.V1.Projects;

public class ProjectListBranchesParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ProjectListBranchesParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        ProjectListBranchesParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/database/v1/projects/id/branches"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ProjectListBranchesParams { ID = "id" };

        ProjectListBranchesParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
