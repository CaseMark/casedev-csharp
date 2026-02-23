using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Router.Core;

namespace Router.Models.Search.V1;

[JsonConverter(typeof(JsonModelConverter<V1SearchResponse, V1SearchResponseFromRaw>))]
public sealed record class V1SearchResponse : JsonModel
{
    /// <summary>
    /// Original search query
    /// </summary>
    public string? Query
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("query");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("query", value);
        }
    }

    /// <summary>
    /// Array of search results
    /// </summary>
    public IReadOnlyList<V1SearchResponseResult>? Results
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<V1SearchResponseResult>>(
                "results"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<V1SearchResponseResult>?>(
                "results",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Total number of results found
    /// </summary>
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
        _ = this.Query;
        foreach (var item in this.Results ?? [])
        {
            item.Validate();
        }
        _ = this.TotalResults;
    }

    public V1SearchResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public V1SearchResponse(V1SearchResponse v1SearchResponse)
        : base(v1SearchResponse) { }
#pragma warning restore CS8618

    public V1SearchResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1SearchResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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

class V1SearchResponseFromRaw : IFromRawJson<V1SearchResponse>
{
    /// <inheritdoc/>
    public V1SearchResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        V1SearchResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<V1SearchResponseResult, V1SearchResponseResultFromRaw>))]
public sealed record class V1SearchResponseResult : JsonModel
{
    /// <summary>
    /// Domain of the source
    /// </summary>
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

    /// <summary>
    /// Publication date of the content
    /// </summary>
    public DateTimeOffset? PublishedDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("publishedDate");
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

    /// <summary>
    /// Brief excerpt from the content
    /// </summary>
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

    /// <summary>
    /// Title of the search result
    /// </summary>
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

    /// <summary>
    /// URL of the search result
    /// </summary>
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
        _ = this.Snippet;
        _ = this.Title;
        _ = this.Url;
    }

    public V1SearchResponseResult() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public V1SearchResponseResult(V1SearchResponseResult v1SearchResponseResult)
        : base(v1SearchResponseResult) { }
#pragma warning restore CS8618

    public V1SearchResponseResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1SearchResponseResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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

class V1SearchResponseResultFromRaw : IFromRawJson<V1SearchResponseResult>
{
    /// <inheritdoc/>
    public V1SearchResponseResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => V1SearchResponseResult.FromRawUnchecked(rawData);
}
