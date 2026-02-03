using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;

namespace CaseDev.Models.Payments.V1.Accounts;

[JsonConverter(
    typeof(JsonModelConverter<AccountGetLedgerResponse, AccountGetLedgerResponseFromRaw>)
)]
public sealed record class AccountGetLedgerResponse : JsonModel
{
    public IReadOnlyList<JsonElement>? Entries
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<JsonElement>>("entries");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<JsonElement>?>(
                "entries",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public JsonElement? Pagination
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("pagination");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("pagination", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Entries;
        _ = this.Pagination;
    }

    public AccountGetLedgerResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountGetLedgerResponse(AccountGetLedgerResponse accountGetLedgerResponse)
        : base(accountGetLedgerResponse) { }
#pragma warning restore CS8618

    public AccountGetLedgerResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountGetLedgerResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountGetLedgerResponseFromRaw.FromRawUnchecked"/>
    public static AccountGetLedgerResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccountGetLedgerResponseFromRaw : IFromRawJson<AccountGetLedgerResponse>
{
    /// <inheritdoc/>
    public AccountGetLedgerResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AccountGetLedgerResponse.FromRawUnchecked(rawData);
}
