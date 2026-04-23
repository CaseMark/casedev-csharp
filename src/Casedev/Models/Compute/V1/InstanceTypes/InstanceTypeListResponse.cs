using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Casedev.Core;

namespace Casedev.Models.Compute.V1.InstanceTypes;

[JsonConverter(
    typeof(JsonModelConverter<InstanceTypeListResponse, InstanceTypeListResponseFromRaw>)
)]
public sealed record class InstanceTypeListResponse : JsonModel
{
    /// <summary>
    /// Total number of instance types
    /// </summary>
    public required long Count
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("count");
        }
        init { this._rawData.Set("count", value); }
    }

    public required IReadOnlyList<InstanceType> InstanceTypes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<InstanceType>>("instanceTypes");
        }
        init
        {
            this._rawData.Set<ImmutableArray<InstanceType>>(
                "instanceTypes",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Count;
        foreach (var item in this.InstanceTypes)
        {
            item.Validate();
        }
    }

    public InstanceTypeListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InstanceTypeListResponse(InstanceTypeListResponse instanceTypeListResponse)
        : base(instanceTypeListResponse) { }
#pragma warning restore CS8618

    public InstanceTypeListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InstanceTypeListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InstanceTypeListResponseFromRaw.FromRawUnchecked"/>
    public static InstanceTypeListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InstanceTypeListResponseFromRaw : IFromRawJson<InstanceTypeListResponse>
{
    /// <inheritdoc/>
    public InstanceTypeListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InstanceTypeListResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<InstanceType, InstanceTypeFromRaw>))]
public sealed record class InstanceType : JsonModel
{
    /// <summary>
    /// Instance description
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    /// <summary>
    /// GPU model and count
    /// </summary>
    public string? Gpu
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("gpu");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("gpu", value);
        }
    }

    /// <summary>
    /// Instance type identifier
    /// </summary>
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

    /// <summary>
    /// Price per hour (e.g. '$1.20')
    /// </summary>
    public string? PricePerHour
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("pricePerHour");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("pricePerHour", value);
        }
    }

    /// <summary>
    /// Available regions
    /// </summary>
    public IReadOnlyList<string>? RegionsAvailable
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("regionsAvailable");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "regionsAvailable",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public Specs? Specs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Specs>("specs");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("specs", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Description;
        _ = this.Gpu;
        _ = this.Name;
        _ = this.PricePerHour;
        _ = this.RegionsAvailable;
        this.Specs?.Validate();
    }

    public InstanceType() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InstanceType(InstanceType instanceType)
        : base(instanceType) { }
#pragma warning restore CS8618

    public InstanceType(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InstanceType(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InstanceTypeFromRaw.FromRawUnchecked"/>
    public static InstanceType FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InstanceTypeFromRaw : IFromRawJson<InstanceType>
{
    /// <inheritdoc/>
    public InstanceType FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        InstanceType.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Specs, SpecsFromRaw>))]
public sealed record class Specs : JsonModel
{
    /// <summary>
    /// RAM in GiB
    /// </summary>
    public long? MemoryGib
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("memoryGib");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("memoryGib", value);
        }
    }

    /// <summary>
    /// Storage in GiB
    /// </summary>
    public long? StorageGib
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("storageGib");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("storageGib", value);
        }
    }

    /// <summary>
    /// Number of vCPUs
    /// </summary>
    public long? Vcpus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("vcpus");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("vcpus", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.MemoryGib;
        _ = this.StorageGib;
        _ = this.Vcpus;
    }

    public Specs() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Specs(Specs specs)
        : base(specs) { }
#pragma warning restore CS8618

    public Specs(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Specs(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SpecsFromRaw.FromRawUnchecked"/>
    public static Specs FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SpecsFromRaw : IFromRawJson<Specs>
{
    /// <inheritdoc/>
    public Specs FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Specs.FromRawUnchecked(rawData);
}
