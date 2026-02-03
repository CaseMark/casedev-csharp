using System;
using CaseDev.Models.Payments.V1.Holds;

namespace CaseDev.Tests.Models.Payments.V1.Holds;

public class HoldReleaseParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new HoldReleaseParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        HoldReleaseParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/payments/v1/holds/id/release"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new HoldReleaseParams { ID = "id" };

        HoldReleaseParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
