using System;
using Router.Models.Legal.V1;

namespace Router.Tests.Models.Legal.V1;

public class V1ListJurisdictionsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new V1ListJurisdictionsParams { Name = "xx" };

        string expectedName = "xx";

        Assert.Equal(expectedName, parameters.Name);
    }

    [Fact]
    public void Url_Works()
    {
        V1ListJurisdictionsParams parameters = new() { Name = "xx" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/legal/v1/jurisdictions"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new V1ListJurisdictionsParams { Name = "xx" };

        V1ListJurisdictionsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
