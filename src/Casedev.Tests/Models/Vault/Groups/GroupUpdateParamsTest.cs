using System;
using Casedev.Models.Vault.Groups;

namespace Casedev.Tests.Models.Vault.Groups;

public class GroupUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new GroupUpdateParams
        {
            GroupID = "groupId",
            Description = "description",
            Name = "name",
        };

        string expectedGroupID = "groupId";
        string expectedDescription = "description";
        string expectedName = "name";

        Assert.Equal(expectedGroupID, parameters.GroupID);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedName, parameters.Name);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new GroupUpdateParams { GroupID = "groupId", Description = "description" };

        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new GroupUpdateParams
        {
            GroupID = "groupId",
            Description = "description",

            // Null should be interpreted as omitted for these properties
            Name = null,
        };

        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new GroupUpdateParams { GroupID = "groupId", Name = "name" };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new GroupUpdateParams
        {
            GroupID = "groupId",
            Name = "name",

            Description = null,
        };

        Assert.Null(parameters.Description);
        Assert.True(parameters.RawBodyData.ContainsKey("description"));
    }

    [Fact]
    public void Url_Works()
    {
        GroupUpdateParams parameters = new() { GroupID = "groupId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/vault/groups/groupId"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new GroupUpdateParams
        {
            GroupID = "groupId",
            Description = "description",
            Name = "name",
        };

        GroupUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
