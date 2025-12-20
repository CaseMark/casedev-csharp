using CaseDev.Models.Voice.Transcription;

namespace CaseDev.Tests.Models.Voice.Transcription;

public class TranscriptionCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TranscriptionCreateParams
        {
            AudioURL = "audio_url",
            AutoHighlights = true,
            ContentSafetyLabels = true,
            FormatText = true,
            LanguageCode = "language_code",
            LanguageDetection = true,
            Punctuate = true,
            SpeakerLabels = true,
        };

        string expectedAudioURL = "audio_url";
        bool expectedAutoHighlights = true;
        bool expectedContentSafetyLabels = true;
        bool expectedFormatText = true;
        string expectedLanguageCode = "language_code";
        bool expectedLanguageDetection = true;
        bool expectedPunctuate = true;
        bool expectedSpeakerLabels = true;

        Assert.Equal(expectedAudioURL, parameters.AudioURL);
        Assert.Equal(expectedAutoHighlights, parameters.AutoHighlights);
        Assert.Equal(expectedContentSafetyLabels, parameters.ContentSafetyLabels);
        Assert.Equal(expectedFormatText, parameters.FormatText);
        Assert.Equal(expectedLanguageCode, parameters.LanguageCode);
        Assert.Equal(expectedLanguageDetection, parameters.LanguageDetection);
        Assert.Equal(expectedPunctuate, parameters.Punctuate);
        Assert.Equal(expectedSpeakerLabels, parameters.SpeakerLabels);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TranscriptionCreateParams { AudioURL = "audio_url" };

        Assert.Null(parameters.AutoHighlights);
        Assert.False(parameters.RawBodyData.ContainsKey("auto_highlights"));
        Assert.Null(parameters.ContentSafetyLabels);
        Assert.False(parameters.RawBodyData.ContainsKey("content_safety_labels"));
        Assert.Null(parameters.FormatText);
        Assert.False(parameters.RawBodyData.ContainsKey("format_text"));
        Assert.Null(parameters.LanguageCode);
        Assert.False(parameters.RawBodyData.ContainsKey("language_code"));
        Assert.Null(parameters.LanguageDetection);
        Assert.False(parameters.RawBodyData.ContainsKey("language_detection"));
        Assert.Null(parameters.Punctuate);
        Assert.False(parameters.RawBodyData.ContainsKey("punctuate"));
        Assert.Null(parameters.SpeakerLabels);
        Assert.False(parameters.RawBodyData.ContainsKey("speaker_labels"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new TranscriptionCreateParams
        {
            AudioURL = "audio_url",

            // Null should be interpreted as omitted for these properties
            AutoHighlights = null,
            ContentSafetyLabels = null,
            FormatText = null,
            LanguageCode = null,
            LanguageDetection = null,
            Punctuate = null,
            SpeakerLabels = null,
        };

        Assert.Null(parameters.AutoHighlights);
        Assert.False(parameters.RawBodyData.ContainsKey("auto_highlights"));
        Assert.Null(parameters.ContentSafetyLabels);
        Assert.False(parameters.RawBodyData.ContainsKey("content_safety_labels"));
        Assert.Null(parameters.FormatText);
        Assert.False(parameters.RawBodyData.ContainsKey("format_text"));
        Assert.Null(parameters.LanguageCode);
        Assert.False(parameters.RawBodyData.ContainsKey("language_code"));
        Assert.Null(parameters.LanguageDetection);
        Assert.False(parameters.RawBodyData.ContainsKey("language_detection"));
        Assert.Null(parameters.Punctuate);
        Assert.False(parameters.RawBodyData.ContainsKey("punctuate"));
        Assert.Null(parameters.SpeakerLabels);
        Assert.False(parameters.RawBodyData.ContainsKey("speaker_labels"));
    }
}
