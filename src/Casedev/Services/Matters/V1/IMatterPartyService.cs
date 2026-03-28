using System;
using System.Threading;
using System.Threading.Tasks;
using Casedev.Core;
using Casedev.Models.Matters.V1.MatterParties;

namespace Casedev.Services.Matters.V1;

/// <summary>
/// Matter-native legal workspaces and orchestration primitives
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IMatterPartyService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IMatterPartyServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMatterPartyService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Attach a reusable party to a matter with a matter-specific role.
    /// </summary>
    Task Create(MatterPartyCreateParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Create(MatterPartyCreateParams, CancellationToken)"/>
    Task Create(
        string id,
        MatterPartyCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List parties attached to a matter.
    /// </summary>
    Task List(MatterPartyListParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="List(MatterPartyListParams, CancellationToken)"/>
    Task List(
        string id,
        MatterPartyListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IMatterPartyService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IMatterPartyServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMatterPartyServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /matters/v1/{id}/parties</c>, but is otherwise the
    /// same as <see cref="IMatterPartyService.Create(MatterPartyCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Create(
        MatterPartyCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(MatterPartyCreateParams, CancellationToken)"/>
    Task<HttpResponse> Create(
        string id,
        MatterPartyCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /matters/v1/{id}/parties</c>, but is otherwise the
    /// same as <see cref="IMatterPartyService.List(MatterPartyListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> List(
        MatterPartyListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(MatterPartyListParams, CancellationToken)"/>
    Task<HttpResponse> List(
        string id,
        MatterPartyListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
