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
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("model");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("model", value);
        }
    }

    /// <summary>
    /// Unique identifier for this research
    /// </summary>
    public string? ResearchID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("researchId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("researchId", value);
        }
    }

    /// <summary>
    /// Research findings and analysis
    /// </summary>
    public JsonElement? Results
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("results");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("results", value);
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public V1ResearchResponse(V1ResearchResponse v1ResearchResponse)
        : base(v1ResearchResponse) { }
#pragma warning restore CS8618

    public V1ResearchResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1ResearchResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
