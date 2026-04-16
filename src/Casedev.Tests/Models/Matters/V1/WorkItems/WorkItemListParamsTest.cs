using System;
using Casedev.Models.Matters.V1.WorkItems;

namespace Casedev.Tests.Models.Matters.V1.WorkItems;

public class WorkItemListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WorkItemListParams
        {
            ID = "id",
            AssigneeID = "assignee_id",
            Status = "status",
        };

        string expectedID = "id";
        string expectedAssigneeID = "assignee_id";
        string expectedStatus = "status";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedAssigneeID, parameters.AssigneeID);
        Assert.Equal(expectedStatus, parameters.Status);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new WorkItemListParams { ID = "id" };

        Assert.Null(parameters.AssigneeID);
        Assert.False(parameters.RawQueryData.ContainsKey("assignee_id"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawQueryData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new WorkItemListParams
        {
            ID = "id",

            // Null should be interpreted as omitted for these properties
            AssigneeID = null,
            Status = null,
        };

        Assert.Null(parameters.AssigneeID);
        Assert.False(parameters.RawQueryData.ContainsKey("assignee_id"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawQueryData.ContainsKey("status"));
    }

    [Fact]
    public void Url_Works()
    {
        WorkItemListParams parameters = new()
        {
            ID = "id",
            AssigneeID = "assignee_id",
            Status = "status",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.case.dev/matters/v1/id/work-items?assignee_id=assignee_id&status=status"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new WorkItemListParams
        {
            ID = "id",
            AssigneeID = "assignee_id",
            Status = "status",
        };

        WorkItemListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
