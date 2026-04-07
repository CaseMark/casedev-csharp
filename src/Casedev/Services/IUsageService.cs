using System;
using Casedev.Core;
using Casedev.Services.Usage;

namespace Casedev.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IUsageService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IUsageServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IUsageService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IV1Service V1 { get; }
}

/// <summary>
/// A view of <see cref="IUsageService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IUsageServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IUsageServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IV1ServiceWithRawResponse V1 { get; }
}
