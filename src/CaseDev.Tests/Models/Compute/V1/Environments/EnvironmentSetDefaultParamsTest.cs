using System;
using CaseDev.Models.Compute.V1.Environments;

namespace CaseDev.Tests.Models.Compute.V1.Environments;

public class EnvironmentSetDefaultParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EnvironmentSetDefaultParams { Name = "prod-legal-docs" };

        string expectedName = "prod-legal-docs";

        Assert.Equal(expectedName, parameters.Name);
    }

    [Fact]
    public void Url_Works()
    {
        EnvironmentSetDefaultParams parameters = new() { Name = "prod-legal-docs" };

        var url = parameters.Url(new() { APIKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.case.dev/compute/v1/environments/prod-legal-docs/default"),
            url
        );
    }
}
