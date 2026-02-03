using System;
using System.Text.Json;
using CaseDev.Core;
using CaseDev.Exceptions;
using CaseDev.Models.Payments.V1.Payouts;

namespace CaseDev.Tests.Models.Payments.V1.Payouts;

public class PayoutCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PayoutCreateParams
        {
            Amount = 0,
            DestinationType = DestinationType.BankAccount,
            FromAccountID = "from_account_id",
            Currency = "currency",
            Memo = "memo",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            PartyID = "party_id",
        };

        long expectedAmount = 0;
        ApiEnum<string, DestinationType> expectedDestinationType = DestinationType.BankAccount;
        string expectedFromAccountID = "from_account_id";
        string expectedCurrency = "currency";
        string expectedMemo = "memo";
        JsonElement expectedMetadata = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedPartyID = "party_id";

        Assert.Equal(expectedAmount, parameters.Amount);
        Assert.Equal(expectedDestinationType, parameters.DestinationType);
        Assert.Equal(expectedFromAccountID, parameters.FromAccountID);
        Assert.Equal(expectedCurrency, parameters.Currency);
        Assert.Equal(expectedMemo, parameters.Memo);
        Assert.NotNull(parameters.Metadata);
        Assert.True(JsonElement.DeepEquals(expectedMetadata, parameters.Metadata.Value));
        Assert.Equal(expectedPartyID, parameters.PartyID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new PayoutCreateParams
        {
            Amount = 0,
            DestinationType = DestinationType.BankAccount,
            FromAccountID = "from_account_id",
        };

        Assert.Null(parameters.Currency);
        Assert.False(parameters.RawBodyData.ContainsKey("currency"));
        Assert.Null(parameters.Memo);
        Assert.False(parameters.RawBodyData.ContainsKey("memo"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.PartyID);
        Assert.False(parameters.RawBodyData.ContainsKey("party_id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new PayoutCreateParams
        {
            Amount = 0,
            DestinationType = DestinationType.BankAccount,
            FromAccountID = "from_account_id",

            // Null should be interpreted as omitted for these properties
            Currency = null,
            Memo = null,
            Metadata = null,
            PartyID = null,
        };

        Assert.Null(parameters.Currency);
        Assert.False(parameters.RawBodyData.ContainsKey("currency"));
        Assert.Null(parameters.Memo);
        Assert.False(parameters.RawBodyData.ContainsKey("memo"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.PartyID);
        Assert.False(parameters.RawBodyData.ContainsKey("party_id"));
    }

    [Fact]
    public void Url_Works()
    {
        PayoutCreateParams parameters = new()
        {
            Amount = 0,
            DestinationType = DestinationType.BankAccount,
            FromAccountID = "from_account_id",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/payments/v1/payouts"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PayoutCreateParams
        {
            Amount = 0,
            DestinationType = DestinationType.BankAccount,
            FromAccountID = "from_account_id",
            Currency = "currency",
            Memo = "memo",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            PartyID = "party_id",
        };

        PayoutCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class DestinationTypeTest : TestBase
{
    [Theory]
    [InlineData(DestinationType.BankAccount)]
    [InlineData(DestinationType.Card)]
    public void Validation_Works(DestinationType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DestinationType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DestinationType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DestinationType.BankAccount)]
    [InlineData(DestinationType.Card)]
    public void SerializationRoundtrip_Works(DestinationType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DestinationType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DestinationType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DestinationType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DestinationType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
