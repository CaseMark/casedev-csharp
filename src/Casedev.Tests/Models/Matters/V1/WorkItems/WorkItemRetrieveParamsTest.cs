using System;
using Casedev.Models.Matters.V1.WorkItems;

namespace Casedev.Tests.Models.Matters.V1.WorkItems;

public class WorkItemRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WorkItemRetrieveParams { ID = "id", WorkItemID = "workItemId" };

        string expectedID = "id";
        string expectedWorkItemID = "workItemId";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedWorkItemID, parameters.WorkItemID);
    }

    [Fact]
    public void Url_Works()
    {
        WorkItemRetrieveParams parameters = new() { ID = "id", WorkItemID = "workItemId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.case.dev/matters/v1/id/work-items/workItemId"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new WorkItemRetrieveParams { ID = "id", WorkItemID = "workItemId" };

        WorkItemRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
