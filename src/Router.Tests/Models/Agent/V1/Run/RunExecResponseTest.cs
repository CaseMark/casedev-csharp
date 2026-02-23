using System.Text.Json;
using Router.Core;
using Router.Exceptions;
using Router.Models.Agent.V1.Run;

namespace Router.Tests.Models.Agent.V1.Run;

public class RunExecResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RunExecResponse
        {
            ID = "id",
            Message = "message",
            Status = RunExecResponseStatus.Running,
            WorkflowID = "workflowId",
        };

        string expectedID = "id";
        string expectedMessage = "message";
        ApiEnum<string, RunExecResponseStatus> expectedStatus = RunExecResponseStatus.Running;
        string expectedWorkflowID = "workflowId";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedMessage, model.Message);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedWorkflowID, model.WorkflowID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RunExecResponse
        {
            ID = "id",
            Message = "message",
            Status = RunExecResponseStatus.Running,
            WorkflowID = "workflowId",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RunExecResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RunExecResponse
        {
            ID = "id",
            Message = "message",
            Status = RunExecResponseStatus.Running,
            WorkflowID = "workflowId",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RunExecResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedMessage = "message";
        ApiEnum<string, RunExecResponseStatus> expectedStatus = RunExecResponseStatus.Running;
        string expectedWorkflowID = "workflowId";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedWorkflowID, deserialized.WorkflowID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RunExecResponse
        {
            ID = "id",
            Message = "message",
            Status = RunExecResponseStatus.Running,
            WorkflowID = "workflowId",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new RunExecResponse { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.WorkflowID);
        Assert.False(model.RawData.ContainsKey("workflowId"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new RunExecResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new RunExecResponse
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            Message = null,
            Status = null,
            WorkflowID = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.WorkflowID);
        Assert.False(model.RawData.ContainsKey("workflowId"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new RunExecResponse
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            Message = null,
            Status = null,
            WorkflowID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RunExecResponse
        {
            ID = "id",
            Message = "message",
            Status = RunExecResponseStatus.Running,
            WorkflowID = "workflowId",
        };

        RunExecResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RunExecResponseStatusTest : TestBase
{
    [Theory]
    [InlineData(RunExecResponseStatus.Running)]
    public void Validation_Works(RunExecResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RunExecResponseStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RunExecResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RunExecResponseStatus.Running)]
    public void SerializationRoundtrip_Works(RunExecResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RunExecResponseStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RunExecResponseStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RunExecResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RunExecResponseStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
