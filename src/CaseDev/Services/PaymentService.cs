using System;
using CaseDev.Core;
using CaseDev.Services.Payments;

namespace CaseDev.Services;

/// <inheritdoc/>
public sealed class PaymentService : IPaymentService
{
    readonly Lazy<IPaymentServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IPaymentServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICasedevClient _client;

    /// <inheritdoc/>
    public IPaymentService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PaymentService(this._client.WithOptions(modifier));
    }

    public PaymentService(ICasedevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new PaymentServiceWithRawResponse(client.WithRawResponse));
        _v1 = new(() => new V1Service(client));
    }

    readonly Lazy<IV1Service> _v1;
    public IV1Service V1
    {
        get { return _v1.Value; }
    }
}

/// <inheritdoc/>
public sealed class PaymentServiceWithRawResponse : IPaymentServiceWithRawResponse
{
    readonly ICasedevClientWithRawResponse _client;

    /// <inheritdoc/>
    public IPaymentServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PaymentServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public PaymentServiceWithRawResponse(ICasedevClientWithRawResponse client)
    {
        _client = client;

        _v1 = new(() => new V1ServiceWithRawResponse(client));
    }

    readonly Lazy<IV1ServiceWithRawResponse> _v1;
    public IV1ServiceWithRawResponse V1
    {
        get { return _v1.Value; }
    }
}
