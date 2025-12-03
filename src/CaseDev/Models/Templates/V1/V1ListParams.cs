using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using CaseDev.Core;

namespace CaseDev.Models.Templates.V1;

/// <summary>
/// Retrieve a paginated list of available workflows with optional filtering by category,
/// subcategory, type, and publication status. Workflows are pre-built document processing
/// pipelines optimized for legal use cases.
/// </summary>
public sealed record class V1ListParams : ParamsBase
{
    /// <summary>
    /// Filter workflows by category (e.g., 'legal', 'compliance', 'contract')
    /// </summary>
    public string? Category
    {
        get { return ModelBase.GetNullableClass<string>(this.RawQueryData, "category"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "category", value);
        }
    }

    /// <summary>
    /// Maximum number of workflows to return
    /// </summary>
    public long? Limit
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawQueryData, "limit"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "limit", value);
        }
    }

    /// <summary>
    /// Number of workflows to skip for pagination
    /// </summary>
    public long? Offset
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawQueryData, "offset"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "offset", value);
        }
    }

    /// <summary>
    /// Include only published workflows
    /// </summary>
    public bool? Published
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawQueryData, "published"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "published", value);
        }
    }

    /// <summary>
    /// Filter workflows by subcategory (e.g., 'due-diligence', 'litigation', 'mergers')
    /// </summary>
    public string? SubCategory
    {
        get { return ModelBase.GetNullableClass<string>(this.RawQueryData, "sub_category"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "sub_category", value);
        }
    }

    /// <summary>
    /// Filter workflows by type (e.g., 'document-review', 'contract-analysis', 'compliance-check')
    /// </summary>
    public string? Type
    {
        get { return ModelBase.GetNullableClass<string>(this.RawQueryData, "type"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "type", value);
        }
    }

    public V1ListParams() { }

    public V1ListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1ListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }
#pragma warning restore CS8618

    public static V1ListParams FromRawUnchecked(
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/templates/v1")
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
