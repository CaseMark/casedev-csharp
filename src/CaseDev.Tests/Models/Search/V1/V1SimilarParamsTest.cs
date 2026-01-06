using System;
using System.Collections.Generic;
using CaseDev.Models.Search.V1;

namespace CaseDev.Tests.Models.Search.V1;

public class V1SimilarParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new V1SimilarParams
        {
            UrlValue = "https://example.com",
            Contents = "contents",
            EndCrawlDate = "2019-12-27",
            EndPublishedDate = "2019-12-27",
            ExcludeDomains = ["string"],
            IncludeDomains = ["string"],
            IncludeText = true,
            NumResults = 1,
            StartCrawlDate = "2019-12-27",
            StartPublishedDate = "2019-12-27",
        };

        string expectedUrlValue = "https://example.com";
        string expectedContents = "contents";
        string expectedEndCrawlDate = "2019-12-27";
        string expectedEndPublishedDate = "2019-12-27";
        List<string> expectedExcludeDomains = ["string"];
        List<string> expectedIncludeDomains = ["string"];
        bool expectedIncludeText = true;
        long expectedNumResults = 1;
        string expectedStartCrawlDate = "2019-12-27";
        string expectedStartPublishedDate = "2019-12-27";

        Assert.Equal(expectedUrlValue, parameters.UrlValue);
        Assert.Equal(expectedContents, parameters.Contents);
        Assert.Equal(expectedEndCrawlDate, parameters.EndCrawlDate);
        Assert.Equal(expectedEndPublishedDate, parameters.EndPublishedDate);
        Assert.NotNull(parameters.ExcludeDomains);
        Assert.Equal(expectedExcludeDomains.Count, parameters.ExcludeDomains.Count);
        for (int i = 0; i < expectedExcludeDomains.Count; i++)
        {
            Assert.Equal(expectedExcludeDomains[i], parameters.ExcludeDomains[i]);
        }
        Assert.NotNull(parameters.IncludeDomains);
        Assert.Equal(expectedIncludeDomains.Count, parameters.IncludeDomains.Count);
        for (int i = 0; i < expectedIncludeDomains.Count; i++)
        {
            Assert.Equal(expectedIncludeDomains[i], parameters.IncludeDomains[i]);
        }
        Assert.Equal(expectedIncludeText, parameters.IncludeText);
        Assert.Equal(expectedNumResults, parameters.NumResults);
        Assert.Equal(expectedStartCrawlDate, parameters.StartCrawlDate);
        Assert.Equal(expectedStartPublishedDate, parameters.StartPublishedDate);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new V1SimilarParams { UrlValue = "https://example.com" };

        Assert.Null(parameters.Contents);
        Assert.False(parameters.RawBodyData.ContainsKey("contents"));
        Assert.Null(parameters.EndCrawlDate);
        Assert.False(parameters.RawBodyData.ContainsKey("endCrawlDate"));
        Assert.Null(parameters.EndPublishedDate);
        Assert.False(parameters.RawBodyData.ContainsKey("endPublishedDate"));
        Assert.Null(parameters.ExcludeDomains);
        Assert.False(parameters.RawBodyData.ContainsKey("excludeDomains"));
        Assert.Null(parameters.IncludeDomains);
        Assert.False(parameters.RawBodyData.ContainsKey("includeDomains"));
        Assert.Null(parameters.IncludeText);
        Assert.False(parameters.RawBodyData.ContainsKey("includeText"));
        Assert.Null(parameters.NumResults);
        Assert.False(parameters.RawBodyData.ContainsKey("numResults"));
        Assert.Null(parameters.StartCrawlDate);
        Assert.False(parameters.RawBodyData.ContainsKey("startCrawlDate"));
        Assert.Null(parameters.StartPublishedDate);
        Assert.False(parameters.RawBodyData.ContainsKey("startPublishedDate"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new V1SimilarParams
        {
            UrlValue = "https://example.com",

            // Null should be interpreted as omitted for these properties
            Contents = null,
            EndCrawlDate = null,
            EndPublishedDate = null,
            ExcludeDomains = null,
            IncludeDomains = null,
            IncludeText = null,
            NumResults = null,
            StartCrawlDate = null,
            StartPublishedDate = null,
        };

        Assert.Null(parameters.Contents);
        Assert.False(parameters.RawBodyData.ContainsKey("contents"));
        Assert.Null(parameters.EndCrawlDate);
        Assert.False(parameters.RawBodyData.ContainsKey("endCrawlDate"));
        Assert.Null(parameters.EndPublishedDate);
        Assert.False(parameters.RawBodyData.ContainsKey("endPublishedDate"));
        Assert.Null(parameters.ExcludeDomains);
        Assert.False(parameters.RawBodyData.ContainsKey("excludeDomains"));
        Assert.Null(parameters.IncludeDomains);
        Assert.False(parameters.RawBodyData.ContainsKey("includeDomains"));
        Assert.Null(parameters.IncludeText);
        Assert.False(parameters.RawBodyData.ContainsKey("includeText"));
        Assert.Null(parameters.NumResults);
        Assert.False(parameters.RawBodyData.ContainsKey("numResults"));
        Assert.Null(parameters.StartCrawlDate);
        Assert.False(parameters.RawBodyData.ContainsKey("startCrawlDate"));
        Assert.Null(parameters.StartPublishedDate);
        Assert.False(parameters.RawBodyData.ContainsKey("startPublishedDate"));
    }

    [Fact]
    public void Url_Works()
    {
        V1SimilarParams parameters = new() { UrlValue = "https://example.com" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/search/v1/similar"), url);
    }
}
