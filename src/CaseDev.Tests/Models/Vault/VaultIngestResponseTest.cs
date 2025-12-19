using System.Text.Json;
using CaseDev.Core;
using CaseDev.Exceptions;
using CaseDev.Models.Vault;

namespace CaseDev.Tests.Models.Vault;

public class VaultIngestResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VaultIngestResponse
        {
            EnableGraphRag = true,
            Message = "message",
            ObjectID = "objectId",
            Status = Status.Processing,
            WorkflowID = "workflowId",
        };

        bool expectedEnableGraphRag = true;
        string expectedMessage = "message";
        string expectedObjectID = "objectId";
        ApiEnum<string, Status> expectedStatus = Status.Processing;
        string expectedWorkflowID = "workflowId";

        Assert.Equal(expectedEnableGraphRag, model.EnableGraphRag);
        Assert.Equal(expectedMessage, model.Message);
        Assert.Equal(expectedObjectID, model.ObjectID);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedWorkflowID, model.WorkflowID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VaultIngestResponse
        {
            EnableGraphRag = true,
            Message = "message",
            ObjectID = "objectId",
            Status = Status.Processing,
            WorkflowID = "workflowId",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<VaultIngestResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VaultIngestResponse
        {
            EnableGraphRag = true,
            Message = "message",
            ObjectID = "objectId",
            Status = Status.Processing,
            WorkflowID = "workflowId",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<VaultIngestResponse>(element);
        Assert.NotNull(deserialized);

        bool expectedEnableGraphRag = true;
        string expectedMessage = "message";
        string expectedObjectID = "objectId";
        ApiEnum<string, Status> expectedStatus = Status.Processing;
        string expectedWorkflowID = "workflowId";

        Assert.Equal(expectedEnableGraphRag, deserialized.EnableGraphRag);
        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.Equal(expectedObjectID, deserialized.ObjectID);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedWorkflowID, deserialized.WorkflowID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VaultIngestResponse
        {
            EnableGraphRag = true,
            Message = "message",
            ObjectID = "objectId",
            Status = Status.Processing,
            WorkflowID = "workflowId",
        };

        model.Validate();
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Processing)]
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

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.Processing)]
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
