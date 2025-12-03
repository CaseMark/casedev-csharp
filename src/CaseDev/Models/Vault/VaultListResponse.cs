using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;

namespace CaseDev.Models.Vault;

[JsonConverter(typeof(ModelConverter<VaultListResponse, VaultListResponseFromRaw>))]
public sealed record class VaultListResponse : ModelBase
{
    /// <summary>
    /// Total number of vaults
    /// </summary>
    public long? Total
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "total"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "total", value);
        }
    }

    public IReadOnlyList<VaultModel>? Vaults
    {
        get { return ModelBase.GetNullableClass<List<VaultModel>>(this.RawData, "vaults"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "vaults", value);
        }
    }

    public override void Validate()
    {
        _ = this.Total;
        foreach (var item in this.Vaults ?? [])
        {
            item.Validate();
        }
    }

    public VaultListResponse() { }

    public VaultListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VaultListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static VaultListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VaultListResponseFromRaw : IFromRaw<VaultListResponse>
{
    public VaultListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        VaultListResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<VaultModel, VaultModelFromRaw>))]
public sealed record class VaultModel : ModelBase
{
    /// <summary>
    /// Vault identifier
    /// </summary>
    public string? ID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "id"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "id", value);
        }
    }

    /// <summary>
    /// Vault creation timestamp
    /// </summary>
    public DateTimeOffset? CreatedAt
    {
        get { return ModelBase.GetNullableStruct<DateTimeOffset>(this.RawData, "createdAt"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "createdAt", value);
        }
    }

    /// <summary>
    /// Vault description
    /// </summary>
    public string? Description
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "description"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "description", value);
        }
    }

    /// <summary>
    /// Whether GraphRAG is enabled
    /// </summary>
    public bool? EnableGraph
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "enableGraph"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "enableGraph", value);
        }
    }

    /// <summary>
    /// Vault name
    /// </summary>
    public string? Name
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "name"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "name", value);
        }
    }

    /// <summary>
    /// Total storage size in bytes
    /// </summary>
    public long? TotalBytes
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "totalBytes"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "totalBytes", value);
        }
    }

    /// <summary>
    /// Number of stored documents
    /// </summary>
    public long? TotalObjects
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "totalObjects"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "totalObjects", value);
        }
    }

    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.Description;
        _ = this.EnableGraph;
        _ = this.Name;
        _ = this.TotalBytes;
        _ = this.TotalObjects;
    }

    public VaultModel() { }

    public VaultModel(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VaultModel(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static VaultModel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VaultModelFromRaw : IFromRaw<VaultModel>
{
    public VaultModel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        VaultModel.FromRawUnchecked(rawData);
}
