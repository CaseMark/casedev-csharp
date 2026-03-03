using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Casedev.Core;
using Casedev.Exceptions;
using Casedev.Models.Skills;

namespace Casedev.Services;

/// <inheritdoc/>
public sealed class SkillService : ISkillService
{
    readonly Lazy<ISkillServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ISkillServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICasedevClient _client;

    /// <inheritdoc/>
    public ISkillService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SkillService(this._client.WithOptions(modifier));
    }

    public SkillService(ICasedevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new SkillServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<SkillReadResponse> Read(
        SkillReadParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Read(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<SkillReadResponse> Read(
        string slug,
        SkillReadParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Read(parameters with { Slug = slug }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<SkillResolveResponse> Resolve(
        SkillResolveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Resolve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class SkillServiceWithRawResponse : ISkillServiceWithRawResponse
{
    readonly ICasedevClientWithRawResponse _client;

    /// <inheritdoc/>
    public ISkillServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SkillServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public SkillServiceWithRawResponse(ICasedevClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SkillReadResponse>> Read(
        SkillReadParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Slug == null)
        {
            throw new CasedevInvalidDataException("'parameters.Slug' cannot be null");
        }

        HttpRequest<SkillReadParams> request = new()
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
                    .Deserialize<SkillReadResponse>(token)
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
    public Task<HttpResponse<SkillReadResponse>> Read(
        string slug,
        SkillReadParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Read(parameters with { Slug = slug }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SkillResolveResponse>> Resolve(
        SkillResolveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<SkillResolveParams> request = new()
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
                    .Deserialize<SkillResolveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }
}
