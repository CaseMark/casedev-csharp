using System;
using Casedev.Core;
using Casedev.Services.Agent.V2;

namespace Casedev.Services.Agent;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IV2Service
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IV2ServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IV2Service WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IRunService Run { get; }

    IExecuteService Execute { get; }

    IChatService Chat { get; }
}

/// <summary>
/// A view of <see cref="IV2Service"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IV2ServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IV2ServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IRunServiceWithRawResponse Run { get; }

    IExecuteServiceWithRawResponse Execute { get; }

    IChatServiceWithRawResponse Chat { get; }
}
