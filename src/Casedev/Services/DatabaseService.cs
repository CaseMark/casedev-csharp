using System;
using Casedev.Core;
using Casedev.Services.Database;

namespace Casedev.Services;

/// <inheritdoc/>
public sealed class DatabaseService : IDatabaseService
{
    readonly Lazy<IDatabaseServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IDatabaseServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICasedevClient _client;

    /// <inheritdoc/>
    public IDatabaseService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new DatabaseService(this._client.WithOptions(modifier));
    }

    public DatabaseService(ICasedevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new DatabaseServiceWithRawResponse(client.WithRawResponse));
        _v1 = new(() => new V1Service(client));
    }

    readonly Lazy<IV1Service> _v1;
    public IV1Service V1
    {
        get { return _v1.Value; }
    }
}

/// <inheritdoc/>
public sealed class DatabaseServiceWithRawResponse : IDatabaseServiceWithRawResponse
{
    readonly ICasedevClientWithRawResponse _client;

    /// <inheritdoc/>
    public IDatabaseServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new DatabaseServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public DatabaseServiceWithRawResponse(ICasedevClientWithRawResponse client)
    {
        _client = client;

        _v1 = new(() => new V1ServiceWithRawResponse(client));
    }

    readonly Lazy<IV1ServiceWithRawResponse> _v1;
    public IV1ServiceWithRawResponse V1
    {
        get { return _v1.Value; }
    }
}
