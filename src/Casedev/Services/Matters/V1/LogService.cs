using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Casedev.Core;
using Casedev.Exceptions;
using Casedev.Models.Matters.V1.Log;

namespace Casedev.Services.Matters.V1;

/// <inheritdoc/>
public sealed class LogService : ILogService
{
    readonly Lazy<ILogServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ILogServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICasedevClient _client;

    /// <inheritdoc/>
    public ILogService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new LogService(this._client.WithOptions(modifier));
    }

    public LogService(ICasedevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new LogServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public Task Create(LogCreateParams parameters, CancellationToken cancellationToken = default)
    {
        return this.WithRawResponse.Create(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Create(
        string id,
        LogCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Create(parameters with { ID = id }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task List(LogListParams parameters, CancellationToken cancellationToken = default)
    {
        return this.WithRawResponse.List(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task List(
        string id,
        LogListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.List(parameters with { ID = id }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<LogExportResponse> Export(
        LogExportParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Export(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<LogExportResponse> Export(
        string id,
        LogExportParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Export(parameters with { ID = id }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class LogServiceWithRawResponse : ILogServiceWithRawResponse
{
    readonly ICasedevClientWithRawResponse _client;

    /// <inheritdoc/>
    public ILogServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new LogServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public LogServiceWithRawResponse(ICasedevClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Create(
        LogCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CasedevInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<LogCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Create(
        string id,
        LogCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> List(
        LogListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CasedevInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<LogListParams> request = new() { Method = HttpMethod.Get, Params = parameters };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> List(
        string id,
        LogListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<LogExportResponse>> Export(
        LogExportParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CasedevInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<LogExportParams> request = new()
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
                    .Deserialize<LogExportResponse>(token)
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
    public Task<HttpResponse<LogExportResponse>> Export(
        string id,
        LogExportParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Export(parameters with { ID = id }, cancellationToken);
    }
}
