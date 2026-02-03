using System;
using CaseDev.Core;
using CaseDev.Services.Payments.V1;

namespace CaseDev.Services.Payments;

/// <inheritdoc/>
public sealed class V1Service : IV1Service
{
    readonly Lazy<IV1ServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IV1ServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICasedevClient _client;

    /// <inheritdoc/>
    public IV1Service WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new V1Service(this._client.WithOptions(modifier));
    }

    public V1Service(ICasedevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new V1ServiceWithRawResponse(client.WithRawResponse));
        _accounts = new(() => new AccountService(client));
        _charges = new(() => new ChargeService(client));
        _holds = new(() => new HoldService(client));
        _ledger = new(() => new LedgerService(client));
        _parties = new(() => new PartyService(client));
        _payouts = new(() => new PayoutService(client));
        _transfers = new(() => new TransferService(client));
    }

    readonly Lazy<IAccountService> _accounts;
    public IAccountService Accounts
    {
        get { return _accounts.Value; }
    }

    readonly Lazy<IChargeService> _charges;
    public IChargeService Charges
    {
        get { return _charges.Value; }
    }

    readonly Lazy<IHoldService> _holds;
    public IHoldService Holds
    {
        get { return _holds.Value; }
    }

    readonly Lazy<ILedgerService> _ledger;
    public ILedgerService Ledger
    {
        get { return _ledger.Value; }
    }

    readonly Lazy<IPartyService> _parties;
    public IPartyService Parties
    {
        get { return _parties.Value; }
    }

    readonly Lazy<IPayoutService> _payouts;
    public IPayoutService Payouts
    {
        get { return _payouts.Value; }
    }

    readonly Lazy<ITransferService> _transfers;
    public ITransferService Transfers
    {
        get { return _transfers.Value; }
    }
}

/// <inheritdoc/>
public sealed class V1ServiceWithRawResponse : IV1ServiceWithRawResponse
{
    readonly ICasedevClientWithRawResponse _client;

    /// <inheritdoc/>
    public IV1ServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new V1ServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public V1ServiceWithRawResponse(ICasedevClientWithRawResponse client)
    {
        _client = client;

        _accounts = new(() => new AccountServiceWithRawResponse(client));
        _charges = new(() => new ChargeServiceWithRawResponse(client));
        _holds = new(() => new HoldServiceWithRawResponse(client));
        _ledger = new(() => new LedgerServiceWithRawResponse(client));
        _parties = new(() => new PartyServiceWithRawResponse(client));
        _payouts = new(() => new PayoutServiceWithRawResponse(client));
        _transfers = new(() => new TransferServiceWithRawResponse(client));
    }

    readonly Lazy<IAccountServiceWithRawResponse> _accounts;
    public IAccountServiceWithRawResponse Accounts
    {
        get { return _accounts.Value; }
    }

    readonly Lazy<IChargeServiceWithRawResponse> _charges;
    public IChargeServiceWithRawResponse Charges
    {
        get { return _charges.Value; }
    }

    readonly Lazy<IHoldServiceWithRawResponse> _holds;
    public IHoldServiceWithRawResponse Holds
    {
        get { return _holds.Value; }
    }

    readonly Lazy<ILedgerServiceWithRawResponse> _ledger;
    public ILedgerServiceWithRawResponse Ledger
    {
        get { return _ledger.Value; }
    }

    readonly Lazy<IPartyServiceWithRawResponse> _parties;
    public IPartyServiceWithRawResponse Parties
    {
        get { return _parties.Value; }
    }

    readonly Lazy<IPayoutServiceWithRawResponse> _payouts;
    public IPayoutServiceWithRawResponse Payouts
    {
        get { return _payouts.Value; }
    }

    readonly Lazy<ITransferServiceWithRawResponse> _transfers;
    public ITransferServiceWithRawResponse Transfers
    {
        get { return _transfers.Value; }
    }
}
