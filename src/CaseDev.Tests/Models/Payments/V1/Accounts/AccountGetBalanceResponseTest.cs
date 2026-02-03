using System.Text.Json;
using CaseDev.Core;
using CaseDev.Models.Payments.V1.Accounts;

namespace CaseDev.Tests.Models.Payments.V1.Accounts;

public class AccountGetBalanceResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AccountGetBalanceResponse
        {
            AccountID = "accountId",
            AvailableBalance = 0,
            Balance = 0,
            Currency = "currency",
            HeldAmount = 0,
            PendingCharges = 0,
        };

        string expectedAccountID = "accountId";
        double expectedAvailableBalance = 0;
        double expectedBalance = 0;
        string expectedCurrency = "currency";
        double expectedHeldAmount = 0;
        double expectedPendingCharges = 0;

        Assert.Equal(expectedAccountID, model.AccountID);
        Assert.Equal(expectedAvailableBalance, model.AvailableBalance);
        Assert.Equal(expectedBalance, model.Balance);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedHeldAmount, model.HeldAmount);
        Assert.Equal(expectedPendingCharges, model.PendingCharges);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AccountGetBalanceResponse
        {
            AccountID = "accountId",
            AvailableBalance = 0,
            Balance = 0,
            Currency = "currency",
            HeldAmount = 0,
            PendingCharges = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountGetBalanceResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AccountGetBalanceResponse
        {
            AccountID = "accountId",
            AvailableBalance = 0,
            Balance = 0,
            Currency = "currency",
            HeldAmount = 0,
            PendingCharges = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountGetBalanceResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAccountID = "accountId";
        double expectedAvailableBalance = 0;
        double expectedBalance = 0;
        string expectedCurrency = "currency";
        double expectedHeldAmount = 0;
        double expectedPendingCharges = 0;

        Assert.Equal(expectedAccountID, deserialized.AccountID);
        Assert.Equal(expectedAvailableBalance, deserialized.AvailableBalance);
        Assert.Equal(expectedBalance, deserialized.Balance);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedHeldAmount, deserialized.HeldAmount);
        Assert.Equal(expectedPendingCharges, deserialized.PendingCharges);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AccountGetBalanceResponse
        {
            AccountID = "accountId",
            AvailableBalance = 0,
            Balance = 0,
            Currency = "currency",
            HeldAmount = 0,
            PendingCharges = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AccountGetBalanceResponse { };

        Assert.Null(model.AccountID);
        Assert.False(model.RawData.ContainsKey("accountId"));
        Assert.Null(model.AvailableBalance);
        Assert.False(model.RawData.ContainsKey("availableBalance"));
        Assert.Null(model.Balance);
        Assert.False(model.RawData.ContainsKey("balance"));
        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
        Assert.Null(model.HeldAmount);
        Assert.False(model.RawData.ContainsKey("heldAmount"));
        Assert.Null(model.PendingCharges);
        Assert.False(model.RawData.ContainsKey("pendingCharges"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new AccountGetBalanceResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AccountGetBalanceResponse
        {
            // Null should be interpreted as omitted for these properties
            AccountID = null,
            AvailableBalance = null,
            Balance = null,
            Currency = null,
            HeldAmount = null,
            PendingCharges = null,
        };

        Assert.Null(model.AccountID);
        Assert.False(model.RawData.ContainsKey("accountId"));
        Assert.Null(model.AvailableBalance);
        Assert.False(model.RawData.ContainsKey("availableBalance"));
        Assert.Null(model.Balance);
        Assert.False(model.RawData.ContainsKey("balance"));
        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
        Assert.Null(model.HeldAmount);
        Assert.False(model.RawData.ContainsKey("heldAmount"));
        Assert.Null(model.PendingCharges);
        Assert.False(model.RawData.ContainsKey("pendingCharges"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AccountGetBalanceResponse
        {
            // Null should be interpreted as omitted for these properties
            AccountID = null,
            AvailableBalance = null,
            Balance = null,
            Currency = null,
            HeldAmount = null,
            PendingCharges = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AccountGetBalanceResponse
        {
            AccountID = "accountId",
            AvailableBalance = 0,
            Balance = 0,
            Currency = "currency",
            HeldAmount = 0,
            PendingCharges = 0,
        };

        AccountGetBalanceResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
