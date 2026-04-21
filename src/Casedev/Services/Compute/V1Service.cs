using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Casedev.Core;
using Casedev.Models.Compute.V1;
using Casedev.Services.Compute.V1;

namespace Casedev.Services.Compute;

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
        _secrets = new(() => new SecretService(client));
    }

    readonly Lazy<IEnvironmentService> _environments;
    public IEnvironmentService Environments
    {
        get { return _environments.Value; }
    }

    readonly Lazy<ISecretService> _secrets;
    public ISecretService Secrets
    {
        get { return _secrets.Value; }
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
        _secrets = new(() => new SecretServiceWithRawResponse(client));
    }

    readonly Lazy<IEnvironmentServiceWithRawResponse> _environments;
    public IEnvironmentServiceWithRawResponse Environments
    {
        get { return _environments.Value; }
    }

    readonly Lazy<ISecretServiceWithRawResponse> _secrets;
    public ISecretServiceWithRawResponse Secrets
    {
        get { return _secrets.Value; }
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
