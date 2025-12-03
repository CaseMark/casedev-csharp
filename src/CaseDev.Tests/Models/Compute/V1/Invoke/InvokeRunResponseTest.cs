using System.Text.Json;
using CaseDev.Core;
using CaseDev.Models.Compute.V1.Invoke;

namespace CaseDev.Tests.Models.Compute.V1.Invoke;

public class SynchronousResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SynchronousResponse
        {
            Duration = 0,
            Error = "error",
            Output = JsonSerializer.Deserialize<JsonElement>("{}"),
            RunID = "runId",
            Status = Status.Completed,
        };

        double expectedDuration = 0;
        string expectedError = "error";
        JsonElement expectedOutput = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedRunID = "runId";
        ApiEnum<string, Status> expectedStatus = Status.Completed;

        Assert.Equal(expectedDuration, model.Duration);
        Assert.Equal(expectedError, model.Error);
        Assert.True(
            model.Output.HasValue && JsonElement.DeepEquals(expectedOutput, model.Output.Value)
        );
        Assert.Equal(expectedRunID, model.RunID);
        Assert.Equal(expectedStatus, model.Status);
    }
}

public class AsynchronousResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AsynchronousResponse
        {
            LogsURL = "logsUrl",
            RunID = "runId",
            Status = AsynchronousResponseStatus.Running,
        };

        string expectedLogsURL = "logsUrl";
        string expectedRunID = "runId";
        ApiEnum<string, AsynchronousResponseStatus> expectedStatus =
            AsynchronousResponseStatus.Running;

        Assert.Equal(expectedLogsURL, model.LogsURL);
        Assert.Equal(expectedRunID, model.RunID);
        Assert.Equal(expectedStatus, model.Status);
    }
}
