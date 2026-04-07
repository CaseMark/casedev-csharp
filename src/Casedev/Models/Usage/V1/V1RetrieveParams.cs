using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Casedev.Core;
using Casedev.Exceptions;

namespace Casedev.Models.Usage.V1;

/// <summary>
/// Returns customer-facing usage metrics and costs for the requested period. Supports
/// summary totals and daily buckets for timestamped usage sources. Vault storage
/// is intentionally omitted from totals because it is not yet periodized for arbitrary windows.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class V1RetrieveParams : ParamsBase
{
    /// <summary>
    /// Whether to return period totals only or include daily buckets.
    /// </summary>
    public ApiEnum<string, Granularity>? Granularity
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, Granularity>>("granularity");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("granularity", value);
        }
    }

    /// <summary>
    /// Period end date. Defaults to now.
    /// </summary>
    public DateTimeOffset? PeriodEnd
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<DateTimeOffset>("periodEnd");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("periodEnd", value);
        }
    }

    /// <summary>
    /// Period start date. Defaults to the start of the current calendar month.
    /// </summary>
    public DateTimeOffset? PeriodStart
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<DateTimeOffset>("periodStart");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("periodStart", value);
        }
    }

    public V1RetrieveParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public V1RetrieveParams(V1RetrieveParams v1RetrieveParams)
        : base(v1RetrieveParams) { }
#pragma warning restore CS8618

    public V1RetrieveParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1RetrieveParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static V1RetrieveParams FromRawUnchecked(
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

    public virtual bool Equals(V1RetrieveParams? other)
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/usage/v1")
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

/// <summary>
/// Whether to return period totals only or include daily buckets.
/// </summary>
[JsonConverter(typeof(GranularityConverter))]
public enum Granularity
{
    Summary,
    Daily,
}

sealed class GranularityConverter : JsonConverter<Granularity>
{
    public override Granularity Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "summary" => Granularity.Summary,
            "daily" => Granularity.Daily,
            _ => (Granularity)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Granularity value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Granularity.Summary => "summary",
                Granularity.Daily => "daily",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
