using System;
using System.Threading;
using System.Threading.Tasks;
using Casedev.Core;
using Casedev.Models.Skills;
using Casedev.Services.Skills;

namespace Casedev.Services;

/// <summary>
/// Search and read legal AI skills for agents
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ISkillService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ISkillServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISkillService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ICustomService Custom { get; }

    /// <summary>
    /// Create an org-scoped custom skill. The skill will be searchable via /skills/resolve
    /// alongside curated skills.
    /// </summary>
    Task<SkillCreateResponse> Create(
        SkillCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update an org-scoped custom skill by slug. Only provided fields are updated.
    /// Version is auto-incremented.
    /// </summary>
    Task<SkillUpdateResponse> Update(
        SkillUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(SkillUpdateParams, CancellationToken)"/>
    Task<SkillUpdateResponse> Update(
        string slug,
        SkillUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Soft-delete an org-scoped custom skill by slug. The skill will no longer
    /// appear in search results.
    /// </summary>
    Task<SkillDeleteResponse> Delete(
        SkillDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(SkillDeleteParams, CancellationToken)"/>
    Task<SkillDeleteResponse> Delete(
        string slug,
        SkillDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Read the full content of a legal skill by its slug. Returns markdown content,
    /// tags, and metadata.
    /// </summary>
    Task<SkillReadResponse> Read(
        SkillReadParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Read(SkillReadParams, CancellationToken)"/>
    Task<SkillReadResponse> Read(
        string slug,
        SkillReadParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Search the Legal Skills Store using hybrid search (text + tag + semantic).
    /// Returns ranked results with relevance scores.
    /// </summary>
    Task<SkillResolveResponse> Resolve(
        SkillResolveParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ISkillService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ISkillServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISkillServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ICustomServiceWithRawResponse Custom { get; }

    /// <summary>
    /// Returns a raw HTTP response for `post /skills`, but is otherwise the
    /// same as <see cref="ISkillService.Create(SkillCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SkillCreateResponse>> Create(
        SkillCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `put /skills/{slug}`, but is otherwise the
    /// same as <see cref="ISkillService.Update(SkillUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SkillUpdateResponse>> Update(
        SkillUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(SkillUpdateParams, CancellationToken)"/>
    Task<HttpResponse<SkillUpdateResponse>> Update(
        string slug,
        SkillUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `delete /skills/{slug}`, but is otherwise the
    /// same as <see cref="ISkillService.Delete(SkillDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SkillDeleteResponse>> Delete(
        SkillDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(SkillDeleteParams, CancellationToken)"/>
    Task<HttpResponse<SkillDeleteResponse>> Delete(
        string slug,
        SkillDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /skills/{slug}`, but is otherwise the
    /// same as <see cref="ISkillService.Read(SkillReadParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SkillReadResponse>> Read(
        SkillReadParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Read(SkillReadParams, CancellationToken)"/>
    Task<HttpResponse<SkillReadResponse>> Read(
        string slug,
        SkillReadParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /skills/resolve`, but is otherwise the
    /// same as <see cref="ISkillService.Resolve(SkillResolveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SkillResolveResponse>> Resolve(
        SkillResolveParams parameters,
        CancellationToken cancellationToken = default
    );
}
