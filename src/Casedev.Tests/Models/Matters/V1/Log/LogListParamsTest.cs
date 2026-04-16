using System;
using System.Text.Json;
using Casedev.Core;
using Casedev.Models.Matters.V1.Log;

namespace Casedev.Tests.Models.Matters.V1.Log;

public class LogListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new LogListParams
        {
            ID = "id",
            ActorID = "actor_id",
            ActorType = "actor_type",
            EndTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = "event_type",
            Limit = 200,
            Offset = 0,
            Scope = "string",
            StartTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            WorkItemID = "work_item_id",
        };

        string expectedID = "id";
        string expectedActorID = "actor_id";
        string expectedActorType = "actor_type";
        DateTimeOffset expectedEndTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedEventType = "event_type";
        long expectedLimit = 200;
        long expectedOffset = 0;
        Scope expectedScope = "string";
        DateTimeOffset expectedStartTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedWorkItemID = "work_item_id";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedActorID, parameters.ActorID);
        Assert.Equal(expectedActorType, parameters.ActorType);
        Assert.Equal(expectedEndTime, parameters.EndTime);
        Assert.Equal(expectedEventType, parameters.EventType);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedOffset, parameters.Offset);
        Assert.Equal(expectedScope, parameters.Scope);
        Assert.Equal(expectedStartTime, parameters.StartTime);
        Assert.Equal(expectedWorkItemID, parameters.WorkItemID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new LogListParams { ID = "id" };

        Assert.Null(parameters.ActorID);
        Assert.False(parameters.RawQueryData.ContainsKey("actor_id"));
        Assert.Null(parameters.ActorType);
        Assert.False(parameters.RawQueryData.ContainsKey("actor_type"));
        Assert.Null(parameters.EndTime);
        Assert.False(parameters.RawQueryData.ContainsKey("end_time"));
        Assert.Null(parameters.EventType);
        Assert.False(parameters.RawQueryData.ContainsKey("event_type"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Offset);
        Assert.False(parameters.RawQueryData.ContainsKey("offset"));
        Assert.Null(parameters.Scope);
        Assert.False(parameters.RawQueryData.ContainsKey("scope"));
        Assert.Null(parameters.StartTime);
        Assert.False(parameters.RawQueryData.ContainsKey("start_time"));
        Assert.Null(parameters.WorkItemID);
        Assert.False(parameters.RawQueryData.ContainsKey("work_item_id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new LogListParams
        {
            ID = "id",

            // Null should be interpreted as omitted for these properties
            ActorID = null,
            ActorType = null,
            EndTime = null,
            EventType = null,
            Limit = null,
            Offset = null,
            Scope = null,
            StartTime = null,
            WorkItemID = null,
        };

        Assert.Null(parameters.ActorID);
        Assert.False(parameters.RawQueryData.ContainsKey("actor_id"));
        Assert.Null(parameters.ActorType);
        Assert.False(parameters.RawQueryData.ContainsKey("actor_type"));
        Assert.Null(parameters.EndTime);
        Assert.False(parameters.RawQueryData.ContainsKey("end_time"));
        Assert.Null(parameters.EventType);
        Assert.False(parameters.RawQueryData.ContainsKey("event_type"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Offset);
        Assert.False(parameters.RawQueryData.ContainsKey("offset"));
        Assert.Null(parameters.Scope);
        Assert.False(parameters.RawQueryData.ContainsKey("scope"));
        Assert.Null(parameters.StartTime);
        Assert.False(parameters.RawQueryData.ContainsKey("start_time"));
        Assert.Null(parameters.WorkItemID);
        Assert.False(parameters.RawQueryData.ContainsKey("work_item_id"));
    }

    [Fact]
    public void Url_Works()
    {
        LogListParams parameters = new()
        {
            ID = "id",
            ActorID = "actor_id",
            ActorType = "actor_type",
            EndTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117+00:00"),
            EventType = "event_type",
            Limit = 200,
            Offset = 0,
            Scope = "string",
            StartTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117+00:00"),
            WorkItemID = "work_item_id",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.case.dev/matters/v1/id/log?actor_id=actor_id&actor_type=actor_type&end_time=2019-12-27T18%3a11%3a19.117%2b00%3a00&event_type=event_type&limit=200&offset=0&scope=string&start_time=2019-12-27T18%3a11%3a19.117%2b00%3a00&work_item_id=work_item_id"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new LogListParams
        {
            ID = "id",
            ActorID = "actor_id",
            ActorType = "actor_type",
            EndTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = "event_type",
            Limit = 200,
            Offset = 0,
            Scope = "string",
            StartTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            WorkItemID = "work_item_id",
        };

        LogListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ScopeTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        Scope value = "string";
        value.Validate();
    }

    [Fact]
    public void StringsValidationWorks()
    {
        Scope value = new(["string"]);
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Scope value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Scope>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringsSerializationRoundtripWorks()
    {
        Scope value = new(["string"]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Scope>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
