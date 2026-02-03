using System;
using CaseDev.Models.Payments.V1.Accounts;

namespace CaseDev.Tests.Models.Payments.V1.Accounts;

public class AccountListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AccountListParams
        {
            Limit = 0,
            MatterID = "matter_id",
            Offset = 0,
            ParentAccountID = "parent_account_id",
            Type = "type",
        };

        long expectedLimit = 0;
        string expectedMatterID = "matter_id";
        long expectedOffset = 0;
        string expectedParentAccountID = "parent_account_id";
        string expectedType = "type";

        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedMatterID, parameters.MatterID);
        Assert.Equal(expectedOffset, parameters.Offset);
        Assert.Equal(expectedParentAccountID, parameters.ParentAccountID);
        Assert.Equal(expectedType, parameters.Type);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AccountListParams { };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.MatterID);
        Assert.False(parameters.RawQueryData.ContainsKey("matter_id"));
        Assert.Null(parameters.Offset);
        Assert.False(parameters.RawQueryData.ContainsKey("offset"));
        Assert.Null(parameters.ParentAccountID);
        Assert.False(parameters.RawQueryData.ContainsKey("parent_account_id"));
        Assert.Null(parameters.Type);
        Assert.False(parameters.RawQueryData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new AccountListParams
        {
            // Null should be interpreted as omitted for these properties
            Limit = null,
            MatterID = null,
            Offset = null,
            ParentAccountID = null,
            Type = null,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.MatterID);
        Assert.False(parameters.RawQueryData.ContainsKey("matter_id"));
        Assert.Null(parameters.Offset);
        Assert.False(parameters.RawQueryData.ContainsKey("offset"));
        Assert.Null(parameters.ParentAccountID);
        Assert.False(parameters.RawQueryData.ContainsKey("parent_account_id"));
        Assert.Null(parameters.Type);
        Assert.False(parameters.RawQueryData.ContainsKey("type"));
    }

    [Fact]
    public void Url_Works()
    {
        AccountListParams parameters = new()
        {
            Limit = 0,
            MatterID = "matter_id",
            Offset = 0,
            ParentAccountID = "parent_account_id",
            Type = "type",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.case.dev/payments/v1/accounts?limit=0&matter_id=matter_id&offset=0&parent_account_id=parent_account_id&type=type"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AccountListParams
        {
            Limit = 0,
            MatterID = "matter_id",
            Offset = 0,
            ParentAccountID = "parent_account_id",
            Type = "type",
        };

        AccountListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
