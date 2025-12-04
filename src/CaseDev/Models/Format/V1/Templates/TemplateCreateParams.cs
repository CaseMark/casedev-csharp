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

namespace CaseDev.Models.Format.V1.Templates;

/// <summary>
/// Create a new format template for document formatting. Templates support variables
/// using `{{variable}}` syntax and can be used for captions, signatures, letterheads,
/// certificates, footers, or custom formatting needs.
/// </summary>
public sealed record class TemplateCreateParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Template content with {{variable}} placeholders
    /// </summary>
    public required string Content
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawBodyData, "content"); }
        init { ModelBase.Set(this._rawBodyData, "content", value); }
    }

    /// <summary>
    /// Template name
    /// </summary>
    public required string Name
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawBodyData, "name"); }
        init { ModelBase.Set(this._rawBodyData, "name", value); }
    }

    /// <summary>
    /// Template type
    /// </summary>
    public required ApiEnum<string, global::CaseDev.Models.Format.V1.Templates.Type> Type
    {
        get
        {
            return ModelBase.GetNotNullClass<
                ApiEnum<string, global::CaseDev.Models.Format.V1.Templates.Type>
            >(this.RawBodyData, "type");
        }
        init { ModelBase.Set(this._rawBodyData, "type", value); }
    }

    /// <summary>
    /// Template description
    /// </summary>
    public string? Description
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "description"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "description", value);
        }
    }

    /// <summary>
    /// CSS styles for the template
    /// </summary>
    public JsonElement? Styles
    {
        get { return ModelBase.GetNullableStruct<JsonElement>(this.RawBodyData, "styles"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "styles", value);
        }
    }

    /// <summary>
    /// Template tags for organization
    /// </summary>
    public IReadOnlyList<string>? Tags
    {
        get { return ModelBase.GetNullableClass<List<string>>(this.RawBodyData, "tags"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "tags", value);
        }
    }

    /// <summary>
    /// Template variables (auto-detected if not provided)
    /// </summary>
    public IReadOnlyList<string>? Variables
    {
        get { return ModelBase.GetNullableClass<List<string>>(this.RawBodyData, "variables"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "variables", value);
        }
    }

    public TemplateCreateParams() { }

    public TemplateCreateParams(TemplateCreateParams templateCreateParams)
        : base(templateCreateParams)
    {
        this._rawBodyData = [.. templateCreateParams._rawBodyData];
    }

    public TemplateCreateParams(
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
    TemplateCreateParams(
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
    public static TemplateCreateParams FromRawUnchecked(
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
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/format/v1/templates"
        )
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
/// Template type
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Caption,
    Signature,
    Letterhead,
    Certificate,
    Footer,
    Custom,
}

sealed class TypeConverter : JsonConverter<global::CaseDev.Models.Format.V1.Templates.Type>
{
    public override global::CaseDev.Models.Format.V1.Templates.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "caption" => global::CaseDev.Models.Format.V1.Templates.Type.Caption,
            "signature" => global::CaseDev.Models.Format.V1.Templates.Type.Signature,
            "letterhead" => global::CaseDev.Models.Format.V1.Templates.Type.Letterhead,
            "certificate" => global::CaseDev.Models.Format.V1.Templates.Type.Certificate,
            "footer" => global::CaseDev.Models.Format.V1.Templates.Type.Footer,
            "custom" => global::CaseDev.Models.Format.V1.Templates.Type.Custom,
            _ => (global::CaseDev.Models.Format.V1.Templates.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::CaseDev.Models.Format.V1.Templates.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::CaseDev.Models.Format.V1.Templates.Type.Caption => "caption",
                global::CaseDev.Models.Format.V1.Templates.Type.Signature => "signature",
                global::CaseDev.Models.Format.V1.Templates.Type.Letterhead => "letterhead",
                global::CaseDev.Models.Format.V1.Templates.Type.Certificate => "certificate",
                global::CaseDev.Models.Format.V1.Templates.Type.Footer => "footer",
                global::CaseDev.Models.Format.V1.Templates.Type.Custom => "custom",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
