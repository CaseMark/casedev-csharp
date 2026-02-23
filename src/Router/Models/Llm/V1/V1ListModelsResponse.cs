using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Router.Core;

namespace Router.Models.Llm.V1;

[JsonConverter(typeof(JsonModelConverter<V1ListModelsResponse, V1ListModelsResponseFromRaw>))]
public sealed record class V1ListModelsResponse : JsonModel
{
    public IReadOnlyList<V1ListModelsResponseData>? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<V1ListModelsResponseData>>(
                "data"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<V1ListModelsResponseData>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Response object type, always 'list'
    /// </summary>
    public string? Object
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("object");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("object", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data ?? [])
        {
            item.Validate();
        }
        _ = this.Object;
    }

    public V1ListModelsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public V1ListModelsResponse(V1ListModelsResponse v1ListModelsResponse)
        : base(v1ListModelsResponse) { }
#pragma warning restore CS8618

    public V1ListModelsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1ListModelsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="V1ListModelsResponseFromRaw.FromRawUnchecked"/>
    public static V1ListModelsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class V1ListModelsResponseFromRaw : IFromRawJson<V1ListModelsResponse>
{
    /// <inheritdoc/>
    public V1ListModelsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => V1ListModelsResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<V1ListModelsResponseData, V1ListModelsResponseDataFromRaw>)
)]
public sealed record class V1ListModelsResponseData : JsonModel
{
    /// <summary>
    /// Unique model identifier
    /// </summary>
    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    /// <summary>
    /// Unix timestamp of model creation
    /// </summary>
    public long? Created
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("created");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("created", value);
        }
    }

    /// <summary>
    /// Object type, always 'model'
    /// </summary>
    public string? Object
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("object");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("object", value);
        }
    }

    /// <summary>
    /// Model provider (openai, anthropic, google, casemark, etc.)
    /// </summary>
    public string? OwnedBy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("owned_by");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("owned_by", value);
        }
    }

    public Pricing? Pricing
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Pricing>("pricing");
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Created;
        _ = this.Object;
        _ = this.OwnedBy;
        this.Pricing?.Validate();
    }

    public V1ListModelsResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public V1ListModelsResponseData(V1ListModelsResponseData v1ListModelsResponseData)
        : base(v1ListModelsResponseData) { }
#pragma warning restore CS8618

    public V1ListModelsResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1ListModelsResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="V1ListModelsResponseDataFromRaw.FromRawUnchecked"/>
    public static V1ListModelsResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class V1ListModelsResponseDataFromRaw : IFromRawJson<V1ListModelsResponseData>
{
    /// <inheritdoc/>
    public V1ListModelsResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => V1ListModelsResponseData.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Pricing, PricingFromRaw>))]
public sealed record class Pricing : JsonModel
{
    /// <summary>
    /// Input token price per token
    /// </summary>
    public string? Input
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("input");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("input", value);
        }
    }

    /// <summary>
    /// Cache read price per token (if supported)
    /// </summary>
    public string? InputCacheRead
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("input_cache_read");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("input_cache_read", value);
        }
    }

    /// <summary>
    /// Output token price per token
    /// </summary>
    public string? Output
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("output");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("output", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Input;
        _ = this.InputCacheRead;
        _ = this.Output;
    }

    public Pricing() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Pricing(Pricing pricing)
        : base(pricing) { }
#pragma warning restore CS8618

    public Pricing(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Pricing(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PricingFromRaw.FromRawUnchecked"/>
    public static Pricing FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PricingFromRaw : IFromRawJson<Pricing>
{
    /// <inheritdoc/>
    public Pricing FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Pricing.FromRawUnchecked(rawData);
}
