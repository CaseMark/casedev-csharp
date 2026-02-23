using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Router.Core;

namespace Router.Models.Vault;

[JsonConverter(typeof(JsonModelConverter<VaultDeleteResponse, VaultDeleteResponseFromRaw>))]
public sealed record class VaultDeleteResponse : JsonModel
{
    public DeletedVault? DeletedVault
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<DeletedVault>("deletedVault");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("deletedVault", value);
        }
    }

    /// <summary>
    /// Either 'deleted' or 'deletion_queued'
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

    public bool? Success
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("success");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("success", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.DeletedVault?.Validate();
        _ = this.Status;
        _ = this.Success;
    }

    public VaultDeleteResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VaultDeleteResponse(VaultDeleteResponse vaultDeleteResponse)
        : base(vaultDeleteResponse) { }
#pragma warning restore CS8618

    public VaultDeleteResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VaultDeleteResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VaultDeleteResponseFromRaw.FromRawUnchecked"/>
    public static VaultDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VaultDeleteResponseFromRaw : IFromRawJson<VaultDeleteResponse>
{
    /// <inheritdoc/>
    public VaultDeleteResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        VaultDeleteResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<DeletedVault, DeletedVaultFromRaw>))]
public sealed record class DeletedVault : JsonModel
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

    public long? BytesFreed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("bytesFreed");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("bytesFreed", value);
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

    public long? ObjectsDeleted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("objectsDeleted");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("objectsDeleted", value);
        }
    }

    public long? VectorsDeleted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("vectorsDeleted");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("vectorsDeleted", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.BytesFreed;
        _ = this.Name;
        _ = this.ObjectsDeleted;
        _ = this.VectorsDeleted;
    }

    public DeletedVault() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DeletedVault(DeletedVault deletedVault)
        : base(deletedVault) { }
#pragma warning restore CS8618

    public DeletedVault(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DeletedVault(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DeletedVaultFromRaw.FromRawUnchecked"/>
    public static DeletedVault FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DeletedVaultFromRaw : IFromRawJson<DeletedVault>
{
    /// <inheritdoc/>
    public DeletedVault FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DeletedVault.FromRawUnchecked(rawData);
}
