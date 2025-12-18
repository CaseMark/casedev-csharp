using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;

namespace CaseDev.Models.Workflows.V1;

[JsonConverter(typeof(JsonModelConverter<V1CreateResponse, V1CreateResponseFromRaw>))]
public sealed record class V1CreateResponse : JsonModel
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

    public string? CreatedAt
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "createdAt"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "createdAt", value);
        }
    }

    public string? Description
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "description"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "description", value);
        }
    }

    public IReadOnlyList<JsonElement>? Edges
    {
        get { return JsonModel.GetNullableClass<List<JsonElement>>(this.RawData, "edges"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "edges", value);
        }
    }

    public string? Name
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "name"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "name", value);
        }
    }

    public IReadOnlyList<JsonElement>? Nodes
    {
        get { return JsonModel.GetNullableClass<List<JsonElement>>(this.RawData, "nodes"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "nodes", value);
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

    public string? UpdatedAt
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "updatedAt"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "updatedAt", value);
        }
    }

    public string? Visibility
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "visibility"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "visibility", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.Description;
        _ = this.Edges;
        _ = this.Name;
        _ = this.Nodes;
        _ = this.TriggerType;
        _ = this.UpdatedAt;
        _ = this.Visibility;
    }

    public V1CreateResponse() { }

    public V1CreateResponse(V1CreateResponse v1CreateResponse)
        : base(v1CreateResponse) { }

    public V1CreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1CreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="V1CreateResponseFromRaw.FromRawUnchecked"/>
    public static V1CreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class V1CreateResponseFromRaw : IFromRawJson<V1CreateResponse>
{
    /// <inheritdoc/>
    public V1CreateResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        V1CreateResponse.FromRawUnchecked(rawData);
}
