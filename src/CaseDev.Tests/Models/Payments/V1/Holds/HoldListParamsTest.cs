using System;
using CaseDev.Models.Payments.V1.Holds;

namespace CaseDev.Tests.Models.Payments.V1.Holds;

public class HoldListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new HoldListParams
        {
            AccountID = "account_id",
            Limit = 0,
            Offset = 0,
            Status = "status",
        };

        string expectedAccountID = "account_id";
        long expectedLimit = 0;
        long expectedOffset = 0;
        string expectedStatus = "status";

        Assert.Equal(expectedAccountID, parameters.AccountID);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedOffset, parameters.Offset);
        Assert.Equal(expectedStatus, parameters.Status);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new HoldListParams { };

        Assert.Null(parameters.AccountID);
        Assert.False(parameters.RawQueryData.ContainsKey("account_id"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Offset);
        Assert.False(parameters.RawQueryData.ContainsKey("offset"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawQueryData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new HoldListParams
        {
            // Null should be interpreted as omitted for these properties
            AccountID = null,
            Limit = null,
            Offset = null,
            Status = null,
        };

        Assert.Null(parameters.AccountID);
        Assert.False(parameters.RawQueryData.ContainsKey("account_id"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Offset);
        Assert.False(parameters.RawQueryData.ContainsKey("offset"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawQueryData.ContainsKey("status"));
    }

    [Fact]
    public void Url_Works()
    {
        HoldListParams parameters = new()
        {
            AccountID = "account_id",
            Limit = 0,
            Offset = 0,
            Status = "status",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.case.dev/payments/v1/holds?account_id=account_id&limit=0&offset=0&status=status"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new HoldListParams
        {
            AccountID = "account_id",
            Limit = 0,
            Offset = 0,
            Status = "status",
        };

        HoldListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
