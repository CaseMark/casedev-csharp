using System.Collections.Generic;
using System.Text.Json;
using CaseDev.Models.Workflows.V1;

namespace CaseDev.Tests.Models.Workflows.V1;

public class V1ListExecutionsResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new V1ListExecutionsResponse
        {
            Executions =
            [
                new()
                {
                    ID = "id",
                    CompletedAt = "completedAt",
                    DurationMs = 0,
                    StartedAt = "startedAt",
                    Status = "status",
                    TriggerType = "triggerType",
                },
            ],
        };

        List<Execution> expectedExecutions =
        [
            new()
            {
                ID = "id",
                CompletedAt = "completedAt",
                DurationMs = 0,
                StartedAt = "startedAt",
                Status = "status",
                TriggerType = "triggerType",
            },
        ];

        Assert.Equal(expectedExecutions.Count, model.Executions.Count);
        for (int i = 0; i < expectedExecutions.Count; i++)
        {
            Assert.Equal(expectedExecutions[i], model.Executions[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new V1ListExecutionsResponse
        {
            Executions =
            [
                new()
                {
                    ID = "id",
                    CompletedAt = "completedAt",
                    DurationMs = 0,
                    StartedAt = "startedAt",
                    Status = "status",
                    TriggerType = "triggerType",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<V1ListExecutionsResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new V1ListExecutionsResponse
        {
            Executions =
            [
                new()
                {
                    ID = "id",
                    CompletedAt = "completedAt",
                    DurationMs = 0,
                    StartedAt = "startedAt",
                    Status = "status",
                    TriggerType = "triggerType",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<V1ListExecutionsResponse>(json);
        Assert.NotNull(deserialized);

        List<Execution> expectedExecutions =
        [
            new()
            {
                ID = "id",
                CompletedAt = "completedAt",
                DurationMs = 0,
                StartedAt = "startedAt",
                Status = "status",
                TriggerType = "triggerType",
            },
        ];

        Assert.Equal(expectedExecutions.Count, deserialized.Executions.Count);
        for (int i = 0; i < expectedExecutions.Count; i++)
        {
            Assert.Equal(expectedExecutions[i], deserialized.Executions[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new V1ListExecutionsResponse
        {
            Executions =
            [
                new()
                {
                    ID = "id",
                    CompletedAt = "completedAt",
                    DurationMs = 0,
                    StartedAt = "startedAt",
                    Status = "status",
                    TriggerType = "triggerType",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new V1ListExecutionsResponse { };

        Assert.Null(model.Executions);
        Assert.False(model.RawData.ContainsKey("executions"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new V1ListExecutionsResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new V1ListExecutionsResponse
        {
            // Null should be interpreted as omitted for these properties
            Executions = null,
        };

        Assert.Null(model.Executions);
        Assert.False(model.RawData.ContainsKey("executions"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new V1ListExecutionsResponse
        {
            // Null should be interpreted as omitted for these properties
            Executions = null,
        };

        model.Validate();
    }
}

public class ExecutionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Execution
        {
            ID = "id",
            CompletedAt = "completedAt",
            DurationMs = 0,
            StartedAt = "startedAt",
            Status = "status",
            TriggerType = "triggerType",
        };

        string expectedID = "id";
        string expectedCompletedAt = "completedAt";
        long expectedDurationMs = 0;
        string expectedStartedAt = "startedAt";
        string expectedStatus = "status";
        string expectedTriggerType = "triggerType";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCompletedAt, model.CompletedAt);
        Assert.Equal(expectedDurationMs, model.DurationMs);
        Assert.Equal(expectedStartedAt, model.StartedAt);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedTriggerType, model.TriggerType);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Execution
        {
            ID = "id",
            CompletedAt = "completedAt",
            DurationMs = 0,
            StartedAt = "startedAt",
            Status = "status",
            TriggerType = "triggerType",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Execution>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Execution
        {
            ID = "id",
            CompletedAt = "completedAt",
            DurationMs = 0,
            StartedAt = "startedAt",
            Status = "status",
            TriggerType = "triggerType",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Execution>(json);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedCompletedAt = "completedAt";
        long expectedDurationMs = 0;
        string expectedStartedAt = "startedAt";
        string expectedStatus = "status";
        string expectedTriggerType = "triggerType";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCompletedAt, deserialized.CompletedAt);
        Assert.Equal(expectedDurationMs, deserialized.DurationMs);
        Assert.Equal(expectedStartedAt, deserialized.StartedAt);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedTriggerType, deserialized.TriggerType);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Execution
        {
            ID = "id",
            CompletedAt = "completedAt",
            DurationMs = 0,
            StartedAt = "startedAt",
            Status = "status",
            TriggerType = "triggerType",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Execution { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CompletedAt);
        Assert.False(model.RawData.ContainsKey("completedAt"));
        Assert.Null(model.DurationMs);
        Assert.False(model.RawData.ContainsKey("durationMs"));
        Assert.Null(model.StartedAt);
        Assert.False(model.RawData.ContainsKey("startedAt"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.TriggerType);
        Assert.False(model.RawData.ContainsKey("triggerType"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Execution { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Execution
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            CompletedAt = null,
            DurationMs = null,
            StartedAt = null,
            Status = null,
            TriggerType = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CompletedAt);
        Assert.False(model.RawData.ContainsKey("completedAt"));
        Assert.Null(model.DurationMs);
        Assert.False(model.RawData.ContainsKey("durationMs"));
        Assert.Null(model.StartedAt);
        Assert.False(model.RawData.ContainsKey("startedAt"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.TriggerType);
        Assert.False(model.RawData.ContainsKey("triggerType"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Execution
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            CompletedAt = null,
            DurationMs = null,
            StartedAt = null,
            Status = null,
            TriggerType = null,
        };

        model.Validate();
    }
}
