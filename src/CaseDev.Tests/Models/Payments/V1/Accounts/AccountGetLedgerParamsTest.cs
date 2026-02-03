using System;
using CaseDev.Models.Payments.V1.Accounts;

namespace CaseDev.Tests.Models.Payments.V1.Accounts;

public class AccountGetLedgerParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AccountGetLedgerParams
        {
            ID = "id",
            Limit = 0,
            Offset = 0,
        };

        string expectedID = "id";
        long expectedLimit = 0;
        long expectedOffset = 0;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedOffset, parameters.Offset);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AccountGetLedgerParams { ID = "id" };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Offset);
        Assert.False(parameters.RawQueryData.ContainsKey("offset"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new AccountGetLedgerParams
        {
            ID = "id",

            // Null should be interpreted as omitted for these properties
            Limit = null,
            Offset = null,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Offset);
        Assert.False(parameters.RawQueryData.ContainsKey("offset"));
    }

    [Fact]
    public void Url_Works()
    {
        AccountGetLedgerParams parameters = new()
        {
            ID = "id",
            Limit = 0,
            Offset = 0,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.case.dev/payments/v1/accounts/id/ledger?limit=0&offset=0"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AccountGetLedgerParams
        {
            ID = "id",
            Limit = 0,
            Offset = 0,
        };

        AccountGetLedgerParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
