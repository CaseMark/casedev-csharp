using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;

namespace CaseDev.Models.Legal.V1;

[JsonConverter(
    typeof(JsonModelConverter<V1GetCitationsFromUrlResponse, V1GetCitationsFromUrlResponseFromRaw>)
)]
public sealed record class V1GetCitationsFromUrlResponse : JsonModel
{
    public Citations? Citations
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Citations>("citations");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("citations", value);
        }
    }

    /// <summary>
    /// External links found in the document
    /// </summary>
    public IReadOnlyList<string>? ExternalLinks
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("externalLinks");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "externalLinks",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
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
    /// Total citations found
    /// </summary>
    public long? TotalCitations
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("totalCitations");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("totalCitations", value);
        }
    }

    /// <summary>
    /// Source document URL
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
        this.Citations?.Validate();
        _ = this.ExternalLinks;
        _ = this.Hint;
        _ = this.Title;
        _ = this.TotalCitations;
        _ = this.Url;
    }

    public V1GetCitationsFromUrlResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public V1GetCitationsFromUrlResponse(
        V1GetCitationsFromUrlResponse v1GetCitationsFromUrlResponse
    )
        : base(v1GetCitationsFromUrlResponse) { }
#pragma warning restore CS8618

    public V1GetCitationsFromUrlResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1GetCitationsFromUrlResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="V1GetCitationsFromUrlResponseFromRaw.FromRawUnchecked"/>
    public static V1GetCitationsFromUrlResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class V1GetCitationsFromUrlResponseFromRaw : IFromRawJson<V1GetCitationsFromUrlResponse>
{
    /// <inheritdoc/>
    public V1GetCitationsFromUrlResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => V1GetCitationsFromUrlResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Citations, CitationsFromRaw>))]
public sealed record class Citations : JsonModel
{
    public IReadOnlyList<Case>? Cases
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Case>>("cases");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Case>?>(
                "cases",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public IReadOnlyList<Regulation>? Regulations
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Regulation>>("regulations");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Regulation>?>(
                "regulations",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public IReadOnlyList<Statute>? Statutes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Statute>>("statutes");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Statute>?>(
                "statutes",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Cases ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.Regulations ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.Statutes ?? [])
        {
            item.Validate();
        }
    }

    public Citations() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Citations(Citations citations)
        : base(citations) { }
#pragma warning restore CS8618

    public Citations(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Citations(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CitationsFromRaw.FromRawUnchecked"/>
    public static Citations FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CitationsFromRaw : IFromRawJson<Citations>
{
    /// <inheritdoc/>
    public Citations FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Citations.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Case, CaseFromRaw>))]
public sealed record class Case : JsonModel
{
    /// <summary>
    /// The citation string
    /// </summary>
    public string? Citation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("citation");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("citation", value);
        }
    }

    /// <summary>
    /// Number of occurrences
    /// </summary>
    public long? Count
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("count");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("count", value);
        }
    }

    /// <summary>
    /// Citation type (usReporter, federalReporter, etc.)
    /// </summary>
    public string? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Citation;
        _ = this.Count;
        _ = this.Type;
    }

    public Case() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Case(Case case_)
        : base(case_) { }
#pragma warning restore CS8618

    public Case(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Case(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CaseFromRaw.FromRawUnchecked"/>
    public static Case FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CaseFromRaw : IFromRawJson<Case>
{
    /// <inheritdoc/>
    public Case FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Case.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Regulation, RegulationFromRaw>))]
public sealed record class Regulation : JsonModel
{
    /// <summary>
    /// The citation string
    /// </summary>
    public string? Citation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("citation");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("citation", value);
        }
    }

    /// <summary>
    /// Number of occurrences
    /// </summary>
    public long? Count
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("count");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("count", value);
        }
    }

    /// <summary>
    /// Citation type (cfr)
    /// </summary>
    public string? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Citation;
        _ = this.Count;
        _ = this.Type;
    }

    public Regulation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Regulation(Regulation regulation)
        : base(regulation) { }
#pragma warning restore CS8618

    public Regulation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Regulation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RegulationFromRaw.FromRawUnchecked"/>
    public static Regulation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RegulationFromRaw : IFromRawJson<Regulation>
{
    /// <inheritdoc/>
    public Regulation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Regulation.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Statute, StatuteFromRaw>))]
public sealed record class Statute : JsonModel
{
    /// <summary>
    /// The citation string
    /// </summary>
    public string? Citation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("citation");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("citation", value);
        }
    }

    /// <summary>
    /// Number of occurrences
    /// </summary>
    public long? Count
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("count");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("count", value);
        }
    }

    /// <summary>
    /// Citation type (usc)
    /// </summary>
    public string? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Citation;
        _ = this.Count;
        _ = this.Type;
    }

    public Statute() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Statute(Statute statute)
        : base(statute) { }
#pragma warning restore CS8618

    public Statute(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Statute(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="StatuteFromRaw.FromRawUnchecked"/>
    public static Statute FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class StatuteFromRaw : IFromRawJson<Statute>
{
    /// <inheritdoc/>
    public Statute FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Statute.FromRawUnchecked(rawData);
}
