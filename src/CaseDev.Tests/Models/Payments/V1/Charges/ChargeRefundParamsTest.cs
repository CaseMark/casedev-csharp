using System;
using CaseDev.Models.Payments.V1.Charges;

namespace CaseDev.Tests.Models.Payments.V1.Charges;

public class ChargeRefundParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ChargeRefundParams
        {
            ID = "id",
            Amount = 0,
            Reason = "reason",
        };

        string expectedID = "id";
        long expectedAmount = 0;
        string expectedReason = "reason";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedAmount, parameters.Amount);
        Assert.Equal(expectedReason, parameters.Reason);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ChargeRefundParams { ID = "id" };

        Assert.Null(parameters.Amount);
        Assert.False(parameters.RawBodyData.ContainsKey("amount"));
        Assert.Null(parameters.Reason);
        Assert.False(parameters.RawBodyData.ContainsKey("reason"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ChargeRefundParams
        {
            ID = "id",

            // Null should be interpreted as omitted for these properties
            Amount = null,
            Reason = null,
        };

        Assert.Null(parameters.Amount);
        Assert.False(parameters.RawBodyData.ContainsKey("amount"));
        Assert.Null(parameters.Reason);
        Assert.False(parameters.RawBodyData.ContainsKey("reason"));
    }

    [Fact]
    public void Url_Works()
    {
        ChargeRefundParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/payments/v1/charges/id/refund"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ChargeRefundParams
        {
            ID = "id",
            Amount = 0,
            Reason = "reason",
        };

        ChargeRefundParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
