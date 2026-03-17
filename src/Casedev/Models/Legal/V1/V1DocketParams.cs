using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Casedev.Core;
using Casedev.Exceptions;
using System = System;

namespace Casedev.Models.Legal.V1;

/// <summary>
/// Search federal court dockets or retrieve a specific docket with optional filing
/// entries. Use legal.listCourts() to resolve court slugs for filtering.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class V1DocketParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Search dockets or look up a docket by ID
    /// </summary>
    public required ApiEnum<string, global::Casedev.Models.Legal.V1.Type> Type
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<
                ApiEnum<string, global::Casedev.Models.Legal.V1.Type>
            >("type");
        }
        init { this._rawBodyData.Set("type", value); }
    }

    /// <summary>
    /// Required when live: true. Acknowledges that PACER fees (up to $3.00 per docket)
    /// plus a $0.05 service fee will be charged to your account.
    /// </summary>
    public bool? AcknowledgePacerFees
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("acknowledgePacerFees");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("acknowledgePacerFees", value);
        }
    }

    /// <summary>
    /// Optional court slug for filtering (e.g. "nysd", "ca9", "cafc"). Use legal.listCourts()
    /// to find slugs.
    /// </summary>
    public string? Court
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("court");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("court", value);
        }
    }

    /// <summary>
    /// Optional lower bound for filing date (YYYY-MM-DD)
    /// </summary>
    public string? DateFiledAfter
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("dateFiledAfter");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("dateFiledAfter", value);
        }
    }

    /// <summary>
    /// Optional upper bound for filing date (YYYY-MM-DD)
    /// </summary>
    public string? DateFiledBefore
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("dateFiledBefore");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("dateFiledBefore", value);
        }
    }

    /// <summary>
    /// Docket ID (required for lookup)
    /// </summary>
    public string? DocketID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("docketId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("docketId", value);
        }
    }

    /// <summary>
    /// Include docket entries/filings in lookup responses. Coming soon — currently
    /// returns 501. The parameter is accepted for forward compatibility.
    /// </summary>
    public bool? IncludeEntries
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("includeEntries");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("includeEntries", value);
        }
    }

    /// <summary>
    /// Page size for search results or entry list (default 25 for search, 50 for lookup)
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
    /// Trigger a live PACER fetch for dockets not yet in the RECAP archive. Requires
    /// acknowledgePacerFees: true. PACER charges up to $3.00 per docket sheet plus
    /// a $0.05 service fee. Only valid with type: "lookup".
    /// </summary>
    public bool? Live
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("live");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("live", value);
        }
    }

    /// <summary>
    /// Offset for search results or entry list
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
    /// Case name or party name search query (required for search)
    /// </summary>
    public string? Query
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("query");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("query", value);
        }
    }

    public V1DocketParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public V1DocketParams(V1DocketParams v1DocketParams)
        : base(v1DocketParams)
    {
        this._rawBodyData = new(v1DocketParams._rawBodyData);
    }
#pragma warning restore CS8618

    public V1DocketParams(
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
    V1DocketParams(
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

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static V1DocketParams FromRawUnchecked(
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

    public virtual bool Equals(V1DocketParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/legal/v1/docket")
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
/// Search dockets or look up a docket by ID
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Search,
    Lookup,
}

sealed class TypeConverter : JsonConverter<global::Casedev.Models.Legal.V1.Type>
{
    public override global::Casedev.Models.Legal.V1.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "search" => global::Casedev.Models.Legal.V1.Type.Search,
            "lookup" => global::Casedev.Models.Legal.V1.Type.Lookup,
            _ => (global::Casedev.Models.Legal.V1.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Casedev.Models.Legal.V1.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Casedev.Models.Legal.V1.Type.Search => "search",
                global::Casedev.Models.Legal.V1.Type.Lookup => "lookup",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
