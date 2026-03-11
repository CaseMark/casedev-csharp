using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Casedev.Core;
using Casedev.Exceptions;

namespace Casedev.Models.Voice.BoostList;

[JsonConverter(
    typeof(JsonModelConverter<BoostListExtractResponse, BoostListExtractResponseFromRaw>)
)]
public sealed record class BoostListExtractResponse : JsonModel
{
    public IReadOnlyList<Item>? Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Item>>("items");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Item>?>(
                "items",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public ApiEnum<string, Source>? Source
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Source>>("source");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("source", value);
        }
    }

    public IReadOnlyList<string>? SourceIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("source_ids");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "source_ids",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Items ?? [])
        {
            item.Validate();
        }
        this.Source?.Validate();
        _ = this.SourceIds;
    }

    public BoostListExtractResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BoostListExtractResponse(BoostListExtractResponse boostListExtractResponse)
        : base(boostListExtractResponse) { }
#pragma warning restore CS8618

    public BoostListExtractResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BoostListExtractResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BoostListExtractResponseFromRaw.FromRawUnchecked"/>
    public static BoostListExtractResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BoostListExtractResponseFromRaw : IFromRawJson<BoostListExtractResponse>
{
    /// <inheritdoc/>
    public BoostListExtractResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BoostListExtractResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Item, ItemFromRaw>))]
public sealed record class Item : JsonModel
{
    public ApiEnum<string, BoostParam>? BoostParam
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, BoostParam>>("boost_param");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("boost_param", value);
        }
    }

    public string? Category
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("category");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("category", value);
        }
    }

    public string? Word
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("word");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("word", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.BoostParam?.Validate();
        _ = this.Category;
        _ = this.Word;
    }

    public Item() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Item(Item item)
        : base(item) { }
#pragma warning restore CS8618

    public Item(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Item(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ItemFromRaw.FromRawUnchecked"/>
    public static Item FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ItemFromRaw : IFromRawJson<Item>
{
    /// <inheritdoc/>
    public Item FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Item.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BoostParamConverter))]
public enum BoostParam
{
    Low,
    Default,
    High,
}

sealed class BoostParamConverter : JsonConverter<BoostParam>
{
    public override BoostParam Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "low" => BoostParam.Low,
            "default" => BoostParam.Default,
            "high" => BoostParam.High,
            _ => (BoostParam)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BoostParam value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BoostParam.Low => "low",
                BoostParam.Default => "default",
                BoostParam.High => "high",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(SourceConverter))]
public enum Source
{
    Document,
    Text,
}

sealed class SourceConverter : JsonConverter<Source>
{
    public override Source Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "document" => Source.Document,
            "text" => Source.Text,
            _ => (Source)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Source value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Source.Document => "document",
                Source.Text => "text",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
