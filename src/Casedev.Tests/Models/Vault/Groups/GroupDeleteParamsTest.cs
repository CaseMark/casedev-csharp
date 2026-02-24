using System;
using Casedev.Models.Vault.Groups;

namespace Casedev.Tests.Models.Vault.Groups;

public class GroupDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new GroupDeleteParams { GroupID = "groupId" };

        string expectedGroupID = "groupId";

        Assert.Equal(expectedGroupID, parameters.GroupID);
    }

    [Fact]
    public void Url_Works()
    {
        GroupDeleteParams parameters = new() { GroupID = "groupId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/vault/groups/groupId"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new GroupDeleteParams { GroupID = "groupId" };

        GroupDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
