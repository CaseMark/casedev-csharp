using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using CaseDev.Core;

namespace CaseDev.Models.Compute.V1.Functions;

/// <summary>
/// Retrieve execution logs from a deployed serverless function. Logs include function
/// output, errors, and runtime information. Useful for debugging and monitoring function
/// performance in production.
/// </summary>
public sealed record class FunctionGetLogsParams : ParamsBase
{
    public string? ID { get; init; }

    /// <summary>
    /// Number of log lines to retrieve (default 200, max 1000)
    /// </summary>
    public long? Tail
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawQueryData, "tail"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "tail", value);
        }
    }

    public FunctionGetLogsParams() { }

    public FunctionGetLogsParams(FunctionGetLogsParams functionGetLogsParams)
        : base(functionGetLogsParams) { }

    public FunctionGetLogsParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionGetLogsParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRaw.FromRawUnchecked"/>
    public static FunctionGetLogsParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        );
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/compute/v1/functions/{0}/logs", this.ID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
