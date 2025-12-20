using CaseDev.Models.Vault;

namespace CaseDev.Tests.Models.Vault;

public class VaultCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new VaultCreateParams
        {
            Name = "Contract Review Archive",
            Description = "Repository for all client contract reviews and analysis",
            EnableGraph = true,
        };

        string expectedName = "Contract Review Archive";
        string expectedDescription = "Repository for all client contract reviews and analysis";
        bool expectedEnableGraph = true;

        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedEnableGraph, parameters.EnableGraph);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new VaultCreateParams { Name = "Contract Review Archive" };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.EnableGraph);
        Assert.False(parameters.RawBodyData.ContainsKey("enableGraph"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new VaultCreateParams
        {
            Name = "Contract Review Archive",

            // Null should be interpreted as omitted for these properties
            Description = null,
            EnableGraph = null,
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.EnableGraph);
        Assert.False(parameters.RawBodyData.ContainsKey("enableGraph"));
    }
}
