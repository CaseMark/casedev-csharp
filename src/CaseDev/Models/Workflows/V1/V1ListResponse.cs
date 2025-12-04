using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;

namespace CaseDev.Models.Workflows.V1;

[JsonConverter(typeof(ModelConverter<V1ListResponse, V1ListResponseFromRaw>))]
public sealed record class V1ListResponse : ModelBase
{
    public long? Limit
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "limit"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "limit", value);
        }
    }

    public long? Offset
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "offset"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "offset", value);
        }
    }

    public long? Total
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "total"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "total", value);
        }
    }

    public IReadOnlyList<Workflow>? Workflows
    {
        get { return ModelBase.GetNullableClass<List<Workflow>>(this.RawData, "workflows"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "workflows", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Limit;
        _ = this.Offset;
        _ = this.Total;
        foreach (var item in this.Workflows ?? [])
        {
            item.Validate();
        }
    }

    public V1ListResponse() { }

    public V1ListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1ListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="V1ListResponseFromRaw.FromRawUnchecked"/>
    public static V1ListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class V1ListResponseFromRaw : IFromRaw<V1ListResponse>
{
    /// <inheritdoc/>
    public V1ListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        V1ListResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<Workflow, WorkflowFromRaw>))]
public sealed record class Workflow : ModelBase
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

    public string? CreatedAt
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "createdAt"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "createdAt", value);
        }
    }

    public string? DeployedAt
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "deployedAt"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "deployedAt", value);
        }
    }

    public string? Description
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "description"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "description", value);
        }
    }

    public string? Name
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "name"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "name", value);
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

    public string? UpdatedAt
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "updatedAt"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "updatedAt", value);
        }
    }

    public string? Visibility
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "visibility"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "visibility", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.DeployedAt;
        _ = this.Description;
        _ = this.Name;
        _ = this.TriggerType;
        _ = this.UpdatedAt;
        _ = this.Visibility;
    }

    public Workflow() { }

    public Workflow(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Workflow(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WorkflowFromRaw.FromRawUnchecked"/>
    public static Workflow FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WorkflowFromRaw : IFromRaw<Workflow>
{
    /// <inheritdoc/>
    public Workflow FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Workflow.FromRawUnchecked(rawData);
}
