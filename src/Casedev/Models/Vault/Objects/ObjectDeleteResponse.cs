using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Casedev.Core;

namespace Casedev.Models.Vault.Objects;

[JsonConverter(typeof(JsonModelConverter<ObjectDeleteResponse, ObjectDeleteResponseFromRaw>))]
public sealed record class ObjectDeleteResponse : JsonModel
{
    public DeletedObject? DeletedObject
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<DeletedObject>("deletedObject");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("deletedObject", value);
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
        this.DeletedObject?.Validate();
        _ = this.Success;
    }

    public ObjectDeleteResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ObjectDeleteResponse(ObjectDeleteResponse objectDeleteResponse)
        : base(objectDeleteResponse) { }
#pragma warning restore CS8618

    public ObjectDeleteResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ObjectDeleteResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ObjectDeleteResponseFromRaw.FromRawUnchecked"/>
    public static ObjectDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ObjectDeleteResponseFromRaw : IFromRawJson<ObjectDeleteResponse>
{
    /// <inheritdoc/>
    public ObjectDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ObjectDeleteResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<DeletedObject, DeletedObjectFromRaw>))]
public sealed record class DeletedObject : JsonModel
{
    /// <summary>
    /// Deleted object ID
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
    /// Original filename
    /// </summary>
    public string? Filename
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("filename");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("filename", value);
        }
    }

    /// <summary>
    /// Size of deleted file in bytes
    /// </summary>
    public long? SizeBytes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("sizeBytes");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("sizeBytes", value);
        }
    }

    /// <summary>
    /// Number of vectors deleted
    /// </summary>
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
        _ = this.Filename;
        _ = this.SizeBytes;
        _ = this.VectorsDeleted;
    }

    public DeletedObject() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DeletedObject(DeletedObject deletedObject)
        : base(deletedObject) { }
#pragma warning restore CS8618

    public DeletedObject(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DeletedObject(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DeletedObjectFromRaw.FromRawUnchecked"/>
    public static DeletedObject FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DeletedObjectFromRaw : IFromRawJson<DeletedObject>
{
    /// <inheritdoc/>
    public DeletedObject FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DeletedObject.FromRawUnchecked(rawData);
}
