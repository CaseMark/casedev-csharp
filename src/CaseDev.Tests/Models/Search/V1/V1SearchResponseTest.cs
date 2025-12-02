using System;
using System.Collections.Generic;
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
                    URL = "url",
                },
            ],
            TotalResults = 0,
        };

        string expectedQuery = "query";
        List<ResultModel> expectedResults =
        [
            new()
            {
                Domain = "domain",
                PublishedDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Snippet = "snippet",
                Title = "title",
                URL = "url",
            },
        ];
        long expectedTotalResults = 0;

        Assert.Equal(expectedQuery, model.Query);
        Assert.Equal(expectedResults.Count, model.Results.Count);
        for (int i = 0; i < expectedResults.Count; i++)
        {
            Assert.Equal(expectedResults[i], model.Results[i]);
        }
        Assert.Equal(expectedTotalResults, model.TotalResults);
    }
}

public class ResultModelTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ResultModel
        {
            Domain = "domain",
            PublishedDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Snippet = "snippet",
            Title = "title",
            URL = "url",
        };

        string expectedDomain = "domain";
        DateTimeOffset expectedPublishedDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedSnippet = "snippet";
        string expectedTitle = "title";
        string expectedURL = "url";

        Assert.Equal(expectedDomain, model.Domain);
        Assert.Equal(expectedPublishedDate, model.PublishedDate);
        Assert.Equal(expectedSnippet, model.Snippet);
        Assert.Equal(expectedTitle, model.Title);
        Assert.Equal(expectedURL, model.URL);
    }
}
