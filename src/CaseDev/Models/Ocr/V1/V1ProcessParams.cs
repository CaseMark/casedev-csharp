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
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// URL or S3 path to the document to process
    /// </summary>
    public required string DocumentURL
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawBodyData, "document_url"); }
        init { ModelBase.Set(this._rawBodyData, "document_url", value); }
    }

    /// <summary>
    /// URL to receive completion webhook
    /// </summary>
    public string? CallbackURL
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "callback_url"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "callback_url", value);
        }
    }

    /// <summary>
    /// Optional custom document identifier
    /// </summary>
    public string? DocumentID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "document_id"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "document_id", value);
        }
    }

    /// <summary>
    /// OCR engine to use
    /// </summary>
    public ApiEnum<string, Engine>? Engine
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<string, Engine>>(this.RawBodyData, "engine");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "engine", value);
        }
    }

    /// <summary>
    /// OCR features to extract
    /// </summary>
    public Features? Features
    {
        get { return ModelBase.GetNullableClass<Features>(this.RawBodyData, "features"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "features", value);
        }
    }

    /// <summary>
    /// S3 bucket to store results
    /// </summary>
    public string? ResultBucket
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "result_bucket"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "result_bucket", value);
        }
    }

    /// <summary>
    /// S3 key prefix for results
    /// </summary>
    public string? ResultPrefix
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "result_prefix"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "result_prefix", value);
        }
    }

    public V1ProcessParams() { }

    public V1ProcessParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1ProcessParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRaw.FromRawUnchecked"/>
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

    internal override StringContent? BodyContent()
    {
        return new(JsonSerializer.Serialize(this.RawBodyData), Encoding.UTF8, "application/json");
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
[JsonConverter(typeof(ModelConverter<Features, FeaturesFromRaw>))]
public sealed record class Features : ModelBase
{
    /// <summary>
    /// Detect form fields
    /// </summary>
    public bool? Forms
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "forms"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "forms", value);
        }
    }

    /// <summary>
    /// Preserve document layout
    /// </summary>
    public bool? Layout
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "layout"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "layout", value);
        }
    }

    /// <summary>
    /// Detect and extract tables
    /// </summary>
    public bool? Tables
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "tables"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "tables", value);
        }
    }

    /// <summary>
    /// Extract text content
    /// </summary>
    public bool? Text
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "text"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "text", value);
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

    public Features(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Features(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FeaturesFromRaw.FromRawUnchecked"/>
    public static Features FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FeaturesFromRaw : IFromRaw<Features>
{
    /// <inheritdoc/>
    public Features FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Features.FromRawUnchecked(rawData);
}
