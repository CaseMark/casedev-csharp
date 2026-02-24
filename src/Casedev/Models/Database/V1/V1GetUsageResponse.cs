using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Casedev.Core;

namespace Casedev.Models.Database.V1;

[JsonConverter(typeof(JsonModelConverter<V1GetUsageResponse, V1GetUsageResponseFromRaw>))]
public sealed record class V1GetUsageResponse : JsonModel
{
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

    /// <summary>
    /// Current pricing rates
    /// </summary>
    public Pricing? Pricing
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Pricing>("pricing");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("pricing", value);
        }
    }

    /// <summary>
    /// Total number of projects with usage
    /// </summary>
    public long? ProjectCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("projectCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("projectCount", value);
        }
    }

    /// <summary>
    /// Usage breakdown by project
    /// </summary>
    public IReadOnlyList<Project>? Projects
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Project>>("projects");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Project>?>(
                "projects",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Aggregated totals across all projects
    /// </summary>
    public Totals? Totals
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Totals>("totals");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("totals", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Period?.Validate();
        this.Pricing?.Validate();
        _ = this.ProjectCount;
        foreach (var item in this.Projects ?? [])
        {
            item.Validate();
        }
        this.Totals?.Validate();
    }

    public V1GetUsageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public V1GetUsageResponse(V1GetUsageResponse v1GetUsageResponse)
        : base(v1GetUsageResponse) { }
#pragma warning restore CS8618

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

[JsonConverter(typeof(JsonModelConverter<Period, PeriodFromRaw>))]
public sealed record class Period : JsonModel
{
    /// <summary>
    /// End of the billing period
    /// </summary>
    public DateTimeOffset? End
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("end");
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

    /// <summary>
    /// Start of the billing period
    /// </summary>
    public DateTimeOffset? Start
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("start");
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

    public Period() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Period(Period period)
        : base(period) { }
#pragma warning restore CS8618

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

/// <summary>
/// Current pricing rates
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Pricing, PricingFromRaw>))]
public sealed record class Pricing : JsonModel
{
    /// <summary>
    /// Cost per branch per month in dollars
    /// </summary>
    public double? BranchPerMonth
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("branchPerMonth");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("branchPerMonth", value);
        }
    }

    /// <summary>
    /// Cost per compute unit hour in dollars
    /// </summary>
    public double? ComputePerCuHour
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("computePerCuHour");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("computePerCuHour", value);
        }
    }

    /// <summary>
    /// Number of free branches included
    /// </summary>
    public long? FreeBranches
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("freeBranches");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("freeBranches", value);
        }
    }

    /// <summary>
    /// Cost per GB of storage per month in dollars
    /// </summary>
    public double? StoragePerGBMonth
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("storagePerGbMonth");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("storagePerGbMonth", value);
        }
    }

    /// <summary>
    /// Cost per GB of data transfer in dollars
    /// </summary>
    public double? TransferPerGB
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("transferPerGb");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("transferPerGb", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BranchPerMonth;
        _ = this.ComputePerCuHour;
        _ = this.FreeBranches;
        _ = this.StoragePerGBMonth;
        _ = this.TransferPerGB;
    }

    public Pricing() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Pricing(Pricing pricing)
        : base(pricing) { }
#pragma warning restore CS8618

    public Pricing(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Pricing(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PricingFromRaw.FromRawUnchecked"/>
    public static Pricing FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PricingFromRaw : IFromRawJson<Pricing>
{
    /// <inheritdoc/>
    public Pricing FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Pricing.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Project, ProjectFromRaw>))]
public sealed record class Project : JsonModel
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

    public long? BranchCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("branchCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("branchCount", value);
        }
    }

    public double? ComputeCuHours
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("computeCuHours");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("computeCuHours", value);
        }
    }

    public Costs? Costs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Costs>("costs");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("costs", value);
        }
    }

    public DateTimeOffset? LastUpdated
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("lastUpdated");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("lastUpdated", value);
        }
    }

    public string? ProjectID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("projectId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("projectId", value);
        }
    }

    public string? ProjectName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("projectName");
        }
        init { this._rawData.Set("projectName", value); }
    }

    public double? StorageGBMonths
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("storageGbMonths");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("storageGbMonths", value);
        }
    }

    public double? TransferGB
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("transferGb");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("transferGb", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.BranchCount;
        _ = this.ComputeCuHours;
        this.Costs?.Validate();
        _ = this.LastUpdated;
        _ = this.ProjectID;
        _ = this.ProjectName;
        _ = this.StorageGBMonths;
        _ = this.TransferGB;
    }

    public Project() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Project(Project project)
        : base(project) { }
#pragma warning restore CS8618

    public Project(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Project(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProjectFromRaw.FromRawUnchecked"/>
    public static Project FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProjectFromRaw : IFromRawJson<Project>
{
    /// <inheritdoc/>
    public Project FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Project.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Costs, CostsFromRaw>))]
public sealed record class Costs : JsonModel
{
    public string? Branches
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("branches");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("branches", value);
        }
    }

    public string? Compute
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("compute");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("compute", value);
        }
    }

    public string? Storage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("storage");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("storage", value);
        }
    }

    public string? Total
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("total");
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

    public string? Transfer
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("transfer");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("transfer", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Branches;
        _ = this.Compute;
        _ = this.Storage;
        _ = this.Total;
        _ = this.Transfer;
    }

    public Costs() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Costs(Costs costs)
        : base(costs) { }
#pragma warning restore CS8618

    public Costs(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Costs(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CostsFromRaw.FromRawUnchecked"/>
    public static Costs FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CostsFromRaw : IFromRawJson<Costs>
{
    /// <inheritdoc/>
    public Costs FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Costs.FromRawUnchecked(rawData);
}

/// <summary>
/// Aggregated totals across all projects
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Totals, TotalsFromRaw>))]
public sealed record class Totals : JsonModel
{
    /// <summary>
    /// Total branch cost formatted as dollars
    /// </summary>
    public string? BranchCostDollars
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("branchCostDollars");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("branchCostDollars", value);
        }
    }

    /// <summary>
    /// Total compute cost formatted as dollars
    /// </summary>
    public string? ComputeCostDollars
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("computeCostDollars");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("computeCostDollars", value);
        }
    }

    /// <summary>
    /// Total compute unit hours
    /// </summary>
    public double? ComputeCuHours
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("computeCuHours");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("computeCuHours", value);
        }
    }

    /// <summary>
    /// Total storage cost formatted as dollars
    /// </summary>
    public string? StorageCostDollars
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("storageCostDollars");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("storageCostDollars", value);
        }
    }

    /// <summary>
    /// Total storage in GB-months
    /// </summary>
    public double? StorageGBMonths
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("storageGbMonths");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("storageGbMonths", value);
        }
    }

    /// <summary>
    /// Total number of branches
    /// </summary>
    public long? TotalBranches
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("totalBranches");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("totalBranches", value);
        }
    }

    /// <summary>
    /// Total cost formatted as dollars
    /// </summary>
    public string? TotalCostDollars
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("totalCostDollars");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("totalCostDollars", value);
        }
    }

    /// <summary>
    /// Total transfer cost formatted as dollars
    /// </summary>
    public string? TransferCostDollars
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("transferCostDollars");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("transferCostDollars", value);
        }
    }

    /// <summary>
    /// Total data transfer in GB
    /// </summary>
    public double? TransferGB
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("transferGb");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("transferGb", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BranchCostDollars;
        _ = this.ComputeCostDollars;
        _ = this.ComputeCuHours;
        _ = this.StorageCostDollars;
        _ = this.StorageGBMonths;
        _ = this.TotalBranches;
        _ = this.TotalCostDollars;
        _ = this.TransferCostDollars;
        _ = this.TransferGB;
    }

    public Totals() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Totals(Totals totals)
        : base(totals) { }
#pragma warning restore CS8618

    public Totals(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Totals(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TotalsFromRaw.FromRawUnchecked"/>
    public static Totals FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TotalsFromRaw : IFromRawJson<Totals>
{
    /// <inheritdoc/>
    public Totals FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Totals.FromRawUnchecked(rawData);
}
