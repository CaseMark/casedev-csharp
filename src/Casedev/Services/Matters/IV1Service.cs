using System;
using System.Threading;
using System.Threading.Tasks;
using Casedev.Core;
using Casedev.Models.Matters.V1;
using Casedev.Services.Matters.V1;

namespace Casedev.Services.Matters;

/// <summary>
/// Matter-native legal workspaces and orchestration primitives
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IV1Service
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IV1ServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IV1Service WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IAgentTypeService AgentTypes { get; }

    IPartyService Parties { get; }

    ITypeService Types { get; }

    IEventService Events { get; }

    ILogService Log { get; }

    IMatterPartyService MatterParties { get; }

    IShareService Shares { get; }

    IWorkItemService WorkItems { get; }

    /// <summary>
    /// Create a new legal matter and provision its primary vault.
    /// </summary>
    Task Create(V1CreateParams parameters, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get a single matter by ID.
    /// </summary>
    Task Retrieve(V1RetrieveParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Retrieve(V1RetrieveParams, CancellationToken)"/>
    Task Retrieve(
        string id,
        V1RetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update mutable matter fields.
    /// </summary>
    Task Update(V1UpdateParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Update(V1UpdateParams, CancellationToken)"/>
    Task Update(
        string id,
        V1UpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List matters for the authenticated organization.
    /// </summary>
    Task List(V1ListParams? parameters = null, CancellationToken cancellationToken = default);
}

/// <summary>
/// A view of <see cref="IV1Service"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IV1ServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IV1ServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IAgentTypeServiceWithRawResponse AgentTypes { get; }

    IPartyServiceWithRawResponse Parties { get; }

    ITypeServiceWithRawResponse Types { get; }

    IEventServiceWithRawResponse Events { get; }

    ILogServiceWithRawResponse Log { get; }

    IMatterPartyServiceWithRawResponse MatterParties { get; }

    IShareServiceWithRawResponse Shares { get; }

    IWorkItemServiceWithRawResponse WorkItems { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>post /matters/v1</c>, but is otherwise the
    /// same as <see cref="IV1Service.Create(V1CreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Create(
        V1CreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /matters/v1/{id}</c>, but is otherwise the
    /// same as <see cref="IV1Service.Retrieve(V1RetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Retrieve(
        V1RetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(V1RetrieveParams, CancellationToken)"/>
    Task<HttpResponse> Retrieve(
        string id,
        V1RetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /matters/v1/{id}</c>, but is otherwise the
    /// same as <see cref="IV1Service.Update(V1UpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Update(
        V1UpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(V1UpdateParams, CancellationToken)"/>
    Task<HttpResponse> Update(
        string id,
        V1UpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /matters/v1</c>, but is otherwise the
    /// same as <see cref="IV1Service.List(V1ListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> List(
        V1ListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
