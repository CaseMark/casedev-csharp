using System;
using System.Collections.Generic;
using CaseDev.Models.Compute.V1.Secrets;

namespace CaseDev.Tests.Models.Compute.V1.Secrets;

public class SecretUpdateGroupParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SecretUpdateGroupParams
        {
            Group = "litigation-apis",
            Secrets = new Dictionary<string, string>() { { "foo", "string" } },
            Env = "env",
        };

        string expectedGroup = "litigation-apis";
        Dictionary<string, string> expectedSecrets = new() { { "foo", "string" } };
        string expectedEnv = "env";

        Assert.Equal(expectedGroup, parameters.Group);
        Assert.Equal(expectedSecrets.Count, parameters.Secrets.Count);
        foreach (var item in expectedSecrets)
        {
            Assert.True(parameters.Secrets.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Secrets[item.Key]);
        }
        Assert.Equal(expectedEnv, parameters.Env);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SecretUpdateGroupParams
        {
            Group = "litigation-apis",
            Secrets = new Dictionary<string, string>() { { "foo", "string" } },
        };

        Assert.Null(parameters.Env);
        Assert.False(parameters.RawBodyData.ContainsKey("env"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new SecretUpdateGroupParams
        {
            Group = "litigation-apis",
            Secrets = new Dictionary<string, string>() { { "foo", "string" } },

            // Null should be interpreted as omitted for these properties
            Env = null,
        };

        Assert.Null(parameters.Env);
        Assert.False(parameters.RawBodyData.ContainsKey("env"));
    }

    [Fact]
    public void Url_Works()
    {
        SecretUpdateGroupParams parameters = new()
        {
            Group = "litigation-apis",
            Secrets = new Dictionary<string, string>() { { "foo", "string" } },
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/compute/v1/secrets/litigation-apis"), url);
    }
}
