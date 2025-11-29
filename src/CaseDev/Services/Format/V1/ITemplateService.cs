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
    Task Retrieve(TemplateRetrieveParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Retrieve(TemplateRetrieveParams, CancellationToken)"/>
    Task Retrieve(
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
    Task List(TemplateListParams? parameters = null, CancellationToken cancellationToken = default);
}
