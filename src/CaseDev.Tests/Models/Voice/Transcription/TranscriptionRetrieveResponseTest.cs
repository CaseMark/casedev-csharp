using System.Collections.Generic;
using CaseDev.Core;
using CaseDev.Models.Voice.Transcription;

namespace CaseDev.Tests.Models.Voice.Transcription;

public class TranscriptionRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TranscriptionRetrieveResponse
        {
            ID = "id",
            Status = Status.Queued,
            AudioDuration = 0,
            Confidence = 0,
            Error = "error",
            Text = "text",
            Words =
            [
                new()
                {
                    Confidence = 0,
                    End = 0,
                    Start = 0,
                    Text = "text",
                },
            ],
        };

        string expectedID = "id";
        ApiEnum<string, Status> expectedStatus = Status.Queued;
        double expectedAudioDuration = 0;
        double expectedConfidence = 0;
        string expectedError = "error";
        string expectedText = "text";
        List<Word> expectedWords =
        [
            new()
            {
                Confidence = 0,
                End = 0,
                Start = 0,
                Text = "text",
            },
        ];

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedAudioDuration, model.AudioDuration);
        Assert.Equal(expectedConfidence, model.Confidence);
        Assert.Equal(expectedError, model.Error);
        Assert.Equal(expectedText, model.Text);
        Assert.Equal(expectedWords.Count, model.Words.Count);
        for (int i = 0; i < expectedWords.Count; i++)
        {
            Assert.Equal(expectedWords[i], model.Words[i]);
        }
    }
}

public class WordTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Word
        {
            Confidence = 0,
            End = 0,
            Start = 0,
            Text = "text",
        };

        double expectedConfidence = 0;
        double expectedEnd = 0;
        double expectedStart = 0;
        string expectedText = "text";

        Assert.Equal(expectedConfidence, model.Confidence);
        Assert.Equal(expectedEnd, model.End);
        Assert.Equal(expectedStart, model.Start);
        Assert.Equal(expectedText, model.Text);
    }
}
