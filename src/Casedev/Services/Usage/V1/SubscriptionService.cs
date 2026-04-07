using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Casedev.Core;
using Casedev.Exceptions;
using Casedev.Models.Usage.V1.Subscriptions;

namespace Casedev.Services.Usage.V1;

/// <inheritdoc/>
public sealed class SubscriptionService : ISubscriptionService
{
    readonly Lazy<ISubscriptionServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ISubscriptionServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICasedevClient _client;

    /// <inheritdoc/>
    public ISubscriptionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SubscriptionService(this._client.WithOptions(modifier));
    }

    public SubscriptionService(ICasedevClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new SubscriptionServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public Task Create(
        SubscriptionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Create(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Update(
        SubscriptionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Update(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Update(
        string subscriptionID,
        SubscriptionUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Update(parameters with { SubscriptionID = subscriptionID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task List(
        SubscriptionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.List(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Delete(
        SubscriptionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string subscriptionID,
        SubscriptionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { SubscriptionID = subscriptionID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Test(
        SubscriptionTestParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Test(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Test(
        string subscriptionID,
        SubscriptionTestParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Test(parameters with { SubscriptionID = subscriptionID }, cancellationToken)
            .ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class SubscriptionServiceWithRawResponse : ISubscriptionServiceWithRawResponse
{
    readonly ICasedevClientWithRawResponse _client;

    /// <inheritdoc/>
    public ISubscriptionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new SubscriptionServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public SubscriptionServiceWithRawResponse(ICasedevClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Create(
        SubscriptionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<SubscriptionCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Update(
        SubscriptionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SubscriptionID == null)
        {
            throw new CasedevInvalidDataException("'parameters.SubscriptionID' cannot be null");
        }

        HttpRequest<SubscriptionUpdateParams> request = new()
        {
            Method = CasedevClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Update(
        string subscriptionID,
        SubscriptionUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { SubscriptionID = subscriptionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> List(
        SubscriptionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<SubscriptionListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        SubscriptionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SubscriptionID == null)
        {
            throw new CasedevInvalidDataException("'parameters.SubscriptionID' cannot be null");
        }

        HttpRequest<SubscriptionDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string subscriptionID,
        SubscriptionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { SubscriptionID = subscriptionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Test(
        SubscriptionTestParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SubscriptionID == null)
        {
            throw new CasedevInvalidDataException("'parameters.SubscriptionID' cannot be null");
        }

        HttpRequest<SubscriptionTestParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Test(
        string subscriptionID,
        SubscriptionTestParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Test(parameters with { SubscriptionID = subscriptionID }, cancellationToken);
    }
}
