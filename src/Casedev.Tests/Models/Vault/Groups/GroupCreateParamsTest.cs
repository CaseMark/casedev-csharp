using System;
using Casedev.Models.Vault.Groups;

namespace Casedev.Tests.Models.Vault.Groups;

public class GroupCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new GroupCreateParams { Name = "name", Description = "description" };

        string expectedName = "name";
        string expectedDescription = "description";

        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedDescription, parameters.Description);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new GroupCreateParams { Name = "name" };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new GroupCreateParams
        {
            Name = "name",

            // Null should be interpreted as omitted for these properties
            Description = null,
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
    }

    [Fact]
    public void Url_Works()
    {
        GroupCreateParams parameters = new() { Name = "name" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.case.dev/vault/groups"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new GroupCreateParams { Name = "name", Description = "description" };

        GroupCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
