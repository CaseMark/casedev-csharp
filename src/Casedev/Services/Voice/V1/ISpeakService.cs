using System;
using System.Threading;
using System.Threading.Tasks;
using Casedev.Core;
using Casedev.Models.Voice.V1.Speak;

namespace Casedev.Services.Voice.V1;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ISpeakService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ISpeakServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISpeakService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Convert text to natural-sounding audio using ElevenLabs voices. Ideal for
    /// creating audio summaries of legal documents, client presentations, or accessibility
    /// features. Supports multiple languages and voice customization.
    ///
    /// <para>It's the caller's responsibility to dispose the returned response.</para>
    /// </summary>
    Task<HttpResponse> Create(
        SpeakCreateParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ISpeakService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ISpeakServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISpeakServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `post /voice/v1/speak`, but is otherwise the
    /// same as <see cref="ISpeakService.Create(SpeakCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Create(
        SpeakCreateParams parameters,
        CancellationToken cancellationToken = default
    );
}
