using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Router.Core;

namespace Router.Models.Translate.V1;

[JsonConverter(typeof(JsonModelConverter<V1DetectResponse, V1DetectResponseFromRaw>))]
public sealed record class V1DetectResponse : JsonModel
{
    public Data? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Data>("data");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("data", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data?.Validate();
    }

    public V1DetectResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public V1DetectResponse(V1DetectResponse v1DetectResponse)
        : base(v1DetectResponse) { }
#pragma warning restore CS8618

    public V1DetectResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1DetectResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="V1DetectResponseFromRaw.FromRawUnchecked"/>
    public static V1DetectResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class V1DetectResponseFromRaw : IFromRawJson<V1DetectResponse>
{
    /// <inheritdoc/>
    public V1DetectResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        V1DetectResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    public IReadOnlyList<IReadOnlyList<UnnamedSchemaWithArrayParent0>>? Detections
    {
        get
        {
            this._rawData.Freeze();
            var value = this._rawData.GetNullableStruct<
                ImmutableArray<ImmutableArray<UnnamedSchemaWithArrayParent0>>
            >("detections");
            if (value == null)
            {
                return null;
            }

            return ImmutableArray.ToImmutableArray(
                Enumerable.Select(
                    value.Value,
                    (item) => (IReadOnlyList<UnnamedSchemaWithArrayParent0>)item
                )
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ImmutableArray<UnnamedSchemaWithArrayParent0>>?>(
                "detections",
                value == null
                    ? null
                    : ImmutableArray.ToImmutableArray(
                        Enumerable.Select(value, (item) => ImmutableArray.ToImmutableArray(item))
                    )
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Detections ?? [])
        {
            foreach (var item1 in item)
            {
                item1.Validate();
            }
        }
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
    typeof(JsonModelConverter<UnnamedSchemaWithArrayParent0, UnnamedSchemaWithArrayParent0FromRaw>)
)]
public sealed record class UnnamedSchemaWithArrayParent0 : JsonModel
{
    /// <summary>
    /// Confidence score (0-1)
    /// </summary>
    public double? Confidence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("confidence");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("confidence", value);
        }
    }

    /// <summary>
    /// Whether the detection is reliable
    /// </summary>
    public bool? IsReliable
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isReliable");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isReliable", value);
        }
    }

    /// <summary>
    /// Detected language code (ISO 639-1)
    /// </summary>
    public string? Language
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("language");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("language", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Confidence;
        _ = this.IsReliable;
        _ = this.Language;
    }

    public UnnamedSchemaWithArrayParent0() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UnnamedSchemaWithArrayParent0(
        UnnamedSchemaWithArrayParent0 unnamedSchemaWithArrayParent0
    )
        : base(unnamedSchemaWithArrayParent0) { }
#pragma warning restore CS8618

    public UnnamedSchemaWithArrayParent0(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnnamedSchemaWithArrayParent0(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UnnamedSchemaWithArrayParent0FromRaw.FromRawUnchecked"/>
    public static UnnamedSchemaWithArrayParent0 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UnnamedSchemaWithArrayParent0FromRaw : IFromRawJson<UnnamedSchemaWithArrayParent0>
{
    /// <inheritdoc/>
    public UnnamedSchemaWithArrayParent0 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UnnamedSchemaWithArrayParent0.FromRawUnchecked(rawData);
}
