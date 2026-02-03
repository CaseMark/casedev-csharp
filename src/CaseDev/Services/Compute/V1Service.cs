using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CaseDev.Core;
using CaseDev.Models.Compute.V1;
using CaseDev.Services.Compute.V1;

namespace CaseDev.Services.Compute;

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
        _environments = new(() => new EnvironmentService(client));
        _instanceTypes = new(() => new InstanceTypeService(client));
        _instances = new(() => new InstanceService(client));
        _secrets = new(() => new SecretService(client));
    }

    readonly Lazy<IEnvironmentService> _environments;
    public IEnvironmentService Environments
    {
        get { return _environments.Value; }
    }

    readonly Lazy<IInstanceTypeService> _instanceTypes;
    public IInstanceTypeService InstanceTypes
    {
        get { return _instanceTypes.Value; }
    }

    readonly Lazy<IInstanceService> _instances;
    public IInstanceService Instances
    {
        get { return _instances.Value; }
    }

    readonly Lazy<ISecretService> _secrets;
    public ISecretService Secrets
    {
        get { return _secrets.Value; }
    }

    /// <inheritdoc/>
    public Task GetPricing(
        V1GetPricingParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.GetPricing(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<V1GetUsageResponse> GetUsage(
        V1GetUsageParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.GetUsage(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
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

        _environments = new(() => new EnvironmentServiceWithRawResponse(client));
        _instanceTypes = new(() => new InstanceTypeServiceWithRawResponse(client));
        _instances = new(() => new InstanceServiceWithRawResponse(client));
        _secrets = new(() => new SecretServiceWithRawResponse(client));
    }

    readonly Lazy<IEnvironmentServiceWithRawResponse> _environments;
    public IEnvironmentServiceWithRawResponse Environments
    {
        get { return _environments.Value; }
    }

    readonly Lazy<IInstanceTypeServiceWithRawResponse> _instanceTypes;
    public IInstanceTypeServiceWithRawResponse InstanceTypes
    {
        get { return _instanceTypes.Value; }
    }

    readonly Lazy<IInstanceServiceWithRawResponse> _instances;
    public IInstanceServiceWithRawResponse Instances
    {
        get { return _instances.Value; }
    }

    readonly Lazy<ISecretServiceWithRawResponse> _secrets;
    public ISecretServiceWithRawResponse Secrets
    {
        get { return _secrets.Value; }
    }

    /// <inheritdoc/>
    public Task<HttpResponse> GetPricing(
        V1GetPricingParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<V1GetPricingParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<V1GetUsageResponse>> GetUsage(
        V1GetUsageParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<V1GetUsageParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<V1GetUsageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }
}
