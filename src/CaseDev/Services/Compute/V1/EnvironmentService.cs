using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CaseDev.Core;
using CaseDev.Exceptions;
using CaseDev.Models.Compute.V1.Environments;

namespace CaseDev.Services.Compute.V1;

/// <inheritdoc/>
public sealed class EnvironmentService : IEnvironmentService
{
    /// <inheritdoc/>
    public IEnvironmentService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new EnvironmentService(this._client.WithOptions(modifier));
    }

    readonly ICasedevClient _client;

    public EnvironmentService(ICasedevClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<EnvironmentCreateResponse> Create(
        EnvironmentCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<EnvironmentCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var environment = await response
            .Deserialize<EnvironmentCreateResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            environment.Validate();
        }
        return environment;
    }

    /// <inheritdoc/>
    public async Task Retrieve(
        EnvironmentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Name == null)
        {
            throw new CasedevInvalidDataException("'parameters.Name' cannot be null");
        }

        HttpRequest<EnvironmentRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task Retrieve(
        string name,
        EnvironmentRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Retrieve(parameters with { Name = name }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task List(
        EnvironmentListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<EnvironmentListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<EnvironmentDeleteResponse> Delete(
        EnvironmentDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Name == null)
        {
            throw new CasedevInvalidDataException("'parameters.Name' cannot be null");
        }

        HttpRequest<EnvironmentDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var environment = await response
            .Deserialize<EnvironmentDeleteResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            environment.Validate();
        }
        return environment;
    }

    /// <inheritdoc/>
    public async Task<EnvironmentDeleteResponse> Delete(
        string name,
        EnvironmentDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Delete(parameters with { Name = name }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task SetDefault(
        EnvironmentSetDefaultParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Name == null)
        {
            throw new CasedevInvalidDataException("'parameters.Name' cannot be null");
        }

        HttpRequest<EnvironmentSetDefaultParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task SetDefault(
        string name,
        EnvironmentSetDefaultParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.SetDefault(parameters with { Name = name }, cancellationToken);
    }
}
