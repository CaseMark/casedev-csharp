using System.Text.Json;
using CaseDev.Core;
using CaseDev.Models.Workflows.V1;

namespace CaseDev.Tests.Models.Workflows.V1;

public class V1ExecuteResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new V1ExecuteResponse
        {
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
            Status = Status.Completed,
            Usage = new()
            {
                CompletionTokens = 0,
                Cost = 0,
                PromptTokens = 0,
                TotalTokens = 0,
            },
            WorkflowName = "workflow_name",
        };

        JsonElement expectedResult = JsonSerializer.Deserialize<JsonElement>("{}");
        ApiEnum<string, Status> expectedStatus = Status.Completed;
        Usage expectedUsage = new()
        {
            CompletionTokens = 0,
            Cost = 0,
            PromptTokens = 0,
            TotalTokens = 0,
        };
        string expectedWorkflowName = "workflow_name";

        Assert.True(JsonElement.DeepEquals(expectedResult, model.Result));
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedUsage, model.Usage);
        Assert.Equal(expectedWorkflowName, model.WorkflowName);
    }
}

public class UsageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Usage
        {
            CompletionTokens = 0,
            Cost = 0,
            PromptTokens = 0,
            TotalTokens = 0,
        };

        long expectedCompletionTokens = 0;
        double expectedCost = 0;
        long expectedPromptTokens = 0;
        long expectedTotalTokens = 0;

        Assert.Equal(expectedCompletionTokens, model.CompletionTokens);
        Assert.Equal(expectedCost, model.Cost);
        Assert.Equal(expectedPromptTokens, model.PromptTokens);
        Assert.Equal(expectedTotalTokens, model.TotalTokens);
    }
}
