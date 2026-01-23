using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;

namespace CaseDev.Models.Search.V1;

[JsonConverter(typeof(JsonModelConverter<V1SimilarResponse, V1SimilarResponseFromRaw>))]
public sealed record class V1SimilarResponse : JsonModel
{
    public double? ProcessingTime
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("processingTime");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("processingTime", value);
        }
    }

    public IReadOnlyList<V1SimilarResponseResult>? Results
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<V1SimilarResponseResult>>(
                "results"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<V1SimilarResponseResult>?>(
                "results",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public long? TotalResults
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("totalResults");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("totalResults", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ProcessingTime;
        foreach (var item in this.Results ?? [])
        {
            item.Validate();
        }
        _ = this.TotalResults;
    }

    public V1SimilarResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public V1SimilarResponse(V1SimilarResponse v1SimilarResponse)
        : base(v1SimilarResponse) { }
#pragma warning restore CS8618

    public V1SimilarResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1SimilarResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="V1SimilarResponseFromRaw.FromRawUnchecked"/>
    public static V1SimilarResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class V1SimilarResponseFromRaw : IFromRawJson<V1SimilarResponse>
{
    /// <inheritdoc/>
    public V1SimilarResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        V1SimilarResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<V1SimilarResponseResult, V1SimilarResponseResultFromRaw>))]
public sealed record class V1SimilarResponseResult : JsonModel
{
    public string? Domain
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("domain");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("domain", value);
        }
    }

    public string? PublishedDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("publishedDate");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("publishedDate", value);
        }
    }

    public double? SimilarityScore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("similarityScore");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("similarityScore", value);
        }
    }

    public string? Snippet
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("snippet");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("snippet", value);
        }
    }

    public string? Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("text");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("text", value);
        }
    }

    public string? Title
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("title");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("title", value);
        }
    }

    public string? Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("url");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("url", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Domain;
        _ = this.PublishedDate;
        _ = this.SimilarityScore;
        _ = this.Snippet;
        _ = this.Text;
        _ = this.Title;
        _ = this.Url;
    }

    public V1SimilarResponseResult() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public V1SimilarResponseResult(V1SimilarResponseResult v1SimilarResponseResult)
        : base(v1SimilarResponseResult) { }
#pragma warning restore CS8618

    public V1SimilarResponseResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1SimilarResponseResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="V1SimilarResponseResultFromRaw.FromRawUnchecked"/>
    public static V1SimilarResponseResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class V1SimilarResponseResultFromRaw : IFromRawJson<V1SimilarResponseResult>
{
    /// <inheritdoc/>
    public V1SimilarResponseResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => V1SimilarResponseResult.FromRawUnchecked(rawData);
}
