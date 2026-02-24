using System;
using Casedev.Models.Compute.V1.Secrets;

namespace Casedev.Tests.Models.Compute.V1.Secrets;

public class SecretRetrieveGroupParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SecretRetrieveGroupParams { Group = "group", Env = "env" };

        string expectedGroup = "group";
        string expectedEnv = "env";

        Assert.Equal(expectedGroup, parameters.Group);
        Assert.Equal(expectedEnv, parameters.Env);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SecretRetrieveGroupParams { Group = "group" };

        Assert.Null(parameters.Env);
        Assert.False(parameters.RawQueryData.ContainsKey("env"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new SecretRetrieveGroupParams
        {
            Group = "group",

            // Null should be interpreted as omitted for these properties
            Env = null,
        };

        Assert.Null(parameters.Env);
        Assert.False(parameters.RawQueryData.ContainsKey("env"));
    }

    [Fact]
    public void Url_Works()
    {
        SecretRetrieveGroupParams parameters = new() { Group = "group", Env = "env" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/compute/v1/secrets/group?env=env"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SecretRetrieveGroupParams { Group = "group", Env = "env" };

        SecretRetrieveGroupParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
