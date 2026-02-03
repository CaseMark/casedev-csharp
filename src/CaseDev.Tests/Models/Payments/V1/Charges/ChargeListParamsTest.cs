using System;
using CaseDev.Models.Payments.V1.Charges;

namespace CaseDev.Tests.Models.Payments.V1.Charges;

public class ChargeListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ChargeListParams
        {
            DestinationAccountID = "destination_account_id",
            Limit = 0,
            Offset = 0,
            PartyID = "party_id",
            Status = "status",
        };

        string expectedDestinationAccountID = "destination_account_id";
        long expectedLimit = 0;
        long expectedOffset = 0;
        string expectedPartyID = "party_id";
        string expectedStatus = "status";

        Assert.Equal(expectedDestinationAccountID, parameters.DestinationAccountID);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedOffset, parameters.Offset);
        Assert.Equal(expectedPartyID, parameters.PartyID);
        Assert.Equal(expectedStatus, parameters.Status);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ChargeListParams { };

        Assert.Null(parameters.DestinationAccountID);
        Assert.False(parameters.RawQueryData.ContainsKey("destination_account_id"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Offset);
        Assert.False(parameters.RawQueryData.ContainsKey("offset"));
        Assert.Null(parameters.PartyID);
        Assert.False(parameters.RawQueryData.ContainsKey("party_id"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawQueryData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ChargeListParams
        {
            // Null should be interpreted as omitted for these properties
            DestinationAccountID = null,
            Limit = null,
            Offset = null,
            PartyID = null,
            Status = null,
        };

        Assert.Null(parameters.DestinationAccountID);
        Assert.False(parameters.RawQueryData.ContainsKey("destination_account_id"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Offset);
        Assert.False(parameters.RawQueryData.ContainsKey("offset"));
        Assert.Null(parameters.PartyID);
        Assert.False(parameters.RawQueryData.ContainsKey("party_id"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawQueryData.ContainsKey("status"));
    }

    [Fact]
    public void Url_Works()
    {
        ChargeListParams parameters = new()
        {
            DestinationAccountID = "destination_account_id",
            Limit = 0,
            Offset = 0,
            PartyID = "party_id",
            Status = "status",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.case.dev/payments/v1/charges?destination_account_id=destination_account_id&limit=0&offset=0&party_id=party_id&status=status"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ChargeListParams
        {
            DestinationAccountID = "destination_account_id",
            Limit = 0,
            Offset = 0,
            PartyID = "party_id",
            Status = "status",
        };

        ChargeListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
