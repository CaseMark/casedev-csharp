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
            InputUrl = "https://example.com",
            CallbackUrl = "https://example.com",
        };

        string expectedInputUrl = "https://example.com";
        string expectedCallbackUrl = "https://example.com";

        Assert.Equal(expectedInputUrl, parameters.InputUrl);
        Assert.Equal(expectedCallbackUrl, parameters.CallbackUrl);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new V1ProcessParams { InputUrl = "https://example.com" };

        Assert.Null(parameters.CallbackUrl);
        Assert.False(parameters.RawBodyData.ContainsKey("callback_url"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new V1ProcessParams
        {
            InputUrl = "https://example.com",

            // Null should be interpreted as omitted for these properties
            CallbackUrl = null,
        };

        Assert.Null(parameters.CallbackUrl);
        Assert.False(parameters.RawBodyData.ContainsKey("callback_url"));
    }

    [Fact]
    public void Url_Works()
    {
        V1ProcessParams parameters = new() { InputUrl = "https://example.com" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/convert/v1/process"), url);
    }
}
