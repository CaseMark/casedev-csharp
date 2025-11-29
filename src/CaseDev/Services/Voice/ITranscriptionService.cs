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
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITranscriptionService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Creates an asynchronous transcription job for audio files. Supports various
    /// audio formats and advanced features like speaker identification, content moderation,
    /// and automatic highlights. Returns a job ID for checking transcription status
    /// and retrieving results.
    /// </summary>
    Task Create(
        TranscriptionCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve the status and result of an audio transcription job. Returns the
    /// transcription text when complete, or status information for pending jobs.
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
