using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;

namespace CaseDev.Models.Search.V1;

[JsonConverter(typeof(JsonModelConverter<V1AnswerResponse, V1AnswerResponseFromRaw>))]
public sealed record class V1AnswerResponse : JsonModel
{
    /// <summary>
    /// The generated answer with citations
    /// </summary>
    public string? Answer
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "answer"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "answer", value);
        }
    }

    /// <summary>
    /// Sources used to generate the answer
    /// </summary>
    public IReadOnlyList<Citation>? Citations
    {
        get { return JsonModel.GetNullableClass<List<Citation>>(this.RawData, "citations"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "citations", value);
        }
    }

    /// <summary>
    /// Model used for answer generation
    /// </summary>
    public string? Model
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "model"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "model", value);
        }
    }

    /// <summary>
    /// Type of search performed
    /// </summary>
    public string? SearchType
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "searchType"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "searchType", value);
        }
    }

    /// <inheritdoc/>
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

    public V1AnswerResponse(V1AnswerResponse v1AnswerResponse)
        : base(v1AnswerResponse) { }

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

    /// <inheritdoc cref="V1AnswerResponseFromRaw.FromRawUnchecked"/>
    public static V1AnswerResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class V1AnswerResponseFromRaw : IFromRawJson<V1AnswerResponse>
{
    /// <inheritdoc/>
    public V1AnswerResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        V1AnswerResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Citation, CitationFromRaw>))]
public sealed record class Citation : JsonModel
{
    public string? ID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "id"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "id", value);
        }
    }

    public string? PublishedDate
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "publishedDate"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "publishedDate", value);
        }
    }

    public string? Text
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "text"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "text", value);
        }
    }

    public string? Title
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "title"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "title", value);
        }
    }

    public string? URL
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "url"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "url", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.PublishedDate;
        _ = this.Text;
        _ = this.Title;
        _ = this.URL;
    }

    public Citation() { }

    public Citation(Citation citation)
        : base(citation) { }

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

    /// <inheritdoc cref="CitationFromRaw.FromRawUnchecked"/>
    public static Citation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CitationFromRaw : IFromRawJson<Citation>
{
    /// <inheritdoc/>
    public Citation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Citation.FromRawUnchecked(rawData);
}
