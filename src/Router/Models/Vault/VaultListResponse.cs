using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Router.Core;

namespace Router.Models.Vault;

[JsonConverter(typeof(JsonModelConverter<VaultListResponse, VaultListResponseFromRaw>))]
public sealed record class VaultListResponse : JsonModel
{
    /// <summary>
    /// Total number of vaults
    /// </summary>
    public long? Total
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("total");
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

    public IReadOnlyList<VaultListResponseVault>? Vaults
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<VaultListResponseVault>>(
                "vaults"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<VaultListResponseVault>?>(
                "vaults",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VaultListResponse(VaultListResponse vaultListResponse)
        : base(vaultListResponse) { }
#pragma warning restore CS8618

    public VaultListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VaultListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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

    /// <summary>
    /// Vault creation timestamp
    /// </summary>
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

    /// <summary>
    /// Vault description
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
    /// Whether GraphRAG is enabled
    /// </summary>
    public bool? EnableGraph
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("enableGraph");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("enableGraph", value);
        }
    }

    /// <summary>
    /// Vault name
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
    /// Total storage size in bytes
    /// </summary>
    public long? TotalBytes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("totalBytes");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("totalBytes", value);
        }
    }

    /// <summary>
    /// Number of stored documents
    /// </summary>
    public long? TotalObjects
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("totalObjects");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("totalObjects", value);
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VaultListResponseVault(VaultListResponseVault vaultListResponseVault)
        : base(vaultListResponseVault) { }
#pragma warning restore CS8618

    public VaultListResponseVault(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VaultListResponseVault(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
