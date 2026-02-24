using System;
using Casedev.Models.Legal.V1;

namespace Casedev.Tests.Models.Legal.V1;

public class V1GetFullTextParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new V1GetFullTextParams
        {
            UrlValue = "https://example.com",
            HighlightQuery = "highlightQuery",
            MaxCharacters = 1000,
            SummaryQuery = "summaryQuery",
        };

        string expectedUrlValue = "https://example.com";
        string expectedHighlightQuery = "highlightQuery";
        long expectedMaxCharacters = 1000;
        string expectedSummaryQuery = "summaryQuery";

        Assert.Equal(expectedUrlValue, parameters.UrlValue);
        Assert.Equal(expectedHighlightQuery, parameters.HighlightQuery);
        Assert.Equal(expectedMaxCharacters, parameters.MaxCharacters);
        Assert.Equal(expectedSummaryQuery, parameters.SummaryQuery);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new V1GetFullTextParams { UrlValue = "https://example.com" };

        Assert.Null(parameters.HighlightQuery);
        Assert.False(parameters.RawBodyData.ContainsKey("highlightQuery"));
        Assert.Null(parameters.MaxCharacters);
        Assert.False(parameters.RawBodyData.ContainsKey("maxCharacters"));
        Assert.Null(parameters.SummaryQuery);
        Assert.False(parameters.RawBodyData.ContainsKey("summaryQuery"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new V1GetFullTextParams
        {
            UrlValue = "https://example.com",

            // Null should be interpreted as omitted for these properties
            HighlightQuery = null,
            MaxCharacters = null,
            SummaryQuery = null,
        };

        Assert.Null(parameters.HighlightQuery);
        Assert.False(parameters.RawBodyData.ContainsKey("highlightQuery"));
        Assert.Null(parameters.MaxCharacters);
        Assert.False(parameters.RawBodyData.ContainsKey("maxCharacters"));
        Assert.Null(parameters.SummaryQuery);
        Assert.False(parameters.RawBodyData.ContainsKey("summaryQuery"));
    }

    [Fact]
    public void Url_Works()
    {
        V1GetFullTextParams parameters = new() { UrlValue = "https://example.com" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/legal/v1/full-text"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new V1GetFullTextParams
        {
            UrlValue = "https://example.com",
            HighlightQuery = "highlightQuery",
            MaxCharacters = 1000,
            SummaryQuery = "summaryQuery",
        };

        V1GetFullTextParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
