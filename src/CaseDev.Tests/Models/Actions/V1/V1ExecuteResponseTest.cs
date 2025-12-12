using System.Collections.Generic;
using System.Text.Json;
using CaseDev.Core;
using CaseDev.Exceptions;
using CaseDev.Models.Actions.V1;

namespace CaseDev.Tests.Models.Actions.V1;

public class V1ExecuteResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new V1ExecuteResponse
        {
            DurationMs = 0,
            ExecutionID = "execution_id",
            Message = "message",
            Output = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Status = Status.Completed,
            StepResults =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            WebhookConfigured = true,
        };

        double expectedDurationMs = 0;
        string expectedExecutionID = "execution_id";
        string expectedMessage = "message";
        Dictionary<string, JsonElement> expectedOutput = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        ApiEnum<string, Status> expectedStatus = Status.Completed;
        List<Dictionary<string, JsonElement>> expectedStepResults =
        [
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        ];
        bool expectedWebhookConfigured = true;

        Assert.Equal(expectedDurationMs, model.DurationMs);
        Assert.Equal(expectedExecutionID, model.ExecutionID);
        Assert.Equal(expectedMessage, model.Message);
        Assert.Equal(expectedOutput.Count, model.Output.Count);
        foreach (var item in expectedOutput)
        {
            Assert.True(model.Output.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Output[item.Key]));
        }
        Assert.Equal(expectedStatus, model.Status);
        Assert.NotNull(model.StepResults);
        Assert.Equal(expectedStepResults.Count, model.StepResults.Count);
        for (int i = 0; i < expectedStepResults.Count; i++)
        {
            Assert.Equal(expectedStepResults[i].Count, model.StepResults[i].Count);
            foreach (var item in expectedStepResults[i])
            {
                Assert.True(model.StepResults[i].TryGetValue(item.Key, out var value));

                Assert.True(JsonElement.DeepEquals(value, model.StepResults[i][item.Key]));
            }
        }
        Assert.Equal(expectedWebhookConfigured, model.WebhookConfigured);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new V1ExecuteResponse
        {
            DurationMs = 0,
            ExecutionID = "execution_id",
            Message = "message",
            Output = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Status = Status.Completed,
            StepResults =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            WebhookConfigured = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<V1ExecuteResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new V1ExecuteResponse
        {
            DurationMs = 0,
            ExecutionID = "execution_id",
            Message = "message",
            Output = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Status = Status.Completed,
            StepResults =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            WebhookConfigured = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<V1ExecuteResponse>(json);
        Assert.NotNull(deserialized);

        double expectedDurationMs = 0;
        string expectedExecutionID = "execution_id";
        string expectedMessage = "message";
        Dictionary<string, JsonElement> expectedOutput = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        ApiEnum<string, Status> expectedStatus = Status.Completed;
        List<Dictionary<string, JsonElement>> expectedStepResults =
        [
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        ];
        bool expectedWebhookConfigured = true;

        Assert.Equal(expectedDurationMs, deserialized.DurationMs);
        Assert.Equal(expectedExecutionID, deserialized.ExecutionID);
        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.Equal(expectedOutput.Count, deserialized.Output.Count);
        foreach (var item in expectedOutput)
        {
            Assert.True(deserialized.Output.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Output[item.Key]));
        }
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.NotNull(deserialized.StepResults);
        Assert.Equal(expectedStepResults.Count, deserialized.StepResults.Count);
        for (int i = 0; i < expectedStepResults.Count; i++)
        {
            Assert.Equal(expectedStepResults[i].Count, deserialized.StepResults[i].Count);
            foreach (var item in expectedStepResults[i])
            {
                Assert.True(deserialized.StepResults[i].TryGetValue(item.Key, out var value));

                Assert.True(JsonElement.DeepEquals(value, deserialized.StepResults[i][item.Key]));
            }
        }
        Assert.Equal(expectedWebhookConfigured, deserialized.WebhookConfigured);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new V1ExecuteResponse
        {
            DurationMs = 0,
            ExecutionID = "execution_id",
            Message = "message",
            Output = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Status = Status.Completed,
            StepResults =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            WebhookConfigured = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new V1ExecuteResponse { };

        Assert.Null(model.DurationMs);
        Assert.False(model.RawData.ContainsKey("duration_ms"));
        Assert.Null(model.ExecutionID);
        Assert.False(model.RawData.ContainsKey("execution_id"));
        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
        Assert.Null(model.Output);
        Assert.False(model.RawData.ContainsKey("output"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.StepResults);
        Assert.False(model.RawData.ContainsKey("step_results"));
        Assert.Null(model.WebhookConfigured);
        Assert.False(model.RawData.ContainsKey("webhook_configured"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new V1ExecuteResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new V1ExecuteResponse
        {
            // Null should be interpreted as omitted for these properties
            DurationMs = null,
            ExecutionID = null,
            Message = null,
            Output = null,
            Status = null,
            StepResults = null,
            WebhookConfigured = null,
        };

        Assert.Null(model.DurationMs);
        Assert.False(model.RawData.ContainsKey("duration_ms"));
        Assert.Null(model.ExecutionID);
        Assert.False(model.RawData.ContainsKey("execution_id"));
        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
        Assert.Null(model.Output);
        Assert.False(model.RawData.ContainsKey("output"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.StepResults);
        Assert.False(model.RawData.ContainsKey("step_results"));
        Assert.Null(model.WebhookConfigured);
        Assert.False(model.RawData.ContainsKey("webhook_configured"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new V1ExecuteResponse
        {
            // Null should be interpreted as omitted for these properties
            DurationMs = null,
            ExecutionID = null,
            Message = null,
            Output = null,
            Status = null,
            StepResults = null,
            WebhookConfigured = null,
        };

        model.Validate();
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Completed)]
    [InlineData(Status.Running)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.Completed)]
    [InlineData(Status.Running)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
