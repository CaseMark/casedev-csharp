using System;
using CaseDev.Models.Payments.V1.Transfers;

namespace CaseDev.Tests.Models.Payments.V1.Transfers;

public class TransferRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TransferRetrieveParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        TransferRetrieveParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/payments/v1/transfers/id"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TransferRetrieveParams { ID = "id" };

        TransferRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
