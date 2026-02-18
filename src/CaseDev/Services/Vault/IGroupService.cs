using System;
using System.Threading;
using System.Threading.Tasks;
using CaseDev.Core;
using CaseDev.Models.Vault.Groups;

namespace CaseDev.Services.Vault;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IGroupService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IGroupServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IGroupService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create vault group
    /// </summary>
    Task Create(
        GroupCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update vault group
    /// </summary>
    Task Update(GroupUpdateParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Update(GroupUpdateParams, CancellationToken)"/>
    Task Update(
        string groupID,
        GroupUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List vault groups
    /// </summary>
    Task List(GroupListParams? parameters = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete vault group
    /// </summary>
    Task Delete(GroupDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(GroupDeleteParams, CancellationToken)"/>
    Task Delete(
        string groupID,
        GroupDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IGroupService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IGroupServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IGroupServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `post /vault/groups`, but is otherwise the
    /// same as <see cref="IGroupService.Create(GroupCreateParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Create(
        GroupCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `patch /vault/groups/{groupId}`, but is otherwise the
    /// same as <see cref="IGroupService.Update(GroupUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Update(
        GroupUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(GroupUpdateParams, CancellationToken)"/>
    Task<HttpResponse> Update(
        string groupID,
        GroupUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /vault/groups`, but is otherwise the
    /// same as <see cref="IGroupService.List(GroupListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> List(
        GroupListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `delete /vault/groups/{groupId}`, but is otherwise the
    /// same as <see cref="IGroupService.Delete(GroupDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        GroupDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(GroupDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string groupID,
        GroupDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
