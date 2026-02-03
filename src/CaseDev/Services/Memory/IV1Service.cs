using System;
using System.Threading;
using System.Threading.Tasks;
using CaseDev.Core;
using CaseDev.Models.Memory.V1;

namespace CaseDev.Services.Memory;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
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

    /// <summary>
    /// Store memories from conversation messages. Automatically extracts facts and
    /// handles deduplication.
    ///
    /// <para>Use tag_1 through tag_12 for filtering - these are generic indexed fields
    /// you can use for any purpose: - Legal app: tag_1=client_id, tag_2=matter_id
    /// - Healthcare: tag_1=patient_id, tag_2=encounter_id - E-commerce: tag_1=customer_id, tag_2=order_id</para>
    /// </summary>
    Task<V1CreateResponse> Create(
        V1CreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a single memory by its ID.
    /// </summary>
    Task<V1RetrieveResponse> Retrieve(
        V1RetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(V1RetrieveParams, CancellationToken)"/>
    Task<V1RetrieveResponse> Retrieve(
        string id,
        V1RetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List all memories with optional filtering by tags and category.
    /// </summary>
    Task<V1ListResponse> List(
        V1ListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a single memory by its ID.
    /// </summary>
    Task<V1DeleteResponse> Delete(
        V1DeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(V1DeleteParams, CancellationToken)"/>
    Task<V1DeleteResponse> Delete(
        string id,
        V1DeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete multiple memories matching tag filter criteria. CAUTION: This will
    /// delete all matching memories for your organization.
    /// </summary>
    Task<V1DeleteAllResponse> DeleteAll(
        V1DeleteAllParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Search memories using semantic similarity. Filter by tag fields to narrow results.
    ///
    /// <para>Use tag_1 through tag_12 for filtering - these are generic indexed fields
    /// you define: - Legal app: tag_1=client_id, tag_2=matter_id - Healthcare: tag_1=patient_id, tag_2=encounter_id</para>
    /// </summary>
    Task<V1SearchResponse> Search(
        V1SearchParams parameters,
        CancellationToken cancellationToken = default
    );
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

    /// <summary>
    /// Returns a raw HTTP response for `post /memory/v1`, but is otherwise the
    /// same as <see cref="IV1Service.Create(V1CreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<V1CreateResponse>> Create(
        V1CreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /memory/v1/{id}`, but is otherwise the
    /// same as <see cref="IV1Service.Retrieve(V1RetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<V1RetrieveResponse>> Retrieve(
        V1RetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(V1RetrieveParams, CancellationToken)"/>
    Task<HttpResponse<V1RetrieveResponse>> Retrieve(
        string id,
        V1RetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /memory/v1`, but is otherwise the
    /// same as <see cref="IV1Service.List(V1ListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<V1ListResponse>> List(
        V1ListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `delete /memory/v1/{id}`, but is otherwise the
    /// same as <see cref="IV1Service.Delete(V1DeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<V1DeleteResponse>> Delete(
        V1DeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(V1DeleteParams, CancellationToken)"/>
    Task<HttpResponse<V1DeleteResponse>> Delete(
        string id,
        V1DeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `delete /memory/v1`, but is otherwise the
    /// same as <see cref="IV1Service.DeleteAll(V1DeleteAllParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<V1DeleteAllResponse>> DeleteAll(
        V1DeleteAllParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /memory/v1/search`, but is otherwise the
    /// same as <see cref="IV1Service.Search(V1SearchParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<V1SearchResponse>> Search(
        V1SearchParams parameters,
        CancellationToken cancellationToken = default
    );
}
