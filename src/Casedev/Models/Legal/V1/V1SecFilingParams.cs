using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
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
/// Search SEC EDGAR full-text filings via efts.sec.gov or fetch a filer's structured
/// filing history via data.sec.gov. Returns direct SEC archive URLs with filing metadata
/// and match snippets when available.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class V1SecFilingParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Run a full-text search or fetch a single entity filing history
    /// </summary>
    public required ApiEnum<string, V1SecFilingParamsType> Type
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, V1SecFilingParamsType>>(
                "type"
            );
        }
        init { this._rawBodyData.Set("type", value); }
    }

    /// <summary>
    /// CIK for entity lookups. Accepts padded or unpadded digits.
    /// </summary>
    public string? Cik
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("cik");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("cik", value);
        }
    }

    /// <summary>
    /// Optional lower filing date bound (YYYY-MM-DD)
    /// </summary>
    public string? DateAfter
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("dateAfter");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("dateAfter", value);
        }
    }

    /// <summary>
    /// Optional upper filing date bound (YYYY-MM-DD)
    /// </summary>
    public string? DateBefore
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("dateBefore");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("dateBefore", value);
        }
    }

    /// <summary>
    /// Optional entity filter passed through to EDGAR full-text search
    /// </summary>
    public string? Entity
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("entity");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("entity", value);
        }
    }

    /// <summary>
    /// Optional SEC form type filter such as 10-K, 10-Q, 8-K, or 4
    /// </summary>
    public IReadOnlyList<string>? FormTypes
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>("formTypes");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<string>?>(
                "formTypes",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Maximum filings to return
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
    /// Result offset for pagination
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
    /// Full-text SEC search query (required for type: search)
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

    /// <summary>
    /// Optional company ticker. Valid for both search and entity lookups.
    /// </summary>
    public string? Ticker
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("ticker");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("ticker", value);
        }
    }

    public V1SecFilingParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public V1SecFilingParams(V1SecFilingParams v1SecFilingParams)
        : base(v1SecFilingParams)
    {
        this._rawBodyData = new(v1SecFilingParams._rawBodyData);
    }
#pragma warning restore CS8618

    public V1SecFilingParams(
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
    V1SecFilingParams(
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
    public static V1SecFilingParams FromRawUnchecked(
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

    public virtual bool Equals(V1SecFilingParams? other)
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
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/legal/v1/sec-filing"
        )
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
/// Run a full-text search or fetch a single entity filing history
/// </summary>
[JsonConverter(typeof(V1SecFilingParamsTypeConverter))]
public enum V1SecFilingParamsType
{
    Search,
    Entity,
}

sealed class V1SecFilingParamsTypeConverter : JsonConverter<V1SecFilingParamsType>
{
    public override V1SecFilingParamsType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "search" => V1SecFilingParamsType.Search,
            "entity" => V1SecFilingParamsType.Entity,
            _ => (V1SecFilingParamsType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        V1SecFilingParamsType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                V1SecFilingParamsType.Search => "search",
                V1SecFilingParamsType.Entity => "entity",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
