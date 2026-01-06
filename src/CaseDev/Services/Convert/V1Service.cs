using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CaseDev.Core;
using CaseDev.Exceptions;
using CaseDev.Models.Convert.V1;
using CaseDev.Services.Convert.V1;

namespace CaseDev.Services.Convert;

/// <inheritdoc/>
public sealed class V1Service : IV1Service
{
    /// <inheritdoc/>
    public IV1Service WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new V1Service(this._client.WithOptions(modifier));
    }

    readonly ICasedevClient _client;

    public V1Service(ICasedevClient client)
    {
        _client = client;
        _jobs = new(() => new JobService(client));
    }

    readonly Lazy<IJobService> _jobs;
    public IJobService Jobs
    {
        get { return _jobs.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse> Download(
        V1DownloadParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CasedevInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<V1DownloadParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse> Download(
        string id,
        V1DownloadParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Download(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<V1ProcessResponse> Process(
        V1ProcessParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<V1ProcessParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<V1ProcessResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    /// <inheritdoc/>
    public async Task<V1WebhookResponse> Webhook(
        V1WebhookParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<V1WebhookParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<V1WebhookResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }
}
