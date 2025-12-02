using CaseDev.Core;
using CaseDev.Models.Convert.V1;

namespace CaseDev.Tests.Models.Convert.V1;

public class V1ProcessResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new V1ProcessResponse
        {
            JobID = "job_id",
            Message = "message",
            Status = V1ProcessResponseStatus.Queued,
        };

        string expectedJobID = "job_id";
        string expectedMessage = "message";
        ApiEnum<string, V1ProcessResponseStatus> expectedStatus = V1ProcessResponseStatus.Queued;

        Assert.Equal(expectedJobID, model.JobID);
        Assert.Equal(expectedMessage, model.Message);
        Assert.Equal(expectedStatus, model.Status);
    }
}
