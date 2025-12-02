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
        get { return ModelBase.GetNullableStruct<double>(this.RawData, "duration_ms"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "duration_ms", value);
        }
    }

    /// <summary>
    /// Unique identifier for this execution
    /// </summary>
    public string? ExecutionID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "execution_id"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "execution_id", value);
        }
    }

    /// <summary>
    /// Human-readable status message
    /// </summary>
    public string? Message
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "message"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "message", value);
        }
    }

    /// <summary>
    /// Final output (only for synchronous/completed executions)
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Output
    {
        get
        {
            return ModelBase.GetNullableClass<Dictionary<string, JsonElement>>(
                this.RawData,
                "output"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "output", value);
        }
    }

    /// <summary>
    /// Current status of the execution
    /// </summary>
    public ApiEnum<string, Status>? Status
    {
        get { return ModelBase.GetNullableClass<ApiEnum<string, Status>>(this.RawData, "status"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "status", value);
        }
    }

    /// <summary>
    /// Results from each step (only for synchronous/completed executions)
    /// </summary>
    public IReadOnlyList<Dictionary<string, JsonElement>>? StepResults
    {
        get
        {
            return ModelBase.GetNullableClass<List<Dictionary<string, JsonElement>>>(
                this.RawData,
                "step_results"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "step_results", value);
        }
    }

    /// <summary>
    /// Whether webhook notifications are configured
    /// </summary>
    public bool? WebhookConfigured
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "webhook_configured"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "webhook_configured", value);
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
