using System.Collections.Generic;
using System.Text.Json;
using CaseDev.Core;
using CaseDev.Models.Actions.V1;

namespace CaseDev.Tests.Models.Actions.V1;

public class V1ExecuteResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new V1ExecuteResponse
        {
            DurationMs = 0,
            ExecutionID = "execution_id",
            Message = "message",
            Output = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Status = Status.Completed,
            StepResults =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            WebhookConfigured = true,
        };

        double expectedDurationMs = 0;
        string expectedExecutionID = "execution_id";
        string expectedMessage = "message";
        Dictionary<string, JsonElement> expectedOutput = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        ApiEnum<string, Status> expectedStatus = Status.Completed;
        List<Dictionary<string, JsonElement>> expectedStepResults =
        [
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        ];
        bool expectedWebhookConfigured = true;

        Assert.Equal(expectedDurationMs, model.DurationMs);
        Assert.Equal(expectedExecutionID, model.ExecutionID);
        Assert.Equal(expectedMessage, model.Message);
        Assert.Equal(expectedOutput.Count, model.Output.Count);
        foreach (var item in expectedOutput)
        {
            Assert.True(model.Output.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Output[item.Key]));
        }
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedStepResults.Count, model.StepResults.Count);
        for (int i = 0; i < expectedStepResults.Count; i++)
        {
            Assert.Equal(expectedStepResults[i].Count, model.StepResults[i].Count);
            foreach (var item in expectedStepResults[i])
            {
                Assert.True(model.StepResults[i].TryGetValue(item.Key, out var value));

                Assert.True(JsonElement.DeepEquals(value, model.StepResults[i][item.Key]));
            }
        }
        Assert.Equal(expectedWebhookConfigured, model.WebhookConfigured);
    }
}
