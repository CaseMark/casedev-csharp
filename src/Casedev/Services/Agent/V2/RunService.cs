using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Casedev.Core;
using Casedev.Exceptions;
using Casedev.Models.Agent.V2.Run;

namespace Casedev.Services.Agent.V2;

/// <inheritdoc/>
public sealed class RunService : IRunService
{
    readonly Lazy<IRunServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IRunServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICasedevClient _client;

    /// <inheritdoc/>
    public IRunService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new RunService(this._client.WithOptions(modifier));
    }

    public RunService(ICasedevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new RunServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<RunCreateResponse> Create(
        RunCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async IAsyncEnumerable<string> EventsStreaming(
        RunEventsParams parameters,
        [EnumeratorCancellation] CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.EventsStreaming(parameters, cancellationToken)
            .ConfigureAwait(false);
        await foreach (var item in response.Enumerate(cancellationToken))
        {
            yield return item;
        }
    }

    /// <inheritdoc/>
    public async IAsyncEnumerable<string> EventsStreaming(
        string id,
        RunEventsParams? parameters = null,
        [EnumeratorCancellation] CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await foreach (
            var item in this.EventsStreaming(parameters with { ID = id }, cancellationToken)
        )
        {
            yield return item;
        }
    }

    /// <inheritdoc/>
    public async Task<RunExecResponse> Exec(
        RunExecParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Exec(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<RunExecResponse> Exec(
        string id,
        RunExecParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Exec(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<JsonElement> GetDetails(
        RunGetDetailsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.GetDetails(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<JsonElement> GetDetails(
        string id,
        RunGetDetailsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetDetails(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<RunGetStatusResponse> GetStatus(
        RunGetStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.GetStatus(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<RunGetStatusResponse> GetStatus(
        string id,
        RunGetStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetStatus(parameters with { ID = id }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class RunServiceWithRawResponse : IRunServiceWithRawResponse
{
    readonly ICasedevClientWithRawResponse _client;

    /// <inheritdoc/>
    public IRunServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new RunServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public RunServiceWithRawResponse(ICasedevClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RunCreateResponse>> Create(
        RunCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<RunCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var run = await response
                    .Deserialize<RunCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    run.Validate();
                }
                return run;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<StreamingHttpResponse<string>> EventsStreaming(
        RunEventsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CasedevInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<RunEventsParams> request = new()
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
    public Task<StreamingHttpResponse<string>> EventsStreaming(
        string id,
        RunEventsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.EventsStreaming(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RunExecResponse>> Exec(
        RunExecParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CasedevInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<RunExecParams> request = new()
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
                    .Deserialize<RunExecResponse>(token)
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
    public Task<HttpResponse<RunExecResponse>> Exec(
        string id,
        RunExecParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Exec(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<JsonElement>> GetDetails(
        RunGetDetailsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CasedevInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<RunGetDetailsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                return await response.Deserialize<JsonElement>(token).ConfigureAwait(false);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<JsonElement>> GetDetails(
        string id,
        RunGetDetailsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetDetails(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RunGetStatusResponse>> GetStatus(
        RunGetStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CasedevInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<RunGetStatusParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<RunGetStatusResponse>(token)
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
    public Task<HttpResponse<RunGetStatusResponse>> GetStatus(
        string id,
        RunGetStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetStatus(parameters with { ID = id }, cancellationToken);
    }
}
