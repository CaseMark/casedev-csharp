using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using CaseDev.Core;

namespace CaseDev.Models.Search.V1;

/// <summary>
/// Retrieve the status and results of a deep research task by ID. Supports both
/// standard JSON responses and streaming for real-time updates as the research progresses.
/// Research tasks analyze topics comprehensively using web search and AI synthesis.
/// </summary>
public sealed record class V1RetrieveResearchParams : ParamsBase
{
    public string? ID { get; init; }

    /// <summary>
    /// Filter specific event types for streaming
    /// </summary>
    public string? Events
    {
        get { return JsonModel.GetNullableClass<string>(this.RawQueryData, "events"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawQueryData, "events", value);
        }
    }

    /// <summary>
    /// Enable streaming for real-time updates
    /// </summary>
    public bool? Stream
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawQueryData, "stream"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawQueryData, "stream", value);
        }
    }

    public V1RetrieveResearchParams() { }

    public V1RetrieveResearchParams(V1RetrieveResearchParams v1RetrieveResearchParams)
        : base(v1RetrieveResearchParams) { }

    public V1RetrieveResearchParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1RetrieveResearchParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static V1RetrieveResearchParams FromRawUnchecked(
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
                + string.Format("/search/v1/research/{0}", this.ID)
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
