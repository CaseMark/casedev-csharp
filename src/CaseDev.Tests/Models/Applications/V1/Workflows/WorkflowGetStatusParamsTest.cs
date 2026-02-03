using System;
using CaseDev.Models.Applications.V1.Workflows;

namespace CaseDev.Tests.Models.Applications.V1.Workflows;

public class WorkflowGetStatusParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WorkflowGetStatusParams { ID = "id", ProjectID = "projectId" };

        string expectedID = "id";
        string expectedProjectID = "projectId";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedProjectID, parameters.ProjectID);
    }

    [Fact]
    public void Url_Works()
    {
        WorkflowGetStatusParams parameters = new() { ID = "id", ProjectID = "projectId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.case.dev/applications/v1/workflows/id/status?projectId=projectId"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new WorkflowGetStatusParams { ID = "id", ProjectID = "projectId" };

        WorkflowGetStatusParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
