using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;
using CaseDev.Exceptions;
using System = System;

namespace CaseDev.Models.Ocr.V1;

/// <summary>
/// Download OCR processing results in various formats. Returns the processed document
/// as text extraction, structured JSON with coordinates, searchable PDF with text
/// layer, or the original uploaded document.
/// </summary>
public sealed record class V1DownloadParams : ParamsBase
{
    public required string ID { get; init; }

    public ApiEnum<string, global::CaseDev.Models.Ocr.V1.Type>? Type { get; init; }

    public V1DownloadParams() { }

    public V1DownloadParams(V1DownloadParams v1DownloadParams)
        : base(v1DownloadParams) { }

    public V1DownloadParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1DownloadParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRaw.FromRawUnchecked"/>
    public static V1DownloadParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        );
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/ocr/v1/{0}/download/{1}", this.ID, this.Type.Raw())
        )
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

[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Text,
    Json,
    Pdf,
    Original,
}

sealed class TypeConverter : JsonConverter<global::CaseDev.Models.Ocr.V1.Type>
{
    public override global::CaseDev.Models.Ocr.V1.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "text" => global::CaseDev.Models.Ocr.V1.Type.Text,
            "json" => global::CaseDev.Models.Ocr.V1.Type.Json,
            "pdf" => global::CaseDev.Models.Ocr.V1.Type.Pdf,
            "original" => global::CaseDev.Models.Ocr.V1.Type.Original,
            _ => (global::CaseDev.Models.Ocr.V1.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::CaseDev.Models.Ocr.V1.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::CaseDev.Models.Ocr.V1.Type.Text => "text",
                global::CaseDev.Models.Ocr.V1.Type.Json => "json",
                global::CaseDev.Models.Ocr.V1.Type.Pdf => "pdf",
                global::CaseDev.Models.Ocr.V1.Type.Original => "original",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
