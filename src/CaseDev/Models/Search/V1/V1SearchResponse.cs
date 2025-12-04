using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;

namespace CaseDev.Models.Search.V1;

[JsonConverter(typeof(ModelConverter<V1SearchResponse, V1SearchResponseFromRaw>))]
public sealed record class V1SearchResponse : ModelBase
{
    /// <summary>
    /// Original search query
    /// </summary>
    public string? Query
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "query"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "query", value);
        }
    }

    /// <summary>
    /// Array of search results
    /// </summary>
    public IReadOnlyList<V1SearchResponseResult>? Results
    {
        get
        {
            return ModelBase.GetNullableClass<List<V1SearchResponseResult>>(
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

    /// <summary>
    /// Total number of results found
    /// </summary>
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
        _ = this.Query;
        foreach (var item in this.Results ?? [])
        {
            item.Validate();
        }
        _ = this.TotalResults;
    }

    public V1SearchResponse() { }

    public V1SearchResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1SearchResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="V1SearchResponseFromRaw.FromRawUnchecked"/>
    public static V1SearchResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class V1SearchResponseFromRaw : IFromRaw<V1SearchResponse>
{
    /// <inheritdoc/>
    public V1SearchResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        V1SearchResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<V1SearchResponseResult, V1SearchResponseResultFromRaw>))]
public sealed record class V1SearchResponseResult : ModelBase
{
    /// <summary>
    /// Domain of the source
    /// </summary>
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

    /// <summary>
    /// Publication date of the content
    /// </summary>
    public DateTimeOffset? PublishedDate
    {
        get { return ModelBase.GetNullableStruct<DateTimeOffset>(this.RawData, "publishedDate"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "publishedDate", value);
        }
    }

    /// <summary>
    /// Brief excerpt from the content
    /// </summary>
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

    /// <summary>
    /// Title of the search result
    /// </summary>
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

    /// <summary>
    /// URL of the search result
    /// </summary>
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
        _ = this.Snippet;
        _ = this.Title;
        _ = this.URL;
    }

    public V1SearchResponseResult() { }

    public V1SearchResponseResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1SearchResponseResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="V1SearchResponseResultFromRaw.FromRawUnchecked"/>
    public static V1SearchResponseResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class V1SearchResponseResultFromRaw : IFromRaw<V1SearchResponseResult>
{
    /// <inheritdoc/>
    public V1SearchResponseResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => V1SearchResponseResult.FromRawUnchecked(rawData);
}
