using System.Collections.Generic;
using System.Text.Json;
using Router.Core;
using Router.Exceptions;
using Router.Models.Legal.V1;

namespace Router.Tests.Models.Legal.V1;

public class V1VerifyResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new V1VerifyResponse
        {
            Citations =
            [
                new()
                {
                    Candidates =
                    [
                        new()
                        {
                            Court = "court",
                            DateDecided = "dateDecided",
                            Name = "name",
                            Url = "url",
                        },
                    ],
                    Case = new()
                    {
                        ID = 0,
                        Court = "court",
                        DateDecided = "dateDecided",
                        DocketNumber = "docketNumber",
                        Name = "name",
                        ParallelCitations = ["string"],
                        ShortName = "shortName",
                        Url = "url",
                    },
                    Confidence = 0,
                    Normalized = "normalized",
                    Original = "original",
                    Span = new() { End = 0, Start = 0 },
                    Status = Status.Verified,
                    VerificationSource = VerificationSource.Courtlistener,
                },
            ],
            Summary = new()
            {
                MultipleMatches = 0,
                NotFound = 0,
                Total = 0,
                Verified = 0,
            },
        };

        List<V1VerifyResponseCitation> expectedCitations =
        [
            new()
            {
                Candidates =
                [
                    new()
                    {
                        Court = "court",
                        DateDecided = "dateDecided",
                        Name = "name",
                        Url = "url",
                    },
                ],
                Case = new()
                {
                    ID = 0,
                    Court = "court",
                    DateDecided = "dateDecided",
                    DocketNumber = "docketNumber",
                    Name = "name",
                    ParallelCitations = ["string"],
                    ShortName = "shortName",
                    Url = "url",
                },
                Confidence = 0,
                Normalized = "normalized",
                Original = "original",
                Span = new() { End = 0, Start = 0 },
                Status = Status.Verified,
                VerificationSource = VerificationSource.Courtlistener,
            },
        ];
        Summary expectedSummary = new()
        {
            MultipleMatches = 0,
            NotFound = 0,
            Total = 0,
            Verified = 0,
        };

        Assert.NotNull(model.Citations);
        Assert.Equal(expectedCitations.Count, model.Citations.Count);
        for (int i = 0; i < expectedCitations.Count; i++)
        {
            Assert.Equal(expectedCitations[i], model.Citations[i]);
        }
        Assert.Equal(expectedSummary, model.Summary);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new V1VerifyResponse
        {
            Citations =
            [
                new()
                {
                    Candidates =
                    [
                        new()
                        {
                            Court = "court",
                            DateDecided = "dateDecided",
                            Name = "name",
                            Url = "url",
                        },
                    ],
                    Case = new()
                    {
                        ID = 0,
                        Court = "court",
                        DateDecided = "dateDecided",
                        DocketNumber = "docketNumber",
                        Name = "name",
                        ParallelCitations = ["string"],
                        ShortName = "shortName",
                        Url = "url",
                    },
                    Confidence = 0,
                    Normalized = "normalized",
                    Original = "original",
                    Span = new() { End = 0, Start = 0 },
                    Status = Status.Verified,
                    VerificationSource = VerificationSource.Courtlistener,
                },
            ],
            Summary = new()
            {
                MultipleMatches = 0,
                NotFound = 0,
                Total = 0,
                Verified = 0,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1VerifyResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new V1VerifyResponse
        {
            Citations =
            [
                new()
                {
                    Candidates =
                    [
                        new()
                        {
                            Court = "court",
                            DateDecided = "dateDecided",
                            Name = "name",
                            Url = "url",
                        },
                    ],
                    Case = new()
                    {
                        ID = 0,
                        Court = "court",
                        DateDecided = "dateDecided",
                        DocketNumber = "docketNumber",
                        Name = "name",
                        ParallelCitations = ["string"],
                        ShortName = "shortName",
                        Url = "url",
                    },
                    Confidence = 0,
                    Normalized = "normalized",
                    Original = "original",
                    Span = new() { End = 0, Start = 0 },
                    Status = Status.Verified,
                    VerificationSource = VerificationSource.Courtlistener,
                },
            ],
            Summary = new()
            {
                MultipleMatches = 0,
                NotFound = 0,
                Total = 0,
                Verified = 0,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1VerifyResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<V1VerifyResponseCitation> expectedCitations =
        [
            new()
            {
                Candidates =
                [
                    new()
                    {
                        Court = "court",
                        DateDecided = "dateDecided",
                        Name = "name",
                        Url = "url",
                    },
                ],
                Case = new()
                {
                    ID = 0,
                    Court = "court",
                    DateDecided = "dateDecided",
                    DocketNumber = "docketNumber",
                    Name = "name",
                    ParallelCitations = ["string"],
                    ShortName = "shortName",
                    Url = "url",
                },
                Confidence = 0,
                Normalized = "normalized",
                Original = "original",
                Span = new() { End = 0, Start = 0 },
                Status = Status.Verified,
                VerificationSource = VerificationSource.Courtlistener,
            },
        ];
        Summary expectedSummary = new()
        {
            MultipleMatches = 0,
            NotFound = 0,
            Total = 0,
            Verified = 0,
        };

        Assert.NotNull(deserialized.Citations);
        Assert.Equal(expectedCitations.Count, deserialized.Citations.Count);
        for (int i = 0; i < expectedCitations.Count; i++)
        {
            Assert.Equal(expectedCitations[i], deserialized.Citations[i]);
        }
        Assert.Equal(expectedSummary, deserialized.Summary);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new V1VerifyResponse
        {
            Citations =
            [
                new()
                {
                    Candidates =
                    [
                        new()
                        {
                            Court = "court",
                            DateDecided = "dateDecided",
                            Name = "name",
                            Url = "url",
                        },
                    ],
                    Case = new()
                    {
                        ID = 0,
                        Court = "court",
                        DateDecided = "dateDecided",
                        DocketNumber = "docketNumber",
                        Name = "name",
                        ParallelCitations = ["string"],
                        ShortName = "shortName",
                        Url = "url",
                    },
                    Confidence = 0,
                    Normalized = "normalized",
                    Original = "original",
                    Span = new() { End = 0, Start = 0 },
                    Status = Status.Verified,
                    VerificationSource = VerificationSource.Courtlistener,
                },
            ],
            Summary = new()
            {
                MultipleMatches = 0,
                NotFound = 0,
                Total = 0,
                Verified = 0,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new V1VerifyResponse { };

        Assert.Null(model.Citations);
        Assert.False(model.RawData.ContainsKey("citations"));
        Assert.Null(model.Summary);
        Assert.False(model.RawData.ContainsKey("summary"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new V1VerifyResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new V1VerifyResponse
        {
            // Null should be interpreted as omitted for these properties
            Citations = null,
            Summary = null,
        };

        Assert.Null(model.Citations);
        Assert.False(model.RawData.ContainsKey("citations"));
        Assert.Null(model.Summary);
        Assert.False(model.RawData.ContainsKey("summary"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new V1VerifyResponse
        {
            // Null should be interpreted as omitted for these properties
            Citations = null,
            Summary = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new V1VerifyResponse
        {
            Citations =
            [
                new()
                {
                    Candidates =
                    [
                        new()
                        {
                            Court = "court",
                            DateDecided = "dateDecided",
                            Name = "name",
                            Url = "url",
                        },
                    ],
                    Case = new()
                    {
                        ID = 0,
                        Court = "court",
                        DateDecided = "dateDecided",
                        DocketNumber = "docketNumber",
                        Name = "name",
                        ParallelCitations = ["string"],
                        ShortName = "shortName",
                        Url = "url",
                    },
                    Confidence = 0,
                    Normalized = "normalized",
                    Original = "original",
                    Span = new() { End = 0, Start = 0 },
                    Status = Status.Verified,
                    VerificationSource = VerificationSource.Courtlistener,
                },
            ],
            Summary = new()
            {
                MultipleMatches = 0,
                NotFound = 0,
                Total = 0,
                Verified = 0,
            },
        };

        V1VerifyResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class V1VerifyResponseCitationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new V1VerifyResponseCitation
        {
            Candidates =
            [
                new()
                {
                    Court = "court",
                    DateDecided = "dateDecided",
                    Name = "name",
                    Url = "url",
                },
            ],
            Case = new()
            {
                ID = 0,
                Court = "court",
                DateDecided = "dateDecided",
                DocketNumber = "docketNumber",
                Name = "name",
                ParallelCitations = ["string"],
                ShortName = "shortName",
                Url = "url",
            },
            Confidence = 0,
            Normalized = "normalized",
            Original = "original",
            Span = new() { End = 0, Start = 0 },
            Status = Status.Verified,
            VerificationSource = VerificationSource.Courtlistener,
        };

        List<V1VerifyResponseCitationCandidate> expectedCandidates =
        [
            new()
            {
                Court = "court",
                DateDecided = "dateDecided",
                Name = "name",
                Url = "url",
            },
        ];
        V1VerifyResponseCitationCase expectedCase = new()
        {
            ID = 0,
            Court = "court",
            DateDecided = "dateDecided",
            DocketNumber = "docketNumber",
            Name = "name",
            ParallelCitations = ["string"],
            ShortName = "shortName",
            Url = "url",
        };
        double expectedConfidence = 0;
        string expectedNormalized = "normalized";
        string expectedOriginal = "original";
        V1VerifyResponseCitationSpan expectedSpan = new() { End = 0, Start = 0 };
        ApiEnum<string, Status> expectedStatus = Status.Verified;
        ApiEnum<string, VerificationSource> expectedVerificationSource =
            VerificationSource.Courtlistener;

        Assert.NotNull(model.Candidates);
        Assert.Equal(expectedCandidates.Count, model.Candidates.Count);
        for (int i = 0; i < expectedCandidates.Count; i++)
        {
            Assert.Equal(expectedCandidates[i], model.Candidates[i]);
        }
        Assert.Equal(expectedCase, model.Case);
        Assert.Equal(expectedConfidence, model.Confidence);
        Assert.Equal(expectedNormalized, model.Normalized);
        Assert.Equal(expectedOriginal, model.Original);
        Assert.Equal(expectedSpan, model.Span);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedVerificationSource, model.VerificationSource);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new V1VerifyResponseCitation
        {
            Candidates =
            [
                new()
                {
                    Court = "court",
                    DateDecided = "dateDecided",
                    Name = "name",
                    Url = "url",
                },
            ],
            Case = new()
            {
                ID = 0,
                Court = "court",
                DateDecided = "dateDecided",
                DocketNumber = "docketNumber",
                Name = "name",
                ParallelCitations = ["string"],
                ShortName = "shortName",
                Url = "url",
            },
            Confidence = 0,
            Normalized = "normalized",
            Original = "original",
            Span = new() { End = 0, Start = 0 },
            Status = Status.Verified,
            VerificationSource = VerificationSource.Courtlistener,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1VerifyResponseCitation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new V1VerifyResponseCitation
        {
            Candidates =
            [
                new()
                {
                    Court = "court",
                    DateDecided = "dateDecided",
                    Name = "name",
                    Url = "url",
                },
            ],
            Case = new()
            {
                ID = 0,
                Court = "court",
                DateDecided = "dateDecided",
                DocketNumber = "docketNumber",
                Name = "name",
                ParallelCitations = ["string"],
                ShortName = "shortName",
                Url = "url",
            },
            Confidence = 0,
            Normalized = "normalized",
            Original = "original",
            Span = new() { End = 0, Start = 0 },
            Status = Status.Verified,
            VerificationSource = VerificationSource.Courtlistener,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1VerifyResponseCitation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<V1VerifyResponseCitationCandidate> expectedCandidates =
        [
            new()
            {
                Court = "court",
                DateDecided = "dateDecided",
                Name = "name",
                Url = "url",
            },
        ];
        V1VerifyResponseCitationCase expectedCase = new()
        {
            ID = 0,
            Court = "court",
            DateDecided = "dateDecided",
            DocketNumber = "docketNumber",
            Name = "name",
            ParallelCitations = ["string"],
            ShortName = "shortName",
            Url = "url",
        };
        double expectedConfidence = 0;
        string expectedNormalized = "normalized";
        string expectedOriginal = "original";
        V1VerifyResponseCitationSpan expectedSpan = new() { End = 0, Start = 0 };
        ApiEnum<string, Status> expectedStatus = Status.Verified;
        ApiEnum<string, VerificationSource> expectedVerificationSource =
            VerificationSource.Courtlistener;

        Assert.NotNull(deserialized.Candidates);
        Assert.Equal(expectedCandidates.Count, deserialized.Candidates.Count);
        for (int i = 0; i < expectedCandidates.Count; i++)
        {
            Assert.Equal(expectedCandidates[i], deserialized.Candidates[i]);
        }
        Assert.Equal(expectedCase, deserialized.Case);
        Assert.Equal(expectedConfidence, deserialized.Confidence);
        Assert.Equal(expectedNormalized, deserialized.Normalized);
        Assert.Equal(expectedOriginal, deserialized.Original);
        Assert.Equal(expectedSpan, deserialized.Span);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedVerificationSource, deserialized.VerificationSource);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new V1VerifyResponseCitation
        {
            Candidates =
            [
                new()
                {
                    Court = "court",
                    DateDecided = "dateDecided",
                    Name = "name",
                    Url = "url",
                },
            ],
            Case = new()
            {
                ID = 0,
                Court = "court",
                DateDecided = "dateDecided",
                DocketNumber = "docketNumber",
                Name = "name",
                ParallelCitations = ["string"],
                ShortName = "shortName",
                Url = "url",
            },
            Confidence = 0,
            Normalized = "normalized",
            Original = "original",
            Span = new() { End = 0, Start = 0 },
            Status = Status.Verified,
            VerificationSource = VerificationSource.Courtlistener,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new V1VerifyResponseCitation { };

        Assert.Null(model.Candidates);
        Assert.False(model.RawData.ContainsKey("candidates"));
        Assert.Null(model.Case);
        Assert.False(model.RawData.ContainsKey("case"));
        Assert.Null(model.Confidence);
        Assert.False(model.RawData.ContainsKey("confidence"));
        Assert.Null(model.Normalized);
        Assert.False(model.RawData.ContainsKey("normalized"));
        Assert.Null(model.Original);
        Assert.False(model.RawData.ContainsKey("original"));
        Assert.Null(model.Span);
        Assert.False(model.RawData.ContainsKey("span"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.VerificationSource);
        Assert.False(model.RawData.ContainsKey("verificationSource"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new V1VerifyResponseCitation { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new V1VerifyResponseCitation
        {
            // Null should be interpreted as omitted for these properties
            Candidates = null,
            Case = null,
            Confidence = null,
            Normalized = null,
            Original = null,
            Span = null,
            Status = null,
            VerificationSource = null,
        };

        Assert.Null(model.Candidates);
        Assert.False(model.RawData.ContainsKey("candidates"));
        Assert.Null(model.Case);
        Assert.False(model.RawData.ContainsKey("case"));
        Assert.Null(model.Confidence);
        Assert.False(model.RawData.ContainsKey("confidence"));
        Assert.Null(model.Normalized);
        Assert.False(model.RawData.ContainsKey("normalized"));
        Assert.Null(model.Original);
        Assert.False(model.RawData.ContainsKey("original"));
        Assert.Null(model.Span);
        Assert.False(model.RawData.ContainsKey("span"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.VerificationSource);
        Assert.False(model.RawData.ContainsKey("verificationSource"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new V1VerifyResponseCitation
        {
            // Null should be interpreted as omitted for these properties
            Candidates = null,
            Case = null,
            Confidence = null,
            Normalized = null,
            Original = null,
            Span = null,
            Status = null,
            VerificationSource = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new V1VerifyResponseCitation
        {
            Candidates =
            [
                new()
                {
                    Court = "court",
                    DateDecided = "dateDecided",
                    Name = "name",
                    Url = "url",
                },
            ],
            Case = new()
            {
                ID = 0,
                Court = "court",
                DateDecided = "dateDecided",
                DocketNumber = "docketNumber",
                Name = "name",
                ParallelCitations = ["string"],
                ShortName = "shortName",
                Url = "url",
            },
            Confidence = 0,
            Normalized = "normalized",
            Original = "original",
            Span = new() { End = 0, Start = 0 },
            Status = Status.Verified,
            VerificationSource = VerificationSource.Courtlistener,
        };

        V1VerifyResponseCitation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class V1VerifyResponseCitationCandidateTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new V1VerifyResponseCitationCandidate
        {
            Court = "court",
            DateDecided = "dateDecided",
            Name = "name",
            Url = "url",
        };

        string expectedCourt = "court";
        string expectedDateDecided = "dateDecided";
        string expectedName = "name";
        string expectedUrl = "url";

        Assert.Equal(expectedCourt, model.Court);
        Assert.Equal(expectedDateDecided, model.DateDecided);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new V1VerifyResponseCitationCandidate
        {
            Court = "court",
            DateDecided = "dateDecided",
            Name = "name",
            Url = "url",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1VerifyResponseCitationCandidate>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new V1VerifyResponseCitationCandidate
        {
            Court = "court",
            DateDecided = "dateDecided",
            Name = "name",
            Url = "url",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1VerifyResponseCitationCandidate>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCourt = "court";
        string expectedDateDecided = "dateDecided";
        string expectedName = "name";
        string expectedUrl = "url";

        Assert.Equal(expectedCourt, deserialized.Court);
        Assert.Equal(expectedDateDecided, deserialized.DateDecided);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new V1VerifyResponseCitationCandidate
        {
            Court = "court",
            DateDecided = "dateDecided",
            Name = "name",
            Url = "url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new V1VerifyResponseCitationCandidate { };

        Assert.Null(model.Court);
        Assert.False(model.RawData.ContainsKey("court"));
        Assert.Null(model.DateDecided);
        Assert.False(model.RawData.ContainsKey("dateDecided"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new V1VerifyResponseCitationCandidate { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new V1VerifyResponseCitationCandidate
        {
            // Null should be interpreted as omitted for these properties
            Court = null,
            DateDecided = null,
            Name = null,
            Url = null,
        };

        Assert.Null(model.Court);
        Assert.False(model.RawData.ContainsKey("court"));
        Assert.Null(model.DateDecided);
        Assert.False(model.RawData.ContainsKey("dateDecided"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new V1VerifyResponseCitationCandidate
        {
            // Null should be interpreted as omitted for these properties
            Court = null,
            DateDecided = null,
            Name = null,
            Url = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new V1VerifyResponseCitationCandidate
        {
            Court = "court",
            DateDecided = "dateDecided",
            Name = "name",
            Url = "url",
        };

        V1VerifyResponseCitationCandidate copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class V1VerifyResponseCitationCaseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new V1VerifyResponseCitationCase
        {
            ID = 0,
            Court = "court",
            DateDecided = "dateDecided",
            DocketNumber = "docketNumber",
            Name = "name",
            ParallelCitations = ["string"],
            ShortName = "shortName",
            Url = "url",
        };

        long expectedID = 0;
        string expectedCourt = "court";
        string expectedDateDecided = "dateDecided";
        string expectedDocketNumber = "docketNumber";
        string expectedName = "name";
        List<string> expectedParallelCitations = ["string"];
        string expectedShortName = "shortName";
        string expectedUrl = "url";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCourt, model.Court);
        Assert.Equal(expectedDateDecided, model.DateDecided);
        Assert.Equal(expectedDocketNumber, model.DocketNumber);
        Assert.Equal(expectedName, model.Name);
        Assert.NotNull(model.ParallelCitations);
        Assert.Equal(expectedParallelCitations.Count, model.ParallelCitations.Count);
        for (int i = 0; i < expectedParallelCitations.Count; i++)
        {
            Assert.Equal(expectedParallelCitations[i], model.ParallelCitations[i]);
        }
        Assert.Equal(expectedShortName, model.ShortName);
        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new V1VerifyResponseCitationCase
        {
            ID = 0,
            Court = "court",
            DateDecided = "dateDecided",
            DocketNumber = "docketNumber",
            Name = "name",
            ParallelCitations = ["string"],
            ShortName = "shortName",
            Url = "url",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1VerifyResponseCitationCase>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new V1VerifyResponseCitationCase
        {
            ID = 0,
            Court = "court",
            DateDecided = "dateDecided",
            DocketNumber = "docketNumber",
            Name = "name",
            ParallelCitations = ["string"],
            ShortName = "shortName",
            Url = "url",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1VerifyResponseCitationCase>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedID = 0;
        string expectedCourt = "court";
        string expectedDateDecided = "dateDecided";
        string expectedDocketNumber = "docketNumber";
        string expectedName = "name";
        List<string> expectedParallelCitations = ["string"];
        string expectedShortName = "shortName";
        string expectedUrl = "url";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCourt, deserialized.Court);
        Assert.Equal(expectedDateDecided, deserialized.DateDecided);
        Assert.Equal(expectedDocketNumber, deserialized.DocketNumber);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.NotNull(deserialized.ParallelCitations);
        Assert.Equal(expectedParallelCitations.Count, deserialized.ParallelCitations.Count);
        for (int i = 0; i < expectedParallelCitations.Count; i++)
        {
            Assert.Equal(expectedParallelCitations[i], deserialized.ParallelCitations[i]);
        }
        Assert.Equal(expectedShortName, deserialized.ShortName);
        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new V1VerifyResponseCitationCase
        {
            ID = 0,
            Court = "court",
            DateDecided = "dateDecided",
            DocketNumber = "docketNumber",
            Name = "name",
            ParallelCitations = ["string"],
            ShortName = "shortName",
            Url = "url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new V1VerifyResponseCitationCase { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Court);
        Assert.False(model.RawData.ContainsKey("court"));
        Assert.Null(model.DateDecided);
        Assert.False(model.RawData.ContainsKey("dateDecided"));
        Assert.Null(model.DocketNumber);
        Assert.False(model.RawData.ContainsKey("docketNumber"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.ParallelCitations);
        Assert.False(model.RawData.ContainsKey("parallelCitations"));
        Assert.Null(model.ShortName);
        Assert.False(model.RawData.ContainsKey("shortName"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new V1VerifyResponseCitationCase { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new V1VerifyResponseCitationCase
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            Court = null,
            DateDecided = null,
            DocketNumber = null,
            Name = null,
            ParallelCitations = null,
            ShortName = null,
            Url = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Court);
        Assert.False(model.RawData.ContainsKey("court"));
        Assert.Null(model.DateDecided);
        Assert.False(model.RawData.ContainsKey("dateDecided"));
        Assert.Null(model.DocketNumber);
        Assert.False(model.RawData.ContainsKey("docketNumber"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.ParallelCitations);
        Assert.False(model.RawData.ContainsKey("parallelCitations"));
        Assert.Null(model.ShortName);
        Assert.False(model.RawData.ContainsKey("shortName"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new V1VerifyResponseCitationCase
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            Court = null,
            DateDecided = null,
            DocketNumber = null,
            Name = null,
            ParallelCitations = null,
            ShortName = null,
            Url = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new V1VerifyResponseCitationCase
        {
            ID = 0,
            Court = "court",
            DateDecided = "dateDecided",
            DocketNumber = "docketNumber",
            Name = "name",
            ParallelCitations = ["string"],
            ShortName = "shortName",
            Url = "url",
        };

        V1VerifyResponseCitationCase copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class V1VerifyResponseCitationSpanTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new V1VerifyResponseCitationSpan { End = 0, Start = 0 };

        long expectedEnd = 0;
        long expectedStart = 0;

        Assert.Equal(expectedEnd, model.End);
        Assert.Equal(expectedStart, model.Start);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new V1VerifyResponseCitationSpan { End = 0, Start = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1VerifyResponseCitationSpan>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new V1VerifyResponseCitationSpan { End = 0, Start = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1VerifyResponseCitationSpan>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedEnd = 0;
        long expectedStart = 0;

        Assert.Equal(expectedEnd, deserialized.End);
        Assert.Equal(expectedStart, deserialized.Start);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new V1VerifyResponseCitationSpan { End = 0, Start = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new V1VerifyResponseCitationSpan { };

        Assert.Null(model.End);
        Assert.False(model.RawData.ContainsKey("end"));
        Assert.Null(model.Start);
        Assert.False(model.RawData.ContainsKey("start"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new V1VerifyResponseCitationSpan { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new V1VerifyResponseCitationSpan
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
        var model = new V1VerifyResponseCitationSpan
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
        var model = new V1VerifyResponseCitationSpan { End = 0, Start = 0 };

        V1VerifyResponseCitationSpan copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Verified)]
    [InlineData(Status.NotFound)]
    [InlineData(Status.MultipleMatches)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.Verified)]
    [InlineData(Status.NotFound)]
    [InlineData(Status.MultipleMatches)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class VerificationSourceTest : TestBase
{
    [Theory]
    [InlineData(VerificationSource.Courtlistener)]
    [InlineData(VerificationSource.Heuristic)]
    public void Validation_Works(VerificationSource rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, VerificationSource> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, VerificationSource>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(VerificationSource.Courtlistener)]
    [InlineData(VerificationSource.Heuristic)]
    public void SerializationRoundtrip_Works(VerificationSource rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, VerificationSource> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, VerificationSource>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, VerificationSource>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, VerificationSource>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SummaryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Summary
        {
            MultipleMatches = 0,
            NotFound = 0,
            Total = 0,
            Verified = 0,
        };

        long expectedMultipleMatches = 0;
        long expectedNotFound = 0;
        long expectedTotal = 0;
        long expectedVerified = 0;

        Assert.Equal(expectedMultipleMatches, model.MultipleMatches);
        Assert.Equal(expectedNotFound, model.NotFound);
        Assert.Equal(expectedTotal, model.Total);
        Assert.Equal(expectedVerified, model.Verified);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Summary
        {
            MultipleMatches = 0,
            NotFound = 0,
            Total = 0,
            Verified = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Summary>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Summary
        {
            MultipleMatches = 0,
            NotFound = 0,
            Total = 0,
            Verified = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Summary>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedMultipleMatches = 0;
        long expectedNotFound = 0;
        long expectedTotal = 0;
        long expectedVerified = 0;

        Assert.Equal(expectedMultipleMatches, deserialized.MultipleMatches);
        Assert.Equal(expectedNotFound, deserialized.NotFound);
        Assert.Equal(expectedTotal, deserialized.Total);
        Assert.Equal(expectedVerified, deserialized.Verified);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Summary
        {
            MultipleMatches = 0,
            NotFound = 0,
            Total = 0,
            Verified = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Summary { };

        Assert.Null(model.MultipleMatches);
        Assert.False(model.RawData.ContainsKey("multipleMatches"));
        Assert.Null(model.NotFound);
        Assert.False(model.RawData.ContainsKey("notFound"));
        Assert.Null(model.Total);
        Assert.False(model.RawData.ContainsKey("total"));
        Assert.Null(model.Verified);
        Assert.False(model.RawData.ContainsKey("verified"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Summary { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Summary
        {
            // Null should be interpreted as omitted for these properties
            MultipleMatches = null,
            NotFound = null,
            Total = null,
            Verified = null,
        };

        Assert.Null(model.MultipleMatches);
        Assert.False(model.RawData.ContainsKey("multipleMatches"));
        Assert.Null(model.NotFound);
        Assert.False(model.RawData.ContainsKey("notFound"));
        Assert.Null(model.Total);
        Assert.False(model.RawData.ContainsKey("total"));
        Assert.Null(model.Verified);
        Assert.False(model.RawData.ContainsKey("verified"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Summary
        {
            // Null should be interpreted as omitted for these properties
            MultipleMatches = null,
            NotFound = null,
            Total = null,
            Verified = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Summary
        {
            MultipleMatches = 0,
            NotFound = 0,
            Total = 0,
            Verified = 0,
        };

        Summary copied = new(model);

        Assert.Equal(model, copied);
    }
}
