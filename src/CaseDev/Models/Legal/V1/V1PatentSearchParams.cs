using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;
using CaseDev.Exceptions;

namespace CaseDev.Models.Legal.V1;

/// <summary>
/// Search the USPTO Open Data Portal for US patent applications and granted patents.
/// Supports free-text queries, field-specific search, filters by assignee/inventor/status/type,
/// date ranges, and pagination. Covers applications filed on or after January 1,
/// 2001. Data is refreshed daily.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class V1PatentSearchParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Free-text search across all patent fields, or field-specific query (e.g.
    /// "applicationMetaData.patentNumber:11234567"). Supports AND, OR, NOT operators.
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
    /// Filter by application status (e.g. "Patented Case", "Abandoned", "Pending")
    /// </summary>
    public string? ApplicationStatus
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("applicationStatus");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("applicationStatus", value);
        }
    }

    /// <summary>
    /// Filter by application type
    /// </summary>
    public ApiEnum<string, ApplicationType>? ApplicationType
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, ApplicationType>>(
                "applicationType"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("applicationType", value);
        }
    }

    /// <summary>
    /// Filter by assignee/owner name (e.g. "Google LLC")
    /// </summary>
    public string? Assignee
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("assignee");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("assignee", value);
        }
    }

    /// <summary>
    /// Start of filing date range (YYYY-MM-DD)
    /// </summary>
    public string? FilingDateFrom
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("filingDateFrom");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("filingDateFrom", value);
        }
    }

    /// <summary>
    /// End of filing date range (YYYY-MM-DD)
    /// </summary>
    public string? FilingDateTo
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("filingDateTo");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("filingDateTo", value);
        }
    }

    /// <summary>
    /// Start of grant date range (YYYY-MM-DD)
    /// </summary>
    public string? GrantDateFrom
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("grantDateFrom");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("grantDateFrom", value);
        }
    }

    /// <summary>
    /// End of grant date range (YYYY-MM-DD)
    /// </summary>
    public string? GrantDateTo
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("grantDateTo");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("grantDateTo", value);
        }
    }

    /// <summary>
    /// Filter by inventor name
    /// </summary>
    public string? Inventor
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("inventor");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("inventor", value);
        }
    }

    /// <summary>
    /// Number of results to return (default 25, max 100)
    /// </summary>
    public long? Limit
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("limit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("limit", value);
        }
    }

    /// <summary>
    /// Starting position for pagination
    /// </summary>
    public long? Offset
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("offset");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("offset", value);
        }
    }

    /// <summary>
    /// Field to sort results by
    /// </summary>
    public ApiEnum<string, SortBy>? SortBy
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, SortBy>>("sortBy");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("sortBy", value);
        }
    }

    /// <summary>
    /// Sort order (default desc, newest first)
    /// </summary>
    public ApiEnum<string, SortOrder>? SortOrder
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, SortOrder>>("sortOrder");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("sortOrder", value);
        }
    }

    public V1PatentSearchParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public V1PatentSearchParams(V1PatentSearchParams v1PatentSearchParams)
        : base(v1PatentSearchParams)
    {
        this._rawBodyData = new(v1PatentSearchParams._rawBodyData);
    }
#pragma warning restore CS8618

    public V1PatentSearchParams(
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
    V1PatentSearchParams(
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
    public static V1PatentSearchParams FromRawUnchecked(
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

    public virtual bool Equals(V1PatentSearchParams? other)
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/legal/v1/patent-search")
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

/// <summary>
/// Filter by application type
/// </summary>
[JsonConverter(typeof(ApplicationTypeConverter))]
public enum ApplicationType
{
    Utility,
    Design,
    Plant,
    Provisional,
    Reissue,
}

sealed class ApplicationTypeConverter : JsonConverter<ApplicationType>
{
    public override ApplicationType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Utility" => ApplicationType.Utility,
            "Design" => ApplicationType.Design,
            "Plant" => ApplicationType.Plant,
            "Provisional" => ApplicationType.Provisional,
            "Reissue" => ApplicationType.Reissue,
            _ => (ApplicationType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ApplicationType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ApplicationType.Utility => "Utility",
                ApplicationType.Design => "Design",
                ApplicationType.Plant => "Plant",
                ApplicationType.Provisional => "Provisional",
                ApplicationType.Reissue => "Reissue",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Field to sort results by
/// </summary>
[JsonConverter(typeof(SortByConverter))]
public enum SortBy
{
    FilingDate,
    GrantDate,
}

sealed class SortByConverter : JsonConverter<SortBy>
{
    public override SortBy Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "filingDate" => SortBy.FilingDate,
            "grantDate" => SortBy.GrantDate,
            _ => (SortBy)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, SortBy value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SortBy.FilingDate => "filingDate",
                SortBy.GrantDate => "grantDate",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Sort order (default desc, newest first)
/// </summary>
[JsonConverter(typeof(SortOrderConverter))]
public enum SortOrder
{
    Asc,
    Desc,
}

sealed class SortOrderConverter : JsonConverter<SortOrder>
{
    public override SortOrder Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "asc" => SortOrder.Asc,
            "desc" => SortOrder.Desc,
            _ => (SortOrder)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SortOrder value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SortOrder.Asc => "asc",
                SortOrder.Desc => "desc",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
