using System.Text.Json;
using Casedev.Core;
using Casedev.Exceptions;
using Casedev.Models.Vault;

namespace Casedev.Tests.Models.Vault;

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
            Status = VaultIngestResponseStatus.Processing,
            WorkflowID = "workflowId",
        };

        bool expectedEnableGraphRag = true;
        string expectedMessage = "message";
        string expectedObjectID = "objectId";
        ApiEnum<string, VaultIngestResponseStatus> expectedStatus =
            VaultIngestResponseStatus.Processing;
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
            Status = VaultIngestResponseStatus.Processing,
            WorkflowID = "workflowId",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VaultIngestResponse>(
            json,
            ModelBase.SerializerOptions
        );

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
            Status = VaultIngestResponseStatus.Processing,
            WorkflowID = "workflowId",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VaultIngestResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedEnableGraphRag = true;
        string expectedMessage = "message";
        string expectedObjectID = "objectId";
        ApiEnum<string, VaultIngestResponseStatus> expectedStatus =
            VaultIngestResponseStatus.Processing;
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
            Status = VaultIngestResponseStatus.Processing,
            WorkflowID = "workflowId",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VaultIngestResponse
        {
            EnableGraphRag = true,
            Message = "message",
            ObjectID = "objectId",
            Status = VaultIngestResponseStatus.Processing,
            WorkflowID = "workflowId",
        };

        VaultIngestResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VaultIngestResponseStatusTest : TestBase
{
    [Theory]
    [InlineData(VaultIngestResponseStatus.Processing)]
    [InlineData(VaultIngestResponseStatus.Stored)]
    public void Validation_Works(VaultIngestResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, VaultIngestResponseStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, VaultIngestResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(VaultIngestResponseStatus.Processing)]
    [InlineData(VaultIngestResponseStatus.Stored)]
    public void SerializationRoundtrip_Works(VaultIngestResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, VaultIngestResponseStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, VaultIngestResponseStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, VaultIngestResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, VaultIngestResponseStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
