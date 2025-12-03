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

namespace CaseDev.Models.Templates.V1;

/// <summary>
/// Execute a pre-built workflow with custom input data. Workflows automate common
/// legal document processing tasks like contract analysis, due diligence reviews,
/// and document classification.
///
/// <para>**Available Workflows:** - Contract analysis and risk assessment - Document
/// classification and tagging - Legal research and case summarization - Due diligence
/// document review - Compliance checking and reporting</para>
/// </summary>
public sealed record class V1ExecuteParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ID { get; init; }

    /// <summary>
    /// Input data for the workflow (structure varies by workflow type)
    /// </summary>
    public required JsonElement Input
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawBodyData, "input"); }
        init { ModelBase.Set(this._rawBodyData, "input", value); }
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

    public V1ExecuteParams() { }

    public V1ExecuteParams(
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
    V1ExecuteParams(
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

    public static V1ExecuteParams FromRawUnchecked(
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
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/templates/v1/{0}/execute", this.ID)
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

[JsonConverter(typeof(ModelConverter<Options, OptionsFromRaw>))]
public sealed record class Options : ModelBase
{
    /// <summary>
    /// Output format preference
    /// </summary>
    public ApiEnum<string, OptionsFormat>? Format
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<string, OptionsFormat>>(
                this.RawData,
                "format"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "format", value);
        }
    }

    /// <summary>
    /// LLM model to use for processing
    /// </summary>
    public string? Model
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "model"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "model", value);
        }
    }

    public override void Validate()
    {
        this.Format?.Validate();
        _ = this.Model;
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

/// <summary>
/// Output format preference
/// </summary>
[JsonConverter(typeof(OptionsFormatConverter))]
public enum OptionsFormat
{
    Json,
    Text,
}

sealed class OptionsFormatConverter : JsonConverter<OptionsFormat>
{
    public override OptionsFormat Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "json" => OptionsFormat.Json,
            "text" => OptionsFormat.Text,
            _ => (OptionsFormat)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        OptionsFormat value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                OptionsFormat.Json => "json",
                OptionsFormat.Text => "text",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
