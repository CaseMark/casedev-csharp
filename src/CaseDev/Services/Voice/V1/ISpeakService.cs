using System;
using System.Threading;
using System.Threading.Tasks;
using CaseDev.Core;
using CaseDev.Models.Voice.V1.Speak;

namespace CaseDev.Services.Voice.V1;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ISpeakService
{
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
    /// </summary>
    Task<HttpResponse> Create(
        SpeakCreateParams parameters,
        CancellationToken cancellationToken = default
    );
}
