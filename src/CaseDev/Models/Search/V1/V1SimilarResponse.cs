using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;

namespace CaseDev.Models.Search.V1;

[JsonConverter(typeof(ModelConverter<V1SimilarResponse, V1SimilarResponseFromRaw>))]
public sealed record class V1SimilarResponse : ModelBase
{
    public double? ProcessingTime
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawData, "processingTime"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "processingTime", value);
        }
    }

    public IReadOnlyList<V1SimilarResponseResult>? Results
    {
        get
        {
            return ModelBase.GetNullableClass<List<V1SimilarResponseResult>>(
                this.RawData,
                "results"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "results", value);
        }
    }

    public long? TotalResults
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "totalResults"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "totalResults", value);
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

    public V1SimilarResponse(V1SimilarResponse v1SimilarResponse)
        : base(v1SimilarResponse) { }

    public V1SimilarResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1SimilarResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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

class V1SimilarResponseFromRaw : IFromRaw<V1SimilarResponse>
{
    /// <inheritdoc/>
    public V1SimilarResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        V1SimilarResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<V1SimilarResponseResult, V1SimilarResponseResultFromRaw>))]
public sealed record class V1SimilarResponseResult : ModelBase
{
    public string? Domain
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "domain"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "domain", value);
        }
    }

    public string? PublishedDate
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "publishedDate"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "publishedDate", value);
        }
    }

    public double? SimilarityScore
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawData, "similarityScore"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "similarityScore", value);
        }
    }

    public string? Snippet
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "snippet"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "snippet", value);
        }
    }

    public string? Text
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "text"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "text", value);
        }
    }

    public string? Title
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "title"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "title", value);
        }
    }

    public string? URL
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "url"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "url", value);
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
        _ = this.URL;
    }

    public V1SimilarResponseResult() { }

    public V1SimilarResponseResult(V1SimilarResponseResult v1SimilarResponseResult)
        : base(v1SimilarResponseResult) { }

    public V1SimilarResponseResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1SimilarResponseResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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

class V1SimilarResponseResultFromRaw : IFromRaw<V1SimilarResponseResult>
{
    /// <inheritdoc/>
    public V1SimilarResponseResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => V1SimilarResponseResult.FromRawUnchecked(rawData);
}
