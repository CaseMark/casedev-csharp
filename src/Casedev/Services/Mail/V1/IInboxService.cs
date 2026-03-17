using System;
using System.Threading;
using System.Threading.Tasks;
using Casedev.Core;
using Casedev.Models.Mail.V1.Inboxes;

namespace Casedev.Services.Mail.V1;

/// <summary>
/// Create, manage, and execute AI agents with tool access, sandbox environments,
/// and async run workflows
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IInboxService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IInboxServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInboxService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create an inbox owned by the authenticated organization.
    /// </summary>
    Task Create(
        InboxCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get an inbox owned by the authenticated organization.
    /// </summary>
    Task Retrieve(InboxRetrieveParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Retrieve(InboxRetrieveParams, CancellationToken)"/>
    Task Retrieve(
        string inboxID,
        InboxRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List inboxes owned by the authenticated organization.
    /// </summary>
    Task List(InboxListParams? parameters = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete an inbox owned by the authenticated organization.
    /// </summary>
    Task Delete(InboxDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(InboxDeleteParams, CancellationToken)"/>
    Task Delete(
        string inboxID,
        InboxDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get attachment metadata for a message in an inbox owned by the authenticated
    /// organization.
    /// </summary>
    Task GetAttachment(
        InboxGetAttachmentParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetAttachment(InboxGetAttachmentParams, CancellationToken)"/>
    Task GetAttachment(
        string attachmentID,
        InboxGetAttachmentParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a message for an inbox owned by the authenticated organization.
    /// </summary>
    Task GetMessage(
        InboxGetMessageParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetMessage(InboxGetMessageParams, CancellationToken)"/>
    Task GetMessage(
        string messageID,
        InboxGetMessageParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List messages for an inbox owned by the authenticated organization.
    /// </summary>
    Task ListMessages(
        InboxListMessagesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListMessages(InboxListMessagesParams, CancellationToken)"/>
    Task ListMessages(
        string inboxID,
        InboxListMessagesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Reply to a message in an inbox owned by the authenticated organization.
    /// </summary>
    Task Reply(InboxReplyParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Reply(InboxReplyParams, CancellationToken)"/>
    Task Reply(
        string messageID,
        InboxReplyParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Send a message from an inbox owned by the authenticated organization.
    /// </summary>
    Task Send(InboxSendParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Send(InboxSendParams, CancellationToken)"/>
    Task Send(
        string inboxID,
        InboxSendParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IInboxService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IInboxServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInboxServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /mail/v1/inboxes</c>, but is otherwise the
    /// same as <see cref="IInboxService.Create(InboxCreateParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Create(
        InboxCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /mail/v1/inboxes/{inboxId}</c>, but is otherwise the
    /// same as <see cref="IInboxService.Retrieve(InboxRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Retrieve(
        InboxRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(InboxRetrieveParams, CancellationToken)"/>
    Task<HttpResponse> Retrieve(
        string inboxID,
        InboxRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /mail/v1/inboxes</c>, but is otherwise the
    /// same as <see cref="IInboxService.List(InboxListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> List(
        InboxListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /mail/v1/inboxes/{inboxId}</c>, but is otherwise the
    /// same as <see cref="IInboxService.Delete(InboxDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        InboxDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(InboxDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string inboxID,
        InboxDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /mail/v1/inboxes/{inboxId}/messages/{messageId}/attachments/{attachmentId}</c>, but is otherwise the
    /// same as <see cref="IInboxService.GetAttachment(InboxGetAttachmentParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> GetAttachment(
        InboxGetAttachmentParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetAttachment(InboxGetAttachmentParams, CancellationToken)"/>
    Task<HttpResponse> GetAttachment(
        string attachmentID,
        InboxGetAttachmentParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /mail/v1/inboxes/{inboxId}/messages/{messageId}</c>, but is otherwise the
    /// same as <see cref="IInboxService.GetMessage(InboxGetMessageParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> GetMessage(
        InboxGetMessageParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetMessage(InboxGetMessageParams, CancellationToken)"/>
    Task<HttpResponse> GetMessage(
        string messageID,
        InboxGetMessageParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /mail/v1/inboxes/{inboxId}/messages</c>, but is otherwise the
    /// same as <see cref="IInboxService.ListMessages(InboxListMessagesParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> ListMessages(
        InboxListMessagesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListMessages(InboxListMessagesParams, CancellationToken)"/>
    Task<HttpResponse> ListMessages(
        string inboxID,
        InboxListMessagesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /mail/v1/inboxes/{inboxId}/messages/{messageId}/reply</c>, but is otherwise the
    /// same as <see cref="IInboxService.Reply(InboxReplyParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Reply(
        InboxReplyParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Reply(InboxReplyParams, CancellationToken)"/>
    Task<HttpResponse> Reply(
        string messageID,
        InboxReplyParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /mail/v1/inboxes/{inboxId}/messages/send</c>, but is otherwise the
    /// same as <see cref="IInboxService.Send(InboxSendParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Send(
        InboxSendParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Send(InboxSendParams, CancellationToken)"/>
    Task<HttpResponse> Send(
        string inboxID,
        InboxSendParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
