using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CaseDev.Core;
using CaseDev.Exceptions;
using CaseDev.Models.Compute.V1.Secrets;

namespace CaseDev.Services.Compute.V1;

/// <inheritdoc />
public sealed class SecretService : ISecretService
{
    /// <inheritdoc/>
    public ISecretService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SecretService(this._client.WithOptions(modifier));
    }

    readonly ICasedevClient _client;

    public SecretService(ICasedevClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<SecretCreateResponse> Create(
        SecretCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<SecretCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var secret = await response
            .Deserialize<SecretCreateResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            secret.Validate();
        }
        return secret;
    }

    /// <inheritdoc/>
    public async Task List(
        SecretListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<SecretListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task DeleteGroup(
        SecretDeleteGroupParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Group == null)
        {
            throw new CasedevInvalidDataException("'parameters.Group' cannot be null");
        }

        HttpRequest<SecretDeleteGroupParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task DeleteGroup(
        string group,
        SecretDeleteGroupParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.DeleteGroup(parameters with { Group = group }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task RetrieveGroup(
        SecretRetrieveGroupParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Group == null)
        {
            throw new CasedevInvalidDataException("'parameters.Group' cannot be null");
        }

        HttpRequest<SecretRetrieveGroupParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task RetrieveGroup(
        string group,
        SecretRetrieveGroupParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.RetrieveGroup(parameters with { Group = group }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task UpdateGroup(
        SecretUpdateGroupParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Group == null)
        {
            throw new CasedevInvalidDataException("'parameters.Group' cannot be null");
        }

        HttpRequest<SecretUpdateGroupParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task UpdateGroup(
        string group,
        SecretUpdateGroupParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.UpdateGroup(parameters with { Group = group }, cancellationToken);
    }
}
