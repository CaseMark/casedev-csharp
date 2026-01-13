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
/// </summary>
public sealed record class V1ProcessParams : ParamsBase
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
        get { return this._rawBodyData.GetNotNullClass<string>("document_url"); }
        init { this._rawBodyData.Set("document_url", value); }
    }

    /// <summary>
    /// URL to receive completion webhook
    /// </summary>
    public string? CallbackUrl
    {
        get { return this._rawBodyData.GetNullableClass<string>("callback_url"); }
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
        get { return this._rawBodyData.GetNullableClass<string>("document_id"); }
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
        get { return this._rawBodyData.GetNullableClass<ApiEnum<string, Engine>>("engine"); }
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
    /// OCR features to extract
    /// </summary>
    public Features? Features
    {
        get { return this._rawBodyData.GetNullableClass<Features>("features"); }
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
        get { return this._rawBodyData.GetNullableClass<string>("result_bucket"); }
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
        get { return this._rawBodyData.GetNullableClass<string>("result_prefix"); }
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

    public V1ProcessParams(V1ProcessParams v1ProcessParams)
        : base(v1ProcessParams)
    {
        this._rawBodyData = new(v1ProcessParams._rawBodyData);
    }

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
            JsonSerializer.Serialize(this.RawBodyData),
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
/// OCR features to extract
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Features, FeaturesFromRaw>))]
public sealed record class Features : JsonModel
{
    /// <summary>
    /// Detect form fields
    /// </summary>
    public bool? Forms
    {
        get { return this._rawData.GetNullableStruct<bool>("forms"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("forms", value);
        }
    }

    /// <summary>
    /// Preserve document layout
    /// </summary>
    public bool? Layout
    {
        get { return this._rawData.GetNullableStruct<bool>("layout"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("layout", value);
        }
    }

    /// <summary>
    /// Detect and extract tables
    /// </summary>
    public bool? Tables
    {
        get { return this._rawData.GetNullableStruct<bool>("tables"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("tables", value);
        }
    }

    /// <summary>
    /// Extract text content
    /// </summary>
    public bool? Text
    {
        get { return this._rawData.GetNullableStruct<bool>("text"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("text", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Forms;
        _ = this.Layout;
        _ = this.Tables;
        _ = this.Text;
    }

    public Features() { }

    public Features(Features features)
        : base(features) { }

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
