using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;

namespace CaseDev.Models.Compute.V1.Instances;

[JsonConverter(typeof(JsonModelConverter<InstanceCreateResponse, InstanceCreateResponseFromRaw>))]
public sealed record class InstanceCreateResponse : JsonModel
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

    public string? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("createdAt");
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

    public string? Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("message");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("message", value);
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

    public JsonElement? Specs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("specs");
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

    public IReadOnlyList<JsonElement>? Vaults
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<JsonElement>>("vaults");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<JsonElement>?>(
                "vaults",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
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
        _ = this.Message;
        _ = this.Name;
        _ = this.PricePerHour;
        _ = this.Region;
        _ = this.Specs;
        _ = this.Status;
        _ = this.Vaults;
    }

    public InstanceCreateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InstanceCreateResponse(InstanceCreateResponse instanceCreateResponse)
        : base(instanceCreateResponse) { }
#pragma warning restore CS8618

    public InstanceCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InstanceCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InstanceCreateResponseFromRaw.FromRawUnchecked"/>
    public static InstanceCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InstanceCreateResponseFromRaw : IFromRawJson<InstanceCreateResponse>
{
    /// <inheritdoc/>
    public InstanceCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InstanceCreateResponse.FromRawUnchecked(rawData);
}
