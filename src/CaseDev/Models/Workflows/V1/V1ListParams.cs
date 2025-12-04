using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;
using CaseDev.Exceptions;

namespace CaseDev.Models.Workflows.V1;

/// <summary>
/// List all workflows for the authenticated organization.
/// </summary>
public sealed record class V1ListParams : ParamsBase
{
    /// <summary>
    /// Maximum number of results
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
    /// Offset for pagination
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
    /// Filter by visibility
    /// </summary>
    public ApiEnum<string, V1ListParamsVisibility>? Visibility
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<string, V1ListParamsVisibility>>(
                this.RawQueryData,
                "visibility"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "visibility", value);
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/workflows/v1")
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

/// <summary>
/// Filter by visibility
/// </summary>
[JsonConverter(typeof(V1ListParamsVisibilityConverter))]
public enum V1ListParamsVisibility
{
    Private,
    Org,
    Public,
}

sealed class V1ListParamsVisibilityConverter : JsonConverter<V1ListParamsVisibility>
{
    public override V1ListParamsVisibility Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "private" => V1ListParamsVisibility.Private,
            "org" => V1ListParamsVisibility.Org,
            "public" => V1ListParamsVisibility.Public,
            _ => (V1ListParamsVisibility)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        V1ListParamsVisibility value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                V1ListParamsVisibility.Private => "private",
                V1ListParamsVisibility.Org => "org",
                V1ListParamsVisibility.Public => "public",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
