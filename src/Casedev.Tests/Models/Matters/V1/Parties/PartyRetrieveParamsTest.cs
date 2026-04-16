using System;
using Casedev.Models.Matters.V1.Parties;

namespace Casedev.Tests.Models.Matters.V1.Parties;

public class PartyRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PartyRetrieveParams { PartyID = "partyId" };

        string expectedPartyID = "partyId";

        Assert.Equal(expectedPartyID, parameters.PartyID);
    }

    [Fact]
    public void Url_Works()
    {
        PartyRetrieveParams parameters = new() { PartyID = "partyId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.case.dev/matters/v1/parties/partyId"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PartyRetrieveParams { PartyID = "partyId" };

        PartyRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
