using System;
using CaseDev.Models.Payments.V1.Charges;

namespace CaseDev.Tests.Models.Payments.V1.Charges;

public class ChargeCancelParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ChargeCancelParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        ChargeCancelParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/payments/v1/charges/id/cancel"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ChargeCancelParams { ID = "id" };

        ChargeCancelParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
