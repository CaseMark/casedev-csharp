using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using CaseDev.Core;

namespace CaseDev.Models.Workflows.V1;

/// <summary>
/// Execute a deployed workflow. Supports three modes: - **Fire-and-forget** (default):
/// Returns immediately with executionId. Poll /executions/{id} for status. - **Callback**:
/// Returns immediately, POSTs result to callbackUrl when workflow completes. - **Sync
/// wait**: Blocks until workflow completes (max 5 minutes).
/// </summary>
public sealed record class V1ExecuteParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ID { get; init; }

    /// <summary>
    /// Headers to include in callback request (e.g., Authorization)
    /// </summary>
    public JsonElement? CallbackHeaders
    {
        get
        {
            return JsonModel.GetNullableStruct<JsonElement>(this.RawBodyData, "callbackHeaders");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawBodyData, "callbackHeaders", value);
        }
    }

    /// <summary>
    /// URL to POST results when workflow completes (enables callback mode)
    /// </summary>
    public string? CallbackUrl
    {
        get { return JsonModel.GetNullableClass<string>(this.RawBodyData, "callbackUrl"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawBodyData, "callbackUrl", value);
        }
    }

    /// <summary>
    /// Input data to pass to the workflow
    /// </summary>
    public JsonElement? Input
    {
        get { return JsonModel.GetNullableStruct<JsonElement>(this.RawBodyData, "input"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawBodyData, "input", value);
        }
    }

    /// <summary>
    /// Timeout for sync wait mode (e.g., '30s', '2m'). Max 5m. Default: 30s
    /// </summary>
    public string? Timeout
    {
        get { return JsonModel.GetNullableClass<string>(this.RawBodyData, "timeout"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawBodyData, "timeout", value);
        }
    }

    /// <summary>
    /// Wait for completion (default: false, max 5 min)
    /// </summary>
    public bool? Wait
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawBodyData, "wait"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawBodyData, "wait", value);
        }
    }

    public V1ExecuteParams() { }

    public V1ExecuteParams(V1ExecuteParams v1ExecuteParams)
        : base(v1ExecuteParams)
    {
        this.ID = v1ExecuteParams.ID;

        this._rawBodyData = [.. v1ExecuteParams._rawBodyData];
    }

    public V1ExecuteParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1ExecuteParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static V1ExecuteParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/workflows/v1/{0}/execute", this.ID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData),
            Encoding.UTF8,
            "application/json"
        );
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
