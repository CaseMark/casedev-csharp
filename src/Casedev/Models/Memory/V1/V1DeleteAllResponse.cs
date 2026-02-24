using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Casedev.Core;

namespace Casedev.Models.Memory.V1;

[JsonConverter(typeof(JsonModelConverter<V1DeleteAllResponse, V1DeleteAllResponseFromRaw>))]
public sealed record class V1DeleteAllResponse : JsonModel
{
    /// <summary>
    /// Number of memories deleted
    /// </summary>
    public long? Deleted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("deleted");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("deleted", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Deleted;
    }

    public V1DeleteAllResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public V1DeleteAllResponse(V1DeleteAllResponse v1DeleteAllResponse)
        : base(v1DeleteAllResponse) { }
#pragma warning restore CS8618

    public V1DeleteAllResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1DeleteAllResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="V1DeleteAllResponseFromRaw.FromRawUnchecked"/>
    public static V1DeleteAllResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class V1DeleteAllResponseFromRaw : IFromRawJson<V1DeleteAllResponse>
{
    /// <inheritdoc/>
    public V1DeleteAllResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        V1DeleteAllResponse.FromRawUnchecked(rawData);
}
