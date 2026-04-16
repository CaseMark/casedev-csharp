using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Casedev.Core;
using Casedev.Models.Agent.V1.Chat;
using Casedev.Services.Agent.V1.Chat;

namespace Casedev.Services.Agent.V1;

/// <summary>
/// Create, manage, and execute AI agents with tool access, sandbox environments,
/// and async run workflows
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IChatService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IChatServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IChatService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IFileService Files { get; }

    /// <summary>
    /// Creates a persistent OpenCode chat session backed by a Daytona or Vercel
    /// runtime. Session state is retained and can be resumed or recovered across
    /// requests.
    /// </summary>
    Task<ChatCreateResponse> Create(
        ChatCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Snapshots and terminates the active sandbox (if any), then marks the chat as
    /// ended.
    /// </summary>
    Task<ChatDeleteResponse> Delete(
        ChatDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(ChatDeleteParams, CancellationToken)"/>
    Task<ChatDeleteResponse> Delete(
        string id,
        ChatDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Aborts the active OpenCode generation for this chat session.
    /// </summary>
    Task<ChatCancelResponse> Cancel(
        ChatCancelParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Cancel(ChatCancelParams, CancellationToken)"/>
    Task<ChatCancelResponse> Cancel(
        string id,
        ChatCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Answers a pending OpenCode question for the chat session bound to this agent
    /// chat.
    /// </summary>
    Task ReplyToQuestion(
        ChatReplyToQuestionParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ReplyToQuestion(ChatReplyToQuestionParams, CancellationToken)"/>
    Task ReplyToQuestion(
        string requestID,
        ChatReplyToQuestionParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Streams a single assistant turn as normalized SSE events with stable turn,
    /// message, and part IDs. Emits events: `turn.started`, `turn.status`,
    /// `message.created`, `message.part.updated`, `message.completed`, `session.usage`,
    /// `turn.completed`.
    ///
    /// <para>**When to use this endpoint:** Recommended for building custom chat UIs
    /// that need real-time streaming progress. This is the primary streaming endpoint
    /// for new integrations.</para>
    ///
    /// <para>**Alternatives:** - `POST /chat/:id/message` — synchronous, returns
    /// complete response as JSON (best for server-to-server)</para>
    /// </summary>
    IAsyncEnumerable<string> RespondStreaming(
        ChatRespondParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RespondStreaming(ChatRespondParams, CancellationToken)"/>
    IAsyncEnumerable<string> RespondStreaming(
        string id,
        ChatRespondParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sends a message and returns the complete response as a single JSON body. Blocks
    /// until the agent turn completes.
    ///
    /// <para>**When to use this endpoint:** Best for server-to-server integrations,
    /// background processing, or any context where you want the full response in one
    /// call without managing an SSE stream.</para>
    ///
    /// <para>**Alternatives:** - `POST /chat/:id/respond` — streaming SSE with
    /// normalized events (recommended for custom chat UIs)</para>
    /// </summary>
    Task SendMessage(
        ChatSendMessageParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="SendMessage(ChatSendMessageParams, CancellationToken)"/>
    Task SendMessage(
        string id,
        ChatSendMessageParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Relays OpenCode SSE events for this chat. Supports replay from buffered events
    /// using Last-Event-ID.
    /// </summary>
    IAsyncEnumerable<string> StreamStreaming(
        ChatStreamParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="StreamStreaming(ChatStreamParams, CancellationToken)"/>
    IAsyncEnumerable<string> StreamStreaming(
        string id,
        ChatStreamParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IChatService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IChatServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IChatServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IFileServiceWithRawResponse Files { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>post /agent/v1/chat</c>, but is otherwise the
    /// same as <see cref="IChatService.Create(ChatCreateParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ChatCreateResponse>> Create(
        ChatCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /agent/v1/chat/{id}</c>, but is otherwise the
    /// same as <see cref="IChatService.Delete(ChatDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ChatDeleteResponse>> Delete(
        ChatDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(ChatDeleteParams, CancellationToken)"/>
    Task<HttpResponse<ChatDeleteResponse>> Delete(
        string id,
        ChatDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /agent/v1/chat/{id}/cancel</c>, but is otherwise the
    /// same as <see cref="IChatService.Cancel(ChatCancelParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ChatCancelResponse>> Cancel(
        ChatCancelParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Cancel(ChatCancelParams, CancellationToken)"/>
    Task<HttpResponse<ChatCancelResponse>> Cancel(
        string id,
        ChatCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /agent/v1/chat/{id}/question/{requestID}/reply</c>, but is otherwise the
    /// same as <see cref="IChatService.ReplyToQuestion(ChatReplyToQuestionParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> ReplyToQuestion(
        ChatReplyToQuestionParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ReplyToQuestion(ChatReplyToQuestionParams, CancellationToken)"/>
    Task<HttpResponse> ReplyToQuestion(
        string requestID,
        ChatReplyToQuestionParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /agent/v1/chat/{id}/respond</c>, but is otherwise the
    /// same as <see cref="IChatService.RespondStreaming(ChatRespondParams, CancellationToken)"/>.
    /// </summary>
    Task<StreamingHttpResponse<string>> RespondStreaming(
        ChatRespondParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RespondStreaming(ChatRespondParams, CancellationToken)"/>
    Task<StreamingHttpResponse<string>> RespondStreaming(
        string id,
        ChatRespondParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /agent/v1/chat/{id}/message</c>, but is otherwise the
    /// same as <see cref="IChatService.SendMessage(ChatSendMessageParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> SendMessage(
        ChatSendMessageParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="SendMessage(ChatSendMessageParams, CancellationToken)"/>
    Task<HttpResponse> SendMessage(
        string id,
        ChatSendMessageParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /agent/v1/chat/{id}/stream</c>, but is otherwise the
    /// same as <see cref="IChatService.StreamStreaming(ChatStreamParams, CancellationToken)"/>.
    /// </summary>
    Task<StreamingHttpResponse<string>> StreamStreaming(
        ChatStreamParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="StreamStreaming(ChatStreamParams, CancellationToken)"/>
    Task<StreamingHttpResponse<string>> StreamStreaming(
        string id,
        ChatStreamParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
