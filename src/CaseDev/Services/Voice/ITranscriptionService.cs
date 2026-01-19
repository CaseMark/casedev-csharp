using System;
using System.Threading;
using System.Threading.Tasks;
using CaseDev.Core;
using CaseDev.Models.Voice.Transcription;

namespace CaseDev.Services.Voice;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ITranscriptionService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ITranscriptionServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITranscriptionService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Creates an asynchronous transcription job for audio files. Supports two modes:
    ///
    /// <para>**Vault-based (recommended)**: Pass `vault_id` and `object_id` to transcribe
    /// audio from your vault. The transcript will automatically be saved back to
    /// the vault when complete.</para>
    ///
    /// <para>**Direct URL (legacy)**: Pass `audio_url` for direct transcription
    /// without automatic storage.</para>
    /// </summary>
    Task<TranscriptionCreateResponse> Create(
        TranscriptionCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve the status and result of an audio transcription job. For vault-based
    /// jobs, returns status and result_object_id when complete. For legacy direct
    /// URL jobs, returns the full transcription data.
    /// </summary>
    Task<TranscriptionRetrieveResponse> Retrieve(
        TranscriptionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(TranscriptionRetrieveParams, CancellationToken)"/>
    Task<TranscriptionRetrieveResponse> Retrieve(
        string id,
        TranscriptionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ITranscriptionService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ITranscriptionServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITranscriptionServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `post /voice/transcription`, but is otherwise the
    /// same as <see cref="ITranscriptionService.Create(TranscriptionCreateParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TranscriptionCreateResponse>> Create(
        TranscriptionCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /voice/transcription/{id}`, but is otherwise the
    /// same as <see cref="ITranscriptionService.Retrieve(TranscriptionRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TranscriptionRetrieveResponse>> Retrieve(
        TranscriptionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(TranscriptionRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<TranscriptionRetrieveResponse>> Retrieve(
        string id,
        TranscriptionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
