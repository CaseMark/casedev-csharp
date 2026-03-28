using System;
using System.Text.Json;
using Casedev.Core;
using Casedev.Exceptions;
using Casedev.Models.Matters.V1.Log;

namespace Casedev.Tests.Models.Matters.V1.Log;

public class LogExportParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new LogExportParams
        {
            ID = "id",
            ActorID = "actor_id",
            ActorType = "actor_type",
            EndTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = "event_type",
            Format = LogExportParamsFormat.Json,
            Scope = "string",
            StartTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            WorkItemID = "work_item_id",
        };

        string expectedID = "id";
        string expectedActorID = "actor_id";
        string expectedActorType = "actor_type";
        DateTimeOffset expectedEndTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedEventType = "event_type";
        ApiEnum<string, LogExportParamsFormat> expectedFormat = LogExportParamsFormat.Json;
        LogExportParamsScope expectedScope = "string";
        DateTimeOffset expectedStartTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedWorkItemID = "work_item_id";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedActorID, parameters.ActorID);
        Assert.Equal(expectedActorType, parameters.ActorType);
        Assert.Equal(expectedEndTime, parameters.EndTime);
        Assert.Equal(expectedEventType, parameters.EventType);
        Assert.Equal(expectedFormat, parameters.Format);
        Assert.Equal(expectedScope, parameters.Scope);
        Assert.Equal(expectedStartTime, parameters.StartTime);
        Assert.Equal(expectedWorkItemID, parameters.WorkItemID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new LogExportParams { ID = "id" };

        Assert.Null(parameters.ActorID);
        Assert.False(parameters.RawBodyData.ContainsKey("actor_id"));
        Assert.Null(parameters.ActorType);
        Assert.False(parameters.RawBodyData.ContainsKey("actor_type"));
        Assert.Null(parameters.EndTime);
        Assert.False(parameters.RawBodyData.ContainsKey("end_time"));
        Assert.Null(parameters.EventType);
        Assert.False(parameters.RawBodyData.ContainsKey("event_type"));
        Assert.Null(parameters.Format);
        Assert.False(parameters.RawBodyData.ContainsKey("format"));
        Assert.Null(parameters.Scope);
        Assert.False(parameters.RawBodyData.ContainsKey("scope"));
        Assert.Null(parameters.StartTime);
        Assert.False(parameters.RawBodyData.ContainsKey("start_time"));
        Assert.Null(parameters.WorkItemID);
        Assert.False(parameters.RawBodyData.ContainsKey("work_item_id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new LogExportParams
        {
            ID = "id",

            // Null should be interpreted as omitted for these properties
            ActorID = null,
            ActorType = null,
            EndTime = null,
            EventType = null,
            Format = null,
            Scope = null,
            StartTime = null,
            WorkItemID = null,
        };

        Assert.Null(parameters.ActorID);
        Assert.False(parameters.RawBodyData.ContainsKey("actor_id"));
        Assert.Null(parameters.ActorType);
        Assert.False(parameters.RawBodyData.ContainsKey("actor_type"));
        Assert.Null(parameters.EndTime);
        Assert.False(parameters.RawBodyData.ContainsKey("end_time"));
        Assert.Null(parameters.EventType);
        Assert.False(parameters.RawBodyData.ContainsKey("event_type"));
        Assert.Null(parameters.Format);
        Assert.False(parameters.RawBodyData.ContainsKey("format"));
        Assert.Null(parameters.Scope);
        Assert.False(parameters.RawBodyData.ContainsKey("scope"));
        Assert.Null(parameters.StartTime);
        Assert.False(parameters.RawBodyData.ContainsKey("start_time"));
        Assert.Null(parameters.WorkItemID);
        Assert.False(parameters.RawBodyData.ContainsKey("work_item_id"));
    }

    [Fact]
    public void Url_Works()
    {
        LogExportParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/matters/v1/id/log/export"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new LogExportParams
        {
            ID = "id",
            ActorID = "actor_id",
            ActorType = "actor_type",
            EndTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = "event_type",
            Format = LogExportParamsFormat.Json,
            Scope = "string",
            StartTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            WorkItemID = "work_item_id",
        };

        LogExportParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class LogExportParamsFormatTest : TestBase
{
    [Theory]
    [InlineData(LogExportParamsFormat.Json)]
    [InlineData(LogExportParamsFormat.Jsonl)]
    [InlineData(LogExportParamsFormat.Csv)]
    [InlineData(LogExportParamsFormat.Tsv)]
    public void Validation_Works(LogExportParamsFormat rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, LogExportParamsFormat> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, LogExportParamsFormat>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(LogExportParamsFormat.Json)]
    [InlineData(LogExportParamsFormat.Jsonl)]
    [InlineData(LogExportParamsFormat.Csv)]
    [InlineData(LogExportParamsFormat.Tsv)]
    public void SerializationRoundtrip_Works(LogExportParamsFormat rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, LogExportParamsFormat> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, LogExportParamsFormat>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, LogExportParamsFormat>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, LogExportParamsFormat>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class LogExportParamsScopeTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        LogExportParamsScope value = "string";
        value.Validate();
    }

    [Fact]
    public void StringsValidationWorks()
    {
        LogExportParamsScope value = new(["string"]);
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        LogExportParamsScope value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<LogExportParamsScope>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringsSerializationRoundtripWorks()
    {
        LogExportParamsScope value = new(["string"]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<LogExportParamsScope>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
