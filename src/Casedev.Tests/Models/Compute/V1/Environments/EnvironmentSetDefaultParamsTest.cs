using System;
using Casedev.Models.Compute.V1.Environments;

namespace Casedev.Tests.Models.Compute.V1.Environments;

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

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.case.dev/compute/v1/environments/prod-legal-docs/default"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new EnvironmentSetDefaultParams { Name = "prod-legal-docs" };

        EnvironmentSetDefaultParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
