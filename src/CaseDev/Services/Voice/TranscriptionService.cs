using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CaseDev.Core;
using CaseDev.Exceptions;
using CaseDev.Models.Voice.Transcription;

namespace CaseDev.Services.Voice;

/// <inheritdoc />
public sealed class TranscriptionService : ITranscriptionService
{
    /// <inheritdoc/>
    public ITranscriptionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TranscriptionService(this._client.WithOptions(modifier));
    }

    readonly ICasedevClient _client;

    public TranscriptionService(ICasedevClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task Create(
        TranscriptionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<TranscriptionCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<TranscriptionRetrieveResponse> Retrieve(
        TranscriptionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CasedevInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<TranscriptionRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var transcription = await response
            .Deserialize<TranscriptionRetrieveResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            transcription.Validate();
        }
        return transcription;
    }

    /// <inheritdoc/>
    public async Task<TranscriptionRetrieveResponse> Retrieve(
        string id,
        TranscriptionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Retrieve(parameters with { ID = id }, cancellationToken);
    }
}
