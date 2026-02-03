using System;
using CaseDev.Core;
using V1 = CaseDev.Services.Applications.V1;

namespace CaseDev.Services.Applications;

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

    V1::IDeploymentService Deployments { get; }

    V1::IProjectService Projects { get; }

    V1::IWorkflowService Workflows { get; }
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

    V1::IDeploymentServiceWithRawResponse Deployments { get; }

    V1::IProjectServiceWithRawResponse Projects { get; }

    V1::IWorkflowServiceWithRawResponse Workflows { get; }
}
