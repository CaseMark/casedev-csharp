using System;
using System.Threading;
using System.Threading.Tasks;
using Casedev.Core;
using Casedev.Models.Matters.V1.Shares;

namespace Casedev.Services.Matters.V1;

/// <summary>
/// Matter-native legal workspaces and orchestration primitives
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IShareService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IShareServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IShareService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Grant another organization scoped access to this matter and its primary vault.
    /// </summary>
    Task Create(ShareCreateParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Create(ShareCreateParams, CancellationToken)"/>
    Task Create(
        string id,
        ShareCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List cross-org shares for a matter. Owner only.
    /// </summary>
    Task List(ShareListParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="List(ShareListParams, CancellationToken)"/>
    Task List(
        string id,
        ShareListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Revoke a matter share and its linked vault share.
    /// </summary>
    Task Delete(ShareDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(ShareDeleteParams, CancellationToken)"/>
    Task Delete(
        string shareID,
        ShareDeleteParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IShareService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IShareServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IShareServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /matters/v1/{id}/shares</c>, but is otherwise the
    /// same as <see cref="IShareService.Create(ShareCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Create(
        ShareCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(ShareCreateParams, CancellationToken)"/>
    Task<HttpResponse> Create(
        string id,
        ShareCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /matters/v1/{id}/shares</c>, but is otherwise the
    /// same as <see cref="IShareService.List(ShareListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> List(
        ShareListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(ShareListParams, CancellationToken)"/>
    Task<HttpResponse> List(
        string id,
        ShareListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /matters/v1/{id}/shares/{shareId}</c>, but is otherwise the
    /// same as <see cref="IShareService.Delete(ShareDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        ShareDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(ShareDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string shareID,
        ShareDeleteParams parameters,
        CancellationToken cancellationToken = default
    );
}
