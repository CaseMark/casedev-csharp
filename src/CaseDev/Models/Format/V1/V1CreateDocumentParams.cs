using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;
using CaseDev.Exceptions;

namespace CaseDev.Models.Format.V1;

/// <summary>
/// Convert Markdown, JSON, or text content to professionally formatted PDF, DOCX,
/// or HTML documents. Supports template components with variable interpolation for
/// creating consistent legal documents like contracts, briefs, and reports.
/// </summary>
public sealed record class V1CreateDocumentParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The source content to format
    /// </summary>
    public required string Content
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawBodyData, "content"); }
        init { ModelBase.Set(this._rawBodyData, "content", value); }
    }

    /// <summary>
    /// Desired output format
    /// </summary>
    public required ApiEnum<string, OutputFormat> OutputFormat
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, OutputFormat>>(
                this.RawBodyData,
                "output_format"
            );
        }
        init { ModelBase.Set(this._rawBodyData, "output_format", value); }
    }

    /// <summary>
    /// Format of the input content
    /// </summary>
    public ApiEnum<string, InputFormat>? InputFormat
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<string, InputFormat>>(
                this.RawBodyData,
                "input_format"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "input_format", value);
        }
    }

    public Options? Options
    {
        get { return ModelBase.GetNullableClass<Options>(this.RawBodyData, "options"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "options", value);
        }
    }

    public V1CreateDocumentParams() { }

    public V1CreateDocumentParams(
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
    V1CreateDocumentParams(
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

    public static V1CreateDocumentParams FromRawUnchecked(
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

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/format/v1/document")
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
/// Desired output format
/// </summary>
[JsonConverter(typeof(OutputFormatConverter))]
public enum OutputFormat
{
    Pdf,
    Docx,
    HTMLPreview,
}

sealed class OutputFormatConverter : JsonConverter<OutputFormat>
{
    public override OutputFormat Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pdf" => OutputFormat.Pdf,
            "docx" => OutputFormat.Docx,
            "html_preview" => OutputFormat.HTMLPreview,
            _ => (OutputFormat)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        OutputFormat value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                OutputFormat.Pdf => "pdf",
                OutputFormat.Docx => "docx",
                OutputFormat.HTMLPreview => "html_preview",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Format of the input content
/// </summary>
[JsonConverter(typeof(InputFormatConverter))]
public enum InputFormat
{
    Md,
    Json,
    Text,
}

sealed class InputFormatConverter : JsonConverter<InputFormat>
{
    public override InputFormat Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "md" => InputFormat.Md,
            "json" => InputFormat.Json,
            "text" => InputFormat.Text,
            _ => (InputFormat)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InputFormat value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InputFormat.Md => "md",
                InputFormat.Json => "json",
                InputFormat.Text => "text",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ModelConverter<Options, OptionsFromRaw>))]
public sealed record class Options : ModelBase
{
    /// <summary>
    /// Template components with variables
    /// </summary>
    public IReadOnlyList<Component>? Components
    {
        get { return ModelBase.GetNullableClass<List<Component>>(this.RawData, "components"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "components", value);
        }
    }

    public override void Validate()
    {
        foreach (var item in this.Components ?? [])
        {
            item.Validate();
        }
    }

    public Options() { }

    public Options(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Options(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Options FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OptionsFromRaw : IFromRaw<Options>
{
    public Options FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Options.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<Component, ComponentFromRaw>))]
public sealed record class Component : ModelBase
{
    /// <summary>
    /// Inline template content
    /// </summary>
    public string? Content
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "content"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "content", value);
        }
    }

    /// <summary>
    /// Custom styling options
    /// </summary>
    public JsonElement? Styles
    {
        get { return ModelBase.GetNullableStruct<JsonElement>(this.RawData, "styles"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "styles", value);
        }
    }

    /// <summary>
    /// ID of saved template component
    /// </summary>
    public string? TemplateID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "templateId"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "templateId", value);
        }
    }

    /// <summary>
    /// Variables for template interpolation
    /// </summary>
    public JsonElement? Variables
    {
        get { return ModelBase.GetNullableStruct<JsonElement>(this.RawData, "variables"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "variables", value);
        }
    }

    public override void Validate()
    {
        _ = this.Content;
        _ = this.Styles;
        _ = this.TemplateID;
        _ = this.Variables;
    }

    public Component() { }

    public Component(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Component(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Component FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ComponentFromRaw : IFromRaw<Component>
{
    public Component FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Component.FromRawUnchecked(rawData);
}
