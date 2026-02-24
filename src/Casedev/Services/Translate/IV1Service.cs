using System;
using System.Threading;
using System.Threading.Tasks;
using Casedev.Core;
using Casedev.Models.Translate.V1;

namespace Casedev.Services.Translate;

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

    /// <summary>
    /// Detect the language of text. Returns the most likely language code and confidence
    /// score. Supports batch detection for multiple texts.
    /// </summary>
    Task<V1DetectResponse> Detect(
        V1DetectParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get the list of languages supported for translation. Optionally specify a
    /// target language to get translated language names.
    /// </summary>
    Task<V1ListLanguagesResponse> ListLanguages(
        V1ListLanguagesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Translate text between languages using Google Cloud Translation API. Supports
    /// 100+ languages, automatic language detection, HTML preservation, and batch translation.
    /// </summary>
    Task<V1TranslateResponse> Translate(
        V1TranslateParams parameters,
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

    /// <summary>
    /// Returns a raw HTTP response for `post /translate/v1/detect`, but is otherwise the
    /// same as <see cref="IV1Service.Detect(V1DetectParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<V1DetectResponse>> Detect(
        V1DetectParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /translate/v1/languages`, but is otherwise the
    /// same as <see cref="IV1Service.ListLanguages(V1ListLanguagesParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<V1ListLanguagesResponse>> ListLanguages(
        V1ListLanguagesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /translate/v1/translate`, but is otherwise the
    /// same as <see cref="IV1Service.Translate(V1TranslateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<V1TranslateResponse>> Translate(
        V1TranslateParams parameters,
        CancellationToken cancellationToken = default
    );
}
