using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Casedev.Core;
using Casedev.Exceptions;
using Casedev.Models.Compute.V1.Environments;

namespace Casedev.Services.Compute.V1;

/// <inheritdoc/>
public sealed class EnvironmentService : IEnvironmentService
{
    readonly Lazy<IEnvironmentServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IEnvironmentServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICasedevClient _client;

    /// <inheritdoc/>
    public IEnvironmentService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new EnvironmentService(this._client.WithOptions(modifier));
    }

    public EnvironmentService(ICasedevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new EnvironmentServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<EnvironmentCreateResponse> Create(
        EnvironmentCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<EnvironmentRetrieveResponse> Retrieve(
        EnvironmentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<EnvironmentRetrieveResponse> Retrieve(
        string name,
        EnvironmentRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { Name = name }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<EnvironmentListResponse> List(
        EnvironmentListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<EnvironmentDeleteResponse> Delete(
        EnvironmentDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Delete(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<EnvironmentDeleteResponse> Delete(
        string name,
        EnvironmentDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { Name = name }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<EnvironmentSetDefaultResponse> SetDefault(
        EnvironmentSetDefaultParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.SetDefault(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<EnvironmentSetDefaultResponse> SetDefault(
        string name,
        EnvironmentSetDefaultParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.SetDefault(parameters with { Name = name }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class EnvironmentServiceWithRawResponse : IEnvironmentServiceWithRawResponse
{
    readonly ICasedevClientWithRawResponse _client;

    /// <inheritdoc/>
    public IEnvironmentServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new EnvironmentServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public EnvironmentServiceWithRawResponse(ICasedevClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EnvironmentCreateResponse>> Create(
        EnvironmentCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<EnvironmentCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var environment = await response
                    .Deserialize<EnvironmentCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    environment.Validate();
                }
                return environment;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EnvironmentRetrieveResponse>> Retrieve(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var environment = await response
                    .Deserialize<EnvironmentRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    environment.Validate();
                }
                return environment;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<EnvironmentRetrieveResponse>> Retrieve(
        string name,
        EnvironmentRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { Name = name }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EnvironmentListResponse>> List(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var environments = await response
                    .Deserialize<EnvironmentListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    environments.Validate();
                }
                return environments;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EnvironmentDeleteResponse>> Delete(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var environment = await response
                    .Deserialize<EnvironmentDeleteResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    environment.Validate();
                }
                return environment;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<EnvironmentDeleteResponse>> Delete(
        string name,
        EnvironmentDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { Name = name }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EnvironmentSetDefaultResponse>> SetDefault(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<EnvironmentSetDefaultResponse>(token)
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
    public Task<HttpResponse<EnvironmentSetDefaultResponse>> SetDefault(
        string name,
        EnvironmentSetDefaultParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.SetDefault(parameters with { Name = name }, cancellationToken);
    }
}
