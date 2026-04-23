using System;
using System.Threading;
using System.Threading.Tasks;
using Casedev.Core;
using Casedev.Models.Webhooks.V1.EventTypes;

namespace Casedev.Services.Webhooks.V1;

/// <summary>
/// Webhook endpoint management
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IEventTypeService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IEventTypeServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEventTypeService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns the catalog of event types that can be subscribed to via webhook
    /// endpoints. Each entry lists the required service scope the API key must carry to
    /// subscribe, plus the stability level.
    /// </summary>
    Task List(
        EventTypeListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IEventTypeService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IEventTypeServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEventTypeServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /webhooks/v1/event_types</c>, but is otherwise the
    /// same as <see cref="IEventTypeService.List(EventTypeListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> List(
        EventTypeListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
