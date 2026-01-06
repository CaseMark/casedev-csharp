using System;
using System.Collections.Generic;
using System.Text.Json;
using CaseDev.Models.Search.V1;

namespace CaseDev.Tests.Models.Search.V1;

public class V1SearchResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new V1SearchResponse
        {
            Query = "query",
            Results =
            [
                new()
                {
                    Domain = "domain",
                    PublishedDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Snippet = "snippet",
                    Title = "title",
                    Url = "url",
                },
            ],
            TotalResults = 0,
        };

        string expectedQuery = "query";
        List<V1SearchResponseResult> expectedResults =
        [
            new()
            {
                Domain = "domain",
                PublishedDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Snippet = "snippet",
                Title = "title",
                Url = "url",
            },
        ];
        long expectedTotalResults = 0;

        Assert.Equal(expectedQuery, model.Query);
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
        var model = new V1SearchResponse
        {
            Query = "query",
            Results =
            [
                new()
                {
                    Domain = "domain",
                    PublishedDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Snippet = "snippet",
                    Title = "title",
                    Url = "url",
                },
            ],
            TotalResults = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<V1SearchResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new V1SearchResponse
        {
            Query = "query",
            Results =
            [
                new()
                {
                    Domain = "domain",
                    PublishedDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Snippet = "snippet",
                    Title = "title",
                    Url = "url",
                },
            ],
            TotalResults = 0,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<V1SearchResponse>(element);
        Assert.NotNull(deserialized);

        string expectedQuery = "query";
        List<V1SearchResponseResult> expectedResults =
        [
            new()
            {
                Domain = "domain",
                PublishedDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Snippet = "snippet",
                Title = "title",
                Url = "url",
            },
        ];
        long expectedTotalResults = 0;

        Assert.Equal(expectedQuery, deserialized.Query);
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
        var model = new V1SearchResponse
        {
            Query = "query",
            Results =
            [
                new()
                {
                    Domain = "domain",
                    PublishedDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Snippet = "snippet",
                    Title = "title",
                    Url = "url",
                },
            ],
            TotalResults = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new V1SearchResponse { };

        Assert.Null(model.Query);
        Assert.False(model.RawData.ContainsKey("query"));
        Assert.Null(model.Results);
        Assert.False(model.RawData.ContainsKey("results"));
        Assert.Null(model.TotalResults);
        Assert.False(model.RawData.ContainsKey("totalResults"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new V1SearchResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new V1SearchResponse
        {
            // Null should be interpreted as omitted for these properties
            Query = null,
            Results = null,
            TotalResults = null,
        };

        Assert.Null(model.Query);
        Assert.False(model.RawData.ContainsKey("query"));
        Assert.Null(model.Results);
        Assert.False(model.RawData.ContainsKey("results"));
        Assert.Null(model.TotalResults);
        Assert.False(model.RawData.ContainsKey("totalResults"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new V1SearchResponse
        {
            // Null should be interpreted as omitted for these properties
            Query = null,
            Results = null,
            TotalResults = null,
        };

        model.Validate();
    }
}

public class V1SearchResponseResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new V1SearchResponseResult
        {
            Domain = "domain",
            PublishedDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Snippet = "snippet",
            Title = "title",
            Url = "url",
        };

        string expectedDomain = "domain";
        DateTimeOffset expectedPublishedDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedSnippet = "snippet";
        string expectedTitle = "title";
        string expectedUrl = "url";

        Assert.Equal(expectedDomain, model.Domain);
        Assert.Equal(expectedPublishedDate, model.PublishedDate);
        Assert.Equal(expectedSnippet, model.Snippet);
        Assert.Equal(expectedTitle, model.Title);
        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new V1SearchResponseResult
        {
            Domain = "domain",
            PublishedDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Snippet = "snippet",
            Title = "title",
            Url = "url",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<V1SearchResponseResult>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new V1SearchResponseResult
        {
            Domain = "domain",
            PublishedDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Snippet = "snippet",
            Title = "title",
            Url = "url",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<V1SearchResponseResult>(element);
        Assert.NotNull(deserialized);

        string expectedDomain = "domain";
        DateTimeOffset expectedPublishedDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedSnippet = "snippet";
        string expectedTitle = "title";
        string expectedUrl = "url";

        Assert.Equal(expectedDomain, deserialized.Domain);
        Assert.Equal(expectedPublishedDate, deserialized.PublishedDate);
        Assert.Equal(expectedSnippet, deserialized.Snippet);
        Assert.Equal(expectedTitle, deserialized.Title);
        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new V1SearchResponseResult
        {
            Domain = "domain",
            PublishedDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Snippet = "snippet",
            Title = "title",
            Url = "url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new V1SearchResponseResult { };

        Assert.Null(model.Domain);
        Assert.False(model.RawData.ContainsKey("domain"));
        Assert.Null(model.PublishedDate);
        Assert.False(model.RawData.ContainsKey("publishedDate"));
        Assert.Null(model.Snippet);
        Assert.False(model.RawData.ContainsKey("snippet"));
        Assert.Null(model.Title);
        Assert.False(model.RawData.ContainsKey("title"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new V1SearchResponseResult { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new V1SearchResponseResult
        {
            // Null should be interpreted as omitted for these properties
            Domain = null,
            PublishedDate = null,
            Snippet = null,
            Title = null,
            Url = null,
        };

        Assert.Null(model.Domain);
        Assert.False(model.RawData.ContainsKey("domain"));
        Assert.Null(model.PublishedDate);
        Assert.False(model.RawData.ContainsKey("publishedDate"));
        Assert.Null(model.Snippet);
        Assert.False(model.RawData.ContainsKey("snippet"));
        Assert.Null(model.Title);
        Assert.False(model.RawData.ContainsKey("title"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new V1SearchResponseResult
        {
            // Null should be interpreted as omitted for these properties
            Domain = null,
            PublishedDate = null,
            Snippet = null,
            Title = null,
            Url = null,
        };

        model.Validate();
    }
}
