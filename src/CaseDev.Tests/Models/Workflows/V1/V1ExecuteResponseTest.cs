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
            ExecutionArn = "executionArn",
            ExecutionID = "executionId",
            Mode = Mode.FireAndForget,
            Output = JsonSerializer.Deserialize<JsonElement>("{}"),
            Status = V1ExecuteResponseStatus.Running,
        };

        long expectedDuration = 0;
        string expectedExecutionArn = "executionArn";
        string expectedExecutionID = "executionId";
        ApiEnum<string, Mode> expectedMode = Mode.FireAndForget;
        JsonElement expectedOutput = JsonSerializer.Deserialize<JsonElement>("{}");
        ApiEnum<string, V1ExecuteResponseStatus> expectedStatus = V1ExecuteResponseStatus.Running;

        Assert.Equal(expectedDuration, model.Duration);
        Assert.Equal(expectedExecutionArn, model.ExecutionArn);
        Assert.Equal(expectedExecutionID, model.ExecutionID);
        Assert.Equal(expectedMode, model.Mode);
        Assert.NotNull(model.Output);
        Assert.True(JsonElement.DeepEquals(expectedOutput, model.Output.Value));
        Assert.Equal(expectedStatus, model.Status);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new V1ExecuteResponse
        {
            Duration = 0,
            ExecutionArn = "executionArn",
            ExecutionID = "executionId",
            Mode = Mode.FireAndForget,
            Output = JsonSerializer.Deserialize<JsonElement>("{}"),
            Status = V1ExecuteResponseStatus.Running,
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
            ExecutionArn = "executionArn",
            ExecutionID = "executionId",
            Mode = Mode.FireAndForget,
            Output = JsonSerializer.Deserialize<JsonElement>("{}"),
            Status = V1ExecuteResponseStatus.Running,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<V1ExecuteResponse>(json);
        Assert.NotNull(deserialized);

        long expectedDuration = 0;
        string expectedExecutionArn = "executionArn";
        string expectedExecutionID = "executionId";
        ApiEnum<string, Mode> expectedMode = Mode.FireAndForget;
        JsonElement expectedOutput = JsonSerializer.Deserialize<JsonElement>("{}");
        ApiEnum<string, V1ExecuteResponseStatus> expectedStatus = V1ExecuteResponseStatus.Running;

        Assert.Equal(expectedDuration, deserialized.Duration);
        Assert.Equal(expectedExecutionArn, deserialized.ExecutionArn);
        Assert.Equal(expectedExecutionID, deserialized.ExecutionID);
        Assert.Equal(expectedMode, deserialized.Mode);
        Assert.NotNull(deserialized.Output);
        Assert.True(JsonElement.DeepEquals(expectedOutput, deserialized.Output.Value));
        Assert.Equal(expectedStatus, deserialized.Status);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new V1ExecuteResponse
        {
            Duration = 0,
            ExecutionArn = "executionArn",
            ExecutionID = "executionId",
            Mode = Mode.FireAndForget,
            Output = JsonSerializer.Deserialize<JsonElement>("{}"),
            Status = V1ExecuteResponseStatus.Running,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new V1ExecuteResponse { };

        Assert.Null(model.Duration);
        Assert.False(model.RawData.ContainsKey("duration"));
        Assert.Null(model.ExecutionArn);
        Assert.False(model.RawData.ContainsKey("executionArn"));
        Assert.Null(model.ExecutionID);
        Assert.False(model.RawData.ContainsKey("executionId"));
        Assert.Null(model.Mode);
        Assert.False(model.RawData.ContainsKey("mode"));
        Assert.Null(model.Output);
        Assert.False(model.RawData.ContainsKey("output"));
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
            ExecutionArn = null,
            ExecutionID = null,
            Mode = null,
            Output = null,
            Status = null,
        };

        Assert.Null(model.Duration);
        Assert.False(model.RawData.ContainsKey("duration"));
        Assert.Null(model.ExecutionArn);
        Assert.False(model.RawData.ContainsKey("executionArn"));
        Assert.Null(model.ExecutionID);
        Assert.False(model.RawData.ContainsKey("executionId"));
        Assert.Null(model.Mode);
        Assert.False(model.RawData.ContainsKey("mode"));
        Assert.Null(model.Output);
        Assert.False(model.RawData.ContainsKey("output"));
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
            ExecutionArn = null,
            ExecutionID = null,
            Mode = null,
            Output = null,
            Status = null,
        };

        model.Validate();
    }
}

public class ModeTest : TestBase
{
    [Theory]
    [InlineData(Mode.FireAndForget)]
    [InlineData(Mode.Callback)]
    [InlineData(Mode.Sync)]
    public void Validation_Works(Mode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Mode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Mode>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Mode.FireAndForget)]
    [InlineData(Mode.Callback)]
    [InlineData(Mode.Sync)]
    public void SerializationRoundtrip_Works(Mode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Mode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Mode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Mode>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Mode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class V1ExecuteResponseStatusTest : TestBase
{
    [Theory]
    [InlineData(V1ExecuteResponseStatus.Running)]
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
    [InlineData(V1ExecuteResponseStatus.Running)]
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
