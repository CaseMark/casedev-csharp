using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;

namespace CaseDev.Models.Legal.V1;

[JsonConverter(typeof(JsonModelConverter<V1PatentSearchResponse, V1PatentSearchResponseFromRaw>))]
public sealed record class V1PatentSearchResponse : JsonModel
{
    /// <summary>
    /// Number of results returned
    /// </summary>
    public long? Limit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("limit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("limit", value);
        }
    }

    /// <summary>
    /// Current pagination offset
    /// </summary>
    public long? Offset
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("offset");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("offset", value);
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

    /// <summary>
    /// Array of matching patent applications
    /// </summary>
    public IReadOnlyList<Result>? Results
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Result>>("results");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Result>?>(
                "results",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Total number of matching patent applications
    /// </summary>
    public long? TotalResults
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("totalResults");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("totalResults", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Limit;
        _ = this.Offset;
        _ = this.Query;
        foreach (var item in this.Results ?? [])
        {
            item.Validate();
        }
        _ = this.TotalResults;
    }

    public V1PatentSearchResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public V1PatentSearchResponse(V1PatentSearchResponse v1PatentSearchResponse)
        : base(v1PatentSearchResponse) { }
#pragma warning restore CS8618

    public V1PatentSearchResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1PatentSearchResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="V1PatentSearchResponseFromRaw.FromRawUnchecked"/>
    public static V1PatentSearchResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class V1PatentSearchResponseFromRaw : IFromRawJson<V1PatentSearchResponse>
{
    /// <inheritdoc/>
    public V1PatentSearchResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => V1PatentSearchResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Result, ResultFromRaw>))]
public sealed record class Result : JsonModel
{
    /// <summary>
    /// Patent application serial number
    /// </summary>
    public string? ApplicationNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("applicationNumber");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("applicationNumber", value);
        }
    }

    /// <summary>
    /// Application type (Utility, Design, Plant, etc.)
    /// </summary>
    public string? ApplicationType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("applicationType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("applicationType", value);
        }
    }

    /// <summary>
    /// List of assignee/owner names
    /// </summary>
    public IReadOnlyList<string>? Assignees
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("assignees");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "assignees",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Entity status (e.g. "Small Entity", "Micro Entity")
    /// </summary>
    public string? EntityStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("entityStatus");
        }
        init { this._rawData.Set("entityStatus", value); }
    }

    /// <summary>
    /// Date the application was filed
    /// </summary>
    public string? FilingDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("filingDate");
        }
        init { this._rawData.Set("filingDate", value); }
    }

    /// <summary>
    /// Date the patent was granted
    /// </summary>
    public string? GrantDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("grantDate");
        }
        init { this._rawData.Set("grantDate", value); }
    }

    /// <summary>
    /// List of inventor names
    /// </summary>
    public IReadOnlyList<string>? Inventors
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("inventors");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "inventors",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Granted patent number (if granted)
    /// </summary>
    public string? PatentNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("patentNumber");
        }
        init { this._rawData.Set("patentNumber", value); }
    }

    /// <summary>
    /// Current application status (e.g. "Patented Case", "Pending")
    /// </summary>
    public string? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("status");
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
    /// Invention title
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ApplicationNumber;
        _ = this.ApplicationType;
        _ = this.Assignees;
        _ = this.EntityStatus;
        _ = this.FilingDate;
        _ = this.GrantDate;
        _ = this.Inventors;
        _ = this.PatentNumber;
        _ = this.Status;
        _ = this.Title;
    }

    public Result() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Result(Result result)
        : base(result) { }
#pragma warning restore CS8618

    public Result(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Result(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ResultFromRaw.FromRawUnchecked"/>
    public static Result FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ResultFromRaw : IFromRawJson<Result>
{
    /// <inheritdoc/>
    public Result FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Result.FromRawUnchecked(rawData);
}
