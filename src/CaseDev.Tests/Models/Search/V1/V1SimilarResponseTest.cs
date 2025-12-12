using System.Collections.Generic;
using System.Text.Json;
using CaseDev.Models.Search.V1;

namespace CaseDev.Tests.Models.Search.V1;

public class V1SimilarResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new V1SimilarResponse
        {
            ProcessingTime = 0,
            Results =
            [
                new()
                {
                    Domain = "domain",
                    PublishedDate = "publishedDate",
                    SimilarityScore = 0,
                    Snippet = "snippet",
                    Text = "text",
                    Title = "title",
                    URL = "url",
                },
            ],
            TotalResults = 0,
        };

        double expectedProcessingTime = 0;
        List<V1SimilarResponseResult> expectedResults =
        [
            new()
            {
                Domain = "domain",
                PublishedDate = "publishedDate",
                SimilarityScore = 0,
                Snippet = "snippet",
                Text = "text",
                Title = "title",
                URL = "url",
            },
        ];
        long expectedTotalResults = 0;

        Assert.Equal(expectedProcessingTime, model.ProcessingTime);
        Assert.NotNull(model.Results);
        Assert.Equal(expectedResults.Count, model.Results.Count);
        for (int i = 0; i < expectedResults.Count; i++)
        {
            Assert.Equal(expectedResults[i], model.Results[i]);
        }
        Assert.Equal(expectedTotalResults, model.TotalResults);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new V1SimilarResponse
        {
            ProcessingTime = 0,
            Results =
            [
                new()
                {
                    Domain = "domain",
                    PublishedDate = "publishedDate",
                    SimilarityScore = 0,
                    Snippet = "snippet",
                    Text = "text",
                    Title = "title",
                    URL = "url",
                },
            ],
            TotalResults = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<V1SimilarResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new V1SimilarResponse
        {
            ProcessingTime = 0,
            Results =
            [
                new()
                {
                    Domain = "domain",
                    PublishedDate = "publishedDate",
                    SimilarityScore = 0,
                    Snippet = "snippet",
                    Text = "text",
                    Title = "title",
                    URL = "url",
                },
            ],
            TotalResults = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<V1SimilarResponse>(json);
        Assert.NotNull(deserialized);

        double expectedProcessingTime = 0;
        List<V1SimilarResponseResult> expectedResults =
        [
            new()
            {
                Domain = "domain",
                PublishedDate = "publishedDate",
                SimilarityScore = 0,
                Snippet = "snippet",
                Text = "text",
                Title = "title",
                URL = "url",
            },
        ];
        long expectedTotalResults = 0;

        Assert.Equal(expectedProcessingTime, deserialized.ProcessingTime);
        Assert.NotNull(deserialized.Results);
        Assert.Equal(expectedResults.Count, deserialized.Results.Count);
        for (int i = 0; i < expectedResults.Count; i++)
        {
            Assert.Equal(expectedResults[i], deserialized.Results[i]);
        }
        Assert.Equal(expectedTotalResults, deserialized.TotalResults);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new V1SimilarResponse
        {
            ProcessingTime = 0,
            Results =
            [
                new()
                {
                    Domain = "domain",
                    PublishedDate = "publishedDate",
                    SimilarityScore = 0,
                    Snippet = "snippet",
                    Text = "text",
                    Title = "title",
                    URL = "url",
                },
            ],
            TotalResults = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new V1SimilarResponse { };

        Assert.Null(model.ProcessingTime);
        Assert.False(model.RawData.ContainsKey("processingTime"));
        Assert.Null(model.Results);
        Assert.False(model.RawData.ContainsKey("results"));
        Assert.Null(model.TotalResults);
        Assert.False(model.RawData.ContainsKey("totalResults"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new V1SimilarResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new V1SimilarResponse
        {
            // Null should be interpreted as omitted for these properties
            ProcessingTime = null,
            Results = null,
            TotalResults = null,
        };

        Assert.Null(model.ProcessingTime);
        Assert.False(model.RawData.ContainsKey("processingTime"));
        Assert.Null(model.Results);
        Assert.False(model.RawData.ContainsKey("results"));
        Assert.Null(model.TotalResults);
        Assert.False(model.RawData.ContainsKey("totalResults"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new V1SimilarResponse
        {
            // Null should be interpreted as omitted for these properties
            ProcessingTime = null,
            Results = null,
            TotalResults = null,
        };

        model.Validate();
    }
}

public class V1SimilarResponseResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new V1SimilarResponseResult
        {
            Domain = "domain",
            PublishedDate = "publishedDate",
            SimilarityScore = 0,
            Snippet = "snippet",
            Text = "text",
            Title = "title",
            URL = "url",
        };

        string expectedDomain = "domain";
        string expectedPublishedDate = "publishedDate";
        double expectedSimilarityScore = 0;
        string expectedSnippet = "snippet";
        string expectedText = "text";
        string expectedTitle = "title";
        string expectedURL = "url";

        Assert.Equal(expectedDomain, model.Domain);
        Assert.Equal(expectedPublishedDate, model.PublishedDate);
        Assert.Equal(expectedSimilarityScore, model.SimilarityScore);
        Assert.Equal(expectedSnippet, model.Snippet);
        Assert.Equal(expectedText, model.Text);
        Assert.Equal(expectedTitle, model.Title);
        Assert.Equal(expectedURL, model.URL);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new V1SimilarResponseResult
        {
            Domain = "domain",
            PublishedDate = "publishedDate",
            SimilarityScore = 0,
            Snippet = "snippet",
            Text = "text",
            Title = "title",
            URL = "url",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<V1SimilarResponseResult>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new V1SimilarResponseResult
        {
            Domain = "domain",
            PublishedDate = "publishedDate",
            SimilarityScore = 0,
            Snippet = "snippet",
            Text = "text",
            Title = "title",
            URL = "url",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<V1SimilarResponseResult>(json);
        Assert.NotNull(deserialized);

        string expectedDomain = "domain";
        string expectedPublishedDate = "publishedDate";
        double expectedSimilarityScore = 0;
        string expectedSnippet = "snippet";
        string expectedText = "text";
        string expectedTitle = "title";
        string expectedURL = "url";

        Assert.Equal(expectedDomain, deserialized.Domain);
        Assert.Equal(expectedPublishedDate, deserialized.PublishedDate);
        Assert.Equal(expectedSimilarityScore, deserialized.SimilarityScore);
        Assert.Equal(expectedSnippet, deserialized.Snippet);
        Assert.Equal(expectedText, deserialized.Text);
        Assert.Equal(expectedTitle, deserialized.Title);
        Assert.Equal(expectedURL, deserialized.URL);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new V1SimilarResponseResult
        {
            Domain = "domain",
            PublishedDate = "publishedDate",
            SimilarityScore = 0,
            Snippet = "snippet",
            Text = "text",
            Title = "title",
            URL = "url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new V1SimilarResponseResult { };

        Assert.Null(model.Domain);
        Assert.False(model.RawData.ContainsKey("domain"));
        Assert.Null(model.PublishedDate);
        Assert.False(model.RawData.ContainsKey("publishedDate"));
        Assert.Null(model.SimilarityScore);
        Assert.False(model.RawData.ContainsKey("similarityScore"));
        Assert.Null(model.Snippet);
        Assert.False(model.RawData.ContainsKey("snippet"));
        Assert.Null(model.Text);
        Assert.False(model.RawData.ContainsKey("text"));
        Assert.Null(model.Title);
        Assert.False(model.RawData.ContainsKey("title"));
        Assert.Null(model.URL);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new V1SimilarResponseResult { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new V1SimilarResponseResult
        {
            // Null should be interpreted as omitted for these properties
            Domain = null,
            PublishedDate = null,
            SimilarityScore = null,
            Snippet = null,
            Text = null,
            Title = null,
            URL = null,
        };

        Assert.Null(model.Domain);
        Assert.False(model.RawData.ContainsKey("domain"));
        Assert.Null(model.PublishedDate);
        Assert.False(model.RawData.ContainsKey("publishedDate"));
        Assert.Null(model.SimilarityScore);
        Assert.False(model.RawData.ContainsKey("similarityScore"));
        Assert.Null(model.Snippet);
        Assert.False(model.RawData.ContainsKey("snippet"));
        Assert.Null(model.Text);
        Assert.False(model.RawData.ContainsKey("text"));
        Assert.Null(model.Title);
        Assert.False(model.RawData.ContainsKey("title"));
        Assert.Null(model.URL);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new V1SimilarResponseResult
        {
            // Null should be interpreted as omitted for these properties
            Domain = null,
            PublishedDate = null,
            SimilarityScore = null,
            Snippet = null,
            Text = null,
            Title = null,
            URL = null,
        };

        model.Validate();
    }
}
