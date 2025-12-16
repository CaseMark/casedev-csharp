using System.Collections.Generic;
using System.Text.Json;
using CaseDev.Models.Workflows.V1;

namespace CaseDev.Tests.Models.Workflows.V1;

public class V1RetrieveExecutionResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new V1RetrieveExecutionResponse
        {
            ID = "id",
            CompletedAt = "completedAt",
            DurationMs = 0,
            Error = "error",
            ExecutionArn = "executionArn",
            Input = JsonSerializer.Deserialize<JsonElement>("{}"),
            Output = JsonSerializer.Deserialize<JsonElement>("{}"),
            StartedAt = "startedAt",
            Status = "status",
            Steps = [JsonSerializer.Deserialize<JsonElement>("{}")],
            TriggerType = "triggerType",
            WorkflowID = "workflowId",
        };

        string expectedID = "id";
        string expectedCompletedAt = "completedAt";
        long expectedDurationMs = 0;
        string expectedError = "error";
        string expectedExecutionArn = "executionArn";
        JsonElement expectedInput = JsonSerializer.Deserialize<JsonElement>("{}");
        JsonElement expectedOutput = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedStartedAt = "startedAt";
        string expectedStatus = "status";
        List<JsonElement> expectedSteps = [JsonSerializer.Deserialize<JsonElement>("{}")];
        string expectedTriggerType = "triggerType";
        string expectedWorkflowID = "workflowId";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCompletedAt, model.CompletedAt);
        Assert.Equal(expectedDurationMs, model.DurationMs);
        Assert.Equal(expectedError, model.Error);
        Assert.Equal(expectedExecutionArn, model.ExecutionArn);
        Assert.NotNull(model.Input);
        Assert.True(JsonElement.DeepEquals(expectedInput, model.Input.Value));
        Assert.NotNull(model.Output);
        Assert.True(JsonElement.DeepEquals(expectedOutput, model.Output.Value));
        Assert.Equal(expectedStartedAt, model.StartedAt);
        Assert.Equal(expectedStatus, model.Status);
        Assert.NotNull(model.Steps);
        Assert.Equal(expectedSteps.Count, model.Steps.Count);
        for (int i = 0; i < expectedSteps.Count; i++)
        {
            Assert.True(JsonElement.DeepEquals(expectedSteps[i], model.Steps[i]));
        }
        Assert.Equal(expectedTriggerType, model.TriggerType);
        Assert.Equal(expectedWorkflowID, model.WorkflowID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new V1RetrieveExecutionResponse
        {
            ID = "id",
            CompletedAt = "completedAt",
            DurationMs = 0,
            Error = "error",
            ExecutionArn = "executionArn",
            Input = JsonSerializer.Deserialize<JsonElement>("{}"),
            Output = JsonSerializer.Deserialize<JsonElement>("{}"),
            StartedAt = "startedAt",
            Status = "status",
            Steps = [JsonSerializer.Deserialize<JsonElement>("{}")],
            TriggerType = "triggerType",
            WorkflowID = "workflowId",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<V1RetrieveExecutionResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new V1RetrieveExecutionResponse
        {
            ID = "id",
            CompletedAt = "completedAt",
            DurationMs = 0,
            Error = "error",
            ExecutionArn = "executionArn",
            Input = JsonSerializer.Deserialize<JsonElement>("{}"),
            Output = JsonSerializer.Deserialize<JsonElement>("{}"),
            StartedAt = "startedAt",
            Status = "status",
            Steps = [JsonSerializer.Deserialize<JsonElement>("{}")],
            TriggerType = "triggerType",
            WorkflowID = "workflowId",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<V1RetrieveExecutionResponse>(json);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedCompletedAt = "completedAt";
        long expectedDurationMs = 0;
        string expectedError = "error";
        string expectedExecutionArn = "executionArn";
        JsonElement expectedInput = JsonSerializer.Deserialize<JsonElement>("{}");
        JsonElement expectedOutput = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedStartedAt = "startedAt";
        string expectedStatus = "status";
        List<JsonElement> expectedSteps = [JsonSerializer.Deserialize<JsonElement>("{}")];
        string expectedTriggerType = "triggerType";
        string expectedWorkflowID = "workflowId";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCompletedAt, deserialized.CompletedAt);
        Assert.Equal(expectedDurationMs, deserialized.DurationMs);
        Assert.Equal(expectedError, deserialized.Error);
        Assert.Equal(expectedExecutionArn, deserialized.ExecutionArn);
        Assert.NotNull(deserialized.Input);
        Assert.True(JsonElement.DeepEquals(expectedInput, deserialized.Input.Value));
        Assert.NotNull(deserialized.Output);
        Assert.True(JsonElement.DeepEquals(expectedOutput, deserialized.Output.Value));
        Assert.Equal(expectedStartedAt, deserialized.StartedAt);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.NotNull(deserialized.Steps);
        Assert.Equal(expectedSteps.Count, deserialized.Steps.Count);
        for (int i = 0; i < expectedSteps.Count; i++)
        {
            Assert.True(JsonElement.DeepEquals(expectedSteps[i], deserialized.Steps[i]));
        }
        Assert.Equal(expectedTriggerType, deserialized.TriggerType);
        Assert.Equal(expectedWorkflowID, deserialized.WorkflowID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new V1RetrieveExecutionResponse
        {
            ID = "id",
            CompletedAt = "completedAt",
            DurationMs = 0,
            Error = "error",
            ExecutionArn = "executionArn",
            Input = JsonSerializer.Deserialize<JsonElement>("{}"),
            Output = JsonSerializer.Deserialize<JsonElement>("{}"),
            StartedAt = "startedAt",
            Status = "status",
            Steps = [JsonSerializer.Deserialize<JsonElement>("{}")],
            TriggerType = "triggerType",
            WorkflowID = "workflowId",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new V1RetrieveExecutionResponse { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CompletedAt);
        Assert.False(model.RawData.ContainsKey("completedAt"));
        Assert.Null(model.DurationMs);
        Assert.False(model.RawData.ContainsKey("durationMs"));
        Assert.Null(model.Error);
        Assert.False(model.RawData.ContainsKey("error"));
        Assert.Null(model.ExecutionArn);
        Assert.False(model.RawData.ContainsKey("executionArn"));
        Assert.Null(model.Input);
        Assert.False(model.RawData.ContainsKey("input"));
        Assert.Null(model.Output);
        Assert.False(model.RawData.ContainsKey("output"));
        Assert.Null(model.StartedAt);
        Assert.False(model.RawData.ContainsKey("startedAt"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.Steps);
        Assert.False(model.RawData.ContainsKey("steps"));
        Assert.Null(model.TriggerType);
        Assert.False(model.RawData.ContainsKey("triggerType"));
        Assert.Null(model.WorkflowID);
        Assert.False(model.RawData.ContainsKey("workflowId"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new V1RetrieveExecutionResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new V1RetrieveExecutionResponse
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            CompletedAt = null,
            DurationMs = null,
            Error = null,
            ExecutionArn = null,
            Input = null,
            Output = null,
            StartedAt = null,
            Status = null,
            Steps = null,
            TriggerType = null,
            WorkflowID = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CompletedAt);
        Assert.False(model.RawData.ContainsKey("completedAt"));
        Assert.Null(model.DurationMs);
        Assert.False(model.RawData.ContainsKey("durationMs"));
        Assert.Null(model.Error);
        Assert.False(model.RawData.ContainsKey("error"));
        Assert.Null(model.ExecutionArn);
        Assert.False(model.RawData.ContainsKey("executionArn"));
        Assert.Null(model.Input);
        Assert.False(model.RawData.ContainsKey("input"));
        Assert.Null(model.Output);
        Assert.False(model.RawData.ContainsKey("output"));
        Assert.Null(model.StartedAt);
        Assert.False(model.RawData.ContainsKey("startedAt"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.Steps);
        Assert.False(model.RawData.ContainsKey("steps"));
        Assert.Null(model.TriggerType);
        Assert.False(model.RawData.ContainsKey("triggerType"));
        Assert.Null(model.WorkflowID);
        Assert.False(model.RawData.ContainsKey("workflowId"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new V1RetrieveExecutionResponse
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            CompletedAt = null,
            DurationMs = null,
            Error = null,
            ExecutionArn = null,
            Input = null,
            Output = null,
            StartedAt = null,
            Status = null,
            Steps = null,
            TriggerType = null,
            WorkflowID = null,
        };

        model.Validate();
    }
}
