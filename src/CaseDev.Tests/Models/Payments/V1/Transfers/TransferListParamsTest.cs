using System;
using CaseDev.Models.Payments.V1.Transfers;

namespace CaseDev.Tests.Models.Payments.V1.Transfers;

public class TransferListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TransferListParams
        {
            FromAccountID = "from_account_id",
            Limit = 0,
            Offset = 0,
            Status = "status",
            ToAccountID = "to_account_id",
        };

        string expectedFromAccountID = "from_account_id";
        long expectedLimit = 0;
        long expectedOffset = 0;
        string expectedStatus = "status";
        string expectedToAccountID = "to_account_id";

        Assert.Equal(expectedFromAccountID, parameters.FromAccountID);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedOffset, parameters.Offset);
        Assert.Equal(expectedStatus, parameters.Status);
        Assert.Equal(expectedToAccountID, parameters.ToAccountID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TransferListParams { };

        Assert.Null(parameters.FromAccountID);
        Assert.False(parameters.RawQueryData.ContainsKey("from_account_id"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Offset);
        Assert.False(parameters.RawQueryData.ContainsKey("offset"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawQueryData.ContainsKey("status"));
        Assert.Null(parameters.ToAccountID);
        Assert.False(parameters.RawQueryData.ContainsKey("to_account_id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new TransferListParams
        {
            // Null should be interpreted as omitted for these properties
            FromAccountID = null,
            Limit = null,
            Offset = null,
            Status = null,
            ToAccountID = null,
        };

        Assert.Null(parameters.FromAccountID);
        Assert.False(parameters.RawQueryData.ContainsKey("from_account_id"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Offset);
        Assert.False(parameters.RawQueryData.ContainsKey("offset"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawQueryData.ContainsKey("status"));
        Assert.Null(parameters.ToAccountID);
        Assert.False(parameters.RawQueryData.ContainsKey("to_account_id"));
    }

    [Fact]
    public void Url_Works()
    {
        TransferListParams parameters = new()
        {
            FromAccountID = "from_account_id",
            Limit = 0,
            Offset = 0,
            Status = "status",
            ToAccountID = "to_account_id",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.case.dev/payments/v1/transfers?from_account_id=from_account_id&limit=0&offset=0&status=status&to_account_id=to_account_id"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TransferListParams
        {
            FromAccountID = "from_account_id",
            Limit = 0,
            Offset = 0,
            Status = "status",
            ToAccountID = "to_account_id",
        };

        TransferListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
