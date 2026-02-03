using System;
using System.Text.Json;
using CaseDev.Models.Payments.V1.Transfers;

namespace CaseDev.Tests.Models.Payments.V1.Transfers;

public class TransferCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TransferCreateParams
        {
            Amount = 0,
            FromAccountID = "from_account_id",
            ToAccountID = "to_account_id",
            Memo = "memo",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        long expectedAmount = 0;
        string expectedFromAccountID = "from_account_id";
        string expectedToAccountID = "to_account_id";
        string expectedMemo = "memo";
        JsonElement expectedMetadata = JsonSerializer.Deserialize<JsonElement>("{}");

        Assert.Equal(expectedAmount, parameters.Amount);
        Assert.Equal(expectedFromAccountID, parameters.FromAccountID);
        Assert.Equal(expectedToAccountID, parameters.ToAccountID);
        Assert.Equal(expectedMemo, parameters.Memo);
        Assert.NotNull(parameters.Metadata);
        Assert.True(JsonElement.DeepEquals(expectedMetadata, parameters.Metadata.Value));
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TransferCreateParams
        {
            Amount = 0,
            FromAccountID = "from_account_id",
            ToAccountID = "to_account_id",
        };

        Assert.Null(parameters.Memo);
        Assert.False(parameters.RawBodyData.ContainsKey("memo"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new TransferCreateParams
        {
            Amount = 0,
            FromAccountID = "from_account_id",
            ToAccountID = "to_account_id",

            // Null should be interpreted as omitted for these properties
            Memo = null,
            Metadata = null,
        };

        Assert.Null(parameters.Memo);
        Assert.False(parameters.RawBodyData.ContainsKey("memo"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
    }

    [Fact]
    public void Url_Works()
    {
        TransferCreateParams parameters = new()
        {
            Amount = 0,
            FromAccountID = "from_account_id",
            ToAccountID = "to_account_id",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/payments/v1/transfers"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TransferCreateParams
        {
            Amount = 0,
            FromAccountID = "from_account_id",
            ToAccountID = "to_account_id",
            Memo = "memo",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        TransferCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
