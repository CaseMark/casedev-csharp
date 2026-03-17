using System;
using System.Threading;
using System.Threading.Tasks;
using Casedev.Core;
using Casedev.Models.Voice.BoostList;

namespace Casedev.Services.Voice;

/// <summary>
/// Audio transcription and text-to-speech
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IBoostListService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IBoostListServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBoostListService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Extracts a categorized word boost list from vault documents or raw text using
    /// LLM entity extraction. The resulting list can be passed as `word_boost` to the
    /// transcription endpoint for improved accuracy.
    /// </summary>
    Task<BoostListExtractResponse> Extract(
        BoostListExtractParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Generates a categorized word boost list from a completed transcription job.
    /// Extracts entities from the pass-1 transcript for use as `word_boost` in a second
    /// transcription pass.
    /// </summary>
    Task<BoostListGenerateResponse> Generate(
        BoostListGenerateParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IBoostListService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IBoostListServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBoostListServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /voice/boost-list/extract</c>, but is otherwise the
    /// same as <see cref="IBoostListService.Extract(BoostListExtractParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BoostListExtractResponse>> Extract(
        BoostListExtractParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /voice/boost-list/generate</c>, but is otherwise the
    /// same as <see cref="IBoostListService.Generate(BoostListGenerateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BoostListGenerateResponse>> Generate(
        BoostListGenerateParams parameters,
        CancellationToken cancellationToken = default
    );
}
