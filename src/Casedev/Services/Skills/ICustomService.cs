using System;
using System.Threading;
using System.Threading.Tasks;
using Casedev.Core;
using Casedev.Models.Skills.Custom;

namespace Casedev.Services.Skills;

/// <summary>
/// Search and read legal AI skills for agents
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ICustomService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICustomServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICustomService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// List all custom skills for the authenticated organization. Supports cursor-based
    /// pagination.
    /// </summary>
    Task<CustomListResponse> List(
        CustomListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ICustomService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICustomServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICustomServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /skills/custom</c>, but is otherwise the
    /// same as <see cref="ICustomService.List(CustomListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CustomListResponse>> List(
        CustomListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
