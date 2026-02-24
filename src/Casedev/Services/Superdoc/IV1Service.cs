using System;
using System.Threading;
using System.Threading.Tasks;
using Casedev.Core;
using Casedev.Models.Superdoc.V1;

namespace Casedev.Services.Superdoc;

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
    /// Populate fields inside a DOCX template using SuperDoc annotations. Supports
    /// text, images, dates, and numbers. Can target individual fields by ID or multiple
    /// fields by group.
    ///
    /// <para>It's the caller's responsibility to dispose the returned response.</para>
    /// </summary>
    Task<HttpResponse> Annotate(
        V1AnnotateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Convert documents between formats using SuperDoc. Supports DOCX to PDF, Markdown
    /// to DOCX, and HTML to DOCX conversions.
    ///
    /// <para>It's the caller's responsibility to dispose the returned response.</para>
    /// </summary>
    Task<HttpResponse> Convert(
        V1ConvertParams parameters,
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
    /// Returns a raw HTTP response for `post /superdoc/v1/annotate`, but is otherwise the
    /// same as <see cref="IV1Service.Annotate(V1AnnotateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Annotate(
        V1AnnotateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /superdoc/v1/convert`, but is otherwise the
    /// same as <see cref="IV1Service.Convert(V1ConvertParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Convert(
        V1ConvertParams parameters,
        CancellationToken cancellationToken = default
    );
}
