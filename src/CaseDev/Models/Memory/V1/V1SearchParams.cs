using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using CaseDev.Core;

namespace CaseDev.Models.Memory.V1;

/// <summary>
/// Search memories using semantic similarity. Filter by tag fields to narrow results.
///
/// <para>Use tag_1 through tag_12 for filtering - these are generic indexed fields
/// you define: - Legal app: tag_1=client_id, tag_2=matter_id - Healthcare: tag_1=patient_id, tag_2=encounter_id</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class V1SearchParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Search query for semantic matching
    /// </summary>
    public required string Query
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("query");
        }
        init { this._rawBodyData.Set("query", value); }
    }

    /// <summary>
    /// Filter by category
    /// </summary>
    public string? Category
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("category");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("category", value);
        }
    }

    /// <summary>
    /// Filter by tag_1
    /// </summary>
    public string? Tag1
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("tag_1");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("tag_1", value);
        }
    }

    /// <summary>
    /// Filter by tag_10
    /// </summary>
    public string? Tag10
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("tag_10");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("tag_10", value);
        }
    }

    /// <summary>
    /// Filter by tag_11
    /// </summary>
    public string? Tag11
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("tag_11");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("tag_11", value);
        }
    }

    /// <summary>
    /// Filter by tag_12
    /// </summary>
    public string? Tag12
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("tag_12");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("tag_12", value);
        }
    }

    /// <summary>
    /// Filter by tag_2
    /// </summary>
    public string? Tag2
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("tag_2");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("tag_2", value);
        }
    }

    /// <summary>
    /// Filter by tag_3
    /// </summary>
    public string? Tag3
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("tag_3");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("tag_3", value);
        }
    }

    /// <summary>
    /// Filter by tag_4
    /// </summary>
    public string? Tag4
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("tag_4");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("tag_4", value);
        }
    }

    /// <summary>
    /// Filter by tag_5
    /// </summary>
    public string? Tag5
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("tag_5");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("tag_5", value);
        }
    }

    /// <summary>
    /// Filter by tag_6
    /// </summary>
    public string? Tag6
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("tag_6");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("tag_6", value);
        }
    }

    /// <summary>
    /// Filter by tag_7
    /// </summary>
    public string? Tag7
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("tag_7");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("tag_7", value);
        }
    }

    /// <summary>
    /// Filter by tag_8
    /// </summary>
    public string? Tag8
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("tag_8");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("tag_8", value);
        }
    }

    /// <summary>
    /// Filter by tag_9
    /// </summary>
    public string? Tag9
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("tag_9");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("tag_9", value);
        }
    }

    /// <summary>
    /// Maximum number of results to return
    /// </summary>
    public long? TopK
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("top_k");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("top_k", value);
        }
    }

    public V1SearchParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public V1SearchParams(V1SearchParams v1SearchParams)
        : base(v1SearchParams)
    {
        this._rawBodyData = new(v1SearchParams._rawBodyData);
    }
#pragma warning restore CS8618

    public V1SearchParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1SearchParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static V1SearchParams FromRawUnchecked(
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

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(V1SearchParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/memory/v1/search")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
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

    public override int GetHashCode()
    {
        return 0;
    }
}
