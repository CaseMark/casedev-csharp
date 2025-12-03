using System.Text.Json;
using CaseDev.Core;
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<VaultIngestResponse>(json);
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
