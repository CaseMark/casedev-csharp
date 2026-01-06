using System;
using CaseDev.Models.Compute.V1.Secrets;

namespace CaseDev.Tests.Models.Compute.V1.Secrets;

public class SecretListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SecretListParams { Env = "env" };

        string expectedEnv = "env";

        Assert.Equal(expectedEnv, parameters.Env);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SecretListParams { };

        Assert.Null(parameters.Env);
        Assert.False(parameters.RawQueryData.ContainsKey("env"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new SecretListParams
        {
            // Null should be interpreted as omitted for these properties
            Env = null,
        };

        Assert.Null(parameters.Env);
        Assert.False(parameters.RawQueryData.ContainsKey("env"));
    }

    [Fact]
    public void Url_Works()
    {
        SecretListParams parameters = new() { Env = "env" };

        var url = parameters.Url(new() { APIKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/compute/v1/secrets?env=env"), url);
    }
}
