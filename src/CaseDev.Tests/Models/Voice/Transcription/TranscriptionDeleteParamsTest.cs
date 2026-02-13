using System;
using CaseDev.Models.Voice.Transcription;

namespace CaseDev.Tests.Models.Voice.Transcription;

public class TranscriptionDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TranscriptionDeleteParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        TranscriptionDeleteParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/voice/transcription/id"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TranscriptionDeleteParams { ID = "id" };

        TranscriptionDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
