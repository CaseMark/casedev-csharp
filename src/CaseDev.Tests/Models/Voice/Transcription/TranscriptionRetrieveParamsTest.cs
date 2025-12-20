using CaseDev.Models.Voice.Transcription;

namespace CaseDev.Tests.Models.Voice.Transcription;

public class TranscriptionRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TranscriptionRetrieveParams
        {
            ID = "5551902f-fc65-4a61-81b2-e002d4e464e5",
        };

        string expectedID = "5551902f-fc65-4a61-81b2-e002d4e464e5";

        Assert.Equal(expectedID, parameters.ID);
    }
}
