using System;
using CaseDev.Models.Vault.Groups;

namespace CaseDev.Tests.Models.Vault.Groups;

public class GroupUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new GroupUpdateParams { GroupID = "groupId" };

        string expectedGroupID = "groupId";

        Assert.Equal(expectedGroupID, parameters.GroupID);
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
        var parameters = new GroupUpdateParams { GroupID = "groupId" };

        GroupUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
