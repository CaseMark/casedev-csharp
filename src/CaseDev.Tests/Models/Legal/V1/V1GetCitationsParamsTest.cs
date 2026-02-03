using System;
using CaseDev.Models.Legal.V1;

namespace CaseDev.Tests.Models.Legal.V1;

public class V1GetCitationsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new V1GetCitationsParams { Text = "text" };

        string expectedText = "text";

        Assert.Equal(expectedText, parameters.Text);
    }

    [Fact]
    public void Url_Works()
    {
        V1GetCitationsParams parameters = new() { Text = "text" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/legal/v1/citations"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new V1GetCitationsParams { Text = "text" };

        V1GetCitationsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
