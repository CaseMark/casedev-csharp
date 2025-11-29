using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;

namespace CaseDev.Models.Search.V1;

[JsonConverter(typeof(ModelConverter<V1AnswerResponse, V1AnswerResponseFromRaw>))]
public sealed record class V1AnswerResponse : ModelBase
{
    /// <summary>
    /// The generated answer with citations
    /// </summary>
    public string? Answer
    {
        get
        {
            if (!this._rawData.TryGetValue("answer", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["answer"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Sources used to generate the answer
    /// </summary>
    public IReadOnlyList<Citation>? Citations
    {
        get
        {
            if (!this._rawData.TryGetValue("citations", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<Citation>?>(
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

            this._rawData["citations"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Model used for answer generation
    /// </summary>
    public string? Model
    {
        get
        {
            if (!this._rawData.TryGetValue("model", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["model"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Type of search performed
    /// </summary>
    public string? SearchType
    {
        get
        {
            if (!this._rawData.TryGetValue("searchType", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["searchType"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Answer;
        foreach (var item in this.Citations ?? [])
        {
            item.Validate();
        }
        _ = this.Model;
        _ = this.SearchType;
    }

    public V1AnswerResponse() { }

    public V1AnswerResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1AnswerResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static V1AnswerResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class V1AnswerResponseFromRaw : IFromRaw<V1AnswerResponse>
{
    public V1AnswerResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        V1AnswerResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<Citation, CitationFromRaw>))]
public sealed record class Citation : ModelBase
{
    public string? ID
    {
        get
        {
            if (!this._rawData.TryGetValue("id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? PublishedDate
    {
        get
        {
            if (!this._rawData.TryGetValue("publishedDate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
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

    public string? Text
    {
        get
        {
            if (!this._rawData.TryGetValue("text", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["text"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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
        _ = this.ID;
        _ = this.PublishedDate;
        _ = this.Text;
        _ = this.Title;
        _ = this.URL;
    }

    public Citation() { }

    public Citation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Citation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Citation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CitationFromRaw : IFromRaw<Citation>
{
    public Citation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Citation.FromRawUnchecked(rawData);
}
