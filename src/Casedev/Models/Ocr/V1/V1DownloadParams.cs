using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Casedev.Core;
using Casedev.Exceptions;
using System = System;

namespace Casedev.Models.Ocr.V1;

/// <summary>
/// Download OCR processing results in various formats. Returns the processed document
/// as text extraction, structured JSON with coordinates, searchable PDF with text
/// layer, or the original uploaded document.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class V1DownloadParams : ParamsBase
{
    public required string ID { get; init; }

    public ApiEnum<string, global::Casedev.Models.Ocr.V1.Type>? Type { get; init; }

    public V1DownloadParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public V1DownloadParams(V1DownloadParams v1DownloadParams)
        : base(v1DownloadParams)
    {
        this.ID = v1DownloadParams.ID;
        this.Type = v1DownloadParams.Type;
    }
#pragma warning restore CS8618

    public V1DownloadParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1DownloadParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
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

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["ID"] = JsonSerializer.SerializeToElement(this.ID),
                    ["Type"] = JsonSerializer.SerializeToElement(this.Type),
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

    public virtual bool Equals(V1DownloadParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.ID.Equals(other.ID)
            && (this.Type?.Equals(other.Type) ?? other.Type == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/ocr/v1/{0}/download/{1}", this.ID, this.Type?.Raw())
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

    public override int GetHashCode()
    {
        return 0;
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

sealed class TypeConverter : JsonConverter<global::Casedev.Models.Ocr.V1.Type>
{
    public override global::Casedev.Models.Ocr.V1.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "text" => global::Casedev.Models.Ocr.V1.Type.Text,
            "json" => global::Casedev.Models.Ocr.V1.Type.Json,
            "pdf" => global::Casedev.Models.Ocr.V1.Type.Pdf,
            "original" => global::Casedev.Models.Ocr.V1.Type.Original,
            _ => (global::Casedev.Models.Ocr.V1.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Casedev.Models.Ocr.V1.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Casedev.Models.Ocr.V1.Type.Text => "text",
                global::Casedev.Models.Ocr.V1.Type.Json => "json",
                global::Casedev.Models.Ocr.V1.Type.Pdf => "pdf",
                global::Casedev.Models.Ocr.V1.Type.Original => "original",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
