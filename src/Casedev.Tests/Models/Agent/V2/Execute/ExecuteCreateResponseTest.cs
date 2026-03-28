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
            Message = "message",
            Provider = Provider.Daytona,
            RunID = "runId",
            RuntimeState = RuntimeState.Running,
            Status = Status.Running,
        };

        string expectedAgentID = "agentId";
        string expectedMessage = "message";
        ApiEnum<string, Provider> expectedProvider = Provider.Daytona;
        string expectedRunID = "runId";
        ApiEnum<string, RuntimeState> expectedRuntimeState = RuntimeState.Running;
        ApiEnum<string, Status> expectedStatus = Status.Running;

        Assert.Equal(expectedAgentID, model.AgentID);
        Assert.Equal(expectedMessage, model.Message);
        Assert.Equal(expectedProvider, model.Provider);
        Assert.Equal(expectedRunID, model.RunID);
        Assert.Equal(expectedRuntimeState, model.RuntimeState);
        Assert.Equal(expectedStatus, model.Status);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ExecuteCreateResponse
        {
            AgentID = "agentId",
            Message = "message",
            Provider = Provider.Daytona,
            RunID = "runId",
            RuntimeState = RuntimeState.Running,
            Status = Status.Running,
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
            Message = "message",
            Provider = Provider.Daytona,
            RunID = "runId",
            RuntimeState = RuntimeState.Running,
            Status = Status.Running,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExecuteCreateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAgentID = "agentId";
        string expectedMessage = "message";
        ApiEnum<string, Provider> expectedProvider = Provider.Daytona;
        string expectedRunID = "runId";
        ApiEnum<string, RuntimeState> expectedRuntimeState = RuntimeState.Running;
        ApiEnum<string, Status> expectedStatus = Status.Running;

        Assert.Equal(expectedAgentID, deserialized.AgentID);
        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.Equal(expectedProvider, deserialized.Provider);
        Assert.Equal(expectedRunID, deserialized.RunID);
        Assert.Equal(expectedRuntimeState, deserialized.RuntimeState);
        Assert.Equal(expectedStatus, deserialized.Status);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ExecuteCreateResponse
        {
            AgentID = "agentId",
            Message = "message",
            Provider = Provider.Daytona,
            RunID = "runId",
            RuntimeState = RuntimeState.Running,
            Status = Status.Running,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ExecuteCreateResponse { };

        Assert.Null(model.AgentID);
        Assert.False(model.RawData.ContainsKey("agentId"));
        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
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
        var model = new ExecuteCreateResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ExecuteCreateResponse
        {
            // Null should be interpreted as omitted for these properties
            AgentID = null,
            Message = null,
            Provider = null,
            RunID = null,
            RuntimeState = null,
            Status = null,
        };

        Assert.Null(model.AgentID);
        Assert.False(model.RawData.ContainsKey("agentId"));
        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
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
            // Null should be interpreted as omitted for these properties
            AgentID = null,
            Message = null,
            Provider = null,
            RunID = null,
            RuntimeState = null,
            Status = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ExecuteCreateResponse
        {
            AgentID = "agentId",
            Message = "message",
            Provider = Provider.Daytona,
            RunID = "runId",
            RuntimeState = RuntimeState.Running,
            Status = Status.Running,
        };

        ExecuteCreateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ProviderTest : TestBase
{
    [Theory]
    [InlineData(Provider.Daytona)]
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
