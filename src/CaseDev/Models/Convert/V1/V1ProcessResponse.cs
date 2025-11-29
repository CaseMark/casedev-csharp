using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;
using CaseDev.Exceptions;

namespace CaseDev.Models.Convert.V1;

[JsonConverter(typeof(ModelConverter<V1ProcessResponse, V1ProcessResponseFromRaw>))]
public sealed record class V1ProcessResponse : ModelBase
{
    /// <summary>
    /// Unique identifier for the conversion job
    /// </summary>
    public string? JobID
    {
        get
        {
            if (!this._rawData.TryGetValue("job_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["job_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Instructions for checking job status
    /// </summary>
    public string? Message
    {
        get
        {
            if (!this._rawData.TryGetValue("message", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["message"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Current status of the conversion job
    /// </summary>
    public ApiEnum<string, V1ProcessResponseStatus>? Status
    {
        get
        {
            if (!this._rawData.TryGetValue("status", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, V1ProcessResponseStatus>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["status"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.JobID;
        _ = this.Message;
        this.Status?.Validate();
    }

    public V1ProcessResponse() { }

    public V1ProcessResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1ProcessResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static V1ProcessResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class V1ProcessResponseFromRaw : IFromRaw<V1ProcessResponse>
{
    public V1ProcessResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        V1ProcessResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Current status of the conversion job
/// </summary>
[JsonConverter(typeof(V1ProcessResponseStatusConverter))]
public enum V1ProcessResponseStatus
{
    Queued,
    Processing,
    Completed,
    Failed,
}

sealed class V1ProcessResponseStatusConverter : JsonConverter<V1ProcessResponseStatus>
{
    public override V1ProcessResponseStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "queued" => V1ProcessResponseStatus.Queued,
            "processing" => V1ProcessResponseStatus.Processing,
            "completed" => V1ProcessResponseStatus.Completed,
            "failed" => V1ProcessResponseStatus.Failed,
            _ => (V1ProcessResponseStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        V1ProcessResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                V1ProcessResponseStatus.Queued => "queued",
                V1ProcessResponseStatus.Processing => "processing",
                V1ProcessResponseStatus.Completed => "completed",
                V1ProcessResponseStatus.Failed => "failed",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
