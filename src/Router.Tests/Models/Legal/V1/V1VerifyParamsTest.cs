using System;
using Router.Models.Legal.V1;

namespace Router.Tests.Models.Legal.V1;

public class V1VerifyParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new V1VerifyParams { Text = "text" };

        string expectedText = "text";

        Assert.Equal(expectedText, parameters.Text);
    }

    [Fact]
    public void Url_Works()
    {
        V1VerifyParams parameters = new() { Text = "text" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/legal/v1/verify"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new V1VerifyParams { Text = "text" };

        V1VerifyParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
