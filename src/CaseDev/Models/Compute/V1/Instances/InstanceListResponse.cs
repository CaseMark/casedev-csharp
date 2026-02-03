using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;
using CaseDev.Exceptions;

namespace CaseDev.Models.Compute.V1.Instances;

[JsonConverter(typeof(JsonModelConverter<InstanceListResponse, InstanceListResponseFromRaw>))]
public sealed record class InstanceListResponse : JsonModel
{
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

    public IReadOnlyList<Instance>? Instances
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Instance>>("instances");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Instance>?>(
                "instances",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Count;
        foreach (var item in this.Instances ?? [])
        {
            item.Validate();
        }
    }

    public InstanceListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InstanceListResponse(InstanceListResponse instanceListResponse)
        : base(instanceListResponse) { }
#pragma warning restore CS8618

    public InstanceListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InstanceListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InstanceListResponseFromRaw.FromRawUnchecked"/>
    public static InstanceListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InstanceListResponseFromRaw : IFromRawJson<InstanceListResponse>
{
    /// <inheritdoc/>
    public InstanceListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InstanceListResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Instance, InstanceFromRaw>))]
public sealed record class Instance : JsonModel
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

    public long? AutoShutdownMinutes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("autoShutdownMinutes");
        }
        init { this._rawData.Set("autoShutdownMinutes", value); }
    }

    public DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("createdAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("createdAt", value);
        }
    }

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

    public string? InstanceType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("instanceType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("instanceType", value);
        }
    }

    public string? IP
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("ip");
        }
        init { this._rawData.Set("ip", value); }
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

    public string? Region
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("region");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("region", value);
        }
    }

    public DateTimeOffset? StartedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("startedAt");
        }
        init { this._rawData.Set("startedAt", value); }
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

    public string? TotalCost
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("totalCost");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("totalCost", value);
        }
    }

    public long? TotalRuntimeSeconds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("totalRuntimeSeconds");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("totalRuntimeSeconds", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AutoShutdownMinutes;
        _ = this.CreatedAt;
        _ = this.Gpu;
        _ = this.InstanceType;
        _ = this.IP;
        _ = this.Name;
        _ = this.PricePerHour;
        _ = this.Region;
        _ = this.StartedAt;
        this.Status?.Validate();
        _ = this.TotalCost;
        _ = this.TotalRuntimeSeconds;
    }

    public Instance() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Instance(Instance instance)
        : base(instance) { }
#pragma warning restore CS8618

    public Instance(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Instance(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InstanceFromRaw.FromRawUnchecked"/>
    public static Instance FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InstanceFromRaw : IFromRawJson<Instance>
{
    /// <inheritdoc/>
    public Instance FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Instance.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Booting,
    Running,
    Stopping,
    Stopped,
    Terminated,
    Failed,
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
            "booting" => Status.Booting,
            "running" => Status.Running,
            "stopping" => Status.Stopping,
            "stopped" => Status.Stopped,
            "terminated" => Status.Terminated,
            "failed" => Status.Failed,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Booting => "booting",
                Status.Running => "running",
                Status.Stopping => "stopping",
                Status.Stopped => "stopped",
                Status.Terminated => "terminated",
                Status.Failed => "failed",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
