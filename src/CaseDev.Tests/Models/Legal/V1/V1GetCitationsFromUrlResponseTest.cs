using System.Collections.Generic;
using System.Text.Json;
using CaseDev.Core;
using CaseDev.Models.Legal.V1;

namespace CaseDev.Tests.Models.Legal.V1;

public class V1GetCitationsFromUrlResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new V1GetCitationsFromUrlResponse
        {
            Citations = new()
            {
                Cases =
                [
                    new()
                    {
                        Citation = "citation",
                        Count = 0,
                        Type = "type",
                    },
                ],
                Regulations =
                [
                    new()
                    {
                        Citation = "citation",
                        Count = 0,
                        Type = "type",
                    },
                ],
                Statutes =
                [
                    new()
                    {
                        Citation = "citation",
                        Count = 0,
                        Type = "type",
                    },
                ],
            },
            ExternalLinks = ["string"],
            Hint = "hint",
            Title = "title",
            TotalCitations = 0,
            Url = "url",
        };

        Citations expectedCitations = new()
        {
            Cases =
            [
                new()
                {
                    Citation = "citation",
                    Count = 0,
                    Type = "type",
                },
            ],
            Regulations =
            [
                new()
                {
                    Citation = "citation",
                    Count = 0,
                    Type = "type",
                },
            ],
            Statutes =
            [
                new()
                {
                    Citation = "citation",
                    Count = 0,
                    Type = "type",
                },
            ],
        };
        List<string> expectedExternalLinks = ["string"];
        string expectedHint = "hint";
        string expectedTitle = "title";
        long expectedTotalCitations = 0;
        string expectedUrl = "url";

        Assert.Equal(expectedCitations, model.Citations);
        Assert.NotNull(model.ExternalLinks);
        Assert.Equal(expectedExternalLinks.Count, model.ExternalLinks.Count);
        for (int i = 0; i < expectedExternalLinks.Count; i++)
        {
            Assert.Equal(expectedExternalLinks[i], model.ExternalLinks[i]);
        }
        Assert.Equal(expectedHint, model.Hint);
        Assert.Equal(expectedTitle, model.Title);
        Assert.Equal(expectedTotalCitations, model.TotalCitations);
        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new V1GetCitationsFromUrlResponse
        {
            Citations = new()
            {
                Cases =
                [
                    new()
                    {
                        Citation = "citation",
                        Count = 0,
                        Type = "type",
                    },
                ],
                Regulations =
                [
                    new()
                    {
                        Citation = "citation",
                        Count = 0,
                        Type = "type",
                    },
                ],
                Statutes =
                [
                    new()
                    {
                        Citation = "citation",
                        Count = 0,
                        Type = "type",
                    },
                ],
            },
            ExternalLinks = ["string"],
            Hint = "hint",
            Title = "title",
            TotalCitations = 0,
            Url = "url",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1GetCitationsFromUrlResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new V1GetCitationsFromUrlResponse
        {
            Citations = new()
            {
                Cases =
                [
                    new()
                    {
                        Citation = "citation",
                        Count = 0,
                        Type = "type",
                    },
                ],
                Regulations =
                [
                    new()
                    {
                        Citation = "citation",
                        Count = 0,
                        Type = "type",
                    },
                ],
                Statutes =
                [
                    new()
                    {
                        Citation = "citation",
                        Count = 0,
                        Type = "type",
                    },
                ],
            },
            ExternalLinks = ["string"],
            Hint = "hint",
            Title = "title",
            TotalCitations = 0,
            Url = "url",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1GetCitationsFromUrlResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Citations expectedCitations = new()
        {
            Cases =
            [
                new()
                {
                    Citation = "citation",
                    Count = 0,
                    Type = "type",
                },
            ],
            Regulations =
            [
                new()
                {
                    Citation = "citation",
                    Count = 0,
                    Type = "type",
                },
            ],
            Statutes =
            [
                new()
                {
                    Citation = "citation",
                    Count = 0,
                    Type = "type",
                },
            ],
        };
        List<string> expectedExternalLinks = ["string"];
        string expectedHint = "hint";
        string expectedTitle = "title";
        long expectedTotalCitations = 0;
        string expectedUrl = "url";

        Assert.Equal(expectedCitations, deserialized.Citations);
        Assert.NotNull(deserialized.ExternalLinks);
        Assert.Equal(expectedExternalLinks.Count, deserialized.ExternalLinks.Count);
        for (int i = 0; i < expectedExternalLinks.Count; i++)
        {
            Assert.Equal(expectedExternalLinks[i], deserialized.ExternalLinks[i]);
        }
        Assert.Equal(expectedHint, deserialized.Hint);
        Assert.Equal(expectedTitle, deserialized.Title);
        Assert.Equal(expectedTotalCitations, deserialized.TotalCitations);
        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new V1GetCitationsFromUrlResponse
        {
            Citations = new()
            {
                Cases =
                [
                    new()
                    {
                        Citation = "citation",
                        Count = 0,
                        Type = "type",
                    },
                ],
                Regulations =
                [
                    new()
                    {
                        Citation = "citation",
                        Count = 0,
                        Type = "type",
                    },
                ],
                Statutes =
                [
                    new()
                    {
                        Citation = "citation",
                        Count = 0,
                        Type = "type",
                    },
                ],
            },
            ExternalLinks = ["string"],
            Hint = "hint",
            Title = "title",
            TotalCitations = 0,
            Url = "url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new V1GetCitationsFromUrlResponse { };

        Assert.Null(model.Citations);
        Assert.False(model.RawData.ContainsKey("citations"));
        Assert.Null(model.ExternalLinks);
        Assert.False(model.RawData.ContainsKey("externalLinks"));
        Assert.Null(model.Hint);
        Assert.False(model.RawData.ContainsKey("hint"));
        Assert.Null(model.Title);
        Assert.False(model.RawData.ContainsKey("title"));
        Assert.Null(model.TotalCitations);
        Assert.False(model.RawData.ContainsKey("totalCitations"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new V1GetCitationsFromUrlResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new V1GetCitationsFromUrlResponse
        {
            // Null should be interpreted as omitted for these properties
            Citations = null,
            ExternalLinks = null,
            Hint = null,
            Title = null,
            TotalCitations = null,
            Url = null,
        };

        Assert.Null(model.Citations);
        Assert.False(model.RawData.ContainsKey("citations"));
        Assert.Null(model.ExternalLinks);
        Assert.False(model.RawData.ContainsKey("externalLinks"));
        Assert.Null(model.Hint);
        Assert.False(model.RawData.ContainsKey("hint"));
        Assert.Null(model.Title);
        Assert.False(model.RawData.ContainsKey("title"));
        Assert.Null(model.TotalCitations);
        Assert.False(model.RawData.ContainsKey("totalCitations"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new V1GetCitationsFromUrlResponse
        {
            // Null should be interpreted as omitted for these properties
            Citations = null,
            ExternalLinks = null,
            Hint = null,
            Title = null,
            TotalCitations = null,
            Url = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new V1GetCitationsFromUrlResponse
        {
            Citations = new()
            {
                Cases =
                [
                    new()
                    {
                        Citation = "citation",
                        Count = 0,
                        Type = "type",
                    },
                ],
                Regulations =
                [
                    new()
                    {
                        Citation = "citation",
                        Count = 0,
                        Type = "type",
                    },
                ],
                Statutes =
                [
                    new()
                    {
                        Citation = "citation",
                        Count = 0,
                        Type = "type",
                    },
                ],
            },
            ExternalLinks = ["string"],
            Hint = "hint",
            Title = "title",
            TotalCitations = 0,
            Url = "url",
        };

        V1GetCitationsFromUrlResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CitationsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Citations
        {
            Cases =
            [
                new()
                {
                    Citation = "citation",
                    Count = 0,
                    Type = "type",
                },
            ],
            Regulations =
            [
                new()
                {
                    Citation = "citation",
                    Count = 0,
                    Type = "type",
                },
            ],
            Statutes =
            [
                new()
                {
                    Citation = "citation",
                    Count = 0,
                    Type = "type",
                },
            ],
        };

        List<Case> expectedCases =
        [
            new()
            {
                Citation = "citation",
                Count = 0,
                Type = "type",
            },
        ];
        List<Regulation> expectedRegulations =
        [
            new()
            {
                Citation = "citation",
                Count = 0,
                Type = "type",
            },
        ];
        List<Statute> expectedStatutes =
        [
            new()
            {
                Citation = "citation",
                Count = 0,
                Type = "type",
            },
        ];

        Assert.NotNull(model.Cases);
        Assert.Equal(expectedCases.Count, model.Cases.Count);
        for (int i = 0; i < expectedCases.Count; i++)
        {
            Assert.Equal(expectedCases[i], model.Cases[i]);
        }
        Assert.NotNull(model.Regulations);
        Assert.Equal(expectedRegulations.Count, model.Regulations.Count);
        for (int i = 0; i < expectedRegulations.Count; i++)
        {
            Assert.Equal(expectedRegulations[i], model.Regulations[i]);
        }
        Assert.NotNull(model.Statutes);
        Assert.Equal(expectedStatutes.Count, model.Statutes.Count);
        for (int i = 0; i < expectedStatutes.Count; i++)
        {
            Assert.Equal(expectedStatutes[i], model.Statutes[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Citations
        {
            Cases =
            [
                new()
                {
                    Citation = "citation",
                    Count = 0,
                    Type = "type",
                },
            ],
            Regulations =
            [
                new()
                {
                    Citation = "citation",
                    Count = 0,
                    Type = "type",
                },
            ],
            Statutes =
            [
                new()
                {
                    Citation = "citation",
                    Count = 0,
                    Type = "type",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Citations>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Citations
        {
            Cases =
            [
                new()
                {
                    Citation = "citation",
                    Count = 0,
                    Type = "type",
                },
            ],
            Regulations =
            [
                new()
                {
                    Citation = "citation",
                    Count = 0,
                    Type = "type",
                },
            ],
            Statutes =
            [
                new()
                {
                    Citation = "citation",
                    Count = 0,
                    Type = "type",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Citations>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Case> expectedCases =
        [
            new()
            {
                Citation = "citation",
                Count = 0,
                Type = "type",
            },
        ];
        List<Regulation> expectedRegulations =
        [
            new()
            {
                Citation = "citation",
                Count = 0,
                Type = "type",
            },
        ];
        List<Statute> expectedStatutes =
        [
            new()
            {
                Citation = "citation",
                Count = 0,
                Type = "type",
            },
        ];

        Assert.NotNull(deserialized.Cases);
        Assert.Equal(expectedCases.Count, deserialized.Cases.Count);
        for (int i = 0; i < expectedCases.Count; i++)
        {
            Assert.Equal(expectedCases[i], deserialized.Cases[i]);
        }
        Assert.NotNull(deserialized.Regulations);
        Assert.Equal(expectedRegulations.Count, deserialized.Regulations.Count);
        for (int i = 0; i < expectedRegulations.Count; i++)
        {
            Assert.Equal(expectedRegulations[i], deserialized.Regulations[i]);
        }
        Assert.NotNull(deserialized.Statutes);
        Assert.Equal(expectedStatutes.Count, deserialized.Statutes.Count);
        for (int i = 0; i < expectedStatutes.Count; i++)
        {
            Assert.Equal(expectedStatutes[i], deserialized.Statutes[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Citations
        {
            Cases =
            [
                new()
                {
                    Citation = "citation",
                    Count = 0,
                    Type = "type",
                },
            ],
            Regulations =
            [
                new()
                {
                    Citation = "citation",
                    Count = 0,
                    Type = "type",
                },
            ],
            Statutes =
            [
                new()
                {
                    Citation = "citation",
                    Count = 0,
                    Type = "type",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Citations { };

        Assert.Null(model.Cases);
        Assert.False(model.RawData.ContainsKey("cases"));
        Assert.Null(model.Regulations);
        Assert.False(model.RawData.ContainsKey("regulations"));
        Assert.Null(model.Statutes);
        Assert.False(model.RawData.ContainsKey("statutes"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Citations { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Citations
        {
            // Null should be interpreted as omitted for these properties
            Cases = null,
            Regulations = null,
            Statutes = null,
        };

        Assert.Null(model.Cases);
        Assert.False(model.RawData.ContainsKey("cases"));
        Assert.Null(model.Regulations);
        Assert.False(model.RawData.ContainsKey("regulations"));
        Assert.Null(model.Statutes);
        Assert.False(model.RawData.ContainsKey("statutes"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Citations
        {
            // Null should be interpreted as omitted for these properties
            Cases = null,
            Regulations = null,
            Statutes = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Citations
        {
            Cases =
            [
                new()
                {
                    Citation = "citation",
                    Count = 0,
                    Type = "type",
                },
            ],
            Regulations =
            [
                new()
                {
                    Citation = "citation",
                    Count = 0,
                    Type = "type",
                },
            ],
            Statutes =
            [
                new()
                {
                    Citation = "citation",
                    Count = 0,
                    Type = "type",
                },
            ],
        };

        Citations copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CaseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Case
        {
            Citation = "citation",
            Count = 0,
            Type = "type",
        };

        string expectedCitation = "citation";
        long expectedCount = 0;
        string expectedType = "type";

        Assert.Equal(expectedCitation, model.Citation);
        Assert.Equal(expectedCount, model.Count);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Case
        {
            Citation = "citation",
            Count = 0,
            Type = "type",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Case>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Case
        {
            Citation = "citation",
            Count = 0,
            Type = "type",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Case>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedCitation = "citation";
        long expectedCount = 0;
        string expectedType = "type";

        Assert.Equal(expectedCitation, deserialized.Citation);
        Assert.Equal(expectedCount, deserialized.Count);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Case
        {
            Citation = "citation",
            Count = 0,
            Type = "type",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Case { };

        Assert.Null(model.Citation);
        Assert.False(model.RawData.ContainsKey("citation"));
        Assert.Null(model.Count);
        Assert.False(model.RawData.ContainsKey("count"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Case { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Case
        {
            // Null should be interpreted as omitted for these properties
            Citation = null,
            Count = null,
            Type = null,
        };

        Assert.Null(model.Citation);
        Assert.False(model.RawData.ContainsKey("citation"));
        Assert.Null(model.Count);
        Assert.False(model.RawData.ContainsKey("count"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Case
        {
            // Null should be interpreted as omitted for these properties
            Citation = null,
            Count = null,
            Type = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Case
        {
            Citation = "citation",
            Count = 0,
            Type = "type",
        };

        Case copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RegulationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Regulation
        {
            Citation = "citation",
            Count = 0,
            Type = "type",
        };

        string expectedCitation = "citation";
        long expectedCount = 0;
        string expectedType = "type";

        Assert.Equal(expectedCitation, model.Citation);
        Assert.Equal(expectedCount, model.Count);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Regulation
        {
            Citation = "citation",
            Count = 0,
            Type = "type",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Regulation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Regulation
        {
            Citation = "citation",
            Count = 0,
            Type = "type",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Regulation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCitation = "citation";
        long expectedCount = 0;
        string expectedType = "type";

        Assert.Equal(expectedCitation, deserialized.Citation);
        Assert.Equal(expectedCount, deserialized.Count);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Regulation
        {
            Citation = "citation",
            Count = 0,
            Type = "type",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Regulation { };

        Assert.Null(model.Citation);
        Assert.False(model.RawData.ContainsKey("citation"));
        Assert.Null(model.Count);
        Assert.False(model.RawData.ContainsKey("count"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Regulation { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Regulation
        {
            // Null should be interpreted as omitted for these properties
            Citation = null,
            Count = null,
            Type = null,
        };

        Assert.Null(model.Citation);
        Assert.False(model.RawData.ContainsKey("citation"));
        Assert.Null(model.Count);
        Assert.False(model.RawData.ContainsKey("count"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Regulation
        {
            // Null should be interpreted as omitted for these properties
            Citation = null,
            Count = null,
            Type = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Regulation
        {
            Citation = "citation",
            Count = 0,
            Type = "type",
        };

        Regulation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StatuteTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Statute
        {
            Citation = "citation",
            Count = 0,
            Type = "type",
        };

        string expectedCitation = "citation";
        long expectedCount = 0;
        string expectedType = "type";

        Assert.Equal(expectedCitation, model.Citation);
        Assert.Equal(expectedCount, model.Count);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Statute
        {
            Citation = "citation",
            Count = 0,
            Type = "type",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Statute>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Statute
        {
            Citation = "citation",
            Count = 0,
            Type = "type",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Statute>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCitation = "citation";
        long expectedCount = 0;
        string expectedType = "type";

        Assert.Equal(expectedCitation, deserialized.Citation);
        Assert.Equal(expectedCount, deserialized.Count);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Statute
        {
            Citation = "citation",
            Count = 0,
            Type = "type",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Statute { };

        Assert.Null(model.Citation);
        Assert.False(model.RawData.ContainsKey("citation"));
        Assert.Null(model.Count);
        Assert.False(model.RawData.ContainsKey("count"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Statute { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Statute
        {
            // Null should be interpreted as omitted for these properties
            Citation = null,
            Count = null,
            Type = null,
        };

        Assert.Null(model.Citation);
        Assert.False(model.RawData.ContainsKey("citation"));
        Assert.Null(model.Count);
        Assert.False(model.RawData.ContainsKey("count"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Statute
        {
            // Null should be interpreted as omitted for these properties
            Citation = null,
            Count = null,
            Type = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Statute
        {
            Citation = "citation",
            Count = 0,
            Type = "type",
        };

        Statute copied = new(model);

        Assert.Equal(model, copied);
    }
}
