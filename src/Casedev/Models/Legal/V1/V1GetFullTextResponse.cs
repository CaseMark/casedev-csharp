using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Casedev.Core;

namespace Casedev.Models.Legal.V1;

[JsonConverter(typeof(JsonModelConverter<V1GetFullTextResponse, V1GetFullTextResponseFromRaw>))]
public sealed record class V1GetFullTextResponse : JsonModel
{
    /// <summary>
    /// Author or court
    /// </summary>
    public string? Author
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("author");
        }
        init { this._rawData.Set("author", value); }
    }

    /// <summary>
    /// Total characters in text
    /// </summary>
    public long? CharacterCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("characterCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("characterCount", value);
        }
    }

    /// <summary>
    /// Highlighted relevant passages
    /// </summary>
    public IReadOnlyList<string>? Highlights
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("highlights");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "highlights",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Publication date
    /// </summary>
    public string? PublishedDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("publishedDate");
        }
        init { this._rawData.Set("publishedDate", value); }
    }

    /// <summary>
    /// AI-generated summary
    /// </summary>
    public string? Summary
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("summary");
        }
        init { this._rawData.Set("summary", value); }
    }

    /// <summary>
    /// Full document text
    /// </summary>
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

    /// <summary>
    /// Document title
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
    /// Document URL
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
        _ = this.Author;
        _ = this.CharacterCount;
        _ = this.Highlights;
        _ = this.PublishedDate;
        _ = this.Summary;
        _ = this.Text;
        _ = this.Title;
        _ = this.Url;
    }

    public V1GetFullTextResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public V1GetFullTextResponse(V1GetFullTextResponse v1GetFullTextResponse)
        : base(v1GetFullTextResponse) { }
#pragma warning restore CS8618

    public V1GetFullTextResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1GetFullTextResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="V1GetFullTextResponseFromRaw.FromRawUnchecked"/>
    public static V1GetFullTextResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class V1GetFullTextResponseFromRaw : IFromRawJson<V1GetFullTextResponse>
{
    /// <inheritdoc/>
    public V1GetFullTextResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => V1GetFullTextResponse.FromRawUnchecked(rawData);
}
