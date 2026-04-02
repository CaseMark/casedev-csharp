using System.Text.Json;
using Casedev.Core;
using Casedev.Exceptions;
using Casedev.Models.Agent.V2.Execute;

namespace Casedev.Tests.Models.Agent.V2.Execute;

public class ExecuteCreateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExecuteCreateResponse
        {
            AgentID = "agentId",
            Error = "error",
            Logs = new() { Linc = "linc", Runner = "runner" },
            Message = "message",
            Output = "output",
            Provider = Provider.Daytona,
            RunID = "runId",
            RuntimeID = "runtimeId",
            RuntimeState = RuntimeState.Running,
            Status = Status.Running,
            Usage = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string expectedAgentID = "agentId";
        string expectedError = "error";
        Logs expectedLogs = new() { Linc = "linc", Runner = "runner" };
        string expectedMessage = "message";
        string expectedOutput = "output";
        ApiEnum<string, Provider> expectedProvider = Provider.Daytona;
        string expectedRunID = "runId";
        string expectedRuntimeID = "runtimeId";
        ApiEnum<string, RuntimeState> expectedRuntimeState = RuntimeState.Running;
        ApiEnum<string, Status> expectedStatus = Status.Running;
        JsonElement expectedUsage = JsonSerializer.Deserialize<JsonElement>("{}");

        Assert.Equal(expectedAgentID, model.AgentID);
        Assert.Equal(expectedError, model.Error);
        Assert.Equal(expectedLogs, model.Logs);
        Assert.Equal(expectedMessage, model.Message);
        Assert.Equal(expectedOutput, model.Output);
        Assert.Equal(expectedProvider, model.Provider);
        Assert.Equal(expectedRunID, model.RunID);
        Assert.Equal(expectedRuntimeID, model.RuntimeID);
        Assert.Equal(expectedRuntimeState, model.RuntimeState);
        Assert.Equal(expectedStatus, model.Status);
        Assert.NotNull(model.Usage);
        Assert.True(JsonElement.DeepEquals(expectedUsage, model.Usage.Value));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ExecuteCreateResponse
        {
            AgentID = "agentId",
            Error = "error",
            Logs = new() { Linc = "linc", Runner = "runner" },
            Message = "message",
            Output = "output",
            Provider = Provider.Daytona,
            RunID = "runId",
            RuntimeID = "runtimeId",
            RuntimeState = RuntimeState.Running,
            Status = Status.Running,
            Usage = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExecuteCreateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExecuteCreateResponse
        {
            AgentID = "agentId",
            Error = "error",
            Logs = new() { Linc = "linc", Runner = "runner" },
            Message = "message",
            Output = "output",
            Provider = Provider.Daytona,
            RunID = "runId",
            RuntimeID = "runtimeId",
            RuntimeState = RuntimeState.Running,
            Status = Status.Running,
            Usage = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExecuteCreateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAgentID = "agentId";
        string expectedError = "error";
        Logs expectedLogs = new() { Linc = "linc", Runner = "runner" };
        string expectedMessage = "message";
        string expectedOutput = "output";
        ApiEnum<string, Provider> expectedProvider = Provider.Daytona;
        string expectedRunID = "runId";
        string expectedRuntimeID = "runtimeId";
        ApiEnum<string, RuntimeState> expectedRuntimeState = RuntimeState.Running;
        ApiEnum<string, Status> expectedStatus = Status.Running;
        JsonElement expectedUsage = JsonSerializer.Deserialize<JsonElement>("{}");

        Assert.Equal(expectedAgentID, deserialized.AgentID);
        Assert.Equal(expectedError, deserialized.Error);
        Assert.Equal(expectedLogs, deserialized.Logs);
        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.Equal(expectedOutput, deserialized.Output);
        Assert.Equal(expectedProvider, deserialized.Provider);
        Assert.Equal(expectedRunID, deserialized.RunID);
        Assert.Equal(expectedRuntimeID, deserialized.RuntimeID);
        Assert.Equal(expectedRuntimeState, deserialized.RuntimeState);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.NotNull(deserialized.Usage);
        Assert.True(JsonElement.DeepEquals(expectedUsage, deserialized.Usage.Value));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ExecuteCreateResponse
        {
            AgentID = "agentId",
            Error = "error",
            Logs = new() { Linc = "linc", Runner = "runner" },
            Message = "message",
            Output = "output",
            Provider = Provider.Daytona,
            RunID = "runId",
            RuntimeID = "runtimeId",
            RuntimeState = RuntimeState.Running,
            Status = Status.Running,
            Usage = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ExecuteCreateResponse
        {
            Error = "error",
            Logs = new() { Linc = "linc", Runner = "runner" },
            Message = "message",
            Output = "output",
            RuntimeID = "runtimeId",
            Usage = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        Assert.Null(model.AgentID);
        Assert.False(model.RawData.ContainsKey("agentId"));
        Assert.Null(model.Provider);
        Assert.False(model.RawData.ContainsKey("provider"));
        Assert.Null(model.RunID);
        Assert.False(model.RawData.ContainsKey("runId"));
        Assert.Null(model.RuntimeState);
        Assert.False(model.RawData.ContainsKey("runtimeState"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ExecuteCreateResponse
        {
            Error = "error",
            Logs = new() { Linc = "linc", Runner = "runner" },
            Message = "message",
            Output = "output",
            RuntimeID = "runtimeId",
            Usage = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ExecuteCreateResponse
        {
            Error = "error",
            Logs = new() { Linc = "linc", Runner = "runner" },
            Message = "message",
            Output = "output",
            RuntimeID = "runtimeId",
            Usage = JsonSerializer.Deserialize<JsonElement>("{}"),

            // Null should be interpreted as omitted for these properties
            AgentID = null,
            Provider = null,
            RunID = null,
            RuntimeState = null,
            Status = null,
        };

        Assert.Null(model.AgentID);
        Assert.False(model.RawData.ContainsKey("agentId"));
        Assert.Null(model.Provider);
        Assert.False(model.RawData.ContainsKey("provider"));
        Assert.Null(model.RunID);
        Assert.False(model.RawData.ContainsKey("runId"));
        Assert.Null(model.RuntimeState);
        Assert.False(model.RawData.ContainsKey("runtimeState"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ExecuteCreateResponse
        {
            Error = "error",
            Logs = new() { Linc = "linc", Runner = "runner" },
            Message = "message",
            Output = "output",
            RuntimeID = "runtimeId",
            Usage = JsonSerializer.Deserialize<JsonElement>("{}"),

            // Null should be interpreted as omitted for these properties
            AgentID = null,
            Provider = null,
            RunID = null,
            RuntimeState = null,
            Status = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ExecuteCreateResponse
        {
            AgentID = "agentId",
            Provider = Provider.Daytona,
            RunID = "runId",
            RuntimeState = RuntimeState.Running,
            Status = Status.Running,
        };

        Assert.Null(model.Error);
        Assert.False(model.RawData.ContainsKey("error"));
        Assert.Null(model.Logs);
        Assert.False(model.RawData.ContainsKey("logs"));
        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
        Assert.Null(model.Output);
        Assert.False(model.RawData.ContainsKey("output"));
        Assert.Null(model.RuntimeID);
        Assert.False(model.RawData.ContainsKey("runtimeId"));
        Assert.Null(model.Usage);
        Assert.False(model.RawData.ContainsKey("usage"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ExecuteCreateResponse
        {
            AgentID = "agentId",
            Provider = Provider.Daytona,
            RunID = "runId",
            RuntimeState = RuntimeState.Running,
            Status = Status.Running,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ExecuteCreateResponse
        {
            AgentID = "agentId",
            Provider = Provider.Daytona,
            RunID = "runId",
            RuntimeState = RuntimeState.Running,
            Status = Status.Running,

            Error = null,
            Logs = null,
            Message = null,
            Output = null,
            RuntimeID = null,
            Usage = null,
        };

        Assert.Null(model.Error);
        Assert.True(model.RawData.ContainsKey("error"));
        Assert.Null(model.Logs);
        Assert.True(model.RawData.ContainsKey("logs"));
        Assert.Null(model.Message);
        Assert.True(model.RawData.ContainsKey("message"));
        Assert.Null(model.Output);
        Assert.True(model.RawData.ContainsKey("output"));
        Assert.Null(model.RuntimeID);
        Assert.True(model.RawData.ContainsKey("runtimeId"));
        Assert.Null(model.Usage);
        Assert.True(model.RawData.ContainsKey("usage"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ExecuteCreateResponse
        {
            AgentID = "agentId",
            Provider = Provider.Daytona,
            RunID = "runId",
            RuntimeState = RuntimeState.Running,
            Status = Status.Running,

            Error = null,
            Logs = null,
            Message = null,
            Output = null,
            RuntimeID = null,
            Usage = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ExecuteCreateResponse
        {
            AgentID = "agentId",
            Error = "error",
            Logs = new() { Linc = "linc", Runner = "runner" },
            Message = "message",
            Output = "output",
            Provider = Provider.Daytona,
            RunID = "runId",
            RuntimeID = "runtimeId",
            RuntimeState = RuntimeState.Running,
            Status = Status.Running,
            Usage = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        ExecuteCreateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class LogsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Logs { Linc = "linc", Runner = "runner" };

        string expectedLinc = "linc";
        string expectedRunner = "runner";

        Assert.Equal(expectedLinc, model.Linc);
        Assert.Equal(expectedRunner, model.Runner);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Logs { Linc = "linc", Runner = "runner" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Logs>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Logs { Linc = "linc", Runner = "runner" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Logs>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedLinc = "linc";
        string expectedRunner = "runner";

        Assert.Equal(expectedLinc, deserialized.Linc);
        Assert.Equal(expectedRunner, deserialized.Runner);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Logs { Linc = "linc", Runner = "runner" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Logs { };

        Assert.Null(model.Linc);
        Assert.False(model.RawData.ContainsKey("linc"));
        Assert.Null(model.Runner);
        Assert.False(model.RawData.ContainsKey("runner"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Logs { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Logs { Linc = null, Runner = null };

        Assert.Null(model.Linc);
        Assert.True(model.RawData.ContainsKey("linc"));
        Assert.Null(model.Runner);
        Assert.True(model.RawData.ContainsKey("runner"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Logs { Linc = null, Runner = null };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Logs { Linc = "linc", Runner = "runner" };

        Logs copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ProviderTest : TestBase
{
    [Theory]
    [InlineData(Provider.Daytona)]
    [InlineData(Provider.Vercel)]
    public void Validation_Works(Provider rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Provider> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Provider>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Provider.Daytona)]
    [InlineData(Provider.Vercel)]
    public void SerializationRoundtrip_Works(Provider rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Provider> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Provider>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Provider>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Provider>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class RuntimeStateTest : TestBase
{
    [Theory]
    [InlineData(RuntimeState.Running)]
    [InlineData(RuntimeState.Ended)]
    [InlineData(RuntimeState.Error)]
    public void Validation_Works(RuntimeState rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RuntimeState> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RuntimeState>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RuntimeState.Running)]
    [InlineData(RuntimeState.Ended)]
    [InlineData(RuntimeState.Error)]
    public void SerializationRoundtrip_Works(RuntimeState rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RuntimeState> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RuntimeState>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RuntimeState>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RuntimeState>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Running)]
    [InlineData(Status.Completed)]
    [InlineData(Status.Failed)]
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
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.Running)]
    [InlineData(Status.Completed)]
    [InlineData(Status.Failed)]
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
            JsonSerializer.SerializeToElement("invalid value"),
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
