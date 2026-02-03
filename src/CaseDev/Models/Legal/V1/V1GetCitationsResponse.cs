using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;

namespace CaseDev.Models.Legal.V1;

[JsonConverter(typeof(JsonModelConverter<V1GetCitationsResponse, V1GetCitationsResponseFromRaw>))]
public sealed record class V1GetCitationsResponse : JsonModel
{
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

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Citations ?? [])
        {
            item.Validate();
        }
    }

    public V1GetCitationsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public V1GetCitationsResponse(V1GetCitationsResponse v1GetCitationsResponse)
        : base(v1GetCitationsResponse) { }
#pragma warning restore CS8618

    public V1GetCitationsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1GetCitationsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="V1GetCitationsResponseFromRaw.FromRawUnchecked"/>
    public static V1GetCitationsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class V1GetCitationsResponseFromRaw : IFromRawJson<V1GetCitationsResponse>
{
    /// <inheritdoc/>
    public V1GetCitationsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => V1GetCitationsResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Citation, CitationFromRaw>))]
public sealed record class Citation : JsonModel
{
    /// <summary>
    /// Structured Bluebook components. Null if citation format is not recognized.
    /// </summary>
    public Components? Components
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Components>("components");
        }
        init { this._rawData.Set("components", value); }
    }

    /// <summary>
    /// Whether citation was found in CourtListener database
    /// </summary>
    public bool? Found
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("found");
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
    /// Normalized citation string
    /// </summary>
    public string? Normalized
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("normalized");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("normalized", value);
        }
    }

    /// <summary>
    /// Original citation as found in text
    /// </summary>
    public string? Original
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("original");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("original", value);
        }
    }

    public Span? Span
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Span>("span");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("span", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Components?.Validate();
        _ = this.Found;
        _ = this.Normalized;
        _ = this.Original;
        this.Span?.Validate();
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

/// <summary>
/// Structured Bluebook components. Null if citation format is not recognized.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Components, ComponentsFromRaw>))]
public sealed record class Components : JsonModel
{
    /// <summary>
    /// Case name, e.g., "Bush v. Gore"
    /// </summary>
    public string? CaseName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("caseName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("caseName", value);
        }
    }

    /// <summary>
    /// Court identifier
    /// </summary>
    public string? Court
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("court");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("court", value);
        }
    }

    /// <summary>
    /// Starting page number
    /// </summary>
    public long? Page
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

    /// <summary>
    /// Pin cite (specific page)
    /// </summary>
    public long? PinCite
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("pinCite");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("pinCite", value);
        }
    }

    /// <summary>
    /// Reporter abbreviation, e.g., "U.S."
    /// </summary>
    public string? Reporter
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reporter");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("reporter", value);
        }
    }

    /// <summary>
    /// Volume number
    /// </summary>
    public long? Volume
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("volume");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("volume", value);
        }
    }

    /// <summary>
    /// Decision year
    /// </summary>
    public long? Year
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("year");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("year", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CaseName;
        _ = this.Court;
        _ = this.Page;
        _ = this.PinCite;
        _ = this.Reporter;
        _ = this.Volume;
        _ = this.Year;
    }

    public Components() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Components(Components components)
        : base(components) { }
#pragma warning restore CS8618

    public Components(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Components(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ComponentsFromRaw.FromRawUnchecked"/>
    public static Components FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ComponentsFromRaw : IFromRawJson<Components>
{
    /// <inheritdoc/>
    public Components FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Components.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Span, SpanFromRaw>))]
public sealed record class Span : JsonModel
{
    public long? End
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("end");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("end", value);
        }
    }

    public long? Start
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("start");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("start", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.End;
        _ = this.Start;
    }

    public Span() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Span(Span span)
        : base(span) { }
#pragma warning restore CS8618

    public Span(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Span(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SpanFromRaw.FromRawUnchecked"/>
    public static Span FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SpanFromRaw : IFromRawJson<Span>
{
    /// <inheritdoc/>
    public Span FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Span.FromRawUnchecked(rawData);
}
