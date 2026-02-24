using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Casedev.Core;

namespace Casedev.Models.Vault.Objects;

[JsonConverter(
    typeof(JsonModelConverter<ObjectGetOcrWordsResponse, ObjectGetOcrWordsResponseFromRaw>)
)]
public sealed record class ObjectGetOcrWordsResponse : JsonModel
{
    /// <summary>
    /// When the OCR data was extracted
    /// </summary>
    public DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("createdAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("createdAt", value);
        }
    }

    /// <summary>
    /// The object ID
    /// </summary>
    public string? ObjectID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("objectId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("objectId", value);
        }
    }

    /// <summary>
    /// Total number of pages in the document
    /// </summary>
    public long? PageCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("pageCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("pageCount", value);
        }
    }

    /// <summary>
    /// Per-page word data with bounding boxes
    /// </summary>
    public IReadOnlyList<Page>? Pages
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Page>>("pages");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Page>?>(
                "pages",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Total number of words extracted from the document
    /// </summary>
    public long? TotalWords
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("totalWords");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("totalWords", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CreatedAt;
        _ = this.ObjectID;
        _ = this.PageCount;
        foreach (var item in this.Pages ?? [])
        {
            item.Validate();
        }
        _ = this.TotalWords;
    }

    public ObjectGetOcrWordsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ObjectGetOcrWordsResponse(ObjectGetOcrWordsResponse objectGetOcrWordsResponse)
        : base(objectGetOcrWordsResponse) { }
#pragma warning restore CS8618

    public ObjectGetOcrWordsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ObjectGetOcrWordsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ObjectGetOcrWordsResponseFromRaw.FromRawUnchecked"/>
    public static ObjectGetOcrWordsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ObjectGetOcrWordsResponseFromRaw : IFromRawJson<ObjectGetOcrWordsResponse>
{
    /// <inheritdoc/>
    public ObjectGetOcrWordsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ObjectGetOcrWordsResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Page, PageFromRaw>))]
public sealed record class Page : JsonModel
{
    /// <summary>
    /// Page number (1-indexed)
    /// </summary>
    public long? PageValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("page");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("page", value);
        }
    }

    public IReadOnlyList<Word>? Words
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Word>>("words");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Word>?>(
                "words",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PageValue;
        foreach (var item in this.Words ?? [])
        {
            item.Validate();
        }
    }

    public Page() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Page(Page page)
        : base(page) { }
#pragma warning restore CS8618

    public Page(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Page(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PageFromRaw.FromRawUnchecked"/>
    public static Page FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PageFromRaw : IFromRawJson<Page>
{
    /// <inheritdoc/>
    public Page FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Page.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Word, WordFromRaw>))]
public sealed record class Word : JsonModel
{
    /// <summary>
    /// Bounding box [x0, y0, x1, y1] normalized to 0-1 range
    /// </summary>
    public IReadOnlyList<double>? Bbox
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<double>>("bbox");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<double>?>(
                "bbox",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// OCR confidence score (0-1)
    /// </summary>
    public double? Confidence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("confidence");
        }
        init { this._rawData.Set("confidence", value); }
    }

    /// <summary>
    /// The word text
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
    /// Global word index across the entire document (0-based)
    /// </summary>
    public long? WordIndex
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("wordIndex");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("wordIndex", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Bbox;
        _ = this.Confidence;
        _ = this.Text;
        _ = this.WordIndex;
    }

    public Word() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Word(Word word)
        : base(word) { }
#pragma warning restore CS8618

    public Word(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Word(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WordFromRaw.FromRawUnchecked"/>
    public static Word FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WordFromRaw : IFromRawJson<Word>
{
    /// <inheritdoc/>
    public Word FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Word.FromRawUnchecked(rawData);
}
