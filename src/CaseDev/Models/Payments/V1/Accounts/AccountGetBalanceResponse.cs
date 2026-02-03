using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;

namespace CaseDev.Models.Payments.V1.Accounts;

[JsonConverter(
    typeof(JsonModelConverter<AccountGetBalanceResponse, AccountGetBalanceResponseFromRaw>)
)]
public sealed record class AccountGetBalanceResponse : JsonModel
{
    public string? AccountID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("accountId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("accountId", value);
        }
    }

    /// <summary>
    /// Balance minus holds
    /// </summary>
    public double? AvailableBalance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("availableBalance");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("availableBalance", value);
        }
    }

    /// <summary>
    /// Total balance in cents
    /// </summary>
    public double? Balance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("balance");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("balance", value);
        }
    }

    public string? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("currency");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("currency", value);
        }
    }

    /// <summary>
    /// Amount held by active holds
    /// </summary>
    public double? HeldAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("heldAmount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("heldAmount", value);
        }
    }

    /// <summary>
    /// Pending incoming payments
    /// </summary>
    public double? PendingCharges
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("pendingCharges");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("pendingCharges", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AccountID;
        _ = this.AvailableBalance;
        _ = this.Balance;
        _ = this.Currency;
        _ = this.HeldAmount;
        _ = this.PendingCharges;
    }

    public AccountGetBalanceResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountGetBalanceResponse(AccountGetBalanceResponse accountGetBalanceResponse)
        : base(accountGetBalanceResponse) { }
#pragma warning restore CS8618

    public AccountGetBalanceResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountGetBalanceResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountGetBalanceResponseFromRaw.FromRawUnchecked"/>
    public static AccountGetBalanceResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccountGetBalanceResponseFromRaw : IFromRawJson<AccountGetBalanceResponse>
{
    /// <inheritdoc/>
    public AccountGetBalanceResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AccountGetBalanceResponse.FromRawUnchecked(rawData);
}
