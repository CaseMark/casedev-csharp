using System.Collections.Generic;
using System.Text.Json;
using CaseDev.Core;
using CaseDev.Models.Translate.V1;

namespace CaseDev.Tests.Models.Translate.V1;

public class V1DetectResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new V1DetectResponse
        {
            Data = new()
            {
                Detections =
                [
                    [
                        new()
                        {
                            Confidence = 0,
                            IsReliable = true,
                            Language = "language",
                        },
                    ],
                ],
            },
        };

        Data expectedData = new()
        {
            Detections =
            [
                [
                    new()
                    {
                        Confidence = 0,
                        IsReliable = true,
                        Language = "language",
                    },
                ],
            ],
        };

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new V1DetectResponse
        {
            Data = new()
            {
                Detections =
                [
                    [
                        new()
                        {
                            Confidence = 0,
                            IsReliable = true,
                            Language = "language",
                        },
                    ],
                ],
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1DetectResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new V1DetectResponse
        {
            Data = new()
            {
                Detections =
                [
                    [
                        new()
                        {
                            Confidence = 0,
                            IsReliable = true,
                            Language = "language",
                        },
                    ],
                ],
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1DetectResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Data expectedData = new()
        {
            Detections =
            [
                [
                    new()
                    {
                        Confidence = 0,
                        IsReliable = true,
                        Language = "language",
                    },
                ],
            ],
        };

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new V1DetectResponse
        {
            Data = new()
            {
                Detections =
                [
                    [
                        new()
                        {
                            Confidence = 0,
                            IsReliable = true,
                            Language = "language",
                        },
                    ],
                ],
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new V1DetectResponse { };

        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new V1DetectResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new V1DetectResponse
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
        var model = new V1DetectResponse
        {
            // Null should be interpreted as omitted for these properties
            Data = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new V1DetectResponse
        {
            Data = new()
            {
                Detections =
                [
                    [
                        new()
                        {
                            Confidence = 0,
                            IsReliable = true,
                            Language = "language",
                        },
                    ],
                ],
            },
        };

        V1DetectResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Data
        {
            Detections =
            [
                [
                    new()
                    {
                        Confidence = 0,
                        IsReliable = true,
                        Language = "language",
                    },
                ],
            ],
        };

        List<List<UnnamedSchemaWithArrayParent0>> expectedDetections =
        [
            [
                new()
                {
                    Confidence = 0,
                    IsReliable = true,
                    Language = "language",
                },
            ],
        ];

        Assert.NotNull(model.Detections);
        Assert.Equal(expectedDetections.Count, model.Detections.Count);
        for (int i = 0; i < expectedDetections.Count; i++)
        {
            Assert.Equal(expectedDetections[i].Count, model.Detections[i].Count);
            for (int i1 = 0; i1 < expectedDetections[i].Count; i1++)
            {
                Assert.Equal(expectedDetections[i][i1], model.Detections[i][i1]);
            }
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Data
        {
            Detections =
            [
                [
                    new()
                    {
                        Confidence = 0,
                        IsReliable = true,
                        Language = "language",
                    },
                ],
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Data
        {
            Detections =
            [
                [
                    new()
                    {
                        Confidence = 0,
                        IsReliable = true,
                        Language = "language",
                    },
                ],
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        List<List<UnnamedSchemaWithArrayParent0>> expectedDetections =
        [
            [
                new()
                {
                    Confidence = 0,
                    IsReliable = true,
                    Language = "language",
                },
            ],
        ];

        Assert.NotNull(deserialized.Detections);
        Assert.Equal(expectedDetections.Count, deserialized.Detections.Count);
        for (int i = 0; i < expectedDetections.Count; i++)
        {
            Assert.Equal(expectedDetections[i].Count, deserialized.Detections[i].Count);
            for (int i1 = 0; i1 < expectedDetections[i].Count; i1++)
            {
                Assert.Equal(expectedDetections[i][i1], deserialized.Detections[i][i1]);
            }
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Data
        {
            Detections =
            [
                [
                    new()
                    {
                        Confidence = 0,
                        IsReliable = true,
                        Language = "language",
                    },
                ],
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Data { };

        Assert.Null(model.Detections);
        Assert.False(model.RawData.ContainsKey("detections"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Data { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Data
        {
            // Null should be interpreted as omitted for these properties
            Detections = null,
        };

        Assert.Null(model.Detections);
        Assert.False(model.RawData.ContainsKey("detections"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Data
        {
            // Null should be interpreted as omitted for these properties
            Detections = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Data
        {
            Detections =
            [
                [
                    new()
                    {
                        Confidence = 0,
                        IsReliable = true,
                        Language = "language",
                    },
                ],
            ],
        };

        Data copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UnnamedSchemaWithArrayParent0Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UnnamedSchemaWithArrayParent0
        {
            Confidence = 0,
            IsReliable = true,
            Language = "language",
        };

        double expectedConfidence = 0;
        bool expectedIsReliable = true;
        string expectedLanguage = "language";

        Assert.Equal(expectedConfidence, model.Confidence);
        Assert.Equal(expectedIsReliable, model.IsReliable);
        Assert.Equal(expectedLanguage, model.Language);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UnnamedSchemaWithArrayParent0
        {
            Confidence = 0,
            IsReliable = true,
            Language = "language",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UnnamedSchemaWithArrayParent0
        {
            Confidence = 0,
            IsReliable = true,
            Language = "language",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedConfidence = 0;
        bool expectedIsReliable = true;
        string expectedLanguage = "language";

        Assert.Equal(expectedConfidence, deserialized.Confidence);
        Assert.Equal(expectedIsReliable, deserialized.IsReliable);
        Assert.Equal(expectedLanguage, deserialized.Language);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UnnamedSchemaWithArrayParent0
        {
            Confidence = 0,
            IsReliable = true,
            Language = "language",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UnnamedSchemaWithArrayParent0 { };

        Assert.Null(model.Confidence);
        Assert.False(model.RawData.ContainsKey("confidence"));
        Assert.Null(model.IsReliable);
        Assert.False(model.RawData.ContainsKey("isReliable"));
        Assert.Null(model.Language);
        Assert.False(model.RawData.ContainsKey("language"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new UnnamedSchemaWithArrayParent0 { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new UnnamedSchemaWithArrayParent0
        {
            // Null should be interpreted as omitted for these properties
            Confidence = null,
            IsReliable = null,
            Language = null,
        };

        Assert.Null(model.Confidence);
        Assert.False(model.RawData.ContainsKey("confidence"));
        Assert.Null(model.IsReliable);
        Assert.False(model.RawData.ContainsKey("isReliable"));
        Assert.Null(model.Language);
        Assert.False(model.RawData.ContainsKey("language"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new UnnamedSchemaWithArrayParent0
        {
            // Null should be interpreted as omitted for these properties
            Confidence = null,
            IsReliable = null,
            Language = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UnnamedSchemaWithArrayParent0
        {
            Confidence = 0,
            IsReliable = true,
            Language = "language",
        };

        UnnamedSchemaWithArrayParent0 copied = new(model);

        Assert.Equal(model, copied);
    }
}
