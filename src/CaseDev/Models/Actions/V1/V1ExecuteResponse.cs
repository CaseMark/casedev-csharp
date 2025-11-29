using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;
using CaseDev.Exceptions;

namespace CaseDev.Models.Actions.V1;

[JsonConverter(typeof(ModelConverter<V1ExecuteResponse, V1ExecuteResponseFromRaw>))]
public sealed record class V1ExecuteResponse : ModelBase
{
    /// <summary>
    /// Execution duration in milliseconds (only for completed executions)
    /// </summary>
    public double? DurationMs
    {
        get
        {
            if (!this._rawData.TryGetValue("duration_ms", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["duration_ms"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Unique identifier for this execution
    /// </summary>
    public string? ExecutionID
    {
        get
        {
            if (!this._rawData.TryGetValue("execution_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["execution_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Human-readable status message
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
    /// Final output (only for synchronous/completed executions)
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Output
    {
        get
        {
            if (!this._rawData.TryGetValue("output", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, JsonElement>?>(
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

            this._rawData["output"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Current status of the execution
    /// </summary>
    public ApiEnum<string, Status>? Status
    {
        get
        {
            if (!this._rawData.TryGetValue("status", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, Status>?>(
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

    /// <summary>
    /// Results from each step (only for synchronous/completed executions)
    /// </summary>
    public IReadOnlyList<Dictionary<string, JsonElement>>? StepResults
    {
        get
        {
            if (!this._rawData.TryGetValue("step_results", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<Dictionary<string, JsonElement>>?>(
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

            this._rawData["step_results"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Whether webhook notifications are configured
    /// </summary>
    public bool? WebhookConfigured
    {
        get
        {
            if (!this._rawData.TryGetValue("webhook_configured", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["webhook_configured"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.DurationMs;
        _ = this.ExecutionID;
        _ = this.Message;
        _ = this.Output;
        this.Status?.Validate();
        _ = this.StepResults;
        _ = this.WebhookConfigured;
    }

    public V1ExecuteResponse() { }

    public V1ExecuteResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1ExecuteResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static V1ExecuteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class V1ExecuteResponseFromRaw : IFromRaw<V1ExecuteResponse>
{
    public V1ExecuteResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        V1ExecuteResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Current status of the execution
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Completed,
    Running,
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
            "running" => Status.Running,
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
                Status.Running => "running",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
