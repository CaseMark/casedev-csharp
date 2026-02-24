using System.Collections.Generic;
using System.Text.Json;
using Casedev.Core;
using Casedev.Models.Legal.V1;

namespace Casedev.Tests.Models.Legal.V1;

public class V1ResearchResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new V1ResearchResponse
        {
            AdditionalQueries = ["string"],
            Candidates =
            [
                new()
                {
                    Highlights = ["string"],
                    PublishedDate = "publishedDate",
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
            SearchType = "searchType",
        };

        List<string> expectedAdditionalQueries = ["string"];
        List<V1ResearchResponseCandidate> expectedCandidates =
        [
            new()
            {
                Highlights = ["string"],
                PublishedDate = "publishedDate",
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
        string expectedSearchType = "searchType";

        Assert.NotNull(model.AdditionalQueries);
        Assert.Equal(expectedAdditionalQueries.Count, model.AdditionalQueries.Count);
        for (int i = 0; i < expectedAdditionalQueries.Count; i++)
        {
            Assert.Equal(expectedAdditionalQueries[i], model.AdditionalQueries[i]);
        }
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
        Assert.Equal(expectedSearchType, model.SearchType);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new V1ResearchResponse
        {
            AdditionalQueries = ["string"],
            Candidates =
            [
                new()
                {
                    Highlights = ["string"],
                    PublishedDate = "publishedDate",
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
            SearchType = "searchType",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1ResearchResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new V1ResearchResponse
        {
            AdditionalQueries = ["string"],
            Candidates =
            [
                new()
                {
                    Highlights = ["string"],
                    PublishedDate = "publishedDate",
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
            SearchType = "searchType",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1ResearchResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<string> expectedAdditionalQueries = ["string"];
        List<V1ResearchResponseCandidate> expectedCandidates =
        [
            new()
            {
                Highlights = ["string"],
                PublishedDate = "publishedDate",
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
        string expectedSearchType = "searchType";

        Assert.NotNull(deserialized.AdditionalQueries);
        Assert.Equal(expectedAdditionalQueries.Count, deserialized.AdditionalQueries.Count);
        for (int i = 0; i < expectedAdditionalQueries.Count; i++)
        {
            Assert.Equal(expectedAdditionalQueries[i], deserialized.AdditionalQueries[i]);
        }
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
        Assert.Equal(expectedSearchType, deserialized.SearchType);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new V1ResearchResponse
        {
            AdditionalQueries = ["string"],
            Candidates =
            [
                new()
                {
                    Highlights = ["string"],
                    PublishedDate = "publishedDate",
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
            SearchType = "searchType",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new V1ResearchResponse { AdditionalQueries = ["string"] };

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
        Assert.Null(model.SearchType);
        Assert.False(model.RawData.ContainsKey("searchType"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new V1ResearchResponse { AdditionalQueries = ["string"] };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new V1ResearchResponse
        {
            AdditionalQueries = ["string"],

            // Null should be interpreted as omitted for these properties
            Candidates = null,
            Found = null,
            Hint = null,
            Jurisdiction = null,
            Query = null,
            SearchType = null,
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
        Assert.Null(model.SearchType);
        Assert.False(model.RawData.ContainsKey("searchType"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new V1ResearchResponse
        {
            AdditionalQueries = ["string"],

            // Null should be interpreted as omitted for these properties
            Candidates = null,
            Found = null,
            Hint = null,
            Jurisdiction = null,
            Query = null,
            SearchType = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new V1ResearchResponse
        {
            Candidates =
            [
                new()
                {
                    Highlights = ["string"],
                    PublishedDate = "publishedDate",
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
            SearchType = "searchType",
        };

        Assert.Null(model.AdditionalQueries);
        Assert.False(model.RawData.ContainsKey("additionalQueries"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new V1ResearchResponse
        {
            Candidates =
            [
                new()
                {
                    Highlights = ["string"],
                    PublishedDate = "publishedDate",
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
            SearchType = "searchType",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new V1ResearchResponse
        {
            Candidates =
            [
                new()
                {
                    Highlights = ["string"],
                    PublishedDate = "publishedDate",
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
            SearchType = "searchType",

            AdditionalQueries = null,
        };

        Assert.Null(model.AdditionalQueries);
        Assert.True(model.RawData.ContainsKey("additionalQueries"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new V1ResearchResponse
        {
            Candidates =
            [
                new()
                {
                    Highlights = ["string"],
                    PublishedDate = "publishedDate",
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
            SearchType = "searchType",

            AdditionalQueries = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new V1ResearchResponse
        {
            AdditionalQueries = ["string"],
            Candidates =
            [
                new()
                {
                    Highlights = ["string"],
                    PublishedDate = "publishedDate",
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
            SearchType = "searchType",
        };

        V1ResearchResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class V1ResearchResponseCandidateTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new V1ResearchResponseCandidate
        {
            Highlights = ["string"],
            PublishedDate = "publishedDate",
            Snippet = "snippet",
            Source = "source",
            Title = "title",
            Url = "url",
        };

        List<string> expectedHighlights = ["string"];
        string expectedPublishedDate = "publishedDate";
        string expectedSnippet = "snippet";
        string expectedSource = "source";
        string expectedTitle = "title";
        string expectedUrl = "url";

        Assert.NotNull(model.Highlights);
        Assert.Equal(expectedHighlights.Count, model.Highlights.Count);
        for (int i = 0; i < expectedHighlights.Count; i++)
        {
            Assert.Equal(expectedHighlights[i], model.Highlights[i]);
        }
        Assert.Equal(expectedPublishedDate, model.PublishedDate);
        Assert.Equal(expectedSnippet, model.Snippet);
        Assert.Equal(expectedSource, model.Source);
        Assert.Equal(expectedTitle, model.Title);
        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new V1ResearchResponseCandidate
        {
            Highlights = ["string"],
            PublishedDate = "publishedDate",
            Snippet = "snippet",
            Source = "source",
            Title = "title",
            Url = "url",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1ResearchResponseCandidate>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new V1ResearchResponseCandidate
        {
            Highlights = ["string"],
            PublishedDate = "publishedDate",
            Snippet = "snippet",
            Source = "source",
            Title = "title",
            Url = "url",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1ResearchResponseCandidate>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<string> expectedHighlights = ["string"];
        string expectedPublishedDate = "publishedDate";
        string expectedSnippet = "snippet";
        string expectedSource = "source";
        string expectedTitle = "title";
        string expectedUrl = "url";

        Assert.NotNull(deserialized.Highlights);
        Assert.Equal(expectedHighlights.Count, deserialized.Highlights.Count);
        for (int i = 0; i < expectedHighlights.Count; i++)
        {
            Assert.Equal(expectedHighlights[i], deserialized.Highlights[i]);
        }
        Assert.Equal(expectedPublishedDate, deserialized.PublishedDate);
        Assert.Equal(expectedSnippet, deserialized.Snippet);
        Assert.Equal(expectedSource, deserialized.Source);
        Assert.Equal(expectedTitle, deserialized.Title);
        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new V1ResearchResponseCandidate
        {
            Highlights = ["string"],
            PublishedDate = "publishedDate",
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
        var model = new V1ResearchResponseCandidate { PublishedDate = "publishedDate" };

        Assert.Null(model.Highlights);
        Assert.False(model.RawData.ContainsKey("highlights"));
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
        var model = new V1ResearchResponseCandidate { PublishedDate = "publishedDate" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new V1ResearchResponseCandidate
        {
            PublishedDate = "publishedDate",

            // Null should be interpreted as omitted for these properties
            Highlights = null,
            Snippet = null,
            Source = null,
            Title = null,
            Url = null,
        };

        Assert.Null(model.Highlights);
        Assert.False(model.RawData.ContainsKey("highlights"));
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
        var model = new V1ResearchResponseCandidate
        {
            PublishedDate = "publishedDate",

            // Null should be interpreted as omitted for these properties
            Highlights = null,
            Snippet = null,
            Source = null,
            Title = null,
            Url = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new V1ResearchResponseCandidate
        {
            Highlights = ["string"],
            Snippet = "snippet",
            Source = "source",
            Title = "title",
            Url = "url",
        };

        Assert.Null(model.PublishedDate);
        Assert.False(model.RawData.ContainsKey("publishedDate"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new V1ResearchResponseCandidate
        {
            Highlights = ["string"],
            Snippet = "snippet",
            Source = "source",
            Title = "title",
            Url = "url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new V1ResearchResponseCandidate
        {
            Highlights = ["string"],
            Snippet = "snippet",
            Source = "source",
            Title = "title",
            Url = "url",

            PublishedDate = null,
        };

        Assert.Null(model.PublishedDate);
        Assert.True(model.RawData.ContainsKey("publishedDate"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new V1ResearchResponseCandidate
        {
            Highlights = ["string"],
            Snippet = "snippet",
            Source = "source",
            Title = "title",
            Url = "url",

            PublishedDate = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new V1ResearchResponseCandidate
        {
            Highlights = ["string"],
            PublishedDate = "publishedDate",
            Snippet = "snippet",
            Source = "source",
            Title = "title",
            Url = "url",
        };

        V1ResearchResponseCandidate copied = new(model);

        Assert.Equal(model, copied);
    }
}
