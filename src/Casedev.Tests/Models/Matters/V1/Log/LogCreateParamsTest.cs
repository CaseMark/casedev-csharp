using System;
using System.Collections.Generic;
using System.Text.Json;
using Casedev.Models.Matters.V1.Log;

namespace Casedev.Tests.Models.Matters.V1.Log;

public class LogCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new LogCreateParams
        {
            ID = "id",
            Summary = "summary",
            Details = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            EventType = "event_type",
            WorkItemID = "work_item_id",
        };

        string expectedID = "id";
        string expectedSummary = "summary";
        Dictionary<string, JsonElement> expectedDetails = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedEventType = "event_type";
        string expectedWorkItemID = "work_item_id";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedSummary, parameters.Summary);
        Assert.NotNull(parameters.Details);
        Assert.Equal(expectedDetails.Count, parameters.Details.Count);
        foreach (var item in expectedDetails)
        {
            Assert.True(parameters.Details.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, parameters.Details[item.Key]));
        }
        Assert.Equal(expectedEventType, parameters.EventType);
        Assert.Equal(expectedWorkItemID, parameters.WorkItemID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new LogCreateParams { ID = "id", Summary = "summary" };

        Assert.Null(parameters.Details);
        Assert.False(parameters.RawBodyData.ContainsKey("details"));
        Assert.Null(parameters.EventType);
        Assert.False(parameters.RawBodyData.ContainsKey("event_type"));
        Assert.Null(parameters.WorkItemID);
        Assert.False(parameters.RawBodyData.ContainsKey("work_item_id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new LogCreateParams
        {
            ID = "id",
            Summary = "summary",

            // Null should be interpreted as omitted for these properties
            Details = null,
            EventType = null,
            WorkItemID = null,
        };

        Assert.Null(parameters.Details);
        Assert.False(parameters.RawBodyData.ContainsKey("details"));
        Assert.Null(parameters.EventType);
        Assert.False(parameters.RawBodyData.ContainsKey("event_type"));
        Assert.Null(parameters.WorkItemID);
        Assert.False(parameters.RawBodyData.ContainsKey("work_item_id"));
    }

    [Fact]
    public void Url_Works()
    {
        LogCreateParams parameters = new() { ID = "id", Summary = "summary" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.case.dev/matters/v1/id/log"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new LogCreateParams
        {
            ID = "id",
            Summary = "summary",
            Details = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            EventType = "event_type",
            WorkItemID = "work_item_id",
        };

        LogCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
