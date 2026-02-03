using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;

namespace CaseDev.Models.Legal.V1;

[JsonConverter(typeof(JsonModelConverter<V1FindResponse, V1FindResponseFromRaw>))]
public sealed record class V1FindResponse : JsonModel
{
    public IReadOnlyList<Candidate>? Candidates
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Candidate>>("candidates");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Candidate>?>(
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

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Candidates ?? [])
        {
            item.Validate();
        }
        _ = this.Found;
        _ = this.Hint;
        _ = this.Jurisdiction;
        _ = this.Query;
    }

    public V1FindResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public V1FindResponse(V1FindResponse v1FindResponse)
        : base(v1FindResponse) { }
#pragma warning restore CS8618

    public V1FindResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1FindResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="V1FindResponseFromRaw.FromRawUnchecked"/>
    public static V1FindResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class V1FindResponseFromRaw : IFromRawJson<V1FindResponse>
{
    /// <inheritdoc/>
    public V1FindResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        V1FindResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Candidate, CandidateFromRaw>))]
public sealed record class Candidate : JsonModel
{
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
        _ = this.Snippet;
        _ = this.Source;
        _ = this.Title;
        _ = this.Url;
    }

    public Candidate() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Candidate(Candidate candidate)
        : base(candidate) { }
#pragma warning restore CS8618

    public Candidate(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Candidate(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CandidateFromRaw.FromRawUnchecked"/>
    public static Candidate FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CandidateFromRaw : IFromRawJson<Candidate>
{
    /// <inheritdoc/>
    public Candidate FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Candidate.FromRawUnchecked(rawData);
}
