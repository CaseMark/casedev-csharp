using CaseDev.Models.Voice.Transcription;

namespace CaseDev.Tests.Models.Voice.Transcription;

public class TranscriptionRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TranscriptionRetrieveParams { ID = "tr_abc123def456" };

        string expectedID = "tr_abc123def456";

        Assert.Equal(expectedID, parameters.ID);
    }
}
