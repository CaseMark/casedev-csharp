using System.Text.Json;
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

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VoiceSettings
        {
            SimilarityBoost = 0,
            Stability = 0,
            Style = 0,
            UseSpeakerBoost = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<VoiceSettings>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VoiceSettings
        {
            SimilarityBoost = 0,
            Stability = 0,
            Style = 0,
            UseSpeakerBoost = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<VoiceSettings>(json);
        Assert.NotNull(deserialized);

        double expectedSimilarityBoost = 0;
        double expectedStability = 0;
        double expectedStyle = 0;
        bool expectedUseSpeakerBoost = true;

        Assert.Equal(expectedSimilarityBoost, deserialized.SimilarityBoost);
        Assert.Equal(expectedStability, deserialized.Stability);
        Assert.Equal(expectedStyle, deserialized.Style);
        Assert.Equal(expectedUseSpeakerBoost, deserialized.UseSpeakerBoost);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VoiceSettings
        {
            SimilarityBoost = 0,
            Stability = 0,
            Style = 0,
            UseSpeakerBoost = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VoiceSettings { };

        Assert.Null(model.SimilarityBoost);
        Assert.False(model.RawData.ContainsKey("similarity_boost"));
        Assert.Null(model.Stability);
        Assert.False(model.RawData.ContainsKey("stability"));
        Assert.Null(model.Style);
        Assert.False(model.RawData.ContainsKey("style"));
        Assert.Null(model.UseSpeakerBoost);
        Assert.False(model.RawData.ContainsKey("use_speaker_boost"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new VoiceSettings { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new VoiceSettings
        {
            // Null should be interpreted as omitted for these properties
            SimilarityBoost = null,
            Stability = null,
            Style = null,
            UseSpeakerBoost = null,
        };

        Assert.Null(model.SimilarityBoost);
        Assert.False(model.RawData.ContainsKey("similarity_boost"));
        Assert.Null(model.Stability);
        Assert.False(model.RawData.ContainsKey("stability"));
        Assert.Null(model.Style);
        Assert.False(model.RawData.ContainsKey("style"));
        Assert.Null(model.UseSpeakerBoost);
        Assert.False(model.RawData.ContainsKey("use_speaker_boost"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VoiceSettings
        {
            // Null should be interpreted as omitted for these properties
            SimilarityBoost = null,
            Stability = null,
            Style = null,
            UseSpeakerBoost = null,
        };

        model.Validate();
    }
}
