using System;
using Casedev.Models.Compute.V1.Secrets;

namespace Casedev.Tests.Models.Compute.V1.Secrets;

public class SecretCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SecretCreateParams
        {
            Name = "name",
            Description = "description",
            Env = "env",
        };

        string expectedName = "name";
        string expectedDescription = "description";
        string expectedEnv = "env";

        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedEnv, parameters.Env);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SecretCreateParams { Name = "name" };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Env);
        Assert.False(parameters.RawBodyData.ContainsKey("env"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new SecretCreateParams
        {
            Name = "name",

            // Null should be interpreted as omitted for these properties
            Description = null,
            Env = null,
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Env);
        Assert.False(parameters.RawBodyData.ContainsKey("env"));
    }

    [Fact]
    public void Url_Works()
    {
        SecretCreateParams parameters = new() { Name = "name" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/compute/v1/secrets"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SecretCreateParams
        {
            Name = "name",
            Description = "description",
            Env = "env",
        };

        SecretCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
