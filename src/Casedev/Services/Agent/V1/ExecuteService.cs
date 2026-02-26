using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Casedev.Core;
using Casedev.Models.Agent.V1.Execute;

namespace Casedev.Services.Agent.V1;

/// <inheritdoc/>
public sealed class ExecuteService : IExecuteService
{
    readonly Lazy<IExecuteServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IExecuteServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICasedevClient _client;

    /// <inheritdoc/>
    public IExecuteService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ExecuteService(this._client.WithOptions(modifier));
    }

    public ExecuteService(ICasedevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ExecuteServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<ExecuteCreateResponse> Create(
        ExecuteCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class ExecuteServiceWithRawResponse : IExecuteServiceWithRawResponse
{
    readonly ICasedevClientWithRawResponse _client;

    /// <inheritdoc/>
    public IExecuteServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ExecuteServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ExecuteServiceWithRawResponse(ICasedevClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ExecuteCreateResponse>> Create(
        ExecuteCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ExecuteCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var execute = await response
                    .Deserialize<ExecuteCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    execute.Validate();
                }
                return execute;
            }
        );
    }
}
