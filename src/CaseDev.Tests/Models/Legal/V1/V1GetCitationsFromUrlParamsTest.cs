using System;
using CaseDev.Models.Legal.V1;

namespace CaseDev.Tests.Models.Legal.V1;

public class V1GetCitationsFromUrlParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new V1GetCitationsFromUrlParams { UrlValue = "https://example.com" };

        string expectedUrlValue = "https://example.com";

        Assert.Equal(expectedUrlValue, parameters.UrlValue);
    }

    [Fact]
    public void Url_Works()
    {
        V1GetCitationsFromUrlParams parameters = new() { UrlValue = "https://example.com" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/legal/v1/citations-from-url"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new V1GetCitationsFromUrlParams { UrlValue = "https://example.com" };

        V1GetCitationsFromUrlParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
