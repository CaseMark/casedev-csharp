using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;

namespace CaseDev.Models.Search.V1;

[JsonConverter(typeof(JsonModelConverter<V1ResearchResponse, V1ResearchResponseFromRaw>))]
public sealed record class V1ResearchResponse : JsonModel
{
    /// <summary>
    /// Model used for research
    /// </summary>
    public string? Model
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "model"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "model", value);
        }
    }

    /// <summary>
    /// Unique identifier for this research
    /// </summary>
    public string? ResearchID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "researchId"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "researchId", value);
        }
    }

    /// <summary>
    /// Research findings and analysis
    /// </summary>
    public JsonElement? Results
    {
        get { return JsonModel.GetNullableStruct<JsonElement>(this.RawData, "results"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "results", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Model;
        _ = this.ResearchID;
        _ = this.Results;
    }

    public V1ResearchResponse() { }

    public V1ResearchResponse(V1ResearchResponse v1ResearchResponse)
        : base(v1ResearchResponse) { }

    public V1ResearchResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1ResearchResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="V1ResearchResponseFromRaw.FromRawUnchecked"/>
    public static V1ResearchResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class V1ResearchResponseFromRaw : IFromRawJson<V1ResearchResponse>
{
    /// <inheritdoc/>
    public V1ResearchResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        V1ResearchResponse.FromRawUnchecked(rawData);
}
