using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Casedev.Core;
using Casedev.Exceptions;

namespace Casedev.Models.Privilege.V1;

[JsonConverter(typeof(JsonModelConverter<V1DetectResponse, V1DetectResponseFromRaw>))]
public sealed record class V1DetectResponse : JsonModel
{
    public required IReadOnlyList<V1DetectResponseCategory> Categories
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<V1DetectResponseCategory>>(
                "categories"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<V1DetectResponseCategory>>(
                "categories",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Overall confidence score (0-1)
    /// </summary>
    public required double Confidence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("confidence");
        }
        init { this._rawData.Set("confidence", value); }
    }

    /// <summary>
    /// Policy-friendly explanation for privilege log
    /// </summary>
    public required string PolicyRationale
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("policy_rationale");
        }
        init { this._rawData.Set("policy_rationale", value); }
    }

    /// <summary>
    /// Whether any privilege was detected
    /// </summary>
    public required bool Privileged
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("privileged");
        }
        init { this._rawData.Set("privileged", value); }
    }

    /// <summary>
    /// Recommended action for discovery
    /// </summary>
    public required ApiEnum<string, Recommendation> Recommendation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Recommendation>>("recommendation");
        }
        init { this._rawData.Set("recommendation", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Categories)
        {
            item.Validate();
        }
        _ = this.Confidence;
        _ = this.PolicyRationale;
        _ = this.Privileged;
        this.Recommendation.Validate();
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

[JsonConverter(
    typeof(JsonModelConverter<V1DetectResponseCategory, V1DetectResponseCategoryFromRaw>)
)]
public sealed record class V1DetectResponseCategory : JsonModel
{
    /// <summary>
    /// Confidence for this category (0-1)
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
    /// Whether this privilege type was detected
    /// </summary>
    public bool? Detected
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("detected");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("detected", value);
        }
    }

    /// <summary>
    /// Specific phrases or patterns found
    /// </summary>
    public IReadOnlyList<string>? Indicators
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("indicators");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "indicators",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Explanation of detection result
    /// </summary>
    public string? Rationale
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("rationale");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("rationale", value);
        }
    }

    /// <summary>
    /// Privilege category
    /// </summary>
    public string? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Confidence;
        _ = this.Detected;
        _ = this.Indicators;
        _ = this.Rationale;
        _ = this.Type;
    }

    public V1DetectResponseCategory() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public V1DetectResponseCategory(V1DetectResponseCategory v1DetectResponseCategory)
        : base(v1DetectResponseCategory) { }
#pragma warning restore CS8618

    public V1DetectResponseCategory(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1DetectResponseCategory(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="V1DetectResponseCategoryFromRaw.FromRawUnchecked"/>
    public static V1DetectResponseCategory FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class V1DetectResponseCategoryFromRaw : IFromRawJson<V1DetectResponseCategory>
{
    /// <inheritdoc/>
    public V1DetectResponseCategory FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => V1DetectResponseCategory.FromRawUnchecked(rawData);
}

/// <summary>
/// Recommended action for discovery
/// </summary>
[JsonConverter(typeof(RecommendationConverter))]
public enum Recommendation
{
    Withhold,
    Redact,
    Produce,
    Review,
}

sealed class RecommendationConverter : JsonConverter<Recommendation>
{
    public override Recommendation Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "withhold" => Recommendation.Withhold,
            "redact" => Recommendation.Redact,
            "produce" => Recommendation.Produce,
            "review" => Recommendation.Review,
            _ => (Recommendation)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Recommendation value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Recommendation.Withhold => "withhold",
                Recommendation.Redact => "redact",
                Recommendation.Produce => "produce",
                Recommendation.Review => "review",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
