using System;
using CaseDev.Models.Vault;

namespace CaseDev.Tests.Models.Vault;

public class VaultUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new VaultUpdateParams
        {
            ID = "id",
            Description = "description",
            EnableGraph = false,
            Name = "Updated Vault Name",
        };

        string expectedID = "id";
        string expectedDescription = "description";
        bool expectedEnableGraph = false;
        string expectedName = "Updated Vault Name";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedEnableGraph, parameters.EnableGraph);
        Assert.Equal(expectedName, parameters.Name);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new VaultUpdateParams { ID = "id", Description = "description" };

        Assert.Null(parameters.EnableGraph);
        Assert.False(parameters.RawBodyData.ContainsKey("enableGraph"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new VaultUpdateParams
        {
            ID = "id",
            Description = "description",

            // Null should be interpreted as omitted for these properties
            EnableGraph = null,
            Name = null,
        };

        Assert.Null(parameters.EnableGraph);
        Assert.False(parameters.RawBodyData.ContainsKey("enableGraph"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new VaultUpdateParams
        {
            ID = "id",
            EnableGraph = false,
            Name = "Updated Vault Name",
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new VaultUpdateParams
        {
            ID = "id",
            EnableGraph = false,
            Name = "Updated Vault Name",

            Description = null,
        };

        Assert.Null(parameters.Description);
        Assert.True(parameters.RawBodyData.ContainsKey("description"));
    }

    [Fact]
    public void Url_Works()
    {
        VaultUpdateParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/vault/id"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new VaultUpdateParams
        {
            ID = "id",
            Description = "description",
            EnableGraph = false,
            Name = "Updated Vault Name",
        };

        VaultUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
