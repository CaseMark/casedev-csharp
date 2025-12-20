using CaseDev.Models.Compute.V1.Secrets;

namespace CaseDev.Tests.Models.Compute.V1.Secrets;

public class SecretDeleteGroupParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SecretDeleteGroupParams
        {
            Group = "group",
            Env = "env",
            Key = "key",
        };

        string expectedGroup = "group";
        string expectedEnv = "env";
        string expectedKey = "key";

        Assert.Equal(expectedGroup, parameters.Group);
        Assert.Equal(expectedEnv, parameters.Env);
        Assert.Equal(expectedKey, parameters.Key);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SecretDeleteGroupParams { Group = "group" };

        Assert.Null(parameters.Env);
        Assert.False(parameters.RawQueryData.ContainsKey("env"));
        Assert.Null(parameters.Key);
        Assert.False(parameters.RawQueryData.ContainsKey("key"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new SecretDeleteGroupParams
        {
            Group = "group",

            // Null should be interpreted as omitted for these properties
            Env = null,
            Key = null,
        };

        Assert.Null(parameters.Env);
        Assert.False(parameters.RawQueryData.ContainsKey("env"));
        Assert.Null(parameters.Key);
        Assert.False(parameters.RawQueryData.ContainsKey("key"));
    }
}
