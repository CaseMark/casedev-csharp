using System.Collections.Generic;
using System.Text.Json;
using Casedev.Core;
using Casedev.Models.Voice.V1;

namespace Casedev.Tests.Models.Voice.V1;

public class V1ListVoicesResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new V1ListVoicesResponse
        {
            NextPageToken = "next_page_token",
            TotalCount = 0,
            Voices =
            [
                new()
                {
                    AvailableForTiers = ["string"],
                    Category = "category",
                    Description = "description",
                    Labels = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Name = "name",
                    PreviewUrl = "preview_url",
                    VoiceID = "voice_id",
                },
            ],
        };

        string expectedNextPageToken = "next_page_token";
        long expectedTotalCount = 0;
        List<V1ListVoicesResponseVoice> expectedVoices =
        [
            new()
            {
                AvailableForTiers = ["string"],
                Category = "category",
                Description = "description",
                Labels = JsonSerializer.Deserialize<JsonElement>("{}"),
                Name = "name",
                PreviewUrl = "preview_url",
                VoiceID = "voice_id",
            },
        ];

        Assert.Equal(expectedNextPageToken, model.NextPageToken);
        Assert.Equal(expectedTotalCount, model.TotalCount);
        Assert.NotNull(model.Voices);
        Assert.Equal(expectedVoices.Count, model.Voices.Count);
        for (int i = 0; i < expectedVoices.Count; i++)
        {
            Assert.Equal(expectedVoices[i], model.Voices[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new V1ListVoicesResponse
        {
            NextPageToken = "next_page_token",
            TotalCount = 0,
            Voices =
            [
                new()
                {
                    AvailableForTiers = ["string"],
                    Category = "category",
                    Description = "description",
                    Labels = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Name = "name",
                    PreviewUrl = "preview_url",
                    VoiceID = "voice_id",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1ListVoicesResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new V1ListVoicesResponse
        {
            NextPageToken = "next_page_token",
            TotalCount = 0,
            Voices =
            [
                new()
                {
                    AvailableForTiers = ["string"],
                    Category = "category",
                    Description = "description",
                    Labels = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Name = "name",
                    PreviewUrl = "preview_url",
                    VoiceID = "voice_id",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1ListVoicesResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedNextPageToken = "next_page_token";
        long expectedTotalCount = 0;
        List<V1ListVoicesResponseVoice> expectedVoices =
        [
            new()
            {
                AvailableForTiers = ["string"],
                Category = "category",
                Description = "description",
                Labels = JsonSerializer.Deserialize<JsonElement>("{}"),
                Name = "name",
                PreviewUrl = "preview_url",
                VoiceID = "voice_id",
            },
        ];

        Assert.Equal(expectedNextPageToken, deserialized.NextPageToken);
        Assert.Equal(expectedTotalCount, deserialized.TotalCount);
        Assert.NotNull(deserialized.Voices);
        Assert.Equal(expectedVoices.Count, deserialized.Voices.Count);
        for (int i = 0; i < expectedVoices.Count; i++)
        {
            Assert.Equal(expectedVoices[i], deserialized.Voices[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new V1ListVoicesResponse
        {
            NextPageToken = "next_page_token",
            TotalCount = 0,
            Voices =
            [
                new()
                {
                    AvailableForTiers = ["string"],
                    Category = "category",
                    Description = "description",
                    Labels = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Name = "name",
                    PreviewUrl = "preview_url",
                    VoiceID = "voice_id",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new V1ListVoicesResponse { };

        Assert.Null(model.NextPageToken);
        Assert.False(model.RawData.ContainsKey("next_page_token"));
        Assert.Null(model.TotalCount);
        Assert.False(model.RawData.ContainsKey("total_count"));
        Assert.Null(model.Voices);
        Assert.False(model.RawData.ContainsKey("voices"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new V1ListVoicesResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new V1ListVoicesResponse
        {
            // Null should be interpreted as omitted for these properties
            NextPageToken = null,
            TotalCount = null,
            Voices = null,
        };

        Assert.Null(model.NextPageToken);
        Assert.False(model.RawData.ContainsKey("next_page_token"));
        Assert.Null(model.TotalCount);
        Assert.False(model.RawData.ContainsKey("total_count"));
        Assert.Null(model.Voices);
        Assert.False(model.RawData.ContainsKey("voices"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new V1ListVoicesResponse
        {
            // Null should be interpreted as omitted for these properties
            NextPageToken = null,
            TotalCount = null,
            Voices = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new V1ListVoicesResponse
        {
            NextPageToken = "next_page_token",
            TotalCount = 0,
            Voices =
            [
                new()
                {
                    AvailableForTiers = ["string"],
                    Category = "category",
                    Description = "description",
                    Labels = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Name = "name",
                    PreviewUrl = "preview_url",
                    VoiceID = "voice_id",
                },
            ],
        };

        V1ListVoicesResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class V1ListVoicesResponseVoiceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new V1ListVoicesResponseVoice
        {
            AvailableForTiers = ["string"],
            Category = "category",
            Description = "description",
            Labels = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "name",
            PreviewUrl = "preview_url",
            VoiceID = "voice_id",
        };

        List<string> expectedAvailableForTiers = ["string"];
        string expectedCategory = "category";
        string expectedDescription = "description";
        JsonElement expectedLabels = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedName = "name";
        string expectedPreviewUrl = "preview_url";
        string expectedVoiceID = "voice_id";

        Assert.NotNull(model.AvailableForTiers);
        Assert.Equal(expectedAvailableForTiers.Count, model.AvailableForTiers.Count);
        for (int i = 0; i < expectedAvailableForTiers.Count; i++)
        {
            Assert.Equal(expectedAvailableForTiers[i], model.AvailableForTiers[i]);
        }
        Assert.Equal(expectedCategory, model.Category);
        Assert.Equal(expectedDescription, model.Description);
        Assert.NotNull(model.Labels);
        Assert.True(JsonElement.DeepEquals(expectedLabels, model.Labels.Value));
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPreviewUrl, model.PreviewUrl);
        Assert.Equal(expectedVoiceID, model.VoiceID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new V1ListVoicesResponseVoice
        {
            AvailableForTiers = ["string"],
            Category = "category",
            Description = "description",
            Labels = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "name",
            PreviewUrl = "preview_url",
            VoiceID = "voice_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1ListVoicesResponseVoice>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new V1ListVoicesResponseVoice
        {
            AvailableForTiers = ["string"],
            Category = "category",
            Description = "description",
            Labels = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "name",
            PreviewUrl = "preview_url",
            VoiceID = "voice_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1ListVoicesResponseVoice>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<string> expectedAvailableForTiers = ["string"];
        string expectedCategory = "category";
        string expectedDescription = "description";
        JsonElement expectedLabels = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedName = "name";
        string expectedPreviewUrl = "preview_url";
        string expectedVoiceID = "voice_id";

        Assert.NotNull(deserialized.AvailableForTiers);
        Assert.Equal(expectedAvailableForTiers.Count, deserialized.AvailableForTiers.Count);
        for (int i = 0; i < expectedAvailableForTiers.Count; i++)
        {
            Assert.Equal(expectedAvailableForTiers[i], deserialized.AvailableForTiers[i]);
        }
        Assert.Equal(expectedCategory, deserialized.Category);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.NotNull(deserialized.Labels);
        Assert.True(JsonElement.DeepEquals(expectedLabels, deserialized.Labels.Value));
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPreviewUrl, deserialized.PreviewUrl);
        Assert.Equal(expectedVoiceID, deserialized.VoiceID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new V1ListVoicesResponseVoice
        {
            AvailableForTiers = ["string"],
            Category = "category",
            Description = "description",
            Labels = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "name",
            PreviewUrl = "preview_url",
            VoiceID = "voice_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new V1ListVoicesResponseVoice { };

        Assert.Null(model.AvailableForTiers);
        Assert.False(model.RawData.ContainsKey("available_for_tiers"));
        Assert.Null(model.Category);
        Assert.False(model.RawData.ContainsKey("category"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Labels);
        Assert.False(model.RawData.ContainsKey("labels"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.PreviewUrl);
        Assert.False(model.RawData.ContainsKey("preview_url"));
        Assert.Null(model.VoiceID);
        Assert.False(model.RawData.ContainsKey("voice_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new V1ListVoicesResponseVoice { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new V1ListVoicesResponseVoice
        {
            // Null should be interpreted as omitted for these properties
            AvailableForTiers = null,
            Category = null,
            Description = null,
            Labels = null,
            Name = null,
            PreviewUrl = null,
            VoiceID = null,
        };

        Assert.Null(model.AvailableForTiers);
        Assert.False(model.RawData.ContainsKey("available_for_tiers"));
        Assert.Null(model.Category);
        Assert.False(model.RawData.ContainsKey("category"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Labels);
        Assert.False(model.RawData.ContainsKey("labels"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.PreviewUrl);
        Assert.False(model.RawData.ContainsKey("preview_url"));
        Assert.Null(model.VoiceID);
        Assert.False(model.RawData.ContainsKey("voice_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new V1ListVoicesResponseVoice
        {
            // Null should be interpreted as omitted for these properties
            AvailableForTiers = null,
            Category = null,
            Description = null,
            Labels = null,
            Name = null,
            PreviewUrl = null,
            VoiceID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new V1ListVoicesResponseVoice
        {
            AvailableForTiers = ["string"],
            Category = "category",
            Description = "description",
            Labels = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "name",
            PreviewUrl = "preview_url",
            VoiceID = "voice_id",
        };

        V1ListVoicesResponseVoice copied = new(model);

        Assert.Equal(model, copied);
    }
}
