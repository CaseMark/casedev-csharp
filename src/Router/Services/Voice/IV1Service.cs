using System;
using System.Threading;
using System.Threading.Tasks;
using Router.Core;
using Router.Models.Voice.V1;
using Router.Services.Voice.V1;

namespace Router.Services.Voice;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IV1Service
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IV1ServiceWithRawResponse WithRawResponse { get; }

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
    Task<V1ListVoicesResponse> ListVoices(
        V1ListVoicesParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IV1Service"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IV1ServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IV1ServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ISpeakServiceWithRawResponse Speak { get; }

    /// <summary>
    /// Returns a raw HTTP response for `get /voice/v1/voices`, but is otherwise the
    /// same as <see cref="IV1Service.ListVoices(V1ListVoicesParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<V1ListVoicesResponse>> ListVoices(
        V1ListVoicesParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
