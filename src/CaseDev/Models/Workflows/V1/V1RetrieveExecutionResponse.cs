using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;

namespace CaseDev.Models.Workflows.V1;

[JsonConverter(
    typeof(ModelConverter<V1RetrieveExecutionResponse, V1RetrieveExecutionResponseFromRaw>)
)]
public sealed record class V1RetrieveExecutionResponse : ModelBase
{
    public string? ID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "id"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "id", value);
        }
    }

    public string? CompletedAt
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "completedAt"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "completedAt", value);
        }
    }

    public long? DurationMs
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "durationMs"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "durationMs", value);
        }
    }

    public string? Error
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "error"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "error", value);
        }
    }

    public string? ExecutionArn
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "executionArn"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "executionArn", value);
        }
    }

    public JsonElement? Input
    {
        get { return ModelBase.GetNullableStruct<JsonElement>(this.RawData, "input"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "input", value);
        }
    }

    public JsonElement? Output
    {
        get { return ModelBase.GetNullableStruct<JsonElement>(this.RawData, "output"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "output", value);
        }
    }

    public string? StartedAt
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "startedAt"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "startedAt", value);
        }
    }

    public string? Status
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "status"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "status", value);
        }
    }

    public IReadOnlyList<JsonElement>? Steps
    {
        get { return ModelBase.GetNullableClass<List<JsonElement>>(this.RawData, "steps"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "steps", value);
        }
    }

    public string? TriggerType
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "triggerType"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "triggerType", value);
        }
    }

    public string? WorkflowID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "workflowId"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "workflowId", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CompletedAt;
        _ = this.DurationMs;
        _ = this.Error;
        _ = this.ExecutionArn;
        _ = this.Input;
        _ = this.Output;
        _ = this.StartedAt;
        _ = this.Status;
        _ = this.Steps;
        _ = this.TriggerType;
        _ = this.WorkflowID;
    }

    public V1RetrieveExecutionResponse() { }

    public V1RetrieveExecutionResponse(V1RetrieveExecutionResponse v1RetrieveExecutionResponse)
        : base(v1RetrieveExecutionResponse) { }

    public V1RetrieveExecutionResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1RetrieveExecutionResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="V1RetrieveExecutionResponseFromRaw.FromRawUnchecked"/>
    public static V1RetrieveExecutionResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class V1RetrieveExecutionResponseFromRaw : IFromRaw<V1RetrieveExecutionResponse>
{
    /// <inheritdoc/>
    public V1RetrieveExecutionResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => V1RetrieveExecutionResponse.FromRawUnchecked(rawData);
}
