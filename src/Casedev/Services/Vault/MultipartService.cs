using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Casedev.Core;
using Casedev.Exceptions;
using Casedev.Models.Vault.Multipart;

namespace Casedev.Services.Vault;

/// <inheritdoc/>
public sealed class MultipartService : IMultipartService
{
    readonly Lazy<IMultipartServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IMultipartServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICasedevClient _client;

    /// <inheritdoc/>
    public IMultipartService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new MultipartService(this._client.WithOptions(modifier));
    }

    public MultipartService(ICasedevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new MultipartServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public Task Abort(
        MultipartAbortParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Abort(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Abort(
        string id,
        MultipartAbortParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Abort(parameters with { ID = id }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<MultipartGetPartUrlsResponse> GetPartUrls(
        MultipartGetPartUrlsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.GetPartUrls(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<MultipartGetPartUrlsResponse> GetPartUrls(
        string id,
        MultipartGetPartUrlsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.GetPartUrls(parameters with { ID = id }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class MultipartServiceWithRawResponse : IMultipartServiceWithRawResponse
{
    readonly ICasedevClientWithRawResponse _client;

    /// <inheritdoc/>
    public IMultipartServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new MultipartServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public MultipartServiceWithRawResponse(ICasedevClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Abort(
        MultipartAbortParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CasedevInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<MultipartAbortParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Abort(
        string id,
        MultipartAbortParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Abort(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MultipartGetPartUrlsResponse>> GetPartUrls(
        MultipartGetPartUrlsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CasedevInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<MultipartGetPartUrlsParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<MultipartGetPartUrlsResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<MultipartGetPartUrlsResponse>> GetPartUrls(
        string id,
        MultipartGetPartUrlsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.GetPartUrls(parameters with { ID = id }, cancellationToken);
    }
}
