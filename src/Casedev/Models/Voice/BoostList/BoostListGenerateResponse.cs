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
    typeof(JsonModelConverter<BoostListGenerateResponse, BoostListGenerateResponseFromRaw>)
)]
public sealed record class BoostListGenerateResponse : JsonModel
{
    public IReadOnlyList<BoostListGenerateResponseItem>? Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<BoostListGenerateResponseItem>>(
                "items"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<BoostListGenerateResponseItem>?>(
                "items",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public ApiEnum<string, BoostListGenerateResponseSource>? Source
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, BoostListGenerateResponseSource>>(
                "source"
            );
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

    public BoostListGenerateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BoostListGenerateResponse(BoostListGenerateResponse boostListGenerateResponse)
        : base(boostListGenerateResponse) { }
#pragma warning restore CS8618

    public BoostListGenerateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BoostListGenerateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BoostListGenerateResponseFromRaw.FromRawUnchecked"/>
    public static BoostListGenerateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BoostListGenerateResponseFromRaw : IFromRawJson<BoostListGenerateResponse>
{
    /// <inheritdoc/>
    public BoostListGenerateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BoostListGenerateResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<BoostListGenerateResponseItem, BoostListGenerateResponseItemFromRaw>)
)]
public sealed record class BoostListGenerateResponseItem : JsonModel
{
    public ApiEnum<string, BoostListGenerateResponseItemBoostParam>? BoostParam
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, BoostListGenerateResponseItemBoostParam>
            >("boost_param");
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

    public BoostListGenerateResponseItem() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BoostListGenerateResponseItem(
        BoostListGenerateResponseItem boostListGenerateResponseItem
    )
        : base(boostListGenerateResponseItem) { }
#pragma warning restore CS8618

    public BoostListGenerateResponseItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BoostListGenerateResponseItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BoostListGenerateResponseItemFromRaw.FromRawUnchecked"/>
    public static BoostListGenerateResponseItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BoostListGenerateResponseItemFromRaw : IFromRawJson<BoostListGenerateResponseItem>
{
    /// <inheritdoc/>
    public BoostListGenerateResponseItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BoostListGenerateResponseItem.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BoostListGenerateResponseItemBoostParamConverter))]
public enum BoostListGenerateResponseItemBoostParam
{
    Low,
    Default,
    High,
}

sealed class BoostListGenerateResponseItemBoostParamConverter
    : JsonConverter<BoostListGenerateResponseItemBoostParam>
{
    public override BoostListGenerateResponseItemBoostParam Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "low" => BoostListGenerateResponseItemBoostParam.Low,
            "default" => BoostListGenerateResponseItemBoostParam.Default,
            "high" => BoostListGenerateResponseItemBoostParam.High,
            _ => (BoostListGenerateResponseItemBoostParam)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BoostListGenerateResponseItemBoostParam value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BoostListGenerateResponseItemBoostParam.Low => "low",
                BoostListGenerateResponseItemBoostParam.Default => "default",
                BoostListGenerateResponseItemBoostParam.High => "high",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(BoostListGenerateResponseSourceConverter))]
public enum BoostListGenerateResponseSource
{
    Transcript,
}

sealed class BoostListGenerateResponseSourceConverter
    : JsonConverter<BoostListGenerateResponseSource>
{
    public override BoostListGenerateResponseSource Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "transcript" => BoostListGenerateResponseSource.Transcript,
            _ => (BoostListGenerateResponseSource)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BoostListGenerateResponseSource value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BoostListGenerateResponseSource.Transcript => "transcript",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
