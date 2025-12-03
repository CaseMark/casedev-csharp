using System.Text.Json;
using CaseDev.Core;
using CaseDev.Models.Compute.V1.Invoke;

namespace CaseDev.Tests.Models.Compute.V1.Invoke;

public class SynchronousResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SynchronousResponse
        {
            Duration = 0,
            Error = "error",
            Output = JsonSerializer.Deserialize<JsonElement>("{}"),
            RunID = "runId",
            Status = Status.Completed,
        };

        double expectedDuration = 0;
        string expectedError = "error";
        JsonElement expectedOutput = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedRunID = "runId";
        ApiEnum<string, Status> expectedStatus = Status.Completed;

        Assert.Equal(expectedDuration, model.Duration);
        Assert.Equal(expectedError, model.Error);
        Assert.True(
            model.Output.HasValue && JsonElement.DeepEquals(expectedOutput, model.Output.Value)
        );
        Assert.Equal(expectedRunID, model.RunID);
        Assert.Equal(expectedStatus, model.Status);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SynchronousResponse
        {
            Duration = 0,
            Error = "error",
            Output = JsonSerializer.Deserialize<JsonElement>("{}"),
            RunID = "runId",
            Status = Status.Completed,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SynchronousResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SynchronousResponse
        {
            Duration = 0,
            Error = "error",
            Output = JsonSerializer.Deserialize<JsonElement>("{}"),
            RunID = "runId",
            Status = Status.Completed,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SynchronousResponse>(json);
        Assert.NotNull(deserialized);

        double expectedDuration = 0;
        string expectedError = "error";
        JsonElement expectedOutput = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedRunID = "runId";
        ApiEnum<string, Status> expectedStatus = Status.Completed;

        Assert.Equal(expectedDuration, deserialized.Duration);
        Assert.Equal(expectedError, deserialized.Error);
        Assert.True(
            deserialized.Output.HasValue
                && JsonElement.DeepEquals(expectedOutput, deserialized.Output.Value)
        );
        Assert.Equal(expectedRunID, deserialized.RunID);
        Assert.Equal(expectedStatus, deserialized.Status);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SynchronousResponse
        {
            Duration = 0,
            Error = "error",
            Output = JsonSerializer.Deserialize<JsonElement>("{}"),
            RunID = "runId",
            Status = Status.Completed,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SynchronousResponse { };

        Assert.Null(model.Duration);
        Assert.False(model.RawData.ContainsKey("duration"));
        Assert.Null(model.Error);
        Assert.False(model.RawData.ContainsKey("error"));
        Assert.Null(model.Output);
        Assert.False(model.RawData.ContainsKey("output"));
        Assert.Null(model.RunID);
        Assert.False(model.RawData.ContainsKey("runId"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SynchronousResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SynchronousResponse
        {
            // Null should be interpreted as omitted for these properties
            Duration = null,
            Error = null,
            Output = null,
            RunID = null,
            Status = null,
        };

        Assert.Null(model.Duration);
        Assert.False(model.RawData.ContainsKey("duration"));
        Assert.Null(model.Error);
        Assert.False(model.RawData.ContainsKey("error"));
        Assert.Null(model.Output);
        Assert.False(model.RawData.ContainsKey("output"));
        Assert.Null(model.RunID);
        Assert.False(model.RawData.ContainsKey("runId"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SynchronousResponse
        {
            // Null should be interpreted as omitted for these properties
            Duration = null,
            Error = null,
            Output = null,
            RunID = null,
            Status = null,
        };

        model.Validate();
    }
}

public class AsynchronousResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AsynchronousResponse
        {
            LogsURL = "logsUrl",
            RunID = "runId",
            Status = AsynchronousResponseStatus.Running,
        };

        string expectedLogsURL = "logsUrl";
        string expectedRunID = "runId";
        ApiEnum<string, AsynchronousResponseStatus> expectedStatus =
            AsynchronousResponseStatus.Running;

        Assert.Equal(expectedLogsURL, model.LogsURL);
        Assert.Equal(expectedRunID, model.RunID);
        Assert.Equal(expectedStatus, model.Status);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AsynchronousResponse
        {
            LogsURL = "logsUrl",
            RunID = "runId",
            Status = AsynchronousResponseStatus.Running,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AsynchronousResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AsynchronousResponse
        {
            LogsURL = "logsUrl",
            RunID = "runId",
            Status = AsynchronousResponseStatus.Running,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AsynchronousResponse>(json);
        Assert.NotNull(deserialized);

        string expectedLogsURL = "logsUrl";
        string expectedRunID = "runId";
        ApiEnum<string, AsynchronousResponseStatus> expectedStatus =
            AsynchronousResponseStatus.Running;

        Assert.Equal(expectedLogsURL, deserialized.LogsURL);
        Assert.Equal(expectedRunID, deserialized.RunID);
        Assert.Equal(expectedStatus, deserialized.Status);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AsynchronousResponse
        {
            LogsURL = "logsUrl",
            RunID = "runId",
            Status = AsynchronousResponseStatus.Running,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AsynchronousResponse { };

        Assert.Null(model.LogsURL);
        Assert.False(model.RawData.ContainsKey("logsUrl"));
        Assert.Null(model.RunID);
        Assert.False(model.RawData.ContainsKey("runId"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new AsynchronousResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AsynchronousResponse
        {
            // Null should be interpreted as omitted for these properties
            LogsURL = null,
            RunID = null,
            Status = null,
        };

        Assert.Null(model.LogsURL);
        Assert.False(model.RawData.ContainsKey("logsUrl"));
        Assert.Null(model.RunID);
        Assert.False(model.RawData.ContainsKey("runId"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AsynchronousResponse
        {
            // Null should be interpreted as omitted for these properties
            LogsURL = null,
            RunID = null,
            Status = null,
        };

        model.Validate();
    }
}
