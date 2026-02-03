using System;
using CaseDev.Models.Payments.V1.Parties;

namespace CaseDev.Tests.Models.Payments.V1.Parties;

public class PartyRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PartyRetrieveParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        PartyRetrieveParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/payments/v1/parties/id"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PartyRetrieveParams { ID = "id" };

        PartyRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
