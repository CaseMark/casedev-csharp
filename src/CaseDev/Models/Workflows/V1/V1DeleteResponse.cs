using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;

namespace CaseDev.Models.Workflows.V1;

[JsonConverter(typeof(ModelConverter<V1DeleteResponse, V1DeleteResponseFromRaw>))]
public sealed record class V1DeleteResponse : ModelBase
{
    public string? Message
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "message"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "message", value);
        }
    }

    public bool? Success
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "success"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "success", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Message;
        _ = this.Success;
    }

    public V1DeleteResponse() { }

    public V1DeleteResponse(V1DeleteResponse v1DeleteResponse)
        : base(v1DeleteResponse) { }

    public V1DeleteResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1DeleteResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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

class V1DeleteResponseFromRaw : IFromRaw<V1DeleteResponse>
{
    /// <inheritdoc/>
    public V1DeleteResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        V1DeleteResponse.FromRawUnchecked(rawData);
}
