using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using CaseDev.Core;

namespace CaseDev.Models.Compute.V1;

/// <summary>
/// Returns detailed compute usage statistics and billing information for your organization.
/// Includes GPU and CPU hours, total runs, costs, and breakdowns by environment.
/// Use optional query parameters to filter by specific year and month.
/// </summary>
public sealed record class V1GetUsageParams : ParamsBase
{
    /// <summary>
    /// Month to filter usage data (1-12, defaults to current month)
    /// </summary>
    public long? Month
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawQueryData, "month"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "month", value);
        }
    }

    /// <summary>
    /// Year to filter usage data (defaults to current year)
    /// </summary>
    public long? Year
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawQueryData, "year"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "year", value);
        }
    }

    public V1GetUsageParams() { }

    public V1GetUsageParams(V1GetUsageParams v1GetUsageParams)
        : base(v1GetUsageParams) { }

    public V1GetUsageParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1GetUsageParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRaw.FromRawUnchecked"/>
    public static V1GetUsageParams FromRawUnchecked(
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/compute/v1/usage")
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
