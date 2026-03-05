using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Casedev.Core;

namespace Casedev.Models.Legal.V1;

[JsonConverter(typeof(JsonModelConverter<DocketSearchResult, DocketSearchResultFromRaw>))]
public sealed record class DocketSearchResult : JsonModel
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

    public string? AssignedTo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("assignedTo");
        }
        init { this._rawData.Set("assignedTo", value); }
    }

    public string? CaseName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("caseName");
        }
        init { this._rawData.Set("caseName", value); }
    }

    public string? Cause
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("cause");
        }
        init { this._rawData.Set("cause", value); }
    }

    public string? Court
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("court");
        }
        init { this._rawData.Set("court", value); }
    }

    public string? CourtID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("courtId");
        }
        init { this._rawData.Set("courtId", value); }
    }

    public string? DateFiled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("dateFiled");
        }
        init { this._rawData.Set("dateFiled", value); }
    }

    public string? DateTerminated
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("dateTerminated");
        }
        init { this._rawData.Set("dateTerminated", value); }
    }

    public string? DocketNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("docketNumber");
        }
        init { this._rawData.Set("docketNumber", value); }
    }

    public string? NatureOfSuit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("natureOfSuit");
        }
        init { this._rawData.Set("natureOfSuit", value); }
    }

    public string? PacerCaseID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("pacerCaseId");
        }
        init { this._rawData.Set("pacerCaseId", value); }
    }

    public IReadOnlyList<string>? Parties
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("parties");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "parties",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
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
        _ = this.AssignedTo;
        _ = this.CaseName;
        _ = this.Cause;
        _ = this.Court;
        _ = this.CourtID;
        _ = this.DateFiled;
        _ = this.DateTerminated;
        _ = this.DocketNumber;
        _ = this.NatureOfSuit;
        _ = this.PacerCaseID;
        _ = this.Parties;
        _ = this.Url;
    }

    public DocketSearchResult() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DocketSearchResult(DocketSearchResult docketSearchResult)
        : base(docketSearchResult) { }
#pragma warning restore CS8618

    public DocketSearchResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DocketSearchResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DocketSearchResultFromRaw.FromRawUnchecked"/>
    public static DocketSearchResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DocketSearchResultFromRaw : IFromRawJson<DocketSearchResult>
{
    /// <inheritdoc/>
    public DocketSearchResult FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DocketSearchResult.FromRawUnchecked(rawData);
}
