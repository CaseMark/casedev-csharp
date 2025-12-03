using System;
using System.Threading;
using System.Threading.Tasks;
using CaseDev.Core;
using CaseDev.Models.Format.V1;
using V1 = CaseDev.Services.Format.V1;

namespace CaseDev.Services.Format;

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

    V1::ITemplateService Templates { get; }

    /// <summary>
    /// Convert Markdown, JSON, or text content to professionally formatted PDF,
    /// DOCX, or HTML documents. Supports template components with variable interpolation
    /// for creating consistent legal documents like contracts, briefs, and reports.
    /// </summary>
    Task<HttpResponse> CreateDocument(
        V1CreateDocumentParams parameters,
        CancellationToken cancellationToken = default
    );
}
