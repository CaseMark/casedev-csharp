using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;

namespace CaseDev.Models.Payments.V1.Accounts;

[JsonConverter(typeof(JsonModelConverter<AccountCreateResponse, AccountCreateResponseFromRaw>))]
public sealed record class AccountCreateResponse : JsonModel
{
    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    public double? CachedAvailableBalance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("cachedAvailableBalance");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("cachedAvailableBalance", value);
        }
    }

    public double? CachedBalance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("cachedBalance");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("cachedBalance", value);
        }
    }

    public string? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("createdAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("createdAt", value);
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

    public bool? IsActive
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isActive");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isActive", value);
        }
    }

    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    public string? OrganizationID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("organizationId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("organizationId", value);
        }
    }

    public string? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CachedAvailableBalance;
        _ = this.CachedBalance;
        _ = this.CreatedAt;
        _ = this.Currency;
        _ = this.IsActive;
        _ = this.Name;
        _ = this.OrganizationID;
        _ = this.Type;
    }

    public AccountCreateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountCreateResponse(AccountCreateResponse accountCreateResponse)
        : base(accountCreateResponse) { }
#pragma warning restore CS8618

    public AccountCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountCreateResponseFromRaw.FromRawUnchecked"/>
    public static AccountCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccountCreateResponseFromRaw : IFromRawJson<AccountCreateResponse>
{
    /// <inheritdoc/>
    public AccountCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AccountCreateResponse.FromRawUnchecked(rawData);
}
