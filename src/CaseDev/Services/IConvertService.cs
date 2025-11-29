using System;
using CaseDev.Core;
using CaseDev.Services.Convert;

namespace CaseDev.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IConvertService
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IConvertService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IV1Service V1 { get; }
}
