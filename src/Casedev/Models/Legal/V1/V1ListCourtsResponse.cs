using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Casedev.Core;

namespace Casedev.Models.Legal.V1;

[JsonConverter(typeof(JsonModelConverter<V1ListCourtsResponse, V1ListCourtsResponseFromRaw>))]
public sealed record class V1ListCourtsResponse : JsonModel
{
    public IReadOnlyList<Court>? Courts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Court>>("courts");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Court>?>(
                "courts",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

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
    /// Whether results are filtered to in-use courts only
    /// </summary>
    public bool? InUseOnly
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("inUseOnly");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("inUseOnly", value);
        }
    }

    public string? Jurisdiction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("jurisdiction");
        }
        init { this._rawData.Set("jurisdiction", value); }
    }

    public string? Query
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("query");
        }
        init { this._rawData.Set("query", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Courts ?? [])
        {
            item.Validate();
        }
        _ = this.Found;
        _ = this.InUseOnly;
        _ = this.Jurisdiction;
        _ = this.Query;
    }

    public V1ListCourtsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public V1ListCourtsResponse(V1ListCourtsResponse v1ListCourtsResponse)
        : base(v1ListCourtsResponse) { }
#pragma warning restore CS8618

    public V1ListCourtsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1ListCourtsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="V1ListCourtsResponseFromRaw.FromRawUnchecked"/>
    public static V1ListCourtsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class V1ListCourtsResponseFromRaw : IFromRawJson<V1ListCourtsResponse>
{
    /// <inheritdoc/>
    public V1ListCourtsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => V1ListCourtsResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Court, CourtFromRaw>))]
public sealed record class Court : JsonModel
{
    /// <summary>
    /// Court slug (use as the court parameter in legal.docket())
    /// </summary>
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

    public string? FullName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("fullName");
        }
        init { this._rawData.Set("fullName", value); }
    }

    public string? Jurisdiction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("jurisdiction");
        }
        init { this._rawData.Set("jurisdiction", value); }
    }

    public long? PacerCourtID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("pacerCourtId");
        }
        init { this._rawData.Set("pacerCourtId", value); }
    }

    public string? ShortName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("shortName");
        }
        init { this._rawData.Set("shortName", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.FullName;
        _ = this.Jurisdiction;
        _ = this.PacerCourtID;
        _ = this.ShortName;
    }

    public Court() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Court(Court court)
        : base(court) { }
#pragma warning restore CS8618

    public Court(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Court(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CourtFromRaw.FromRawUnchecked"/>
    public static Court FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CourtFromRaw : IFromRawJson<Court>
{
    /// <inheritdoc/>
    public Court FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Court.FromRawUnchecked(rawData);
}
