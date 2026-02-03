using System;
using System.Collections.Generic;
using System.Text.Json;
using CaseDev.Models.Payments.V1.Charges;

namespace CaseDev.Tests.Models.Payments.V1.Charges;

public class ChargeCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ChargeCreateParams
        {
            Amount = 0,
            DestinationAccountID = "destination_account_id",
            PartyID = "party_id",
            Currency = "currency",
            Description = "description",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            PaymentMethods = ["string"],
        };

        long expectedAmount = 0;
        string expectedDestinationAccountID = "destination_account_id";
        string expectedPartyID = "party_id";
        string expectedCurrency = "currency";
        string expectedDescription = "description";
        JsonElement expectedMetadata = JsonSerializer.Deserialize<JsonElement>("{}");
        List<string> expectedPaymentMethods = ["string"];

        Assert.Equal(expectedAmount, parameters.Amount);
        Assert.Equal(expectedDestinationAccountID, parameters.DestinationAccountID);
        Assert.Equal(expectedPartyID, parameters.PartyID);
        Assert.Equal(expectedCurrency, parameters.Currency);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.NotNull(parameters.Metadata);
        Assert.True(JsonElement.DeepEquals(expectedMetadata, parameters.Metadata.Value));
        Assert.NotNull(parameters.PaymentMethods);
        Assert.Equal(expectedPaymentMethods.Count, parameters.PaymentMethods.Count);
        for (int i = 0; i < expectedPaymentMethods.Count; i++)
        {
            Assert.Equal(expectedPaymentMethods[i], parameters.PaymentMethods[i]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ChargeCreateParams
        {
            Amount = 0,
            DestinationAccountID = "destination_account_id",
            PartyID = "party_id",
        };

        Assert.Null(parameters.Currency);
        Assert.False(parameters.RawBodyData.ContainsKey("currency"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.PaymentMethods);
        Assert.False(parameters.RawBodyData.ContainsKey("payment_methods"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ChargeCreateParams
        {
            Amount = 0,
            DestinationAccountID = "destination_account_id",
            PartyID = "party_id",

            // Null should be interpreted as omitted for these properties
            Currency = null,
            Description = null,
            Metadata = null,
            PaymentMethods = null,
        };

        Assert.Null(parameters.Currency);
        Assert.False(parameters.RawBodyData.ContainsKey("currency"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.PaymentMethods);
        Assert.False(parameters.RawBodyData.ContainsKey("payment_methods"));
    }

    [Fact]
    public void Url_Works()
    {
        ChargeCreateParams parameters = new()
        {
            Amount = 0,
            DestinationAccountID = "destination_account_id",
            PartyID = "party_id",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/payments/v1/charges"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ChargeCreateParams
        {
            Amount = 0,
            DestinationAccountID = "destination_account_id",
            PartyID = "party_id",
            Currency = "currency",
            Description = "description",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            PaymentMethods = ["string"],
        };

        ChargeCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
