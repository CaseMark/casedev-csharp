using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Casedev.Core;
using Casedev.Exceptions;
using Casedev.Models.Mail.V1.Inboxes;

namespace Casedev.Services.Mail.V1;

/// <inheritdoc/>
public sealed class InboxService : IInboxService
{
    readonly Lazy<IInboxServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IInboxServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICasedevClient _client;

    /// <inheritdoc/>
    public IInboxService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new InboxService(this._client.WithOptions(modifier));
    }

    public InboxService(ICasedevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new InboxServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public Task Create(
        InboxCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Create(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Retrieve(
        InboxRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Retrieve(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Retrieve(
        string inboxID,
        InboxRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Retrieve(parameters with { InboxID = inboxID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task List(
        InboxListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.List(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Delete(InboxDeleteParams parameters, CancellationToken cancellationToken = default)
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string inboxID,
        InboxDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { InboxID = inboxID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task GetAttachment(
        InboxGetAttachmentParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.GetAttachment(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task GetAttachment(
        string attachmentID,
        InboxGetAttachmentParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.GetAttachment(parameters with { AttachmentID = attachmentID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task GetMessage(
        InboxGetMessageParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.GetMessage(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task GetMessage(
        string messageID,
        InboxGetMessageParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.GetMessage(parameters with { MessageID = messageID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task GetPolicy(
        InboxGetPolicyParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.GetPolicy(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task GetPolicy(
        string inboxID,
        InboxGetPolicyParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.GetPolicy(parameters with { InboxID = inboxID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task ListMessages(
        InboxListMessagesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.ListMessages(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task ListMessages(
        string inboxID,
        InboxListMessagesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.ListMessages(parameters with { InboxID = inboxID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Reply(InboxReplyParams parameters, CancellationToken cancellationToken = default)
    {
        return this.WithRawResponse.Reply(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Reply(
        string messageID,
        InboxReplyParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Reply(parameters with { MessageID = messageID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Send(InboxSendParams parameters, CancellationToken cancellationToken = default)
    {
        return this.WithRawResponse.Send(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Send(
        string inboxID,
        InboxSendParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Send(parameters with { InboxID = inboxID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task SetPolicy(
        InboxSetPolicyParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.SetPolicy(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task SetPolicy(
        string inboxID,
        InboxSetPolicyParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.SetPolicy(parameters with { InboxID = inboxID }, cancellationToken)
            .ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class InboxServiceWithRawResponse : IInboxServiceWithRawResponse
{
    readonly ICasedevClientWithRawResponse _client;

    /// <inheritdoc/>
    public IInboxServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new InboxServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public InboxServiceWithRawResponse(ICasedevClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Create(
        InboxCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<InboxCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Retrieve(
        InboxRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.InboxID == null)
        {
            throw new CasedevInvalidDataException("'parameters.InboxID' cannot be null");
        }

        HttpRequest<InboxRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Retrieve(
        string inboxID,
        InboxRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { InboxID = inboxID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> List(
        InboxListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<InboxListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        InboxDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.InboxID == null)
        {
            throw new CasedevInvalidDataException("'parameters.InboxID' cannot be null");
        }

        HttpRequest<InboxDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string inboxID,
        InboxDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { InboxID = inboxID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> GetAttachment(
        InboxGetAttachmentParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AttachmentID == null)
        {
            throw new CasedevInvalidDataException("'parameters.AttachmentID' cannot be null");
        }

        HttpRequest<InboxGetAttachmentParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> GetAttachment(
        string attachmentID,
        InboxGetAttachmentParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.GetAttachment(
            parameters with
            {
                AttachmentID = attachmentID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> GetMessage(
        InboxGetMessageParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.MessageID == null)
        {
            throw new CasedevInvalidDataException("'parameters.MessageID' cannot be null");
        }

        HttpRequest<InboxGetMessageParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> GetMessage(
        string messageID,
        InboxGetMessageParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.GetMessage(parameters with { MessageID = messageID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> GetPolicy(
        InboxGetPolicyParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.InboxID == null)
        {
            throw new CasedevInvalidDataException("'parameters.InboxID' cannot be null");
        }

        HttpRequest<InboxGetPolicyParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> GetPolicy(
        string inboxID,
        InboxGetPolicyParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetPolicy(parameters with { InboxID = inboxID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> ListMessages(
        InboxListMessagesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.InboxID == null)
        {
            throw new CasedevInvalidDataException("'parameters.InboxID' cannot be null");
        }

        HttpRequest<InboxListMessagesParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> ListMessages(
        string inboxID,
        InboxListMessagesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListMessages(parameters with { InboxID = inboxID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Reply(
        InboxReplyParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.MessageID == null)
        {
            throw new CasedevInvalidDataException("'parameters.MessageID' cannot be null");
        }

        HttpRequest<InboxReplyParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Reply(
        string messageID,
        InboxReplyParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Reply(parameters with { MessageID = messageID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Send(
        InboxSendParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.InboxID == null)
        {
            throw new CasedevInvalidDataException("'parameters.InboxID' cannot be null");
        }

        HttpRequest<InboxSendParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Send(
        string inboxID,
        InboxSendParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Send(parameters with { InboxID = inboxID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> SetPolicy(
        InboxSetPolicyParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.InboxID == null)
        {
            throw new CasedevInvalidDataException("'parameters.InboxID' cannot be null");
        }

        HttpRequest<InboxSetPolicyParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> SetPolicy(
        string inboxID,
        InboxSetPolicyParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.SetPolicy(parameters with { InboxID = inboxID }, cancellationToken);
    }
}
