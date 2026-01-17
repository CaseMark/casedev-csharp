using System;
using CaseDev.Models.Compute.V1.Environments;

namespace CaseDev.Tests.Models.Compute.V1.Environments;

public class EnvironmentDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EnvironmentDeleteParams { Name = "litigation-processing" };

        string expectedName = "litigation-processing";

        Assert.Equal(expectedName, parameters.Name);
    }

    [Fact]
    public void Url_Works()
    {
        EnvironmentDeleteParams parameters = new() { Name = "litigation-processing" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.case.dev/compute/v1/environments/litigation-processing"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new EnvironmentDeleteParams { Name = "litigation-processing" };

        EnvironmentDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
