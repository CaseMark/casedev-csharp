using System.Collections.Generic;
using System.Text.Json;
using CaseDev.Models.Search.V1;

namespace CaseDev.Tests.Models.Search.V1;

public class V1ContentsResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new V1ContentsResponse
        {
            Results =
            [
                new()
                {
                    Highlights = ["string"],
                    Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Summary = "summary",
                    Text = "text",
                    Title = "title",
                    URL = "url",
                },
            ],
        };

        List<Result> expectedResults =
        [
            new()
            {
                Highlights = ["string"],
                Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                Summary = "summary",
                Text = "text",
                Title = "title",
                URL = "url",
            },
        ];

        Assert.Equal(expectedResults.Count, model.Results.Count);
        for (int i = 0; i < expectedResults.Count; i++)
        {
            Assert.Equal(expectedResults[i], model.Results[i]);
        }
    }
}

public class ResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Result
        {
            Highlights = ["string"],
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Summary = "summary",
            Text = "text",
            Title = "title",
            URL = "url",
        };

        List<string> expectedHighlights = ["string"];
        JsonElement expectedMetadata = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedSummary = "summary";
        string expectedText = "text";
        string expectedTitle = "title";
        string expectedURL = "url";

        Assert.Equal(expectedHighlights.Count, model.Highlights.Count);
        for (int i = 0; i < expectedHighlights.Count; i++)
        {
            Assert.Equal(expectedHighlights[i], model.Highlights[i]);
        }
        Assert.True(
            model.Metadata.HasValue
                && JsonElement.DeepEquals(expectedMetadata, model.Metadata.Value)
        );
        Assert.Equal(expectedSummary, model.Summary);
        Assert.Equal(expectedText, model.Text);
        Assert.Equal(expectedTitle, model.Title);
        Assert.Equal(expectedURL, model.URL);
    }
}
