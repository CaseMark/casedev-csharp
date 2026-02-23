using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Router.Core;
using Router.Exceptions;

namespace Router.Models.Legal.V1;

[JsonConverter(typeof(JsonModelConverter<V1VerifyResponse, V1VerifyResponseFromRaw>))]
public sealed record class V1VerifyResponse : JsonModel
{
    public IReadOnlyList<V1VerifyResponseCitation>? Citations
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<V1VerifyResponseCitation>>(
                "citations"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<V1VerifyResponseCitation>?>(
                "citations",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public Summary? Summary
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Summary>("summary");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("summary", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Citations ?? [])
        {
            item.Validate();
        }
        this.Summary?.Validate();
    }

    public V1VerifyResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public V1VerifyResponse(V1VerifyResponse v1VerifyResponse)
        : base(v1VerifyResponse) { }
#pragma warning restore CS8618

    public V1VerifyResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1VerifyResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="V1VerifyResponseFromRaw.FromRawUnchecked"/>
    public static V1VerifyResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class V1VerifyResponseFromRaw : IFromRawJson<V1VerifyResponse>
{
    /// <inheritdoc/>
    public V1VerifyResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        V1VerifyResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<V1VerifyResponseCitation, V1VerifyResponseCitationFromRaw>)
)]
public sealed record class V1VerifyResponseCitation : JsonModel
{
    /// <summary>
    /// Multiple candidates (when multiple_matches or heuristic verification)
    /// </summary>
    public IReadOnlyList<V1VerifyResponseCitationCandidate>? Candidates
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<V1VerifyResponseCitationCandidate>
            >("candidates");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<V1VerifyResponseCitationCandidate>?>(
                "candidates",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Case metadata (when verified)
    /// </summary>
    public V1VerifyResponseCitationCase? Case
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<V1VerifyResponseCitationCase>("case");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("case", value);
        }
    }

    /// <summary>
    /// Confidence score (1.0 for CourtListener, heuristic score for fallback).
    /// </summary>
    public double? Confidence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("confidence");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("confidence", value);
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

    public V1VerifyResponseCitationSpan? Span
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<V1VerifyResponseCitationSpan>("span");
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

    public ApiEnum<string, Status>? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Status>>("status");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("status", value);
        }
    }

    /// <summary>
    /// Source of verification result (heuristic for fallback matches).
    /// </summary>
    public ApiEnum<string, VerificationSource>? VerificationSource
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, VerificationSource>>(
                "verificationSource"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("verificationSource", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Candidates ?? [])
        {
            item.Validate();
        }
        this.Case?.Validate();
        _ = this.Confidence;
        _ = this.Normalized;
        _ = this.Original;
        this.Span?.Validate();
        this.Status?.Validate();
        this.VerificationSource?.Validate();
    }

    public V1VerifyResponseCitation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public V1VerifyResponseCitation(V1VerifyResponseCitation v1VerifyResponseCitation)
        : base(v1VerifyResponseCitation) { }
#pragma warning restore CS8618

    public V1VerifyResponseCitation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1VerifyResponseCitation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="V1VerifyResponseCitationFromRaw.FromRawUnchecked"/>
    public static V1VerifyResponseCitation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class V1VerifyResponseCitationFromRaw : IFromRawJson<V1VerifyResponseCitation>
{
    /// <inheritdoc/>
    public V1VerifyResponseCitation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => V1VerifyResponseCitation.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        V1VerifyResponseCitationCandidate,
        V1VerifyResponseCitationCandidateFromRaw
    >)
)]
public sealed record class V1VerifyResponseCitationCandidate : JsonModel
{
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

    public string? DateDecided
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("dateDecided");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("dateDecided", value);
        }
    }

    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name", value);
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
        _ = this.Court;
        _ = this.DateDecided;
        _ = this.Name;
        _ = this.Url;
    }

    public V1VerifyResponseCitationCandidate() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public V1VerifyResponseCitationCandidate(
        V1VerifyResponseCitationCandidate v1VerifyResponseCitationCandidate
    )
        : base(v1VerifyResponseCitationCandidate) { }
#pragma warning restore CS8618

    public V1VerifyResponseCitationCandidate(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1VerifyResponseCitationCandidate(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="V1VerifyResponseCitationCandidateFromRaw.FromRawUnchecked"/>
    public static V1VerifyResponseCitationCandidate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class V1VerifyResponseCitationCandidateFromRaw : IFromRawJson<V1VerifyResponseCitationCandidate>
{
    /// <inheritdoc/>
    public V1VerifyResponseCitationCandidate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => V1VerifyResponseCitationCandidate.FromRawUnchecked(rawData);
}

/// <summary>
/// Case metadata (when verified)
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<V1VerifyResponseCitationCase, V1VerifyResponseCitationCaseFromRaw>)
)]
public sealed record class V1VerifyResponseCitationCase : JsonModel
{
    public long? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("id");
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

    public string? DateDecided
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("dateDecided");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("dateDecided", value);
        }
    }

    public string? DocketNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("docketNumber");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("docketNumber", value);
        }
    }

    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    public IReadOnlyList<string>? ParallelCitations
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("parallelCitations");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "parallelCitations",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? ShortName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("shortName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("shortName", value);
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
        _ = this.Court;
        _ = this.DateDecided;
        _ = this.DocketNumber;
        _ = this.Name;
        _ = this.ParallelCitations;
        _ = this.ShortName;
        _ = this.Url;
    }

    public V1VerifyResponseCitationCase() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public V1VerifyResponseCitationCase(V1VerifyResponseCitationCase v1VerifyResponseCitationCase)
        : base(v1VerifyResponseCitationCase) { }
#pragma warning restore CS8618

    public V1VerifyResponseCitationCase(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1VerifyResponseCitationCase(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="V1VerifyResponseCitationCaseFromRaw.FromRawUnchecked"/>
    public static V1VerifyResponseCitationCase FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class V1VerifyResponseCitationCaseFromRaw : IFromRawJson<V1VerifyResponseCitationCase>
{
    /// <inheritdoc/>
    public V1VerifyResponseCitationCase FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => V1VerifyResponseCitationCase.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<V1VerifyResponseCitationSpan, V1VerifyResponseCitationSpanFromRaw>)
)]
public sealed record class V1VerifyResponseCitationSpan : JsonModel
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

    public V1VerifyResponseCitationSpan() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public V1VerifyResponseCitationSpan(V1VerifyResponseCitationSpan v1VerifyResponseCitationSpan)
        : base(v1VerifyResponseCitationSpan) { }
#pragma warning restore CS8618

    public V1VerifyResponseCitationSpan(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1VerifyResponseCitationSpan(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="V1VerifyResponseCitationSpanFromRaw.FromRawUnchecked"/>
    public static V1VerifyResponseCitationSpan FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class V1VerifyResponseCitationSpanFromRaw : IFromRawJson<V1VerifyResponseCitationSpan>
{
    /// <inheritdoc/>
    public V1VerifyResponseCitationSpan FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => V1VerifyResponseCitationSpan.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Verified,
    NotFound,
    MultipleMatches,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "verified" => Status.Verified,
            "not_found" => Status.NotFound,
            "multiple_matches" => Status.MultipleMatches,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Verified => "verified",
                Status.NotFound => "not_found",
                Status.MultipleMatches => "multiple_matches",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Source of verification result (heuristic for fallback matches).
/// </summary>
[JsonConverter(typeof(VerificationSourceConverter))]
public enum VerificationSource
{
    Courtlistener,
    Heuristic,
}

sealed class VerificationSourceConverter : JsonConverter<VerificationSource>
{
    public override VerificationSource Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "courtlistener" => VerificationSource.Courtlistener,
            "heuristic" => VerificationSource.Heuristic,
            _ => (VerificationSource)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VerificationSource value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                VerificationSource.Courtlistener => "courtlistener",
                VerificationSource.Heuristic => "heuristic",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<Summary, SummaryFromRaw>))]
public sealed record class Summary : JsonModel
{
    /// <summary>
    /// Citations with multiple possible matches
    /// </summary>
    public long? MultipleMatches
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("multipleMatches");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("multipleMatches", value);
        }
    }

    /// <summary>
    /// Citations not found in database
    /// </summary>
    public long? NotFound
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("notFound");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("notFound", value);
        }
    }

    /// <summary>
    /// Total citations found
    /// </summary>
    public long? Total
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("total");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("total", value);
        }
    }

    /// <summary>
    /// Citations verified against real cases
    /// </summary>
    public long? Verified
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("verified");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("verified", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.MultipleMatches;
        _ = this.NotFound;
        _ = this.Total;
        _ = this.Verified;
    }

    public Summary() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Summary(Summary summary)
        : base(summary) { }
#pragma warning restore CS8618

    public Summary(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Summary(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SummaryFromRaw.FromRawUnchecked"/>
    public static Summary FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SummaryFromRaw : IFromRawJson<Summary>
{
    /// <inheritdoc/>
    public Summary FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Summary.FromRawUnchecked(rawData);
}
