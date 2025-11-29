using System;
using System.Threading;
using System.Threading.Tasks;
using CaseDev.Core;
using CaseDev.Models.Webhooks.V1;

namespace CaseDev.Services.Webhooks;

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

    /// <summary>
    /// Create a new webhook endpoint to receive real-time notifications for events
    /// in your Case.dev workspace. Webhooks enable automated workflows by sending
    /// HTTP POST requests to your specified URL when events occur.
    ///
    /// <para>**Security**: Webhooks are signed with HMAC-SHA256 using the provided
    /// secret. The signature is included in the `X-Case-Signature` header.</para>
    ///
    /// <para>**Available Events**: - `document.processed` - Document OCR/processing
    /// completed - `vault.updated` - Document added/removed from vault - `action.completed`
    /// - Workflow action finished - `compute.finished` - Compute job completed</para>
    /// </summary>
    Task<V1CreateResponse> Create(
        V1CreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve detailed information about a specific webhook endpoint, including
    /// its URL, description, subscribed events, and status.
    /// </summary>
    Task Retrieve(V1RetrieveParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Retrieve(V1RetrieveParams, CancellationToken)"/>
    Task Retrieve(
        string id,
        V1RetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve all webhook endpoints configured for your organization. Webhooks
    /// allow you to receive real-time notifications when events occur in your Case.dev
    /// workspace, such as document processing completion, OCR results, or workflow
    /// status changes.
    /// </summary>
    Task List(V1ListParams? parameters = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete a webhook endpoint from your organization. This action is irreversible
    /// and will stop all webhook deliveries to the specified URL.
    /// </summary>
    Task Delete(V1DeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(V1DeleteParams, CancellationToken)"/>
    Task Delete(
        string id,
        V1DeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
