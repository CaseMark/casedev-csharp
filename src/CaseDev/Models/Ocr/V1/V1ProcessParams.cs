using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;
using CaseDev.Exceptions;
using System = System;

namespace CaseDev.Models.Ocr.V1;

/// <summary>
/// Submit a document for OCR processing to extract text, detect tables, forms, and
/// other features. Supports PDFs, images, and scanned documents. Returns a job ID
/// that can be used to track processing status.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class V1ProcessParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// URL or S3 path to the document to process
    /// </summary>
    public required string DocumentUrl
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("document_url");
        }
        init { this._rawBodyData.Set("document_url", value); }
    }

    /// <summary>
    /// URL to receive completion webhook
    /// </summary>
    public string? CallbackUrl
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("callback_url");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("callback_url", value);
        }
    }

    /// <summary>
    /// Optional custom document identifier
    /// </summary>
    public string? DocumentID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("document_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("document_id", value);
        }
    }

    /// <summary>
    /// OCR engine to use
    /// </summary>
    public ApiEnum<string, Engine>? Engine
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, Engine>>("engine");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("engine", value);
        }
    }

    /// <summary>
    /// Additional processing options
    /// </summary>
    public Features? Features
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Features>("features");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("features", value);
        }
    }

    /// <summary>
    /// S3 bucket to store results
    /// </summary>
    public string? ResultBucket
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("result_bucket");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("result_bucket", value);
        }
    }

    /// <summary>
    /// S3 key prefix for results
    /// </summary>
    public string? ResultPrefix
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("result_prefix");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("result_prefix", value);
        }
    }

    public V1ProcessParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public V1ProcessParams(V1ProcessParams v1ProcessParams)
        : base(v1ProcessParams)
    {
        this._rawBodyData = new(v1ProcessParams._rawBodyData);
    }
#pragma warning restore CS8618

    public V1ProcessParams(
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
    V1ProcessParams(
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
    public static V1ProcessParams FromRawUnchecked(
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

    public virtual bool Equals(V1ProcessParams? other)
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
        return new System::UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/ocr/v1/process")
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
/// OCR engine to use
/// </summary>
[JsonConverter(typeof(EngineConverter))]
public enum Engine
{
    Doctr,
    Paddleocr,
}

sealed class EngineConverter : JsonConverter<Engine>
{
    public override Engine Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "doctr" => Engine.Doctr,
            "paddleocr" => Engine.Paddleocr,
            _ => (Engine)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Engine value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Engine.Doctr => "doctr",
                Engine.Paddleocr => "paddleocr",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Additional processing options
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Features, FeaturesFromRaw>))]
public sealed record class Features : JsonModel
{
    /// <summary>
    /// Generate searchable PDF with text layer
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Embed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>("embed");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "embed",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Detect and extract form fields
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Forms
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>("forms");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "forms",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Extract tables as structured data
    /// </summary>
    public Tables? Tables
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Tables>("tables");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("tables", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Embed;
        _ = this.Forms;
        this.Tables?.Validate();
    }

    public Features() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Features(Features features)
        : base(features) { }
#pragma warning restore CS8618

    public Features(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Features(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FeaturesFromRaw.FromRawUnchecked"/>
    public static Features FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FeaturesFromRaw : IFromRawJson<Features>
{
    /// <inheritdoc/>
    public Features FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Features.FromRawUnchecked(rawData);
}

/// <summary>
/// Extract tables as structured data
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Tables, TablesFromRaw>))]
public sealed record class Tables : JsonModel
{
    /// <summary>
    /// Output format for extracted tables
    /// </summary>
    public ApiEnum<string, TablesFormat>? Format
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TablesFormat>>("format");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("format", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Format?.Validate();
    }

    public Tables() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Tables(Tables tables)
        : base(tables) { }
#pragma warning restore CS8618

    public Tables(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Tables(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TablesFromRaw.FromRawUnchecked"/>
    public static Tables FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TablesFromRaw : IFromRawJson<Tables>
{
    /// <inheritdoc/>
    public Tables FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Tables.FromRawUnchecked(rawData);
}

/// <summary>
/// Output format for extracted tables
/// </summary>
[JsonConverter(typeof(TablesFormatConverter))]
public enum TablesFormat
{
    Csv,
    Json,
}

sealed class TablesFormatConverter : JsonConverter<TablesFormat>
{
    public override TablesFormat Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "csv" => TablesFormat.Csv,
            "json" => TablesFormat.Json,
            _ => (TablesFormat)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TablesFormat value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TablesFormat.Csv => "csv",
                TablesFormat.Json => "json",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
