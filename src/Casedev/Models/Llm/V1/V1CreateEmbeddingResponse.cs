using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Casedev.Core;

namespace Casedev.Models.Llm.V1;

[JsonConverter(
    typeof(JsonModelConverter<V1CreateEmbeddingResponse, V1CreateEmbeddingResponseFromRaw>)
)]
public sealed record class V1CreateEmbeddingResponse : JsonModel
{
    public IReadOnlyList<Data>? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Data>>("data");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Data>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

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

    public V1CreateEmbeddingResponseUsage? Usage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<V1CreateEmbeddingResponseUsage>("usage");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("usage", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data ?? [])
        {
            item.Validate();
        }
        _ = this.Model;
        _ = this.Object;
        this.Usage?.Validate();
    }

    public V1CreateEmbeddingResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public V1CreateEmbeddingResponse(V1CreateEmbeddingResponse v1CreateEmbeddingResponse)
        : base(v1CreateEmbeddingResponse) { }
#pragma warning restore CS8618

    public V1CreateEmbeddingResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1CreateEmbeddingResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="V1CreateEmbeddingResponseFromRaw.FromRawUnchecked"/>
    public static V1CreateEmbeddingResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class V1CreateEmbeddingResponseFromRaw : IFromRawJson<V1CreateEmbeddingResponse>
{
    /// <inheritdoc/>
    public V1CreateEmbeddingResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => V1CreateEmbeddingResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    public IReadOnlyList<double>? Embedding
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<double>>("embedding");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<double>?>(
                "embedding",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public long? Index
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("index");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("index", value);
        }
    }

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
        _ = this.Embedding;
        _ = this.Index;
        _ = this.Object;
    }

    public Data() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Data(Data data)
        : base(data) { }
#pragma warning restore CS8618

    public Data(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Data(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DataFromRaw.FromRawUnchecked"/>
    public static Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DataFromRaw : IFromRawJson<Data>
{
    /// <inheritdoc/>
    public Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Data.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        V1CreateEmbeddingResponseUsage,
        V1CreateEmbeddingResponseUsageFromRaw
    >)
)]
public sealed record class V1CreateEmbeddingResponseUsage : JsonModel
{
    public long? PromptTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("prompt_tokens");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("prompt_tokens", value);
        }
    }

    public long? TotalTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("total_tokens");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("total_tokens", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PromptTokens;
        _ = this.TotalTokens;
    }

    public V1CreateEmbeddingResponseUsage() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public V1CreateEmbeddingResponseUsage(
        V1CreateEmbeddingResponseUsage v1CreateEmbeddingResponseUsage
    )
        : base(v1CreateEmbeddingResponseUsage) { }
#pragma warning restore CS8618

    public V1CreateEmbeddingResponseUsage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1CreateEmbeddingResponseUsage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="V1CreateEmbeddingResponseUsageFromRaw.FromRawUnchecked"/>
    public static V1CreateEmbeddingResponseUsage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class V1CreateEmbeddingResponseUsageFromRaw : IFromRawJson<V1CreateEmbeddingResponseUsage>
{
    /// <inheritdoc/>
    public V1CreateEmbeddingResponseUsage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => V1CreateEmbeddingResponseUsage.FromRawUnchecked(rawData);
}
