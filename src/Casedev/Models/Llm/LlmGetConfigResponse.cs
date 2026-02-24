using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Casedev.Core;

namespace Casedev.Models.Llm;

[JsonConverter(typeof(JsonModelConverter<LlmGetConfigResponse, LlmGetConfigResponseFromRaw>))]
public sealed record class LlmGetConfigResponse : JsonModel
{
    public required IReadOnlyList<Model> Models
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Model>>("models");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Model>>(
                "models",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Models)
        {
            item.Validate();
        }
    }

    public LlmGetConfigResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public LlmGetConfigResponse(LlmGetConfigResponse llmGetConfigResponse)
        : base(llmGetConfigResponse) { }
#pragma warning restore CS8618

    public LlmGetConfigResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LlmGetConfigResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LlmGetConfigResponseFromRaw.FromRawUnchecked"/>
    public static LlmGetConfigResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public LlmGetConfigResponse(IReadOnlyList<Model> models)
        : this()
    {
        this.Models = models;
    }
}

class LlmGetConfigResponseFromRaw : IFromRawJson<LlmGetConfigResponse>
{
    /// <inheritdoc/>
    public LlmGetConfigResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => LlmGetConfigResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Model, ModelFromRaw>))]
public sealed record class Model : JsonModel
{
    /// <summary>
    /// Unique model identifier
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Type of model (e.g., language, embedding)
    /// </summary>
    public required string ModelType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("modelType");
        }
        init { this._rawData.Set("modelType", value); }
    }

    /// <summary>
    /// Human-readable model name
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Model description and capabilities
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    /// <summary>
    /// Pricing information for the model
    /// </summary>
    public JsonElement? Pricing
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("pricing");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("pricing", value);
        }
    }

    /// <summary>
    /// Technical specifications and limits
    /// </summary>
    public JsonElement? Specification
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("specification");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("specification", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.ModelType;
        _ = this.Name;
        _ = this.Description;
        _ = this.Pricing;
        _ = this.Specification;
    }

    public Model() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Model(Model model)
        : base(model) { }
#pragma warning restore CS8618

    public Model(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Model(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ModelFromRaw.FromRawUnchecked"/>
    public static Model FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ModelFromRaw : IFromRawJson<Model>
{
    /// <inheritdoc/>
    public Model FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Model.FromRawUnchecked(rawData);
}
