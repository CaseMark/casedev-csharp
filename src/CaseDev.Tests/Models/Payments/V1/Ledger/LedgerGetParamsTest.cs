using System;
using CaseDev.Models.Payments.V1.Ledger;

namespace CaseDev.Tests.Models.Payments.V1.Ledger;

public class LedgerGetParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new LedgerGetParams
        {
            AccountID = "account_id",
            Limit = 0,
            Offset = 0,
            TransactionID = "transaction_id",
        };

        string expectedAccountID = "account_id";
        long expectedLimit = 0;
        long expectedOffset = 0;
        string expectedTransactionID = "transaction_id";

        Assert.Equal(expectedAccountID, parameters.AccountID);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedOffset, parameters.Offset);
        Assert.Equal(expectedTransactionID, parameters.TransactionID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new LedgerGetParams { };

        Assert.Null(parameters.AccountID);
        Assert.False(parameters.RawQueryData.ContainsKey("account_id"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Offset);
        Assert.False(parameters.RawQueryData.ContainsKey("offset"));
        Assert.Null(parameters.TransactionID);
        Assert.False(parameters.RawQueryData.ContainsKey("transaction_id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new LedgerGetParams
        {
            // Null should be interpreted as omitted for these properties
            AccountID = null,
            Limit = null,
            Offset = null,
            TransactionID = null,
        };

        Assert.Null(parameters.AccountID);
        Assert.False(parameters.RawQueryData.ContainsKey("account_id"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Offset);
        Assert.False(parameters.RawQueryData.ContainsKey("offset"));
        Assert.Null(parameters.TransactionID);
        Assert.False(parameters.RawQueryData.ContainsKey("transaction_id"));
    }

    [Fact]
    public void Url_Works()
    {
        LedgerGetParams parameters = new()
        {
            AccountID = "account_id",
            Limit = 0,
            Offset = 0,
            TransactionID = "transaction_id",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.case.dev/payments/v1/ledger?account_id=account_id&limit=0&offset=0&transaction_id=transaction_id"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new LedgerGetParams
        {
            AccountID = "account_id",
            Limit = 0,
            Offset = 0,
            TransactionID = "transaction_id",
        };

        LedgerGetParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
