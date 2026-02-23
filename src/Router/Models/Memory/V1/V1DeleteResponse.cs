using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Router.Core;

namespace Router.Models.Memory.V1;

[JsonConverter(typeof(JsonModelConverter<V1DeleteResponse, V1DeleteResponseFromRaw>))]
public sealed record class V1DeleteResponse : JsonModel
{
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
        _ = this.Message;
        _ = this.Success;
    }

    public V1DeleteResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public V1DeleteResponse(V1DeleteResponse v1DeleteResponse)
        : base(v1DeleteResponse) { }
#pragma warning restore CS8618

    public V1DeleteResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1DeleteResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="V1DeleteResponseFromRaw.FromRawUnchecked"/>
    public static V1DeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class V1DeleteResponseFromRaw : IFromRawJson<V1DeleteResponse>
{
    /// <inheritdoc/>
    public V1DeleteResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        V1DeleteResponse.FromRawUnchecked(rawData);
}
