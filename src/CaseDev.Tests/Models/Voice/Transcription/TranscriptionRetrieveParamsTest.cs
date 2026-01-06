using System;
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

    [Fact]
    public void Url_Works()
    {
        TranscriptionRetrieveParams parameters = new() { ID = "tr_abc123def456" };

        var url = parameters.Url(new() { APIKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/voice/transcription/tr_abc123def456"), url);
    }
}
