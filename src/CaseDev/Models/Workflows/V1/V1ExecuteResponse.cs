using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;
using CaseDev.Exceptions;

namespace CaseDev.Models.Workflows.V1;

[JsonConverter(typeof(ModelConverter<V1ExecuteResponse, V1ExecuteResponseFromRaw>))]
public sealed record class V1ExecuteResponse : ModelBase
{
    /// <summary>
    /// Workflow output (structure varies by workflow type)
    /// </summary>
    public JsonElement? Result
    {
        get { return ModelBase.GetNullableStruct<JsonElement>(this.RawData, "result"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "result", value);
        }
    }

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

    public Usage? Usage
    {
        get { return ModelBase.GetNullableClass<Usage>(this.RawData, "usage"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "usage", value);
        }
    }

    /// <summary>
    /// Name of the executed workflow
    /// </summary>
    public string? WorkflowName
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "workflow_name"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "workflow_name", value);
        }
    }

    public override void Validate()
    {
        _ = this.Result;
        this.Status?.Validate();
        this.Usage?.Validate();
        _ = this.WorkflowName;
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

[JsonConverter(typeof(ModelConverter<Usage, UsageFromRaw>))]
public sealed record class Usage : ModelBase
{
    public long? CompletionTokens
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "completion_tokens"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "completion_tokens", value);
        }
    }

    /// <summary>
    /// Total cost in USD
    /// </summary>
    public double? Cost
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawData, "cost"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "cost", value);
        }
    }

    public long? PromptTokens
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "prompt_tokens"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "prompt_tokens", value);
        }
    }

    public long? TotalTokens
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "total_tokens"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "total_tokens", value);
        }
    }

    public override void Validate()
    {
        _ = this.CompletionTokens;
        _ = this.Cost;
        _ = this.PromptTokens;
        _ = this.TotalTokens;
    }

    public Usage() { }

    public Usage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Usage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Usage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UsageFromRaw : IFromRaw<Usage>
{
    public Usage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Usage.FromRawUnchecked(rawData);
}
