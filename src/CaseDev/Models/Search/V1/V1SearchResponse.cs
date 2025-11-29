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
        get
        {
            if (!this._rawData.TryGetValue("query", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["query"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Array of search results
    /// </summary>
    public IReadOnlyList<ResultModel>? Results
    {
        get
        {
            if (!this._rawData.TryGetValue("results", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<ResultModel>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["results"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
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
            if (!this._rawData.TryGetValue("totalResults", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["totalResults"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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

    public static V1SearchResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class V1SearchResponseFromRaw : IFromRaw<V1SearchResponse>
{
    public V1SearchResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        V1SearchResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<ResultModel, ResultModelFromRaw>))]
public sealed record class ResultModel : ModelBase
{
    /// <summary>
    /// Domain of the source
    /// </summary>
    public string? Domain
    {
        get
        {
            if (!this._rawData.TryGetValue("domain", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["domain"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Publication date of the content
    /// </summary>
    public DateTimeOffset? PublishedDate
    {
        get
        {
            if (!this._rawData.TryGetValue("publishedDate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTimeOffset?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["publishedDate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Brief excerpt from the content
    /// </summary>
    public string? Snippet
    {
        get
        {
            if (!this._rawData.TryGetValue("snippet", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["snippet"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Title of the search result
    /// </summary>
    public string? Title
    {
        get
        {
            if (!this._rawData.TryGetValue("title", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["title"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// URL of the search result
    /// </summary>
    public string? URL
    {
        get
        {
            if (!this._rawData.TryGetValue("url", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["url"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Domain;
        _ = this.PublishedDate;
        _ = this.Snippet;
        _ = this.Title;
        _ = this.URL;
    }

    public ResultModel() { }

    public ResultModel(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ResultModel(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static ResultModel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ResultModelFromRaw : IFromRaw<ResultModel>
{
    public ResultModel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ResultModel.FromRawUnchecked(rawData);
}
