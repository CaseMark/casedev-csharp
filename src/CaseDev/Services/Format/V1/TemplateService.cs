using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CaseDev.Core;
using CaseDev.Exceptions;
using CaseDev.Models.Format.V1.Templates;

namespace CaseDev.Services.Format.V1;

/// <inheritdoc/>
public sealed class TemplateService : global::CaseDev.Services.Format.V1.ITemplateService
{
    readonly Lazy<global::CaseDev.Services.Format.V1.ITemplateServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public global::CaseDev.Services.Format.V1.ITemplateServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICasedevClient _client;

    /// <inheritdoc/>
    public global::CaseDev.Services.Format.V1.ITemplateService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new global::CaseDev.Services.Format.V1.TemplateService(
            this._client.WithOptions(modifier)
        );
    }

    public TemplateService(ICasedevClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new global::CaseDev.Services.Format.V1.TemplateServiceWithRawResponse(
                client.WithRawResponse
            )
        );
    }

    /// <inheritdoc/>
    public async Task<TemplateCreateResponse> Create(
        TemplateCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task Retrieve(
        TemplateRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task Retrieve(
        string id,
        TemplateRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Retrieve(parameters with { ID = id }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task List(
        TemplateListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class TemplateServiceWithRawResponse
    : global::CaseDev.Services.Format.V1.ITemplateServiceWithRawResponse
{
    readonly ICasedevClientWithRawResponse _client;

    /// <inheritdoc/>
    public global::CaseDev.Services.Format.V1.ITemplateServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new global::CaseDev.Services.Format.V1.TemplateServiceWithRawResponse(
            this._client.WithOptions(modifier)
        );
    }

    public TemplateServiceWithRawResponse(ICasedevClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TemplateCreateResponse>> Create(
        TemplateCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<TemplateCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var template = await response
                    .Deserialize<TemplateCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    template.Validate();
                }
                return template;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Retrieve(
        TemplateRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CasedevInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<TemplateRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Retrieve(
        string id,
        TemplateRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> List(
        TemplateListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<TemplateListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }
}
