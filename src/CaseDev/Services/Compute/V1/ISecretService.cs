using System;
using System.Threading;
using System.Threading.Tasks;
using CaseDev.Core;
using CaseDev.Models.Compute.V1.Secrets;

namespace CaseDev.Services.Compute.V1;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ISecretService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ISecretServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISecretService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Creates a new secret group in a compute environment. Secret groups organize
    /// related secrets for use in serverless functions and workflows. If no environment
    /// is specified, the group is created in the default environment.
    ///
    /// <para>**Features:** - Organize secrets by logical groups (e.g., database,
    /// APIs, third-party services) - Environment-based isolation - Validation of
    /// group names - Conflict detection for existing groups</para>
    /// </summary>
    Task<SecretCreateResponse> Create(
        SecretCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve all secret groups for a compute environment. Secret groups organize
    /// related secrets (API keys, credentials, etc.) that can be securely accessed
    /// by compute jobs during execution.
    /// </summary>
    Task<SecretListResponse> List(
        SecretListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete an entire secret group or a specific key within a secret group. When
    /// deleting a specific key, the remaining secrets in the group are preserved.
    /// When deleting the entire group, all secrets and the group itself are removed.
    /// </summary>
    Task<SecretDeleteGroupResponse> DeleteGroup(
        SecretDeleteGroupParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="DeleteGroup(SecretDeleteGroupParams, CancellationToken)"/>
    Task<SecretDeleteGroupResponse> DeleteGroup(
        string group,
        SecretDeleteGroupParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve the keys (names) of secrets in a specified group within a compute
    /// environment. For security reasons, actual secret values are not returned -
    /// only the keys and metadata.
    /// </summary>
    Task<SecretRetrieveGroupResponse> RetrieveGroup(
        SecretRetrieveGroupParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveGroup(SecretRetrieveGroupParams, CancellationToken)"/>
    Task<SecretRetrieveGroupResponse> RetrieveGroup(
        string group,
        SecretRetrieveGroupParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Set or update secrets in a compute secret group. Secrets are encrypted with
    /// AES-256-GCM. Use this to manage environment variables and API keys for your
    /// compute workloads.
    /// </summary>
    Task<SecretUpdateGroupResponse> UpdateGroup(
        SecretUpdateGroupParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="UpdateGroup(SecretUpdateGroupParams, CancellationToken)"/>
    Task<SecretUpdateGroupResponse> UpdateGroup(
        string group,
        SecretUpdateGroupParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ISecretService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ISecretServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISecretServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `post /compute/v1/secrets`, but is otherwise the
    /// same as <see cref="ISecretService.Create(SecretCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SecretCreateResponse>> Create(
        SecretCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /compute/v1/secrets`, but is otherwise the
    /// same as <see cref="ISecretService.List(SecretListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SecretListResponse>> List(
        SecretListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `delete /compute/v1/secrets/{group}`, but is otherwise the
    /// same as <see cref="ISecretService.DeleteGroup(SecretDeleteGroupParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SecretDeleteGroupResponse>> DeleteGroup(
        SecretDeleteGroupParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="DeleteGroup(SecretDeleteGroupParams, CancellationToken)"/>
    Task<HttpResponse<SecretDeleteGroupResponse>> DeleteGroup(
        string group,
        SecretDeleteGroupParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /compute/v1/secrets/{group}`, but is otherwise the
    /// same as <see cref="ISecretService.RetrieveGroup(SecretRetrieveGroupParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SecretRetrieveGroupResponse>> RetrieveGroup(
        SecretRetrieveGroupParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveGroup(SecretRetrieveGroupParams, CancellationToken)"/>
    Task<HttpResponse<SecretRetrieveGroupResponse>> RetrieveGroup(
        string group,
        SecretRetrieveGroupParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `put /compute/v1/secrets/{group}`, but is otherwise the
    /// same as <see cref="ISecretService.UpdateGroup(SecretUpdateGroupParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SecretUpdateGroupResponse>> UpdateGroup(
        SecretUpdateGroupParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="UpdateGroup(SecretUpdateGroupParams, CancellationToken)"/>
    Task<HttpResponse<SecretUpdateGroupResponse>> UpdateGroup(
        string group,
        SecretUpdateGroupParams parameters,
        CancellationToken cancellationToken = default
    );
}
