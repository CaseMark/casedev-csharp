using System;
using CaseDev.Models.Convert.V1;

namespace CaseDev.Tests.Models.Convert.V1;

public class V1ProcessParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new V1ProcessParams
        {
            InputURL = "https://example.com",
            CallbackURL = "https://example.com",
        };

        string expectedInputURL = "https://example.com";
        string expectedCallbackURL = "https://example.com";

        Assert.Equal(expectedInputURL, parameters.InputURL);
        Assert.Equal(expectedCallbackURL, parameters.CallbackURL);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new V1ProcessParams { InputURL = "https://example.com" };

        Assert.Null(parameters.CallbackURL);
        Assert.False(parameters.RawBodyData.ContainsKey("callback_url"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new V1ProcessParams
        {
            InputURL = "https://example.com",

            // Null should be interpreted as omitted for these properties
            CallbackURL = null,
        };

        Assert.Null(parameters.CallbackURL);
        Assert.False(parameters.RawBodyData.ContainsKey("callback_url"));
    }

    [Fact]
    public void Url_Works()
    {
        V1ProcessParams parameters = new() { InputURL = "https://example.com" };

        var url = parameters.Url(new() { APIKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/convert/v1/process"), url);
    }
}
