using System.Collections.Generic;
using System.Text.Json;
using Casedev.Core;
using Casedev.Models.Legal.V1;

namespace Casedev.Tests.Models.Legal.V1;

public class V1FindResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new V1FindResponse
        {
            Candidates =
            [
                new()
                {
                    Snippet = "snippet",
                    Source = "source",
                    Title = "title",
                    Url = "url",
                },
            ],
            Found = 0,
            Hint = "hint",
            Jurisdiction = "jurisdiction",
            Query = "query",
        };

        List<Candidate> expectedCandidates =
        [
            new()
            {
                Snippet = "snippet",
                Source = "source",
                Title = "title",
                Url = "url",
            },
        ];
        long expectedFound = 0;
        string expectedHint = "hint";
        string expectedJurisdiction = "jurisdiction";
        string expectedQuery = "query";

        Assert.NotNull(model.Candidates);
        Assert.Equal(expectedCandidates.Count, model.Candidates.Count);
        for (int i = 0; i < expectedCandidates.Count; i++)
        {
            Assert.Equal(expectedCandidates[i], model.Candidates[i]);
        }
        Assert.Equal(expectedFound, model.Found);
        Assert.Equal(expectedHint, model.Hint);
        Assert.Equal(expectedJurisdiction, model.Jurisdiction);
        Assert.Equal(expectedQuery, model.Query);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new V1FindResponse
        {
            Candidates =
            [
                new()
                {
                    Snippet = "snippet",
                    Source = "source",
                    Title = "title",
                    Url = "url",
                },
            ],
            Found = 0,
            Hint = "hint",
            Jurisdiction = "jurisdiction",
            Query = "query",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1FindResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new V1FindResponse
        {
            Candidates =
            [
                new()
                {
                    Snippet = "snippet",
                    Source = "source",
                    Title = "title",
                    Url = "url",
                },
            ],
            Found = 0,
            Hint = "hint",
            Jurisdiction = "jurisdiction",
            Query = "query",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1FindResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Candidate> expectedCandidates =
        [
            new()
            {
                Snippet = "snippet",
                Source = "source",
                Title = "title",
                Url = "url",
            },
        ];
        long expectedFound = 0;
        string expectedHint = "hint";
        string expectedJurisdiction = "jurisdiction";
        string expectedQuery = "query";

        Assert.NotNull(deserialized.Candidates);
        Assert.Equal(expectedCandidates.Count, deserialized.Candidates.Count);
        for (int i = 0; i < expectedCandidates.Count; i++)
        {
            Assert.Equal(expectedCandidates[i], deserialized.Candidates[i]);
        }
        Assert.Equal(expectedFound, deserialized.Found);
        Assert.Equal(expectedHint, deserialized.Hint);
        Assert.Equal(expectedJurisdiction, deserialized.Jurisdiction);
        Assert.Equal(expectedQuery, deserialized.Query);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new V1FindResponse
        {
            Candidates =
            [
                new()
                {
                    Snippet = "snippet",
                    Source = "source",
                    Title = "title",
                    Url = "url",
                },
            ],
            Found = 0,
            Hint = "hint",
            Jurisdiction = "jurisdiction",
            Query = "query",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new V1FindResponse { };

        Assert.Null(model.Candidates);
        Assert.False(model.RawData.ContainsKey("candidates"));
        Assert.Null(model.Found);
        Assert.False(model.RawData.ContainsKey("found"));
        Assert.Null(model.Hint);
        Assert.False(model.RawData.ContainsKey("hint"));
        Assert.Null(model.Jurisdiction);
        Assert.False(model.RawData.ContainsKey("jurisdiction"));
        Assert.Null(model.Query);
        Assert.False(model.RawData.ContainsKey("query"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new V1FindResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new V1FindResponse
        {
            // Null should be interpreted as omitted for these properties
            Candidates = null,
            Found = null,
            Hint = null,
            Jurisdiction = null,
            Query = null,
        };

        Assert.Null(model.Candidates);
        Assert.False(model.RawData.ContainsKey("candidates"));
        Assert.Null(model.Found);
        Assert.False(model.RawData.ContainsKey("found"));
        Assert.Null(model.Hint);
        Assert.False(model.RawData.ContainsKey("hint"));
        Assert.Null(model.Jurisdiction);
        Assert.False(model.RawData.ContainsKey("jurisdiction"));
        Assert.Null(model.Query);
        Assert.False(model.RawData.ContainsKey("query"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new V1FindResponse
        {
            // Null should be interpreted as omitted for these properties
            Candidates = null,
            Found = null,
            Hint = null,
            Jurisdiction = null,
            Query = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new V1FindResponse
        {
            Candidates =
            [
                new()
                {
                    Snippet = "snippet",
                    Source = "source",
                    Title = "title",
                    Url = "url",
                },
            ],
            Found = 0,
            Hint = "hint",
            Jurisdiction = "jurisdiction",
            Query = "query",
        };

        V1FindResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CandidateTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Candidate
        {
            Snippet = "snippet",
            Source = "source",
            Title = "title",
            Url = "url",
        };

        string expectedSnippet = "snippet";
        string expectedSource = "source";
        string expectedTitle = "title";
        string expectedUrl = "url";

        Assert.Equal(expectedSnippet, model.Snippet);
        Assert.Equal(expectedSource, model.Source);
        Assert.Equal(expectedTitle, model.Title);
        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Candidate
        {
            Snippet = "snippet",
            Source = "source",
            Title = "title",
            Url = "url",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Candidate>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Candidate
        {
            Snippet = "snippet",
            Source = "source",
            Title = "title",
            Url = "url",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Candidate>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedSnippet = "snippet";
        string expectedSource = "source";
        string expectedTitle = "title";
        string expectedUrl = "url";

        Assert.Equal(expectedSnippet, deserialized.Snippet);
        Assert.Equal(expectedSource, deserialized.Source);
        Assert.Equal(expectedTitle, deserialized.Title);
        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Candidate
        {
            Snippet = "snippet",
            Source = "source",
            Title = "title",
            Url = "url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Candidate { };

        Assert.Null(model.Snippet);
        Assert.False(model.RawData.ContainsKey("snippet"));
        Assert.Null(model.Source);
        Assert.False(model.RawData.ContainsKey("source"));
        Assert.Null(model.Title);
        Assert.False(model.RawData.ContainsKey("title"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Candidate { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Candidate
        {
            // Null should be interpreted as omitted for these properties
            Snippet = null,
            Source = null,
            Title = null,
            Url = null,
        };

        Assert.Null(model.Snippet);
        Assert.False(model.RawData.ContainsKey("snippet"));
        Assert.Null(model.Source);
        Assert.False(model.RawData.ContainsKey("source"));
        Assert.Null(model.Title);
        Assert.False(model.RawData.ContainsKey("title"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Candidate
        {
            // Null should be interpreted as omitted for these properties
            Snippet = null,
            Source = null,
            Title = null,
            Url = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Candidate
        {
            Snippet = "snippet",
            Source = "source",
            Title = "title",
            Url = "url",
        };

        Candidate copied = new(model);

        Assert.Equal(model, copied);
    }
}
