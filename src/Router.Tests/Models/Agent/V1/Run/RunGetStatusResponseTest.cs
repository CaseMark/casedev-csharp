using System;
using System.Text.Json;
using Router.Core;
using Router.Exceptions;
using Router.Models.Agent.V1.Run;

namespace Router.Tests.Models.Agent.V1.Run;

public class RunGetStatusResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RunGetStatusResponse
        {
            ID = "id",
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DurationMs = 0,
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = RunGetStatusResponseStatus.Queued,
        };

        string expectedID = "id";
        DateTimeOffset expectedCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedDurationMs = 0;
        DateTimeOffset expectedStartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, RunGetStatusResponseStatus> expectedStatus =
            RunGetStatusResponseStatus.Queued;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCompletedAt, model.CompletedAt);
        Assert.Equal(expectedDurationMs, model.DurationMs);
        Assert.Equal(expectedStartedAt, model.StartedAt);
        Assert.Equal(expectedStatus, model.Status);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RunGetStatusResponse
        {
            ID = "id",
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DurationMs = 0,
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = RunGetStatusResponseStatus.Queued,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RunGetStatusResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RunGetStatusResponse
        {
            ID = "id",
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DurationMs = 0,
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = RunGetStatusResponseStatus.Queued,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RunGetStatusResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedDurationMs = 0;
        DateTimeOffset expectedStartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, RunGetStatusResponseStatus> expectedStatus =
            RunGetStatusResponseStatus.Queued;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCompletedAt, deserialized.CompletedAt);
        Assert.Equal(expectedDurationMs, deserialized.DurationMs);
        Assert.Equal(expectedStartedAt, deserialized.StartedAt);
        Assert.Equal(expectedStatus, deserialized.Status);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RunGetStatusResponse
        {
            ID = "id",
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DurationMs = 0,
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = RunGetStatusResponseStatus.Queued,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new RunGetStatusResponse
        {
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DurationMs = 0,
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new RunGetStatusResponse
        {
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DurationMs = 0,
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new RunGetStatusResponse
        {
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DurationMs = 0,
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            ID = null,
            Status = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new RunGetStatusResponse
        {
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DurationMs = 0,
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            ID = null,
            Status = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new RunGetStatusResponse
        {
            ID = "id",
            Status = RunGetStatusResponseStatus.Queued,
        };

        Assert.Null(model.CompletedAt);
        Assert.False(model.RawData.ContainsKey("completedAt"));
        Assert.Null(model.DurationMs);
        Assert.False(model.RawData.ContainsKey("durationMs"));
        Assert.Null(model.StartedAt);
        Assert.False(model.RawData.ContainsKey("startedAt"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new RunGetStatusResponse
        {
            ID = "id",
            Status = RunGetStatusResponseStatus.Queued,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new RunGetStatusResponse
        {
            ID = "id",
            Status = RunGetStatusResponseStatus.Queued,

            CompletedAt = null,
            DurationMs = null,
            StartedAt = null,
        };

        Assert.Null(model.CompletedAt);
        Assert.True(model.RawData.ContainsKey("completedAt"));
        Assert.Null(model.DurationMs);
        Assert.True(model.RawData.ContainsKey("durationMs"));
        Assert.Null(model.StartedAt);
        Assert.True(model.RawData.ContainsKey("startedAt"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new RunGetStatusResponse
        {
            ID = "id",
            Status = RunGetStatusResponseStatus.Queued,

            CompletedAt = null,
            DurationMs = null,
            StartedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RunGetStatusResponse
        {
            ID = "id",
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DurationMs = 0,
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = RunGetStatusResponseStatus.Queued,
        };

        RunGetStatusResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RunGetStatusResponseStatusTest : TestBase
{
    [Theory]
    [InlineData(RunGetStatusResponseStatus.Queued)]
    [InlineData(RunGetStatusResponseStatus.Running)]
    [InlineData(RunGetStatusResponseStatus.Completed)]
    [InlineData(RunGetStatusResponseStatus.Failed)]
    [InlineData(RunGetStatusResponseStatus.Cancelled)]
    public void Validation_Works(RunGetStatusResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RunGetStatusResponseStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RunGetStatusResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RunGetStatusResponseStatus.Queued)]
    [InlineData(RunGetStatusResponseStatus.Running)]
    [InlineData(RunGetStatusResponseStatus.Completed)]
    [InlineData(RunGetStatusResponseStatus.Failed)]
    [InlineData(RunGetStatusResponseStatus.Cancelled)]
    public void SerializationRoundtrip_Works(RunGetStatusResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RunGetStatusResponseStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RunGetStatusResponseStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RunGetStatusResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RunGetStatusResponseStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
