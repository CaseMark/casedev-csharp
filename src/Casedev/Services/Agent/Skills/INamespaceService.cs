using System;
using System.Threading;
using System.Threading.Tasks;
using Casedev.Core;
using Casedev.Models.Agent.Skills.Namespaces;

namespace Casedev.Services.Agent.Skills;

/// <summary>
/// Create, manage, and execute AI agents with tool access, sandbox environments,
/// and async run workflows
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface INamespaceService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    INamespaceServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    INamespaceService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create a private skill namespace owned by the authenticated org and receive a
    /// one-time bearer token used by the case-skills publisher.
    /// </summary>
    Task Create(NamespaceCreateParams parameters, CancellationToken cancellationToken = default);

    /// <summary>
    /// Read skill namespace
    /// </summary>
    Task Retrieve(
        NamespaceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(NamespaceRetrieveParams, CancellationToken)"/>
    Task Retrieve(
        string id,
        NamespaceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List all active skill namespaces owned by the authenticated organization.
    /// </summary>
    Task List(
        NamespaceListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete skill namespace
    /// </summary>
    Task Delete(NamespaceDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(NamespaceDeleteParams, CancellationToken)"/>
    Task Delete(
        string id,
        NamespaceDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Upload a tree of skill files for the namespace. Authenticated by the namespace
    /// bearer token. Atomic at the version-bump level: a partial upload leaves the
    /// namespace pinned to the previous version.
    /// </summary>
    Task Publish(NamespacePublishParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Publish(NamespacePublishParams, CancellationToken)"/>
    Task Publish(
        string id,
        NamespacePublishParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the active version's file manifest with short-lived presigned S3 URLs.
    /// Sandboxes use this to materialize the tree at /workspace/.agents/skills/ before
    /// opencode boots.
    /// </summary>
    Task Pull(NamespacePullParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Pull(NamespacePullParams, CancellationToken)"/>
    Task Pull(
        string id,
        NamespacePullParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Rotate skill namespace token
    /// </summary>
    Task RotateToken(
        NamespaceRotateTokenParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RotateToken(NamespaceRotateTokenParams, CancellationToken)"/>
    Task RotateToken(
        string id,
        NamespaceRotateTokenParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="INamespaceService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface INamespaceServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    INamespaceServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /agent/skills/namespaces</c>, but is otherwise the
    /// same as <see cref="INamespaceService.Create(NamespaceCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Create(
        NamespaceCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /agent/skills/namespaces/{id}</c>, but is otherwise the
    /// same as <see cref="INamespaceService.Retrieve(NamespaceRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Retrieve(
        NamespaceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(NamespaceRetrieveParams, CancellationToken)"/>
    Task<HttpResponse> Retrieve(
        string id,
        NamespaceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /agent/skills/namespaces</c>, but is otherwise the
    /// same as <see cref="INamespaceService.List(NamespaceListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> List(
        NamespaceListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /agent/skills/namespaces/{id}</c>, but is otherwise the
    /// same as <see cref="INamespaceService.Delete(NamespaceDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        NamespaceDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(NamespaceDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string id,
        NamespaceDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /agent/skills/namespaces/{id}/publish</c>, but is otherwise the
    /// same as <see cref="INamespaceService.Publish(NamespacePublishParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Publish(
        NamespacePublishParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Publish(NamespacePublishParams, CancellationToken)"/>
    Task<HttpResponse> Publish(
        string id,
        NamespacePublishParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /agent/skills/namespaces/{id}/pull</c>, but is otherwise the
    /// same as <see cref="INamespaceService.Pull(NamespacePullParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Pull(
        NamespacePullParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Pull(NamespacePullParams, CancellationToken)"/>
    Task<HttpResponse> Pull(
        string id,
        NamespacePullParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /agent/skills/namespaces/{id}/rotate-token</c>, but is otherwise the
    /// same as <see cref="INamespaceService.RotateToken(NamespaceRotateTokenParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> RotateToken(
        NamespaceRotateTokenParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RotateToken(NamespaceRotateTokenParams, CancellationToken)"/>
    Task<HttpResponse> RotateToken(
        string id,
        NamespaceRotateTokenParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
