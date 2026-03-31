using System;
using Casedev.Models.Matters.V1.WorkItems;

namespace Casedev.Tests.Models.Matters.V1.WorkItems;

public class WorkItemListExecutionsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WorkItemListExecutionsParams { ID = "id", WorkItemID = "workItemId" };

        string expectedID = "id";
        string expectedWorkItemID = "workItemId";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedWorkItemID, parameters.WorkItemID);
    }

    [Fact]
    public void Url_Works()
    {
        WorkItemListExecutionsParams parameters = new() { ID = "id", WorkItemID = "workItemId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.case.dev/matters/v1/id/work-items/workItemId/executions"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new WorkItemListExecutionsParams { ID = "id", WorkItemID = "workItemId" };

        WorkItemListExecutionsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
