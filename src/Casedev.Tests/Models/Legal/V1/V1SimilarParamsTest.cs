using System;
using Casedev.Models.Legal.V1;

namespace Casedev.Tests.Models.Legal.V1;

public class V1SimilarParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new V1SimilarParams
        {
            UrlValue = "https://example.com",
            Jurisdiction = "jurisdiction",
            NumResults = 1,
            StartPublishedDate = "2019-12-27",
        };

        string expectedUrlValue = "https://example.com";
        string expectedJurisdiction = "jurisdiction";
        long expectedNumResults = 1;
        string expectedStartPublishedDate = "2019-12-27";

        Assert.Equal(expectedUrlValue, parameters.UrlValue);
        Assert.Equal(expectedJurisdiction, parameters.Jurisdiction);
        Assert.Equal(expectedNumResults, parameters.NumResults);
        Assert.Equal(expectedStartPublishedDate, parameters.StartPublishedDate);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new V1SimilarParams { UrlValue = "https://example.com" };

        Assert.Null(parameters.Jurisdiction);
        Assert.False(parameters.RawBodyData.ContainsKey("jurisdiction"));
        Assert.Null(parameters.NumResults);
        Assert.False(parameters.RawBodyData.ContainsKey("numResults"));
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
            Jurisdiction = null,
            NumResults = null,
            StartPublishedDate = null,
        };

        Assert.Null(parameters.Jurisdiction);
        Assert.False(parameters.RawBodyData.ContainsKey("jurisdiction"));
        Assert.Null(parameters.NumResults);
        Assert.False(parameters.RawBodyData.ContainsKey("numResults"));
        Assert.Null(parameters.StartPublishedDate);
        Assert.False(parameters.RawBodyData.ContainsKey("startPublishedDate"));
    }

    [Fact]
    public void Url_Works()
    {
        V1SimilarParams parameters = new() { UrlValue = "https://example.com" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/legal/v1/similar"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new V1SimilarParams
        {
            UrlValue = "https://example.com",
            Jurisdiction = "jurisdiction",
            NumResults = 1,
            StartPublishedDate = "2019-12-27",
        };

        V1SimilarParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
