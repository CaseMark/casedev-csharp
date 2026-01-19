using System;
using System.Threading;
using System.Threading.Tasks;
using CaseDev.Core;
using CaseDev.Models.Format.V1.Templates;

namespace CaseDev.Services.Format.V1;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ITemplateService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ITemplateServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITemplateService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create a new format template for document formatting. Templates support variables
    /// using `{{variable}}` syntax and can be used for captions, signatures, letterheads,
    /// certificates, footers, or custom formatting needs.
    /// </summary>
    Task<TemplateCreateResponse> Create(
        TemplateCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a specific document format template by ID. Format templates define
    /// how documents should be structured and formatted for specific legal use cases
    /// such as contracts, briefs, or pleadings.
    /// </summary>
    Task<TemplateRetrieveResponse> Retrieve(
        TemplateRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(TemplateRetrieveParams, CancellationToken)"/>
    Task<TemplateRetrieveResponse> Retrieve(
        string id,
        TemplateRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve all format templates for the organization. Templates define reusable
    /// document formatting patterns with customizable variables for consistent legal
    /// document generation.
    ///
    /// <para>Filter by type to get specific template categories like contracts,
    /// pleadings, or correspondence.</para>
    /// </summary>
    Task<TemplateListResponse> List(
        TemplateListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ITemplateService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ITemplateServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITemplateServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `post /format/v1/templates`, but is otherwise the
    /// same as <see cref="ITemplateService.Create(TemplateCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TemplateCreateResponse>> Create(
        TemplateCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /format/v1/templates/{id}`, but is otherwise the
    /// same as <see cref="ITemplateService.Retrieve(TemplateRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TemplateRetrieveResponse>> Retrieve(
        TemplateRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(TemplateRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<TemplateRetrieveResponse>> Retrieve(
        string id,
        TemplateRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /format/v1/templates`, but is otherwise the
    /// same as <see cref="ITemplateService.List(TemplateListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TemplateListResponse>> List(
        TemplateListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
