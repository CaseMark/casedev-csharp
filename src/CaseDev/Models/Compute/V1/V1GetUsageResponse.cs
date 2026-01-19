using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;

namespace CaseDev.Models.Compute.V1;

[JsonConverter(typeof(JsonModelConverter<V1GetUsageResponse, V1GetUsageResponseFromRaw>))]
public sealed record class V1GetUsageResponse : JsonModel
{
    public IReadOnlyList<ByEnvironment>? ByEnvironment
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ByEnvironment>>("byEnvironment");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ByEnvironment>?>(
                "byEnvironment",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public Period? Period
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Period>("period");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("period", value);
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
        foreach (var item in this.ByEnvironment ?? [])
        {
            item.Validate();
        }
        this.Period?.Validate();
        this.Summary?.Validate();
    }

    public V1GetUsageResponse() { }

    public V1GetUsageResponse(V1GetUsageResponse v1GetUsageResponse)
        : base(v1GetUsageResponse) { }

    public V1GetUsageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1GetUsageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="V1GetUsageResponseFromRaw.FromRawUnchecked"/>
    public static V1GetUsageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class V1GetUsageResponseFromRaw : IFromRawJson<V1GetUsageResponse>
{
    /// <inheritdoc/>
    public V1GetUsageResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        V1GetUsageResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<ByEnvironment, ByEnvironmentFromRaw>))]
public sealed record class ByEnvironment : JsonModel
{
    public string? Environment
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("environment");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("environment", value);
        }
    }

    public long? TotalCostCents
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("totalCostCents");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("totalCostCents", value);
        }
    }

    public string? TotalCostFormatted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("totalCostFormatted");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("totalCostFormatted", value);
        }
    }

    public long? TotalCpuSeconds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("totalCpuSeconds");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("totalCpuSeconds", value);
        }
    }

    public long? TotalGpuSeconds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("totalGpuSeconds");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("totalGpuSeconds", value);
        }
    }

    public long? TotalRuns
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("totalRuns");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("totalRuns", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Environment;
        _ = this.TotalCostCents;
        _ = this.TotalCostFormatted;
        _ = this.TotalCpuSeconds;
        _ = this.TotalGpuSeconds;
        _ = this.TotalRuns;
    }

    public ByEnvironment() { }

    public ByEnvironment(ByEnvironment byEnvironment)
        : base(byEnvironment) { }

    public ByEnvironment(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ByEnvironment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ByEnvironmentFromRaw.FromRawUnchecked"/>
    public static ByEnvironment FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ByEnvironmentFromRaw : IFromRawJson<ByEnvironment>
{
    /// <inheritdoc/>
    public ByEnvironment FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ByEnvironment.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Period, PeriodFromRaw>))]
public sealed record class Period : JsonModel
{
    public long? Month
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("month");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("month", value);
        }
    }

    public string? MonthName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("monthName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("monthName", value);
        }
    }

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
        _ = this.Month;
        _ = this.MonthName;
        _ = this.Year;
    }

    public Period() { }

    public Period(Period period)
        : base(period) { }

    public Period(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Period(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PeriodFromRaw.FromRawUnchecked"/>
    public static Period FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PeriodFromRaw : IFromRawJson<Period>
{
    /// <inheritdoc/>
    public Period FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Period.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Summary, SummaryFromRaw>))]
public sealed record class Summary : JsonModel
{
    public long? TotalCostCents
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("totalCostCents");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("totalCostCents", value);
        }
    }

    public string? TotalCostFormatted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("totalCostFormatted");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("totalCostFormatted", value);
        }
    }

    public double? TotalCpuHours
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("totalCpuHours");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("totalCpuHours", value);
        }
    }

    public double? TotalGpuHours
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("totalGpuHours");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("totalGpuHours", value);
        }
    }

    public long? TotalRuns
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("totalRuns");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("totalRuns", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.TotalCostCents;
        _ = this.TotalCostFormatted;
        _ = this.TotalCpuHours;
        _ = this.TotalGpuHours;
        _ = this.TotalRuns;
    }

    public Summary() { }

    public Summary(Summary summary)
        : base(summary) { }

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
