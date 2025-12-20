using CaseDev.Models.Compute.V1.Secrets;

namespace CaseDev.Tests.Models.Compute.V1.Secrets;

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
}
