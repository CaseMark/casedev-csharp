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

namespace Casedev.Models.Legal.V1;

/// <summary>
/// Generate a legal document with structured inputs. Powered by an agent that handles
/// research, formatting, citation verification, and vault upload. Returns a run ID
/// for polling.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class V1DraftParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// What to draft — the core task. E.g., "Motion to compel defendant to produce
    /// discovery responses"
    /// </summary>
    public required string Instructions
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("instructions");
        }
        init { this._rawBodyData.Set("instructions", value); }
    }

    /// <summary>
    /// Vault ID where the final document will be uploaded
    /// </summary>
    public required string VaultID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("vault_id");
        }
        init { this._rawBodyData.Set("vault_id", value); }
    }

    /// <summary>
    /// Research and include legal citations
    /// </summary>
    public bool? Citations
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("citations");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("citations", value);
        }
    }

    /// <summary>
    /// Court or jurisdiction formatting hint. Triggers a legal-skills search. E.g.,
    /// "California Superior Court", "SDNY", "federal pleading"
    /// </summary>
    public string? Format
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("format");
        }
        init { this._rawBodyData.Set("format", value); }
    }

    /// <summary>
    /// Target document length
    /// </summary>
    public Length? Length
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Length>("length");
        }
        init { this._rawBodyData.Set("length", value); }
    }

    /// <summary>
    /// LLM model override. Defaults to anthropic/claude-sonnet-4.6
    /// </summary>
    public string? Model
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("model");
        }
        init { this._rawBodyData.Set("model", value); }
    }

    /// <summary>
    /// Vault object IDs to use as source/reference documents
    /// </summary>
    public IReadOnlyList<string>? ObjectIds
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>("object_ids");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<string>?>(
                "object_ids",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Filename for the output document. Auto-generated if omitted.
    /// </summary>
    public string? OutputName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("output_name");
        }
        init { this._rawBodyData.Set("output_name", value); }
    }

    /// <summary>
    /// Output file format
    /// </summary>
    public ApiEnum<string, OutputType>? OutputType
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, OutputType>>("output_type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("output_type", value);
        }
    }

    /// <summary>
    /// Verify all citations in a loop — re-run verification and repair bad citations
    /// until they pass
    /// </summary>
    public bool? Verified
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("verified");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("verified", value);
        }
    }

    public V1DraftParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public V1DraftParams(V1DraftParams v1DraftParams)
        : base(v1DraftParams)
    {
        this._rawBodyData = new(v1DraftParams._rawBodyData);
    }
#pragma warning restore CS8618

    public V1DraftParams(
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
    V1DraftParams(
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
    public static V1DraftParams FromRawUnchecked(
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

    public virtual bool Equals(V1DraftParams? other)
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
        return new System::UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/legal/v1/draft")
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
/// Target document length
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Length, LengthFromRaw>))]
public sealed record class Length : JsonModel
{
    /// <summary>
    /// Target value (e.g., 2000 words or 5 pages)
    /// </summary>
    public double? Target
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("target");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("target", value);
        }
    }

    public ApiEnum<string, Unit>? Unit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Unit>>("unit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("unit", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Target;
        this.Unit?.Validate();
    }

    public Length() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Length(Length length)
        : base(length) { }
#pragma warning restore CS8618

    public Length(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Length(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LengthFromRaw.FromRawUnchecked"/>
    public static Length FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LengthFromRaw : IFromRawJson<Length>
{
    /// <inheritdoc/>
    public Length FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Length.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(UnitConverter))]
public enum Unit
{
    Words,
    Pages,
}

sealed class UnitConverter : JsonConverter<Unit>
{
    public override Unit Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "words" => Unit.Words,
            "pages" => Unit.Pages,
            _ => (Unit)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Unit value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Unit.Words => "words",
                Unit.Pages => "pages",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Output file format
/// </summary>
[JsonConverter(typeof(OutputTypeConverter))]
public enum OutputType
{
    Pdf,
    Docx,
    Xlsx,
    Pptx,
    Md,
}

sealed class OutputTypeConverter : JsonConverter<OutputType>
{
    public override OutputType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pdf" => OutputType.Pdf,
            "docx" => OutputType.Docx,
            "xlsx" => OutputType.Xlsx,
            "pptx" => OutputType.Pptx,
            "md" => OutputType.Md,
            _ => (OutputType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        OutputType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                OutputType.Pdf => "pdf",
                OutputType.Docx => "docx",
                OutputType.Xlsx => "xlsx",
                OutputType.Pptx => "pptx",
                OutputType.Md => "md",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
