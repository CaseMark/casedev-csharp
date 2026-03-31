using System;
using System.Threading;
using System.Threading.Tasks;
using Casedev.Core;
using Casedev.Models.Matters.V1.Parties;

namespace Casedev.Services.Matters.V1;

/// <summary>
/// Matter-native legal workspaces and orchestration primitives
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IPartyService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IPartyServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPartyService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create a reusable legal party for the authenticated organization.
    /// </summary>
    Task Create(PartyCreateParams parameters, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get a reusable legal party by ID.
    /// </summary>
    Task Retrieve(PartyRetrieveParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Retrieve(PartyRetrieveParams, CancellationToken)"/>
    Task Retrieve(
        string partyID,
        PartyRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update a reusable legal party.
    /// </summary>
    Task Update(PartyUpdateParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Update(PartyUpdateParams, CancellationToken)"/>
    Task Update(
        string partyID,
        PartyUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List reusable legal parties for the authenticated organization.
    /// </summary>
    Task List(PartyListParams? parameters = null, CancellationToken cancellationToken = default);
}

/// <summary>
/// A view of <see cref="IPartyService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IPartyServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPartyServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /matters/v1/parties</c>, but is otherwise the
    /// same as <see cref="IPartyService.Create(PartyCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Create(
        PartyCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /matters/v1/parties/{partyId}</c>, but is otherwise the
    /// same as <see cref="IPartyService.Retrieve(PartyRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Retrieve(
        PartyRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(PartyRetrieveParams, CancellationToken)"/>
    Task<HttpResponse> Retrieve(
        string partyID,
        PartyRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /matters/v1/parties/{partyId}</c>, but is otherwise the
    /// same as <see cref="IPartyService.Update(PartyUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Update(
        PartyUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(PartyUpdateParams, CancellationToken)"/>
    Task<HttpResponse> Update(
        string partyID,
        PartyUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /matters/v1/parties</c>, but is otherwise the
    /// same as <see cref="IPartyService.List(PartyListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> List(
        PartyListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
