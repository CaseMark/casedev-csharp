using System;
using Router.Models.Compute.V1.Environments;

namespace Router.Tests.Models.Compute.V1.Environments;

public class EnvironmentCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EnvironmentCreateParams { Name = "document-review-prod" };

        string expectedName = "document-review-prod";

        Assert.Equal(expectedName, parameters.Name);
    }

    [Fact]
    public void Url_Works()
    {
        EnvironmentCreateParams parameters = new() { Name = "document-review-prod" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/compute/v1/environments"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new EnvironmentCreateParams { Name = "document-review-prod" };

        EnvironmentCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
