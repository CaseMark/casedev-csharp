using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Casedev.Core;
using Casedev.Models.System;

namespace Casedev.Services;

/// <inheritdoc/>
public sealed class SystemService : ISystemService
{
    readonly Lazy<ISystemServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ISystemServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICasedevClient _client;

    /// <inheritdoc/>
    public ISystemService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SystemService(this._client.WithOptions(modifier));
    }

    public SystemService(ICasedevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new SystemServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<SystemListServicesResponse> ListServices(
        SystemListServicesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListServices(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class SystemServiceWithRawResponse : ISystemServiceWithRawResponse
{
    readonly ICasedevClientWithRawResponse _client;

    /// <inheritdoc/>
    public ISystemServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SystemServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public SystemServiceWithRawResponse(ICasedevClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SystemListServicesResponse>> ListServices(
        SystemListServicesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<SystemListServicesParams> request = new()
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
                    .Deserialize<SystemListServicesResponse>(token)
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
