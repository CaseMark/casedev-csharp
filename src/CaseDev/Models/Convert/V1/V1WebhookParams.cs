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

namespace CaseDev.Models.Convert.V1;

/// <summary>
/// Internal webhook endpoint that receives completion notifications from the Modal
/// FTR converter service. This endpoint handles status updates for file conversion
/// jobs, including success and failure notifications. Requires valid Bearer token authentication.
/// </summary>
public sealed record class V1WebhookParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Unique identifier for the conversion job
    /// </summary>
    public required string JobID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawBodyData, "job_id"); }
        init { ModelBase.Set(this._rawBodyData, "job_id", value); }
    }

    /// <summary>
    /// Status of the conversion job
    /// </summary>
    public required ApiEnum<string, Status> Status
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, Status>>(this.RawBodyData, "status");
        }
        init { ModelBase.Set(this._rawBodyData, "status", value); }
    }

    /// <summary>
    /// Error message for failed jobs
    /// </summary>
    public string? Error
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "error"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "error", value);
        }
    }

    /// <summary>
    /// Result data for completed jobs
    /// </summary>
    public Result? Result
    {
        get { return ModelBase.GetNullableClass<Result>(this.RawBodyData, "result"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "result", value);
        }
    }

    public V1WebhookParams() { }

    public V1WebhookParams(V1WebhookParams v1WebhookParams)
        : base(v1WebhookParams)
    {
        this._rawBodyData = [.. v1WebhookParams._rawBodyData];
    }

    public V1WebhookParams(
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
    V1WebhookParams(
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
    public static V1WebhookParams FromRawUnchecked(
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/convert/v1/webhook")
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
/// Status of the conversion job
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Completed,
    Failed,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "completed" => Status.Completed,
            "failed" => Status.Failed,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Completed => "completed",
                Status.Failed => "failed",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Result data for completed jobs
/// </summary>
[JsonConverter(typeof(ModelConverter<Result, ResultFromRaw>))]
public sealed record class Result : ModelBase
{
    /// <summary>
    /// Processing duration in seconds
    /// </summary>
    public double? DurationSeconds
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawData, "duration_seconds"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "duration_seconds", value);
        }
    }

    /// <summary>
    /// Size of processed file in bytes
    /// </summary>
    public long? FileSizeBytes
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "file_size_bytes"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "file_size_bytes", value);
        }
    }

    /// <summary>
    /// Filename where converted file is stored
    /// </summary>
    public string? StoredFilename
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "stored_filename"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "stored_filename", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DurationSeconds;
        _ = this.FileSizeBytes;
        _ = this.StoredFilename;
    }

    public Result() { }

    public Result(Result result)
        : base(result) { }

    public Result(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Result(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ResultFromRaw.FromRawUnchecked"/>
    public static Result FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ResultFromRaw : IFromRaw<Result>
{
    /// <inheritdoc/>
    public Result FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Result.FromRawUnchecked(rawData);
}
