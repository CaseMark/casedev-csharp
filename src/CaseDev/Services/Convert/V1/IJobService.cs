using System;
using System.Threading;
using System.Threading.Tasks;
using CaseDev.Core;
using CaseDev.Models.Convert.V1.Jobs;

namespace CaseDev.Services.Convert.V1;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IJobService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IJobServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IJobService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Retrieve the status of a file conversion job. Returns detailed information
    /// about the conversion progress, completion status, and any errors that occurred
    /// during processing.
    /// </summary>
    Task Retrieve(JobRetrieveParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Retrieve(JobRetrieveParams, CancellationToken)"/>
    Task Retrieve(
        string id,
        JobRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a converted file from Modal storage by its job ID. This permanently
    /// removes the file and its associated metadata from the system.
    /// </summary>
    Task Delete(JobDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(JobDeleteParams, CancellationToken)"/>
    Task Delete(
        string id,
        JobDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IJobService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IJobServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IJobServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `get /convert/v1/jobs/{id}`, but is otherwise the
    /// same as <see cref="IJobService.Retrieve(JobRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Retrieve(
        JobRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(JobRetrieveParams, CancellationToken)"/>
    Task<HttpResponse> Retrieve(
        string id,
        JobRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `delete /convert/v1/jobs/{id}`, but is otherwise the
    /// same as <see cref="IJobService.Delete(JobDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        JobDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(JobDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string id,
        JobDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
