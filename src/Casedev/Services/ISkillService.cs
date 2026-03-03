using System;
using System.Threading;
using System.Threading.Tasks;
using Casedev.Core;
using Casedev.Models.Skills;

namespace Casedev.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
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
