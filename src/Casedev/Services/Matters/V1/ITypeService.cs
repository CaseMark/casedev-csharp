using System;
using System.Threading;
using System.Threading.Tasks;
using Casedev.Core;
using Casedev.Models.Matters.V1.Types;

namespace Casedev.Services.Matters.V1;

/// <summary>
/// Matter-native legal workspaces and orchestration primitives
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ITypeService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ITypeServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITypeService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create a matter type with plain-English operating instructions and seeded work.
    /// </summary>
    Task Create(TypeCreateParams parameters, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get a single matter type.
    /// </summary>
    Task Retrieve(TypeRetrieveParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Retrieve(TypeRetrieveParams, CancellationToken)"/>
    Task Retrieve(
        string id,
        TypeRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update a matter type.
    /// </summary>
    Task Update(TypeUpdateParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Update(TypeUpdateParams, CancellationToken)"/>
    Task Update(
        string id,
        TypeUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List matter types for the authenticated organization.
    /// </summary>
    Task List(TypeListParams? parameters = null, CancellationToken cancellationToken = default);
}

/// <summary>
/// A view of <see cref="ITypeService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ITypeServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITypeServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /matters/v1/types</c>, but is otherwise the
    /// same as <see cref="ITypeService.Create(TypeCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Create(
        TypeCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /matters/v1/types/{id}</c>, but is otherwise the
    /// same as <see cref="ITypeService.Retrieve(TypeRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Retrieve(
        TypeRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(TypeRetrieveParams, CancellationToken)"/>
    Task<HttpResponse> Retrieve(
        string id,
        TypeRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /matters/v1/types/{id}</c>, but is otherwise the
    /// same as <see cref="ITypeService.Update(TypeUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Update(
        TypeUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(TypeUpdateParams, CancellationToken)"/>
    Task<HttpResponse> Update(
        string id,
        TypeUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /matters/v1/types</c>, but is otherwise the
    /// same as <see cref="ITypeService.List(TypeListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> List(
        TypeListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
