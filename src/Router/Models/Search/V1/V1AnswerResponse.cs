using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Router.Core;

namespace Router.Models.Search.V1;

[JsonConverter(typeof(JsonModelConverter<V1AnswerResponse, V1AnswerResponseFromRaw>))]
public sealed record class V1AnswerResponse : JsonModel
{
    /// <summary>
    /// The generated answer with citations
    /// </summary>
    public string? Answer
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("answer");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("answer", value);
        }
    }

    /// <summary>
    /// Sources used to generate the answer
    /// </summary>
    public IReadOnlyList<Citation>? Citations
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Citation>>("citations");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Citation>?>(
                "citations",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("model");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("model", value);
        }
    }

    /// <summary>
    /// Type of search performed
    /// </summary>
    public string? SearchType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("searchType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("searchType", value);
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public V1AnswerResponse(V1AnswerResponse v1AnswerResponse)
        : base(v1AnswerResponse) { }
#pragma warning restore CS8618

    public V1AnswerResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1AnswerResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
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
        _ = this.ID;
        _ = this.PublishedDate;
        _ = this.Text;
        _ = this.Title;
        _ = this.Url;
    }

    public Citation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Citation(Citation citation)
        : base(citation) { }
#pragma warning restore CS8618

    public Citation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Citation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
