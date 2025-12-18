using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;

namespace CaseDev.Models.Workflows.V1;

[JsonConverter(typeof(JsonModelConverter<V1UndeployResponse, V1UndeployResponseFromRaw>))]
public sealed record class V1UndeployResponse : JsonModel
{
    public string? Message
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "message"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "message", value);
        }
    }

    public bool? Success
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "success"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "success", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Message;
        _ = this.Success;
    }

    public V1UndeployResponse() { }

    public V1UndeployResponse(V1UndeployResponse v1UndeployResponse)
        : base(v1UndeployResponse) { }

    public V1UndeployResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1UndeployResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="V1UndeployResponseFromRaw.FromRawUnchecked"/>
    public static V1UndeployResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class V1UndeployResponseFromRaw : IFromRawJson<V1UndeployResponse>
{
    /// <inheritdoc/>
    public V1UndeployResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        V1UndeployResponse.FromRawUnchecked(rawData);
}
