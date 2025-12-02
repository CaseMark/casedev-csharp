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
}
