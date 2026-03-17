using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Casedev.Core;
using Casedev.Models.Skills.Custom;

namespace Casedev.Services.Skills;

/// <inheritdoc/>
public sealed class CustomService : ICustomService
{
    readonly Lazy<ICustomServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICustomServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICasedevClient _client;

    /// <inheritdoc/>
    public ICustomService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CustomService(this._client.WithOptions(modifier));
    }

    public CustomService(ICasedevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new CustomServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<CustomListResponse> List(
        CustomListParams? parameters = null,
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
public sealed class CustomServiceWithRawResponse : ICustomServiceWithRawResponse
{
    readonly ICasedevClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICustomServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CustomServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CustomServiceWithRawResponse(ICasedevClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CustomListResponse>> List(
        CustomListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<CustomListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var customs = await response
                    .Deserialize<CustomListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    customs.Validate();
                }
                return customs;
            }
        );
    }
}
