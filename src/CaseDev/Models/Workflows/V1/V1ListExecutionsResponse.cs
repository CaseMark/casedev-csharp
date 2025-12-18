using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;

namespace CaseDev.Models.Workflows.V1;

[JsonConverter(
    typeof(JsonModelConverter<V1ListExecutionsResponse, V1ListExecutionsResponseFromRaw>)
)]
public sealed record class V1ListExecutionsResponse : JsonModel
{
    public IReadOnlyList<Execution>? Executions
    {
        get { return JsonModel.GetNullableClass<List<Execution>>(this.RawData, "executions"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "executions", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Executions ?? [])
        {
            item.Validate();
        }
    }

    public V1ListExecutionsResponse() { }

    public V1ListExecutionsResponse(V1ListExecutionsResponse v1ListExecutionsResponse)
        : base(v1ListExecutionsResponse) { }

    public V1ListExecutionsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1ListExecutionsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="V1ListExecutionsResponseFromRaw.FromRawUnchecked"/>
    public static V1ListExecutionsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class V1ListExecutionsResponseFromRaw : IFromRawJson<V1ListExecutionsResponse>
{
    /// <inheritdoc/>
    public V1ListExecutionsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => V1ListExecutionsResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Execution, ExecutionFromRaw>))]
public sealed record class Execution : JsonModel
{
    public string? ID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "id"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "id", value);
        }
    }

    public string? CompletedAt
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "completedAt"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "completedAt", value);
        }
    }

    public long? DurationMs
    {
        get { return JsonModel.GetNullableStruct<long>(this.RawData, "durationMs"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "durationMs", value);
        }
    }

    public string? StartedAt
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "startedAt"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "startedAt", value);
        }
    }

    public string? Status
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "status"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "status", value);
        }
    }

    public string? TriggerType
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "triggerType"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "triggerType", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CompletedAt;
        _ = this.DurationMs;
        _ = this.StartedAt;
        _ = this.Status;
        _ = this.TriggerType;
    }

    public Execution() { }

    public Execution(Execution execution)
        : base(execution) { }

    public Execution(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Execution(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExecutionFromRaw.FromRawUnchecked"/>
    public static Execution FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExecutionFromRaw : IFromRawJson<Execution>
{
    /// <inheritdoc/>
    public Execution FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Execution.FromRawUnchecked(rawData);
}
