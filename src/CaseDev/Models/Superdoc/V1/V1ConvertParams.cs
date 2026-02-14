using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;
using CaseDev.Exceptions;
using System = System;

namespace CaseDev.Models.Superdoc.V1;

/// <summary>
/// Convert documents between formats using SuperDoc. Supports DOCX to PDF, Markdown
/// to DOCX, and HTML to DOCX conversions.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class V1ConvertParams : ParamsBase
{
    readonly MultipartJsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, MultipartJsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Source format of the document
    /// </summary>
    public required ApiEnum<string, From> From
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, From>>("from");
        }
        init { this._rawBodyData.Set("from", value); }
    }

    /// <summary>
    /// Base64-encoded document content
    /// </summary>
    public string? DocumentBase64
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("document_base64");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("document_base64", value);
        }
    }

    /// <summary>
    /// URL to the document to convert
    /// </summary>
    public string? DocumentUrl
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("document_url");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("document_url", value);
        }
    }

    /// <summary>
    /// Target format for conversion
    /// </summary>
    public ApiEnum<string, To>? To
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, To>>("to");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("to", value);
        }
    }

    public V1ConvertParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public V1ConvertParams(V1ConvertParams v1ConvertParams)
        : base(v1ConvertParams)
    {
        this._rawBodyData = new(v1ConvertParams._rawBodyData);
    }
#pragma warning restore CS8618

    public V1ConvertParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, MultipartJsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1ConvertParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, MultipartJsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static V1ConvertParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, MultipartJsonElement> rawBodyData
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
                new Dictionary<string, MultipartJsonElement>()
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

    public virtual bool Equals(V1ConvertParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/superdoc/v1/convert"
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return MultipartJsonSerializer.Serialize(RawBodyData);
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
/// Source format of the document
/// </summary>
[JsonConverter(typeof(FromConverter))]
public enum From
{
    Docx,
    Md,
    Html,
}

sealed class FromConverter : JsonConverter<From>
{
    public override From Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "docx" => From.Docx,
            "md" => From.Md,
            "html" => From.Html,
            _ => (From)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, From value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                From.Docx => "docx",
                From.Md => "md",
                From.Html => "html",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Target format for conversion
/// </summary>
[JsonConverter(typeof(ToConverter))]
public enum To
{
    Pdf,
    Docx,
}

sealed class ToConverter : JsonConverter<To>
{
    public override To Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pdf" => To.Pdf,
            "docx" => To.Docx,
            _ => (To)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, To value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                To.Pdf => "pdf",
                To.Docx => "docx",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
