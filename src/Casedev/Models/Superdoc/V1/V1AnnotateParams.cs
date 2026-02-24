using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Casedev.Core;
using Casedev.Exceptions;
using System = System;

namespace Casedev.Models.Superdoc.V1;

/// <summary>
/// Populate fields inside a DOCX template using SuperDoc annotations. Supports text,
/// images, dates, and numbers. Can target individual fields by ID or multiple fields
/// by group.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class V1AnnotateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Document source - provide either URL or base64
    /// </summary>
    public required Document Document
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<Document>("document");
        }
        init { this._rawBodyData.Set("document", value); }
    }

    /// <summary>
    /// Fields to populate in the template
    /// </summary>
    public required IReadOnlyList<Field> Fields
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<ImmutableArray<Field>>("fields");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<Field>>(
                "fields",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Output format for the annotated document
    /// </summary>
    public ApiEnum<string, OutputFormat>? OutputFormat
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, OutputFormat>>(
                "output_format"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("output_format", value);
        }
    }

    public V1AnnotateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public V1AnnotateParams(V1AnnotateParams v1AnnotateParams)
        : base(v1AnnotateParams)
    {
        this._rawBodyData = new(v1AnnotateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public V1AnnotateParams(
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
    V1AnnotateParams(
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
    public static V1AnnotateParams FromRawUnchecked(
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

    public virtual bool Equals(V1AnnotateParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/superdoc/v1/annotate"
        )
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
/// Document source - provide either URL or base64
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Document, DocumentFromRaw>))]
public sealed record class Document : JsonModel
{
    /// <summary>
    /// Base64-encoded DOCX template
    /// </summary>
    public string? Base64
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("base64");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("base64", value);
        }
    }

    /// <summary>
    /// URL to the DOCX template
    /// </summary>
    public string? Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("url");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("url", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Base64;
        _ = this.Url;
    }

    public Document() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Document(Document document)
        : base(document) { }
#pragma warning restore CS8618

    public Document(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Document(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DocumentFromRaw.FromRawUnchecked"/>
    public static Document FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DocumentFromRaw : IFromRawJson<Document>
{
    /// <inheritdoc/>
    public Document FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Document.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Field, FieldFromRaw>))]
public sealed record class Field : JsonModel
{
    /// <summary>
    /// Field data type
    /// </summary>
    public required ApiEnum<string, global::Casedev.Models.Superdoc.V1.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Casedev.Models.Superdoc.V1.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Value to populate
    /// </summary>
    public required FieldValue Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FieldValue>("value");
        }
        init { this._rawData.Set("value", value); }
    }

    /// <summary>
    /// Target field ID (for single field)
    /// </summary>
    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    /// <summary>
    /// Target field group (for multiple fields with same tag)
    /// </summary>
    public string? Group
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("group");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("group", value);
        }
    }

    /// <summary>
    /// Optional configuration (e.g., image dimensions)
    /// </summary>
    public Options? Options
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Options>("options");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("options", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
        this.Value.Validate();
        _ = this.ID;
        _ = this.Group;
        this.Options?.Validate();
    }

    public Field() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Field(Field field)
        : base(field) { }
#pragma warning restore CS8618

    public Field(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Field(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FieldFromRaw.FromRawUnchecked"/>
    public static Field FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FieldFromRaw : IFromRawJson<Field>
{
    /// <inheritdoc/>
    public Field FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Field.FromRawUnchecked(rawData);
}

/// <summary>
/// Field data type
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Text,
    Image,
    Date,
    Number,
}

sealed class TypeConverter : JsonConverter<global::Casedev.Models.Superdoc.V1.Type>
{
    public override global::Casedev.Models.Superdoc.V1.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "text" => global::Casedev.Models.Superdoc.V1.Type.Text,
            "image" => global::Casedev.Models.Superdoc.V1.Type.Image,
            "date" => global::Casedev.Models.Superdoc.V1.Type.Date,
            "number" => global::Casedev.Models.Superdoc.V1.Type.Number,
            _ => (global::Casedev.Models.Superdoc.V1.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Casedev.Models.Superdoc.V1.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Casedev.Models.Superdoc.V1.Type.Text => "text",
                global::Casedev.Models.Superdoc.V1.Type.Image => "image",
                global::Casedev.Models.Superdoc.V1.Type.Date => "date",
                global::Casedev.Models.Superdoc.V1.Type.Number => "number",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Value to populate
/// </summary>
[JsonConverter(typeof(FieldValueConverter))]
public record class FieldValue : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public FieldValue(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public FieldValue(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public FieldValue(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="string"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickString(out var value)) {
    ///     // `value` is of type `string`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="double"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDouble(out var value)) {
    ///     // `value` is of type `double`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = this.Value as double?;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="CasedevInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (string value) => {...},
    ///     (double value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(System::Action<string> @string, System::Action<double> @double)
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case double value:
                @double(value);
                break;
            default:
                throw new CasedevInvalidDataException(
                    "Data did not match any variant of FieldValue"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="CasedevInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (string value) => {...},
    ///     (double value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(System::Func<string, T> @string, System::Func<double, T> @double)
    {
        return this.Value switch
        {
            string value => @string(value),
            double value => @double(value),
            _ => throw new CasedevInvalidDataException(
                "Data did not match any variant of FieldValue"
            ),
        };
    }

    public static implicit operator FieldValue(string value) => new(value);

    public static implicit operator FieldValue(double value) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="CasedevInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new CasedevInvalidDataException("Data did not match any variant of FieldValue");
        }
    }

    public virtual bool Equals(FieldValue? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            string _ => 0,
            double _ => 1,
            _ => -1,
        };
    }
}

sealed class FieldValueConverter : JsonConverter<FieldValue>
{
    public override FieldValue? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is CasedevInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<double>(element, options), element);
        }
        catch (System::Exception e) when (e is JsonException || e is CasedevInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        FieldValue value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Optional configuration (e.g., image dimensions)
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Options, OptionsFromRaw>))]
public sealed record class Options : JsonModel
{
    /// <summary>
    /// Image height in pixels
    /// </summary>
    public double? Height
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("height");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("height", value);
        }
    }

    /// <summary>
    /// Image width in pixels
    /// </summary>
    public double? Width
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("width");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("width", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Height;
        _ = this.Width;
    }

    public Options() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Options(Options options)
        : base(options) { }
#pragma warning restore CS8618

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

/// <summary>
/// Output format for the annotated document
/// </summary>
[JsonConverter(typeof(OutputFormatConverter))]
public enum OutputFormat
{
    Docx,
    Pdf,
}

sealed class OutputFormatConverter : JsonConverter<OutputFormat>
{
    public override OutputFormat Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "docx" => OutputFormat.Docx,
            "pdf" => OutputFormat.Pdf,
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
                OutputFormat.Docx => "docx",
                OutputFormat.Pdf => "pdf",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
