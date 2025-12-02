using System.Collections.Generic;
using CaseDev.Models.Search.V1;

namespace CaseDev.Tests.Models.Search.V1;

public class V1AnswerResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new V1AnswerResponse
        {
            Answer = "answer",
            Citations =
            [
                new()
                {
                    ID = "id",
                    PublishedDate = "publishedDate",
                    Text = "text",
                    Title = "title",
                    URL = "url",
                },
            ],
            Model = "model",
            SearchType = "searchType",
        };

        string expectedAnswer = "answer";
        List<Citation> expectedCitations =
        [
            new()
            {
                ID = "id",
                PublishedDate = "publishedDate",
                Text = "text",
                Title = "title",
                URL = "url",
            },
        ];
        string expectedModel = "model";
        string expectedSearchType = "searchType";

        Assert.Equal(expectedAnswer, model.Answer);
        Assert.Equal(expectedCitations.Count, model.Citations.Count);
        for (int i = 0; i < expectedCitations.Count; i++)
        {
            Assert.Equal(expectedCitations[i], model.Citations[i]);
        }
        Assert.Equal(expectedModel, model.Model);
        Assert.Equal(expectedSearchType, model.SearchType);
    }
}

public class CitationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Citation
        {
            ID = "id",
            PublishedDate = "publishedDate",
            Text = "text",
            Title = "title",
            URL = "url",
        };

        string expectedID = "id";
        string expectedPublishedDate = "publishedDate";
        string expectedText = "text";
        string expectedTitle = "title";
        string expectedURL = "url";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedPublishedDate, model.PublishedDate);
        Assert.Equal(expectedText, model.Text);
        Assert.Equal(expectedTitle, model.Title);
        Assert.Equal(expectedURL, model.URL);
    }
}
