using System.Collections.Generic;
using System.Text.Json;
using Router.Core;
using Router.Models.Legal.V1;

namespace Router.Tests.Models.Legal.V1;

public class V1GetCitationsResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new V1GetCitationsResponse
        {
            Citations =
            [
                new()
                {
                    Components = new()
                    {
                        CaseName = "caseName",
                        Court = "court",
                        Page = 0,
                        PinCite = 0,
                        Reporter = "reporter",
                        Volume = 0,
                        Year = 0,
                    },
                    Found = true,
                    Normalized = "normalized",
                    Original = "original",
                    Span = new() { End = 0, Start = 0 },
                },
            ],
        };

        List<Citation> expectedCitations =
        [
            new()
            {
                Components = new()
                {
                    CaseName = "caseName",
                    Court = "court",
                    Page = 0,
                    PinCite = 0,
                    Reporter = "reporter",
                    Volume = 0,
                    Year = 0,
                },
                Found = true,
                Normalized = "normalized",
                Original = "original",
                Span = new() { End = 0, Start = 0 },
            },
        ];

        Assert.NotNull(model.Citations);
        Assert.Equal(expectedCitations.Count, model.Citations.Count);
        for (int i = 0; i < expectedCitations.Count; i++)
        {
            Assert.Equal(expectedCitations[i], model.Citations[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new V1GetCitationsResponse
        {
            Citations =
            [
                new()
                {
                    Components = new()
                    {
                        CaseName = "caseName",
                        Court = "court",
                        Page = 0,
                        PinCite = 0,
                        Reporter = "reporter",
                        Volume = 0,
                        Year = 0,
                    },
                    Found = true,
                    Normalized = "normalized",
                    Original = "original",
                    Span = new() { End = 0, Start = 0 },
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1GetCitationsResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new V1GetCitationsResponse
        {
            Citations =
            [
                new()
                {
                    Components = new()
                    {
                        CaseName = "caseName",
                        Court = "court",
                        Page = 0,
                        PinCite = 0,
                        Reporter = "reporter",
                        Volume = 0,
                        Year = 0,
                    },
                    Found = true,
                    Normalized = "normalized",
                    Original = "original",
                    Span = new() { End = 0, Start = 0 },
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1GetCitationsResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Citation> expectedCitations =
        [
            new()
            {
                Components = new()
                {
                    CaseName = "caseName",
                    Court = "court",
                    Page = 0,
                    PinCite = 0,
                    Reporter = "reporter",
                    Volume = 0,
                    Year = 0,
                },
                Found = true,
                Normalized = "normalized",
                Original = "original",
                Span = new() { End = 0, Start = 0 },
            },
        ];

        Assert.NotNull(deserialized.Citations);
        Assert.Equal(expectedCitations.Count, deserialized.Citations.Count);
        for (int i = 0; i < expectedCitations.Count; i++)
        {
            Assert.Equal(expectedCitations[i], deserialized.Citations[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new V1GetCitationsResponse
        {
            Citations =
            [
                new()
                {
                    Components = new()
                    {
                        CaseName = "caseName",
                        Court = "court",
                        Page = 0,
                        PinCite = 0,
                        Reporter = "reporter",
                        Volume = 0,
                        Year = 0,
                    },
                    Found = true,
                    Normalized = "normalized",
                    Original = "original",
                    Span = new() { End = 0, Start = 0 },
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new V1GetCitationsResponse { };

        Assert.Null(model.Citations);
        Assert.False(model.RawData.ContainsKey("citations"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new V1GetCitationsResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new V1GetCitationsResponse
        {
            // Null should be interpreted as omitted for these properties
            Citations = null,
        };

        Assert.Null(model.Citations);
        Assert.False(model.RawData.ContainsKey("citations"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new V1GetCitationsResponse
        {
            // Null should be interpreted as omitted for these properties
            Citations = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new V1GetCitationsResponse
        {
            Citations =
            [
                new()
                {
                    Components = new()
                    {
                        CaseName = "caseName",
                        Court = "court",
                        Page = 0,
                        PinCite = 0,
                        Reporter = "reporter",
                        Volume = 0,
                        Year = 0,
                    },
                    Found = true,
                    Normalized = "normalized",
                    Original = "original",
                    Span = new() { End = 0, Start = 0 },
                },
            ],
        };

        V1GetCitationsResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CitationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Citation
        {
            Components = new()
            {
                CaseName = "caseName",
                Court = "court",
                Page = 0,
                PinCite = 0,
                Reporter = "reporter",
                Volume = 0,
                Year = 0,
            },
            Found = true,
            Normalized = "normalized",
            Original = "original",
            Span = new() { End = 0, Start = 0 },
        };

        Components expectedComponents = new()
        {
            CaseName = "caseName",
            Court = "court",
            Page = 0,
            PinCite = 0,
            Reporter = "reporter",
            Volume = 0,
            Year = 0,
        };
        bool expectedFound = true;
        string expectedNormalized = "normalized";
        string expectedOriginal = "original";
        Span expectedSpan = new() { End = 0, Start = 0 };

        Assert.Equal(expectedComponents, model.Components);
        Assert.Equal(expectedFound, model.Found);
        Assert.Equal(expectedNormalized, model.Normalized);
        Assert.Equal(expectedOriginal, model.Original);
        Assert.Equal(expectedSpan, model.Span);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Citation
        {
            Components = new()
            {
                CaseName = "caseName",
                Court = "court",
                Page = 0,
                PinCite = 0,
                Reporter = "reporter",
                Volume = 0,
                Year = 0,
            },
            Found = true,
            Normalized = "normalized",
            Original = "original",
            Span = new() { End = 0, Start = 0 },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Citation>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Citation
        {
            Components = new()
            {
                CaseName = "caseName",
                Court = "court",
                Page = 0,
                PinCite = 0,
                Reporter = "reporter",
                Volume = 0,
                Year = 0,
            },
            Found = true,
            Normalized = "normalized",
            Original = "original",
            Span = new() { End = 0, Start = 0 },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Citation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Components expectedComponents = new()
        {
            CaseName = "caseName",
            Court = "court",
            Page = 0,
            PinCite = 0,
            Reporter = "reporter",
            Volume = 0,
            Year = 0,
        };
        bool expectedFound = true;
        string expectedNormalized = "normalized";
        string expectedOriginal = "original";
        Span expectedSpan = new() { End = 0, Start = 0 };

        Assert.Equal(expectedComponents, deserialized.Components);
        Assert.Equal(expectedFound, deserialized.Found);
        Assert.Equal(expectedNormalized, deserialized.Normalized);
        Assert.Equal(expectedOriginal, deserialized.Original);
        Assert.Equal(expectedSpan, deserialized.Span);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Citation
        {
            Components = new()
            {
                CaseName = "caseName",
                Court = "court",
                Page = 0,
                PinCite = 0,
                Reporter = "reporter",
                Volume = 0,
                Year = 0,
            },
            Found = true,
            Normalized = "normalized",
            Original = "original",
            Span = new() { End = 0, Start = 0 },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Citation
        {
            Components = new()
            {
                CaseName = "caseName",
                Court = "court",
                Page = 0,
                PinCite = 0,
                Reporter = "reporter",
                Volume = 0,
                Year = 0,
            },
        };

        Assert.Null(model.Found);
        Assert.False(model.RawData.ContainsKey("found"));
        Assert.Null(model.Normalized);
        Assert.False(model.RawData.ContainsKey("normalized"));
        Assert.Null(model.Original);
        Assert.False(model.RawData.ContainsKey("original"));
        Assert.Null(model.Span);
        Assert.False(model.RawData.ContainsKey("span"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Citation
        {
            Components = new()
            {
                CaseName = "caseName",
                Court = "court",
                Page = 0,
                PinCite = 0,
                Reporter = "reporter",
                Volume = 0,
                Year = 0,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Citation
        {
            Components = new()
            {
                CaseName = "caseName",
                Court = "court",
                Page = 0,
                PinCite = 0,
                Reporter = "reporter",
                Volume = 0,
                Year = 0,
            },

            // Null should be interpreted as omitted for these properties
            Found = null,
            Normalized = null,
            Original = null,
            Span = null,
        };

        Assert.Null(model.Found);
        Assert.False(model.RawData.ContainsKey("found"));
        Assert.Null(model.Normalized);
        Assert.False(model.RawData.ContainsKey("normalized"));
        Assert.Null(model.Original);
        Assert.False(model.RawData.ContainsKey("original"));
        Assert.Null(model.Span);
        Assert.False(model.RawData.ContainsKey("span"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Citation
        {
            Components = new()
            {
                CaseName = "caseName",
                Court = "court",
                Page = 0,
                PinCite = 0,
                Reporter = "reporter",
                Volume = 0,
                Year = 0,
            },

            // Null should be interpreted as omitted for these properties
            Found = null,
            Normalized = null,
            Original = null,
            Span = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Citation
        {
            Found = true,
            Normalized = "normalized",
            Original = "original",
            Span = new() { End = 0, Start = 0 },
        };

        Assert.Null(model.Components);
        Assert.False(model.RawData.ContainsKey("components"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Citation
        {
            Found = true,
            Normalized = "normalized",
            Original = "original",
            Span = new() { End = 0, Start = 0 },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Citation
        {
            Found = true,
            Normalized = "normalized",
            Original = "original",
            Span = new() { End = 0, Start = 0 },

            Components = null,
        };

        Assert.Null(model.Components);
        Assert.True(model.RawData.ContainsKey("components"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Citation
        {
            Found = true,
            Normalized = "normalized",
            Original = "original",
            Span = new() { End = 0, Start = 0 },

            Components = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Citation
        {
            Components = new()
            {
                CaseName = "caseName",
                Court = "court",
                Page = 0,
                PinCite = 0,
                Reporter = "reporter",
                Volume = 0,
                Year = 0,
            },
            Found = true,
            Normalized = "normalized",
            Original = "original",
            Span = new() { End = 0, Start = 0 },
        };

        Citation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ComponentsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Components
        {
            CaseName = "caseName",
            Court = "court",
            Page = 0,
            PinCite = 0,
            Reporter = "reporter",
            Volume = 0,
            Year = 0,
        };

        string expectedCaseName = "caseName";
        string expectedCourt = "court";
        long expectedPage = 0;
        long expectedPinCite = 0;
        string expectedReporter = "reporter";
        long expectedVolume = 0;
        long expectedYear = 0;

        Assert.Equal(expectedCaseName, model.CaseName);
        Assert.Equal(expectedCourt, model.Court);
        Assert.Equal(expectedPage, model.Page);
        Assert.Equal(expectedPinCite, model.PinCite);
        Assert.Equal(expectedReporter, model.Reporter);
        Assert.Equal(expectedVolume, model.Volume);
        Assert.Equal(expectedYear, model.Year);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Components
        {
            CaseName = "caseName",
            Court = "court",
            Page = 0,
            PinCite = 0,
            Reporter = "reporter",
            Volume = 0,
            Year = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Components>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Components
        {
            CaseName = "caseName",
            Court = "court",
            Page = 0,
            PinCite = 0,
            Reporter = "reporter",
            Volume = 0,
            Year = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Components>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCaseName = "caseName";
        string expectedCourt = "court";
        long expectedPage = 0;
        long expectedPinCite = 0;
        string expectedReporter = "reporter";
        long expectedVolume = 0;
        long expectedYear = 0;

        Assert.Equal(expectedCaseName, deserialized.CaseName);
        Assert.Equal(expectedCourt, deserialized.Court);
        Assert.Equal(expectedPage, deserialized.Page);
        Assert.Equal(expectedPinCite, deserialized.PinCite);
        Assert.Equal(expectedReporter, deserialized.Reporter);
        Assert.Equal(expectedVolume, deserialized.Volume);
        Assert.Equal(expectedYear, deserialized.Year);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Components
        {
            CaseName = "caseName",
            Court = "court",
            Page = 0,
            PinCite = 0,
            Reporter = "reporter",
            Volume = 0,
            Year = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Components { };

        Assert.Null(model.CaseName);
        Assert.False(model.RawData.ContainsKey("caseName"));
        Assert.Null(model.Court);
        Assert.False(model.RawData.ContainsKey("court"));
        Assert.Null(model.Page);
        Assert.False(model.RawData.ContainsKey("page"));
        Assert.Null(model.PinCite);
        Assert.False(model.RawData.ContainsKey("pinCite"));
        Assert.Null(model.Reporter);
        Assert.False(model.RawData.ContainsKey("reporter"));
        Assert.Null(model.Volume);
        Assert.False(model.RawData.ContainsKey("volume"));
        Assert.Null(model.Year);
        Assert.False(model.RawData.ContainsKey("year"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Components { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Components
        {
            // Null should be interpreted as omitted for these properties
            CaseName = null,
            Court = null,
            Page = null,
            PinCite = null,
            Reporter = null,
            Volume = null,
            Year = null,
        };

        Assert.Null(model.CaseName);
        Assert.False(model.RawData.ContainsKey("caseName"));
        Assert.Null(model.Court);
        Assert.False(model.RawData.ContainsKey("court"));
        Assert.Null(model.Page);
        Assert.False(model.RawData.ContainsKey("page"));
        Assert.Null(model.PinCite);
        Assert.False(model.RawData.ContainsKey("pinCite"));
        Assert.Null(model.Reporter);
        Assert.False(model.RawData.ContainsKey("reporter"));
        Assert.Null(model.Volume);
        Assert.False(model.RawData.ContainsKey("volume"));
        Assert.Null(model.Year);
        Assert.False(model.RawData.ContainsKey("year"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Components
        {
            // Null should be interpreted as omitted for these properties
            CaseName = null,
            Court = null,
            Page = null,
            PinCite = null,
            Reporter = null,
            Volume = null,
            Year = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Components
        {
            CaseName = "caseName",
            Court = "court",
            Page = 0,
            PinCite = 0,
            Reporter = "reporter",
            Volume = 0,
            Year = 0,
        };

        Components copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SpanTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Span { End = 0, Start = 0 };

        long expectedEnd = 0;
        long expectedStart = 0;

        Assert.Equal(expectedEnd, model.End);
        Assert.Equal(expectedStart, model.Start);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Span { End = 0, Start = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Span>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Span { End = 0, Start = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Span>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        long expectedEnd = 0;
        long expectedStart = 0;

        Assert.Equal(expectedEnd, deserialized.End);
        Assert.Equal(expectedStart, deserialized.Start);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Span { End = 0, Start = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Span { };

        Assert.Null(model.End);
        Assert.False(model.RawData.ContainsKey("end"));
        Assert.Null(model.Start);
        Assert.False(model.RawData.ContainsKey("start"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Span { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Span
        {
            // Null should be interpreted as omitted for these properties
            End = null,
            Start = null,
        };

        Assert.Null(model.End);
        Assert.False(model.RawData.ContainsKey("end"));
        Assert.Null(model.Start);
        Assert.False(model.RawData.ContainsKey("start"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Span
        {
            // Null should be interpreted as omitted for these properties
            End = null,
            Start = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Span { End = 0, Start = 0 };

        Span copied = new(model);

        Assert.Equal(model, copied);
    }
}
