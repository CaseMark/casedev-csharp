using System.Collections.Generic;
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
        List<Result1> expectedResults =
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
        Assert.Equal(expectedResults.Count, model.Results.Count);
        for (int i = 0; i < expectedResults.Count; i++)
        {
            Assert.Equal(expectedResults[i], model.Results[i]);
        }
        Assert.Equal(expectedTotalResults, model.TotalResults);
    }
}

public class Result1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Result1
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
}
