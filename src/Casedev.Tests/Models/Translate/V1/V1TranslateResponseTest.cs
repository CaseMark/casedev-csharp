using System.Collections.Generic;
using System.Text.Json;
using Casedev.Core;
using Casedev.Models.Translate.V1;

namespace Casedev.Tests.Models.Translate.V1;

public class V1TranslateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new V1TranslateResponse
        {
            Data = new()
            {
                Translations =
                [
                    new()
                    {
                        DetectedSourceLanguage = "detectedSourceLanguage",
                        Model = "model",
                        TranslatedText = "translatedText",
                    },
                ],
            },
        };

        V1TranslateResponseData expectedData = new()
        {
            Translations =
            [
                new()
                {
                    DetectedSourceLanguage = "detectedSourceLanguage",
                    Model = "model",
                    TranslatedText = "translatedText",
                },
            ],
        };

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new V1TranslateResponse
        {
            Data = new()
            {
                Translations =
                [
                    new()
                    {
                        DetectedSourceLanguage = "detectedSourceLanguage",
                        Model = "model",
                        TranslatedText = "translatedText",
                    },
                ],
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1TranslateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new V1TranslateResponse
        {
            Data = new()
            {
                Translations =
                [
                    new()
                    {
                        DetectedSourceLanguage = "detectedSourceLanguage",
                        Model = "model",
                        TranslatedText = "translatedText",
                    },
                ],
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1TranslateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        V1TranslateResponseData expectedData = new()
        {
            Translations =
            [
                new()
                {
                    DetectedSourceLanguage = "detectedSourceLanguage",
                    Model = "model",
                    TranslatedText = "translatedText",
                },
            ],
        };

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new V1TranslateResponse
        {
            Data = new()
            {
                Translations =
                [
                    new()
                    {
                        DetectedSourceLanguage = "detectedSourceLanguage",
                        Model = "model",
                        TranslatedText = "translatedText",
                    },
                ],
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new V1TranslateResponse { };

        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new V1TranslateResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new V1TranslateResponse
        {
            // Null should be interpreted as omitted for these properties
            Data = null,
        };

        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new V1TranslateResponse
        {
            // Null should be interpreted as omitted for these properties
            Data = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new V1TranslateResponse
        {
            Data = new()
            {
                Translations =
                [
                    new()
                    {
                        DetectedSourceLanguage = "detectedSourceLanguage",
                        Model = "model",
                        TranslatedText = "translatedText",
                    },
                ],
            },
        };

        V1TranslateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class V1TranslateResponseDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new V1TranslateResponseData
        {
            Translations =
            [
                new()
                {
                    DetectedSourceLanguage = "detectedSourceLanguage",
                    Model = "model",
                    TranslatedText = "translatedText",
                },
            ],
        };

        List<Translation> expectedTranslations =
        [
            new()
            {
                DetectedSourceLanguage = "detectedSourceLanguage",
                Model = "model",
                TranslatedText = "translatedText",
            },
        ];

        Assert.NotNull(model.Translations);
        Assert.Equal(expectedTranslations.Count, model.Translations.Count);
        for (int i = 0; i < expectedTranslations.Count; i++)
        {
            Assert.Equal(expectedTranslations[i], model.Translations[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new V1TranslateResponseData
        {
            Translations =
            [
                new()
                {
                    DetectedSourceLanguage = "detectedSourceLanguage",
                    Model = "model",
                    TranslatedText = "translatedText",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1TranslateResponseData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new V1TranslateResponseData
        {
            Translations =
            [
                new()
                {
                    DetectedSourceLanguage = "detectedSourceLanguage",
                    Model = "model",
                    TranslatedText = "translatedText",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1TranslateResponseData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Translation> expectedTranslations =
        [
            new()
            {
                DetectedSourceLanguage = "detectedSourceLanguage",
                Model = "model",
                TranslatedText = "translatedText",
            },
        ];

        Assert.NotNull(deserialized.Translations);
        Assert.Equal(expectedTranslations.Count, deserialized.Translations.Count);
        for (int i = 0; i < expectedTranslations.Count; i++)
        {
            Assert.Equal(expectedTranslations[i], deserialized.Translations[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new V1TranslateResponseData
        {
            Translations =
            [
                new()
                {
                    DetectedSourceLanguage = "detectedSourceLanguage",
                    Model = "model",
                    TranslatedText = "translatedText",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new V1TranslateResponseData { };

        Assert.Null(model.Translations);
        Assert.False(model.RawData.ContainsKey("translations"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new V1TranslateResponseData { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new V1TranslateResponseData
        {
            // Null should be interpreted as omitted for these properties
            Translations = null,
        };

        Assert.Null(model.Translations);
        Assert.False(model.RawData.ContainsKey("translations"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new V1TranslateResponseData
        {
            // Null should be interpreted as omitted for these properties
            Translations = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new V1TranslateResponseData
        {
            Translations =
            [
                new()
                {
                    DetectedSourceLanguage = "detectedSourceLanguage",
                    Model = "model",
                    TranslatedText = "translatedText",
                },
            ],
        };

        V1TranslateResponseData copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TranslationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Translation
        {
            DetectedSourceLanguage = "detectedSourceLanguage",
            Model = "model",
            TranslatedText = "translatedText",
        };

        string expectedDetectedSourceLanguage = "detectedSourceLanguage";
        string expectedModel = "model";
        string expectedTranslatedText = "translatedText";

        Assert.Equal(expectedDetectedSourceLanguage, model.DetectedSourceLanguage);
        Assert.Equal(expectedModel, model.Model);
        Assert.Equal(expectedTranslatedText, model.TranslatedText);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Translation
        {
            DetectedSourceLanguage = "detectedSourceLanguage",
            Model = "model",
            TranslatedText = "translatedText",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Translation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Translation
        {
            DetectedSourceLanguage = "detectedSourceLanguage",
            Model = "model",
            TranslatedText = "translatedText",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Translation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedDetectedSourceLanguage = "detectedSourceLanguage";
        string expectedModel = "model";
        string expectedTranslatedText = "translatedText";

        Assert.Equal(expectedDetectedSourceLanguage, deserialized.DetectedSourceLanguage);
        Assert.Equal(expectedModel, deserialized.Model);
        Assert.Equal(expectedTranslatedText, deserialized.TranslatedText);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Translation
        {
            DetectedSourceLanguage = "detectedSourceLanguage",
            Model = "model",
            TranslatedText = "translatedText",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Translation { };

        Assert.Null(model.DetectedSourceLanguage);
        Assert.False(model.RawData.ContainsKey("detectedSourceLanguage"));
        Assert.Null(model.Model);
        Assert.False(model.RawData.ContainsKey("model"));
        Assert.Null(model.TranslatedText);
        Assert.False(model.RawData.ContainsKey("translatedText"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Translation { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Translation
        {
            // Null should be interpreted as omitted for these properties
            DetectedSourceLanguage = null,
            Model = null,
            TranslatedText = null,
        };

        Assert.Null(model.DetectedSourceLanguage);
        Assert.False(model.RawData.ContainsKey("detectedSourceLanguage"));
        Assert.Null(model.Model);
        Assert.False(model.RawData.ContainsKey("model"));
        Assert.Null(model.TranslatedText);
        Assert.False(model.RawData.ContainsKey("translatedText"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Translation
        {
            // Null should be interpreted as omitted for these properties
            DetectedSourceLanguage = null,
            Model = null,
            TranslatedText = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Translation
        {
            DetectedSourceLanguage = "detectedSourceLanguage",
            Model = "model",
            TranslatedText = "translatedText",
        };

        Translation copied = new(model);

        Assert.Equal(model, copied);
    }
}
