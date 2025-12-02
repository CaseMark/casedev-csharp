using CaseDev.Models.Voice.V1.Speak;

namespace CaseDev.Tests.Models.Voice.V1.Speak;

public class VoiceSettingsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VoiceSettings
        {
            SimilarityBoost = 0,
            Stability = 0,
            Style = 0,
            UseSpeakerBoost = true,
        };

        double expectedSimilarityBoost = 0;
        double expectedStability = 0;
        double expectedStyle = 0;
        bool expectedUseSpeakerBoost = true;

        Assert.Equal(expectedSimilarityBoost, model.SimilarityBoost);
        Assert.Equal(expectedStability, model.Stability);
        Assert.Equal(expectedStyle, model.Style);
        Assert.Equal(expectedUseSpeakerBoost, model.UseSpeakerBoost);
    }
}
