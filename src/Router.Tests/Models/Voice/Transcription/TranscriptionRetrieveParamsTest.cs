using System;
using Router.Models.Voice.Transcription;

namespace Router.Tests.Models.Voice.Transcription;

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

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/voice/transcription/tr_abc123def456"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TranscriptionRetrieveParams { ID = "tr_abc123def456" };

        TranscriptionRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
