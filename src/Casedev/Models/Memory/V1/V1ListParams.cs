using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Casedev.Core;

namespace Casedev.Models.Memory.V1;

/// <summary>
/// List all memories with optional filtering by tags and category.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class V1ListParams : ParamsBase
{
    /// <summary>
    /// Filter by category
    /// </summary>
    public string? Category
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("category");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("category", value);
        }
    }

    /// <summary>
    /// Number of results
    /// </summary>
    public long? Limit
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("limit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("limit", value);
        }
    }

    /// <summary>
    /// Pagination offset
    /// </summary>
    public long? Offset
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("offset");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("offset", value);
        }
    }

    /// <summary>
    /// Filter by tag_1
    /// </summary>
    public string? Tag1
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("tag_1");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("tag_1", value);
        }
    }

    /// <summary>
    /// Filter by tag_10
    /// </summary>
    public string? Tag10
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("tag_10");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("tag_10", value);
        }
    }

    /// <summary>
    /// Filter by tag_11
    /// </summary>
    public string? Tag11
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("tag_11");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("tag_11", value);
        }
    }

    /// <summary>
    /// Filter by tag_12
    /// </summary>
    public string? Tag12
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("tag_12");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("tag_12", value);
        }
    }

    /// <summary>
    /// Filter by tag_2
    /// </summary>
    public string? Tag2
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("tag_2");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("tag_2", value);
        }
    }

    /// <summary>
    /// Filter by tag_3
    /// </summary>
    public string? Tag3
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("tag_3");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("tag_3", value);
        }
    }

    /// <summary>
    /// Filter by tag_4
    /// </summary>
    public string? Tag4
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("tag_4");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("tag_4", value);
        }
    }

    /// <summary>
    /// Filter by tag_5
    /// </summary>
    public string? Tag5
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("tag_5");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("tag_5", value);
        }
    }

    /// <summary>
    /// Filter by tag_6
    /// </summary>
    public string? Tag6
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("tag_6");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("tag_6", value);
        }
    }

    /// <summary>
    /// Filter by tag_7
    /// </summary>
    public string? Tag7
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("tag_7");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("tag_7", value);
        }
    }

    /// <summary>
    /// Filter by tag_8
    /// </summary>
    public string? Tag8
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("tag_8");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("tag_8", value);
        }
    }

    /// <summary>
    /// Filter by tag_9
    /// </summary>
    public string? Tag9
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("tag_9");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("tag_9", value);
        }
    }

    public V1ListParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public V1ListParams(V1ListParams v1ListParams)
        : base(v1ListParams) { }
#pragma warning restore CS8618

    public V1ListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1ListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
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
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(V1ListParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/memory/v1")
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

    public override int GetHashCode()
    {
        return 0;
    }
}
