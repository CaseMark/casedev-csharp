using System;
using System.Threading;
using System.Threading.Tasks;
using CaseDev.Core;
using CaseDev.Models.Voice.V1;
using CaseDev.Services.Voice.V1;

namespace CaseDev.Services.Voice;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IV1Service
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IV1Service WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ISpeakService Speak { get; }

    /// <summary>
    /// Retrieve a list of available voices for text-to-speech synthesis. This endpoint
    /// provides access to a comprehensive catalog of voices with various characteristics,
    /// languages, and styles suitable for legal document narration, client presentations,
    /// and accessibility purposes.
    /// </summary>
    Task ListVoices(
        V1ListVoicesParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
