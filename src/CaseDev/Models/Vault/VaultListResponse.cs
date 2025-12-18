using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;

namespace CaseDev.Models.Vault;

[JsonConverter(typeof(JsonModelConverter<VaultListResponse, VaultListResponseFromRaw>))]
public sealed record class VaultListResponse : JsonModel
{
    /// <summary>
    /// Total number of vaults
    /// </summary>
    public long? Total
    {
        get { return JsonModel.GetNullableStruct<long>(this.RawData, "total"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "total", value);
        }
    }

    public IReadOnlyList<VaultListResponseVault>? Vaults
    {
        get
        {
            return JsonModel.GetNullableClass<List<VaultListResponseVault>>(this.RawData, "vaults");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "vaults", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Total;
        foreach (var item in this.Vaults ?? [])
        {
            item.Validate();
        }
    }

    public VaultListResponse() { }

    public VaultListResponse(VaultListResponse vaultListResponse)
        : base(vaultListResponse) { }

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

    /// <inheritdoc cref="VaultListResponseFromRaw.FromRawUnchecked"/>
    public static VaultListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VaultListResponseFromRaw : IFromRawJson<VaultListResponse>
{
    /// <inheritdoc/>
    public VaultListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        VaultListResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<VaultListResponseVault, VaultListResponseVaultFromRaw>))]
public sealed record class VaultListResponseVault : JsonModel
{
    /// <summary>
    /// Vault identifier
    /// </summary>
    public string? ID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "id"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "id", value);
        }
    }

    /// <summary>
    /// Vault creation timestamp
    /// </summary>
    public DateTimeOffset? CreatedAt
    {
        get { return JsonModel.GetNullableStruct<DateTimeOffset>(this.RawData, "createdAt"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "createdAt", value);
        }
    }

    /// <summary>
    /// Vault description
    /// </summary>
    public string? Description
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "description"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "description", value);
        }
    }

    /// <summary>
    /// Whether GraphRAG is enabled
    /// </summary>
    public bool? EnableGraph
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "enableGraph"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "enableGraph", value);
        }
    }

    /// <summary>
    /// Vault name
    /// </summary>
    public string? Name
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "name"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "name", value);
        }
    }

    /// <summary>
    /// Total storage size in bytes
    /// </summary>
    public long? TotalBytes
    {
        get { return JsonModel.GetNullableStruct<long>(this.RawData, "totalBytes"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "totalBytes", value);
        }
    }

    /// <summary>
    /// Number of stored documents
    /// </summary>
    public long? TotalObjects
    {
        get { return JsonModel.GetNullableStruct<long>(this.RawData, "totalObjects"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "totalObjects", value);
        }
    }

    /// <inheritdoc/>
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

    public VaultListResponseVault() { }

    public VaultListResponseVault(VaultListResponseVault vaultListResponseVault)
        : base(vaultListResponseVault) { }

    public VaultListResponseVault(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VaultListResponseVault(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VaultListResponseVaultFromRaw.FromRawUnchecked"/>
    public static VaultListResponseVault FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VaultListResponseVaultFromRaw : IFromRawJson<VaultListResponseVault>
{
    /// <inheritdoc/>
    public VaultListResponseVault FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VaultListResponseVault.FromRawUnchecked(rawData);
}
