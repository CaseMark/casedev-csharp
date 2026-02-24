using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Casedev.Core;
using Casedev.Exceptions;
using Casedev.Models.Compute.V1.Secrets;

namespace Casedev.Services.Compute.V1;

/// <inheritdoc/>
public sealed class SecretService : ISecretService
{
    readonly Lazy<ISecretServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ISecretServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICasedevClient _client;

    /// <inheritdoc/>
    public ISecretService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SecretService(this._client.WithOptions(modifier));
    }

    public SecretService(ICasedevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new SecretServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<SecretCreateResponse> Create(
        SecretCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<SecretListResponse> List(
        SecretListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<SecretDeleteGroupResponse> DeleteGroup(
        SecretDeleteGroupParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.DeleteGroup(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<SecretDeleteGroupResponse> DeleteGroup(
        string group,
        SecretDeleteGroupParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.DeleteGroup(parameters with { Group = group }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<SecretRetrieveGroupResponse> RetrieveGroup(
        SecretRetrieveGroupParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveGroup(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<SecretRetrieveGroupResponse> RetrieveGroup(
        string group,
        SecretRetrieveGroupParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveGroup(parameters with { Group = group }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<SecretUpdateGroupResponse> UpdateGroup(
        SecretUpdateGroupParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.UpdateGroup(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<SecretUpdateGroupResponse> UpdateGroup(
        string group,
        SecretUpdateGroupParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.UpdateGroup(parameters with { Group = group }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class SecretServiceWithRawResponse : ISecretServiceWithRawResponse
{
    readonly ICasedevClientWithRawResponse _client;

    /// <inheritdoc/>
    public ISecretServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SecretServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public SecretServiceWithRawResponse(ICasedevClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SecretCreateResponse>> Create(
        SecretCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<SecretCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var secret = await response
                    .Deserialize<SecretCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    secret.Validate();
                }
                return secret;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SecretListResponse>> List(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var secrets = await response
                    .Deserialize<SecretListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    secrets.Validate();
                }
                return secrets;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SecretDeleteGroupResponse>> DeleteGroup(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<SecretDeleteGroupResponse>(token)
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
    public Task<HttpResponse<SecretDeleteGroupResponse>> DeleteGroup(
        string group,
        SecretDeleteGroupParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.DeleteGroup(parameters with { Group = group }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SecretRetrieveGroupResponse>> RetrieveGroup(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<SecretRetrieveGroupResponse>(token)
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
    public Task<HttpResponse<SecretRetrieveGroupResponse>> RetrieveGroup(
        string group,
        SecretRetrieveGroupParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveGroup(parameters with { Group = group }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SecretUpdateGroupResponse>> UpdateGroup(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<SecretUpdateGroupResponse>(token)
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
    public Task<HttpResponse<SecretUpdateGroupResponse>> UpdateGroup(
        string group,
        SecretUpdateGroupParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.UpdateGroup(parameters with { Group = group }, cancellationToken);
    }
}
