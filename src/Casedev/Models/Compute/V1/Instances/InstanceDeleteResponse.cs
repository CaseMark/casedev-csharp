using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Casedev.Core;

namespace Casedev.Models.Compute.V1.Instances;

[JsonConverter(typeof(JsonModelConverter<InstanceDeleteResponse, InstanceDeleteResponseFromRaw>))]
public sealed record class InstanceDeleteResponse : JsonModel
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
        _ = this.Message;
        _ = this.Name;
        _ = this.Status;
        _ = this.TotalCost;
        _ = this.TotalRuntimeSeconds;
    }

    public InstanceDeleteResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InstanceDeleteResponse(InstanceDeleteResponse instanceDeleteResponse)
        : base(instanceDeleteResponse) { }
#pragma warning restore CS8618

    public InstanceDeleteResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InstanceDeleteResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InstanceDeleteResponseFromRaw.FromRawUnchecked"/>
    public static InstanceDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InstanceDeleteResponseFromRaw : IFromRawJson<InstanceDeleteResponse>
{
    /// <inheritdoc/>
    public InstanceDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InstanceDeleteResponse.FromRawUnchecked(rawData);
}
