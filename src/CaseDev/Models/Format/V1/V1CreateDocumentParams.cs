using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
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
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The source content to format
    /// </summary>
    public required string Content
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("content");
        }
        init { this._rawBodyData.Set("content", value); }
    }

    /// <summary>
    /// Desired output format
    /// </summary>
    public required ApiEnum<string, OutputFormat> OutputFormat
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, OutputFormat>>(
                "output_format"
            );
        }
        init { this._rawBodyData.Set("output_format", value); }
    }

    /// <summary>
    /// Format of the input content
    /// </summary>
    public ApiEnum<string, InputFormat>? InputFormat
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, InputFormat>>("input_format");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("input_format", value);
        }
    }

    public Options? Options
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Options>("options");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("options", value);
        }
    }

    public V1CreateDocumentParams() { }

    public V1CreateDocumentParams(V1CreateDocumentParams v1CreateDocumentParams)
        : base(v1CreateDocumentParams)
    {
        this._rawBodyData = new(v1CreateDocumentParams._rawBodyData);
    }

    public V1CreateDocumentParams(
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
    V1CreateDocumentParams(
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
}

/// <summary>
/// Desired output format
/// </summary>
[JsonConverter(typeof(OutputFormatConverter))]
public enum OutputFormat
{
    Pdf,
    Docx,
    HtmlPreview,
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
            "html_preview" => OutputFormat.HtmlPreview,
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
                OutputFormat.HtmlPreview => "html_preview",
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

[JsonConverter(typeof(JsonModelConverter<Options, OptionsFromRaw>))]
public sealed record class Options : JsonModel
{
    /// <summary>
    /// Template components with variables
    /// </summary>
    public IReadOnlyList<Component>? Components
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Component>>("components");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Component>?>(
                "components",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Components ?? [])
        {
            item.Validate();
        }
    }

    public Options() { }

    public Options(Options options)
        : base(options) { }

    public Options(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Options(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OptionsFromRaw.FromRawUnchecked"/>
    public static Options FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OptionsFromRaw : IFromRawJson<Options>
{
    /// <inheritdoc/>
    public Options FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Options.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Component, ComponentFromRaw>))]
public sealed record class Component : JsonModel
{
    /// <summary>
    /// Inline template content
    /// </summary>
    public string? Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("content");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("content", value);
        }
    }

    /// <summary>
    /// Custom styling options
    /// </summary>
    public JsonElement? Styles
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("styles");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("styles", value);
        }
    }

    /// <summary>
    /// ID of saved template component
    /// </summary>
    public string? TemplateID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("templateId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("templateId", value);
        }
    }

    /// <summary>
    /// Variables for template interpolation
    /// </summary>
    public JsonElement? Variables
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("variables");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("variables", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Content;
        _ = this.Styles;
        _ = this.TemplateID;
        _ = this.Variables;
    }

    public Component() { }

    public Component(Component component)
        : base(component) { }

    public Component(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Component(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ComponentFromRaw.FromRawUnchecked"/>
    public static Component FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ComponentFromRaw : IFromRawJson<Component>
{
    /// <inheritdoc/>
    public Component FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Component.FromRawUnchecked(rawData);
}
