using System;
using System.Threading;
using System.Threading.Tasks;
using Casedev.Core;
using Casedev.Models.Privilege.V1;

namespace Casedev.Services.Privilege;

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
    /// Analyzes text or vault documents for legal privilege. Detects attorney-client
    /// privilege, work product doctrine, common interest privilege, and litigation
    /// hold materials.
    ///
    /// <para>Returns structured privilege flags with confidence scores and policy-friendly
    /// rationale suitable for discovery workflows and privilege logs.</para>
    ///
    /// <para>**Size Limit:** Maximum 200,000 characters (larger documents rejected).</para>
    ///
    /// <para>**Permissions:** Requires `chat` permission. When using `document_id`,
    /// also requires `vault` permission.</para>
    ///
    /// <para>**Note:** When analyzing vault documents, results are automatically
    /// stored in the document's `privilege_analysis` metadata field.</para>
    /// </summary>
    Task<V1DetectResponse> Detect(
        V1DetectParams? parameters = null,
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
    /// Returns a raw HTTP response for `post /privilege/v1/detect`, but is otherwise the
    /// same as <see cref="IV1Service.Detect(V1DetectParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<V1DetectResponse>> Detect(
        V1DetectParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
