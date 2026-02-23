using System;
using System.Threading;
using System.Threading.Tasks;
using Router.Core;
using Router.Models.System;

namespace Router.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ISystemService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ISystemServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISystemService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns the public Case.dev services catalog derived from docs.case.dev/services.
    /// This endpoint is unauthenticated and intended for discovery surfaces such
    /// as the case.dev homepage.
    /// </summary>
    Task<SystemListServicesResponse> ListServices(
        SystemListServicesParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ISystemService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ISystemServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISystemServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `get /services`, but is otherwise the
    /// same as <see cref="ISystemService.ListServices(SystemListServicesParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SystemListServicesResponse>> ListServices(
        SystemListServicesParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
