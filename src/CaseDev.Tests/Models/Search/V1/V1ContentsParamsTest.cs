using System;
using System.Collections.Generic;
using System.Text.Json;
using CaseDev.Models.Search.V1;

namespace CaseDev.Tests.Models.Search.V1;

public class V1ContentsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new V1ContentsParams
        {
            Urls = ["https://example.com"],
            Context = "context",
            Extras = JsonSerializer.Deserialize<JsonElement>("{}"),
            Highlights = true,
            Livecrawl = true,
            LivecrawlTimeout = 0,
            Subpages = true,
            SubpageTarget = 0,
            Summary = true,
            Text = true,
        };

        List<string> expectedUrls = ["https://example.com"];
        string expectedContext = "context";
        JsonElement expectedExtras = JsonSerializer.Deserialize<JsonElement>("{}");
        bool expectedHighlights = true;
        bool expectedLivecrawl = true;
        long expectedLivecrawlTimeout = 0;
        bool expectedSubpages = true;
        long expectedSubpageTarget = 0;
        bool expectedSummary = true;
        bool expectedText = true;

        Assert.Equal(expectedUrls.Count, parameters.Urls.Count);
        for (int i = 0; i < expectedUrls.Count; i++)
        {
            Assert.Equal(expectedUrls[i], parameters.Urls[i]);
        }
        Assert.Equal(expectedContext, parameters.Context);
        Assert.NotNull(parameters.Extras);
        Assert.True(JsonElement.DeepEquals(expectedExtras, parameters.Extras.Value));
        Assert.Equal(expectedHighlights, parameters.Highlights);
        Assert.Equal(expectedLivecrawl, parameters.Livecrawl);
        Assert.Equal(expectedLivecrawlTimeout, parameters.LivecrawlTimeout);
        Assert.Equal(expectedSubpages, parameters.Subpages);
        Assert.Equal(expectedSubpageTarget, parameters.SubpageTarget);
        Assert.Equal(expectedSummary, parameters.Summary);
        Assert.Equal(expectedText, parameters.Text);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new V1ContentsParams { Urls = ["https://example.com"] };

        Assert.Null(parameters.Context);
        Assert.False(parameters.RawBodyData.ContainsKey("context"));
        Assert.Null(parameters.Extras);
        Assert.False(parameters.RawBodyData.ContainsKey("extras"));
        Assert.Null(parameters.Highlights);
        Assert.False(parameters.RawBodyData.ContainsKey("highlights"));
        Assert.Null(parameters.Livecrawl);
        Assert.False(parameters.RawBodyData.ContainsKey("livecrawl"));
        Assert.Null(parameters.LivecrawlTimeout);
        Assert.False(parameters.RawBodyData.ContainsKey("livecrawlTimeout"));
        Assert.Null(parameters.Subpages);
        Assert.False(parameters.RawBodyData.ContainsKey("subpages"));
        Assert.Null(parameters.SubpageTarget);
        Assert.False(parameters.RawBodyData.ContainsKey("subpageTarget"));
        Assert.Null(parameters.Summary);
        Assert.False(parameters.RawBodyData.ContainsKey("summary"));
        Assert.Null(parameters.Text);
        Assert.False(parameters.RawBodyData.ContainsKey("text"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new V1ContentsParams
        {
            Urls = ["https://example.com"],

            // Null should be interpreted as omitted for these properties
            Context = null,
            Extras = null,
            Highlights = null,
            Livecrawl = null,
            LivecrawlTimeout = null,
            Subpages = null,
            SubpageTarget = null,
            Summary = null,
            Text = null,
        };

        Assert.Null(parameters.Context);
        Assert.False(parameters.RawBodyData.ContainsKey("context"));
        Assert.Null(parameters.Extras);
        Assert.False(parameters.RawBodyData.ContainsKey("extras"));
        Assert.Null(parameters.Highlights);
        Assert.False(parameters.RawBodyData.ContainsKey("highlights"));
        Assert.Null(parameters.Livecrawl);
        Assert.False(parameters.RawBodyData.ContainsKey("livecrawl"));
        Assert.Null(parameters.LivecrawlTimeout);
        Assert.False(parameters.RawBodyData.ContainsKey("livecrawlTimeout"));
        Assert.Null(parameters.Subpages);
        Assert.False(parameters.RawBodyData.ContainsKey("subpages"));
        Assert.Null(parameters.SubpageTarget);
        Assert.False(parameters.RawBodyData.ContainsKey("subpageTarget"));
        Assert.Null(parameters.Summary);
        Assert.False(parameters.RawBodyData.ContainsKey("summary"));
        Assert.Null(parameters.Text);
        Assert.False(parameters.RawBodyData.ContainsKey("text"));
    }

    [Fact]
    public void Url_Works()
    {
        V1ContentsParams parameters = new() { Urls = ["https://example.com"] };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/search/v1/contents"), url);
    }
}
