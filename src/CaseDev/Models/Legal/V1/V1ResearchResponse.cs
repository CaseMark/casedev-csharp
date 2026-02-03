using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;

namespace CaseDev.Models.Legal.V1;

[JsonConverter(typeof(JsonModelConverter<V1ResearchResponse, V1ResearchResponseFromRaw>))]
public sealed record class V1ResearchResponse : JsonModel
{
    /// <summary>
    /// Additional queries used
    /// </summary>
    public IReadOnlyList<string>? AdditionalQueries
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("additionalQueries");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "additionalQueries",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public IReadOnlyList<V1ResearchResponseCandidate>? Candidates
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<V1ResearchResponseCandidate>>(
                "candidates"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<V1ResearchResponseCandidate>?>(
                "candidates",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Number of candidates found
    /// </summary>
    public long? Found
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("found");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("found", value);
        }
    }

    /// <summary>
    /// Usage guidance
    /// </summary>
    public string? Hint
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("hint");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("hint", value);
        }
    }

    /// <summary>
    /// Jurisdiction filter applied
    /// </summary>
    public string? Jurisdiction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("jurisdiction");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("jurisdiction", value);
        }
    }

    /// <summary>
    /// Primary search query
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
    /// Search type used (deep)
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
        _ = this.AdditionalQueries;
        foreach (var item in this.Candidates ?? [])
        {
            item.Validate();
        }
        _ = this.Found;
        _ = this.Hint;
        _ = this.Jurisdiction;
        _ = this.Query;
        _ = this.SearchType;
    }

    public V1ResearchResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public V1ResearchResponse(V1ResearchResponse v1ResearchResponse)
        : base(v1ResearchResponse) { }
#pragma warning restore CS8618

    public V1ResearchResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1ResearchResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="V1ResearchResponseFromRaw.FromRawUnchecked"/>
    public static V1ResearchResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class V1ResearchResponseFromRaw : IFromRawJson<V1ResearchResponse>
{
    /// <inheritdoc/>
    public V1ResearchResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        V1ResearchResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<V1ResearchResponseCandidate, V1ResearchResponseCandidateFromRaw>)
)]
public sealed record class V1ResearchResponseCandidate : JsonModel
{
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
    /// Text excerpt from the document
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
    /// Domain of the source
    /// </summary>
    public string? Source
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("source");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("source", value);
        }
    }

    /// <summary>
    /// Title of the document
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
    /// URL of the legal source
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
        _ = this.Highlights;
        _ = this.PublishedDate;
        _ = this.Snippet;
        _ = this.Source;
        _ = this.Title;
        _ = this.Url;
    }

    public V1ResearchResponseCandidate() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public V1ResearchResponseCandidate(V1ResearchResponseCandidate v1ResearchResponseCandidate)
        : base(v1ResearchResponseCandidate) { }
#pragma warning restore CS8618

    public V1ResearchResponseCandidate(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1ResearchResponseCandidate(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="V1ResearchResponseCandidateFromRaw.FromRawUnchecked"/>
    public static V1ResearchResponseCandidate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class V1ResearchResponseCandidateFromRaw : IFromRawJson<V1ResearchResponseCandidate>
{
    /// <inheritdoc/>
    public V1ResearchResponseCandidate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => V1ResearchResponseCandidate.FromRawUnchecked(rawData);
}
