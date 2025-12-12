using System.Text.Json;
using CaseDev.Core;
using CaseDev.Exceptions;
using CaseDev.Models.Workflows.V1;

namespace CaseDev.Tests.Models.Workflows.V1;

public class V1ExecuteResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new V1ExecuteResponse
        {
            Duration = 0,
            Error = "error",
            ExecutionID = "executionId",
            Outputs = JsonSerializer.Deserialize<JsonElement>("{}"),
            Status = V1ExecuteResponseStatus.Completed,
        };

        long expectedDuration = 0;
        string expectedError = "error";
        string expectedExecutionID = "executionId";
        JsonElement expectedOutputs = JsonSerializer.Deserialize<JsonElement>("{}");
        ApiEnum<string, V1ExecuteResponseStatus> expectedStatus = V1ExecuteResponseStatus.Completed;

        Assert.Equal(expectedDuration, model.Duration);
        Assert.Equal(expectedError, model.Error);
        Assert.Equal(expectedExecutionID, model.ExecutionID);
        Assert.NotNull(model.Outputs);
        Assert.True(JsonElement.DeepEquals(expectedOutputs, model.Outputs.Value));
        Assert.Equal(expectedStatus, model.Status);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new V1ExecuteResponse
        {
            Duration = 0,
            Error = "error",
            ExecutionID = "executionId",
            Outputs = JsonSerializer.Deserialize<JsonElement>("{}"),
            Status = V1ExecuteResponseStatus.Completed,
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
            Duration = 0,
            Error = "error",
            ExecutionID = "executionId",
            Outputs = JsonSerializer.Deserialize<JsonElement>("{}"),
            Status = V1ExecuteResponseStatus.Completed,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<V1ExecuteResponse>(json);
        Assert.NotNull(deserialized);

        long expectedDuration = 0;
        string expectedError = "error";
        string expectedExecutionID = "executionId";
        JsonElement expectedOutputs = JsonSerializer.Deserialize<JsonElement>("{}");
        ApiEnum<string, V1ExecuteResponseStatus> expectedStatus = V1ExecuteResponseStatus.Completed;

        Assert.Equal(expectedDuration, deserialized.Duration);
        Assert.Equal(expectedError, deserialized.Error);
        Assert.Equal(expectedExecutionID, deserialized.ExecutionID);
        Assert.NotNull(deserialized.Outputs);
        Assert.True(JsonElement.DeepEquals(expectedOutputs, deserialized.Outputs.Value));
        Assert.Equal(expectedStatus, deserialized.Status);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new V1ExecuteResponse
        {
            Duration = 0,
            Error = "error",
            ExecutionID = "executionId",
            Outputs = JsonSerializer.Deserialize<JsonElement>("{}"),
            Status = V1ExecuteResponseStatus.Completed,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new V1ExecuteResponse { };

        Assert.Null(model.Duration);
        Assert.False(model.RawData.ContainsKey("duration"));
        Assert.Null(model.Error);
        Assert.False(model.RawData.ContainsKey("error"));
        Assert.Null(model.ExecutionID);
        Assert.False(model.RawData.ContainsKey("executionId"));
        Assert.Null(model.Outputs);
        Assert.False(model.RawData.ContainsKey("outputs"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
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
            Duration = null,
            Error = null,
            ExecutionID = null,
            Outputs = null,
            Status = null,
        };

        Assert.Null(model.Duration);
        Assert.False(model.RawData.ContainsKey("duration"));
        Assert.Null(model.Error);
        Assert.False(model.RawData.ContainsKey("error"));
        Assert.Null(model.ExecutionID);
        Assert.False(model.RawData.ContainsKey("executionId"));
        Assert.Null(model.Outputs);
        Assert.False(model.RawData.ContainsKey("outputs"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new V1ExecuteResponse
        {
            // Null should be interpreted as omitted for these properties
            Duration = null,
            Error = null,
            ExecutionID = null,
            Outputs = null,
            Status = null,
        };

        model.Validate();
    }
}

public class V1ExecuteResponseStatusTest : TestBase
{
    [Theory]
    [InlineData(V1ExecuteResponseStatus.Completed)]
    [InlineData(V1ExecuteResponseStatus.Failed)]
    public void Validation_Works(V1ExecuteResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, V1ExecuteResponseStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, V1ExecuteResponseStatus>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(V1ExecuteResponseStatus.Completed)]
    [InlineData(V1ExecuteResponseStatus.Failed)]
    public void SerializationRoundtrip_Works(V1ExecuteResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, V1ExecuteResponseStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, V1ExecuteResponseStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, V1ExecuteResponseStatus>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, V1ExecuteResponseStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
