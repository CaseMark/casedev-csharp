using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CaseDev.Core;
using CaseDev.Models.Compute.V1.InstanceTypes;

namespace CaseDev.Services.Compute.V1;

/// <inheritdoc/>
public sealed class InstanceTypeService : IInstanceTypeService
{
    readonly Lazy<IInstanceTypeServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IInstanceTypeServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICasedevClient _client;

    /// <inheritdoc/>
    public IInstanceTypeService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new InstanceTypeService(this._client.WithOptions(modifier));
    }

    public InstanceTypeService(ICasedevClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new InstanceTypeServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<InstanceTypeListResponse> List(
        InstanceTypeListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class InstanceTypeServiceWithRawResponse : IInstanceTypeServiceWithRawResponse
{
    readonly ICasedevClientWithRawResponse _client;

    /// <inheritdoc/>
    public IInstanceTypeServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new InstanceTypeServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public InstanceTypeServiceWithRawResponse(ICasedevClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<InstanceTypeListResponse>> List(
        InstanceTypeListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<InstanceTypeListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var instanceTypes = await response
                    .Deserialize<InstanceTypeListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    instanceTypes.Validate();
                }
                return instanceTypes;
            }
        );
    }
}
