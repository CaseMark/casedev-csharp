using System;
using Casedev.Models.Matters.V1.Shares;

namespace Casedev.Tests.Models.Matters.V1.Shares;

public class ShareDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ShareDeleteParams { ID = "id", ShareID = "shareId" };

        string expectedID = "id";
        string expectedShareID = "shareId";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedShareID, parameters.ShareID);
    }

    [Fact]
    public void Url_Works()
    {
        ShareDeleteParams parameters = new() { ID = "id", ShareID = "shareId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/matters/v1/id/shares/shareId"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ShareDeleteParams { ID = "id", ShareID = "shareId" };

        ShareDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
