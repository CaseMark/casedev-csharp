using System;
using Casedev.Models.Webhooks.V1.Deliveries;

namespace Casedev.Tests.Models.Webhooks.V1.Deliveries;

public class DeliveryRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DeliveryRetrieveParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        DeliveryRetrieveParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.case.dev/webhooks/v1/deliveries/id"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new DeliveryRetrieveParams { ID = "id" };

        DeliveryRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
