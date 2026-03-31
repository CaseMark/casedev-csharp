using System;
using Casedev.Models.Matters.V1.Parties;

namespace Casedev.Tests.Models.Matters.V1.Parties;

public class PartyUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PartyUpdateParams { PartyID = "partyId" };

        string expectedPartyID = "partyId";

        Assert.Equal(expectedPartyID, parameters.PartyID);
    }

    [Fact]
    public void Url_Works()
    {
        PartyUpdateParams parameters = new() { PartyID = "partyId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/matters/v1/parties/partyId"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PartyUpdateParams { PartyID = "partyId" };

        PartyUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
