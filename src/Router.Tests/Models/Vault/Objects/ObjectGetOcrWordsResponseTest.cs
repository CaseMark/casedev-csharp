using System;
using System.Collections.Generic;
using System.Text.Json;
using Router.Core;
using Router.Models.Vault.Objects;

namespace Router.Tests.Models.Vault.Objects;

public class ObjectGetOcrWordsResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ObjectGetOcrWordsResponse
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ObjectID = "objectId",
            PageCount = 0,
            Pages =
            [
                new()
                {
                    PageValue = 0,
                    Words =
                    [
                        new()
                        {
                            Bbox = [0, 0, 0, 0],
                            Confidence = 0,
                            Text = "text",
                            WordIndex = 0,
                        },
                    ],
                },
            ],
            TotalWords = 0,
        };

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedObjectID = "objectId";
        long expectedPageCount = 0;
        List<Page> expectedPages =
        [
            new()
            {
                PageValue = 0,
                Words =
                [
                    new()
                    {
                        Bbox = [0, 0, 0, 0],
                        Confidence = 0,
                        Text = "text",
                        WordIndex = 0,
                    },
                ],
            },
        ];
        long expectedTotalWords = 0;

        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedObjectID, model.ObjectID);
        Assert.Equal(expectedPageCount, model.PageCount);
        Assert.NotNull(model.Pages);
        Assert.Equal(expectedPages.Count, model.Pages.Count);
        for (int i = 0; i < expectedPages.Count; i++)
        {
            Assert.Equal(expectedPages[i], model.Pages[i]);
        }
        Assert.Equal(expectedTotalWords, model.TotalWords);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ObjectGetOcrWordsResponse
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ObjectID = "objectId",
            PageCount = 0,
            Pages =
            [
                new()
                {
                    PageValue = 0,
                    Words =
                    [
                        new()
                        {
                            Bbox = [0, 0, 0, 0],
                            Confidence = 0,
                            Text = "text",
                            WordIndex = 0,
                        },
                    ],
                },
            ],
            TotalWords = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ObjectGetOcrWordsResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ObjectGetOcrWordsResponse
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ObjectID = "objectId",
            PageCount = 0,
            Pages =
            [
                new()
                {
                    PageValue = 0,
                    Words =
                    [
                        new()
                        {
                            Bbox = [0, 0, 0, 0],
                            Confidence = 0,
                            Text = "text",
                            WordIndex = 0,
                        },
                    ],
                },
            ],
            TotalWords = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ObjectGetOcrWordsResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedObjectID = "objectId";
        long expectedPageCount = 0;
        List<Page> expectedPages =
        [
            new()
            {
                PageValue = 0,
                Words =
                [
                    new()
                    {
                        Bbox = [0, 0, 0, 0],
                        Confidence = 0,
                        Text = "text",
                        WordIndex = 0,
                    },
                ],
            },
        ];
        long expectedTotalWords = 0;

        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedObjectID, deserialized.ObjectID);
        Assert.Equal(expectedPageCount, deserialized.PageCount);
        Assert.NotNull(deserialized.Pages);
        Assert.Equal(expectedPages.Count, deserialized.Pages.Count);
        for (int i = 0; i < expectedPages.Count; i++)
        {
            Assert.Equal(expectedPages[i], deserialized.Pages[i]);
        }
        Assert.Equal(expectedTotalWords, deserialized.TotalWords);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ObjectGetOcrWordsResponse
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ObjectID = "objectId",
            PageCount = 0,
            Pages =
            [
                new()
                {
                    PageValue = 0,
                    Words =
                    [
                        new()
                        {
                            Bbox = [0, 0, 0, 0],
                            Confidence = 0,
                            Text = "text",
                            WordIndex = 0,
                        },
                    ],
                },
            ],
            TotalWords = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ObjectGetOcrWordsResponse { };

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.ObjectID);
        Assert.False(model.RawData.ContainsKey("objectId"));
        Assert.Null(model.PageCount);
        Assert.False(model.RawData.ContainsKey("pageCount"));
        Assert.Null(model.Pages);
        Assert.False(model.RawData.ContainsKey("pages"));
        Assert.Null(model.TotalWords);
        Assert.False(model.RawData.ContainsKey("totalWords"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ObjectGetOcrWordsResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ObjectGetOcrWordsResponse
        {
            // Null should be interpreted as omitted for these properties
            CreatedAt = null,
            ObjectID = null,
            PageCount = null,
            Pages = null,
            TotalWords = null,
        };

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.ObjectID);
        Assert.False(model.RawData.ContainsKey("objectId"));
        Assert.Null(model.PageCount);
        Assert.False(model.RawData.ContainsKey("pageCount"));
        Assert.Null(model.Pages);
        Assert.False(model.RawData.ContainsKey("pages"));
        Assert.Null(model.TotalWords);
        Assert.False(model.RawData.ContainsKey("totalWords"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ObjectGetOcrWordsResponse
        {
            // Null should be interpreted as omitted for these properties
            CreatedAt = null,
            ObjectID = null,
            PageCount = null,
            Pages = null,
            TotalWords = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ObjectGetOcrWordsResponse
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ObjectID = "objectId",
            PageCount = 0,
            Pages =
            [
                new()
                {
                    PageValue = 0,
                    Words =
                    [
                        new()
                        {
                            Bbox = [0, 0, 0, 0],
                            Confidence = 0,
                            Text = "text",
                            WordIndex = 0,
                        },
                    ],
                },
            ],
            TotalWords = 0,
        };

        ObjectGetOcrWordsResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Page
        {
            PageValue = 0,
            Words =
            [
                new()
                {
                    Bbox = [0, 0, 0, 0],
                    Confidence = 0,
                    Text = "text",
                    WordIndex = 0,
                },
            ],
        };

        long expectedPageValue = 0;
        List<Word> expectedWords =
        [
            new()
            {
                Bbox = [0, 0, 0, 0],
                Confidence = 0,
                Text = "text",
                WordIndex = 0,
            },
        ];

        Assert.Equal(expectedPageValue, model.PageValue);
        Assert.NotNull(model.Words);
        Assert.Equal(expectedWords.Count, model.Words.Count);
        for (int i = 0; i < expectedWords.Count; i++)
        {
            Assert.Equal(expectedWords[i], model.Words[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Page
        {
            PageValue = 0,
            Words =
            [
                new()
                {
                    Bbox = [0, 0, 0, 0],
                    Confidence = 0,
                    Text = "text",
                    WordIndex = 0,
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Page>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Page
        {
            PageValue = 0,
            Words =
            [
                new()
                {
                    Bbox = [0, 0, 0, 0],
                    Confidence = 0,
                    Text = "text",
                    WordIndex = 0,
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Page>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        long expectedPageValue = 0;
        List<Word> expectedWords =
        [
            new()
            {
                Bbox = [0, 0, 0, 0],
                Confidence = 0,
                Text = "text",
                WordIndex = 0,
            },
        ];

        Assert.Equal(expectedPageValue, deserialized.PageValue);
        Assert.NotNull(deserialized.Words);
        Assert.Equal(expectedWords.Count, deserialized.Words.Count);
        for (int i = 0; i < expectedWords.Count; i++)
        {
            Assert.Equal(expectedWords[i], deserialized.Words[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Page
        {
            PageValue = 0,
            Words =
            [
                new()
                {
                    Bbox = [0, 0, 0, 0],
                    Confidence = 0,
                    Text = "text",
                    WordIndex = 0,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Page { };

        Assert.Null(model.PageValue);
        Assert.False(model.RawData.ContainsKey("page"));
        Assert.Null(model.Words);
        Assert.False(model.RawData.ContainsKey("words"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Page { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Page
        {
            // Null should be interpreted as omitted for these properties
            PageValue = null,
            Words = null,
        };

        Assert.Null(model.PageValue);
        Assert.False(model.RawData.ContainsKey("page"));
        Assert.Null(model.Words);
        Assert.False(model.RawData.ContainsKey("words"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Page
        {
            // Null should be interpreted as omitted for these properties
            PageValue = null,
            Words = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Page
        {
            PageValue = 0,
            Words =
            [
                new()
                {
                    Bbox = [0, 0, 0, 0],
                    Confidence = 0,
                    Text = "text",
                    WordIndex = 0,
                },
            ],
        };

        Page copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WordTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Word
        {
            Bbox = [0, 0, 0, 0],
            Confidence = 0,
            Text = "text",
            WordIndex = 0,
        };

        List<double> expectedBbox = [0, 0, 0, 0];
        double expectedConfidence = 0;
        string expectedText = "text";
        long expectedWordIndex = 0;

        Assert.NotNull(model.Bbox);
        Assert.Equal(expectedBbox.Count, model.Bbox.Count);
        for (int i = 0; i < expectedBbox.Count; i++)
        {
            Assert.Equal(expectedBbox[i], model.Bbox[i]);
        }
        Assert.Equal(expectedConfidence, model.Confidence);
        Assert.Equal(expectedText, model.Text);
        Assert.Equal(expectedWordIndex, model.WordIndex);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Word
        {
            Bbox = [0, 0, 0, 0],
            Confidence = 0,
            Text = "text",
            WordIndex = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Word>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Word
        {
            Bbox = [0, 0, 0, 0],
            Confidence = 0,
            Text = "text",
            WordIndex = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Word>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        List<double> expectedBbox = [0, 0, 0, 0];
        double expectedConfidence = 0;
        string expectedText = "text";
        long expectedWordIndex = 0;

        Assert.NotNull(deserialized.Bbox);
        Assert.Equal(expectedBbox.Count, deserialized.Bbox.Count);
        for (int i = 0; i < expectedBbox.Count; i++)
        {
            Assert.Equal(expectedBbox[i], deserialized.Bbox[i]);
        }
        Assert.Equal(expectedConfidence, deserialized.Confidence);
        Assert.Equal(expectedText, deserialized.Text);
        Assert.Equal(expectedWordIndex, deserialized.WordIndex);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Word
        {
            Bbox = [0, 0, 0, 0],
            Confidence = 0,
            Text = "text",
            WordIndex = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Word { Confidence = 0 };

        Assert.Null(model.Bbox);
        Assert.False(model.RawData.ContainsKey("bbox"));
        Assert.Null(model.Text);
        Assert.False(model.RawData.ContainsKey("text"));
        Assert.Null(model.WordIndex);
        Assert.False(model.RawData.ContainsKey("wordIndex"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Word { Confidence = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Word
        {
            Confidence = 0,

            // Null should be interpreted as omitted for these properties
            Bbox = null,
            Text = null,
            WordIndex = null,
        };

        Assert.Null(model.Bbox);
        Assert.False(model.RawData.ContainsKey("bbox"));
        Assert.Null(model.Text);
        Assert.False(model.RawData.ContainsKey("text"));
        Assert.Null(model.WordIndex);
        Assert.False(model.RawData.ContainsKey("wordIndex"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Word
        {
            Confidence = 0,

            // Null should be interpreted as omitted for these properties
            Bbox = null,
            Text = null,
            WordIndex = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Word
        {
            Bbox = [0, 0, 0, 0],
            Text = "text",
            WordIndex = 0,
        };

        Assert.Null(model.Confidence);
        Assert.False(model.RawData.ContainsKey("confidence"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Word
        {
            Bbox = [0, 0, 0, 0],
            Text = "text",
            WordIndex = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Word
        {
            Bbox = [0, 0, 0, 0],
            Text = "text",
            WordIndex = 0,

            Confidence = null,
        };

        Assert.Null(model.Confidence);
        Assert.True(model.RawData.ContainsKey("confidence"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Word
        {
            Bbox = [0, 0, 0, 0],
            Text = "text",
            WordIndex = 0,

            Confidence = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Word
        {
            Bbox = [0, 0, 0, 0],
            Confidence = 0,
            Text = "text",
            WordIndex = 0,
        };

        Word copied = new(model);

        Assert.Equal(model, copied);
    }
}
