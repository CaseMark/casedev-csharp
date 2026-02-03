using System;
using CaseDev.Core;
using CaseDev.Services.Projects;

namespace CaseDev.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IProjectService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IProjectServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IProjectService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IV1Service V1 { get; }
}

/// <summary>
/// A view of <see cref="IProjectService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IProjectServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IProjectServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IV1ServiceWithRawResponse V1 { get; }
}
