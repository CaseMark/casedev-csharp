using System;
using Casedev.Models.Matters.V1.Shares;

namespace Casedev.Tests.Models.Matters.V1.Shares;

public class ShareListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ShareListParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        ShareListParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/matters/v1/id/shares"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ShareListParams { ID = "id" };

        ShareListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
