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

namespace CaseDev.Models.Compute.V1.Invoke;

/// <summary>
/// Execute a deployed compute function with custom input data. Supports both synchronous
/// and asynchronous execution modes. Functions can be invoked by ID or name and can
/// process various types of input data for legal document analysis, data processing,
/// or other computational tasks.
/// </summary>
public sealed record class InvokeRunParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? FunctionID { get; init; }

    /// <summary>
    /// Input data to pass to the function
    /// </summary>
    public required IReadOnlyDictionary<string, JsonElement> Input
    {
        get
        {
            return ModelBase.GetNotNullClass<Dictionary<string, JsonElement>>(
                this.RawBodyData,
                "input"
            );
        }
        init { ModelBase.Set(this._rawBodyData, "input", value); }
    }

    /// <summary>
    /// If true, returns immediately with run ID for background execution
    /// </summary>
    public bool? Async
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawBodyData, "async"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "async", value);
        }
    }

    /// <summary>
    /// Override the auto-detected function suffix
    /// </summary>
    public ApiEnum<string, FunctionSuffix>? FunctionSuffix
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<string, FunctionSuffix>>(
                this.RawBodyData,
                "functionSuffix"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "functionSuffix", value);
        }
    }

    public InvokeRunParams() { }

    public InvokeRunParams(
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
    InvokeRunParams(
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
    public static InvokeRunParams FromRawUnchecked(
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
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/compute/v1/invoke/{0}", this.FunctionID)
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
/// Override the auto-detected function suffix
/// </summary>
[JsonConverter(typeof(FunctionSuffixConverter))]
public enum FunctionSuffix
{
    _Modal,
    _Task,
    _Web,
    _Server,
}

sealed class FunctionSuffixConverter : JsonConverter<FunctionSuffix>
{
    public override FunctionSuffix Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "_modal" => FunctionSuffix._Modal,
            "_task" => FunctionSuffix._Task,
            "_web" => FunctionSuffix._Web,
            "_server" => FunctionSuffix._Server,
            _ => (FunctionSuffix)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FunctionSuffix value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FunctionSuffix._Modal => "_modal",
                FunctionSuffix._Task => "_task",
                FunctionSuffix._Web => "_web",
                FunctionSuffix._Server => "_server",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
