using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Casedev.Core;
using Casedev.Exceptions;
using Casedev.Models.Agent.V1.Chat;

namespace Casedev.Services.Agent.V1;

/// <inheritdoc/>
public sealed class ChatService : IChatService
{
    readonly Lazy<IChatServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IChatServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICasedevClient _client;

    /// <inheritdoc/>
    public IChatService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ChatService(this._client.WithOptions(modifier));
    }

    public ChatService(ICasedevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ChatServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<ChatCreateResponse> Create(
        ChatCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ChatDeleteResponse> Delete(
        ChatDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Delete(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ChatDeleteResponse> Delete(
        string id,
        ChatDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ChatCancelResponse> Cancel(
        ChatCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Cancel(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ChatCancelResponse> Cancel(
        string id,
        ChatCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Cancel(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task ReplyToQuestion(
        ChatReplyToQuestionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.ReplyToQuestion(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task ReplyToQuestion(
        string requestID,
        ChatReplyToQuestionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.ReplyToQuestion(parameters with { RequestID = requestID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async IAsyncEnumerable<string> RespondStreaming(
        ChatRespondParams parameters,
        [EnumeratorCancellation] CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RespondStreaming(parameters, cancellationToken)
            .ConfigureAwait(false);
        await foreach (var item in response.Enumerate(cancellationToken))
        {
            yield return item;
        }
    }

    /// <inheritdoc/>
    public async IAsyncEnumerable<string> RespondStreaming(
        string id,
        ChatRespondParams? parameters = null,
        [EnumeratorCancellation] CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await foreach (
            var item in this.RespondStreaming(parameters with { ID = id }, cancellationToken)
        )
        {
            yield return item;
        }
    }

    /// <inheritdoc/>
    public Task SendMessage(
        ChatSendMessageParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.SendMessage(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task SendMessage(
        string id,
        ChatSendMessageParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.SendMessage(parameters with { ID = id }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async IAsyncEnumerable<string> StreamStreaming(
        ChatStreamParams parameters,
        [EnumeratorCancellation] CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.StreamStreaming(parameters, cancellationToken)
            .ConfigureAwait(false);
        await foreach (var item in response.Enumerate(cancellationToken))
        {
            yield return item;
        }
    }

    /// <inheritdoc/>
    public async IAsyncEnumerable<string> StreamStreaming(
        string id,
        ChatStreamParams? parameters = null,
        [EnumeratorCancellation] CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await foreach (
            var item in this.StreamStreaming(parameters with { ID = id }, cancellationToken)
        )
        {
            yield return item;
        }
    }
}

/// <inheritdoc/>
public sealed class ChatServiceWithRawResponse : IChatServiceWithRawResponse
{
    readonly ICasedevClientWithRawResponse _client;

    /// <inheritdoc/>
    public IChatServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ChatServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ChatServiceWithRawResponse(ICasedevClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ChatCreateResponse>> Create(
        ChatCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ChatCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var chat = await response
                    .Deserialize<ChatCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    chat.Validate();
                }
                return chat;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ChatDeleteResponse>> Delete(
        ChatDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CasedevInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<ChatDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var chat = await response
                    .Deserialize<ChatDeleteResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    chat.Validate();
                }
                return chat;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ChatDeleteResponse>> Delete(
        string id,
        ChatDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ChatCancelResponse>> Cancel(
        ChatCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CasedevInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<ChatCancelParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<ChatCancelResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ChatCancelResponse>> Cancel(
        string id,
        ChatCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Cancel(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> ReplyToQuestion(
        ChatReplyToQuestionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RequestID == null)
        {
            throw new CasedevInvalidDataException("'parameters.RequestID' cannot be null");
        }

        HttpRequest<ChatReplyToQuestionParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> ReplyToQuestion(
        string requestID,
        ChatReplyToQuestionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.ReplyToQuestion(parameters with { RequestID = requestID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<StreamingHttpResponse<string>> RespondStreaming(
        ChatRespondParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CasedevInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<ChatRespondParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);

        async IAsyncEnumerable<string> Enumerate([EnumeratorCancellation] CancellationToken token)
        {
            await foreach (
                var deserializedItem in Sse.Enumerate<string>(response.RawMessage, token)
            )
            {
                yield return deserializedItem;
            }
        }
        return new(response, Enumerate);
    }

    /// <inheritdoc/>
    public Task<StreamingHttpResponse<string>> RespondStreaming(
        string id,
        ChatRespondParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RespondStreaming(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> SendMessage(
        ChatSendMessageParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CasedevInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<ChatSendMessageParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> SendMessage(
        string id,
        ChatSendMessageParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.SendMessage(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<StreamingHttpResponse<string>> StreamStreaming(
        ChatStreamParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CasedevInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<ChatStreamParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);

        async IAsyncEnumerable<string> Enumerate([EnumeratorCancellation] CancellationToken token)
        {
            await foreach (
                var deserializedItem in Sse.Enumerate<string>(response.RawMessage, token)
            )
            {
                yield return deserializedItem;
            }
        }
        return new(response, Enumerate);
    }

    /// <inheritdoc/>
    public Task<StreamingHttpResponse<string>> StreamStreaming(
        string id,
        ChatStreamParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.StreamStreaming(parameters with { ID = id }, cancellationToken);
    }
}
