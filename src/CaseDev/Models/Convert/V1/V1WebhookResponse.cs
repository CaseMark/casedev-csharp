using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;

namespace CaseDev.Models.Convert.V1;

[JsonConverter(typeof(JsonModelConverter<V1WebhookResponse, V1WebhookResponseFromRaw>))]
public sealed record class V1WebhookResponse : JsonModel
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

    public V1WebhookResponse() { }

    public V1WebhookResponse(V1WebhookResponse v1WebhookResponse)
        : base(v1WebhookResponse) { }

    public V1WebhookResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1WebhookResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="V1WebhookResponseFromRaw.FromRawUnchecked"/>
    public static V1WebhookResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class V1WebhookResponseFromRaw : IFromRawJson<V1WebhookResponse>
{
    /// <inheritdoc/>
    public V1WebhookResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        V1WebhookResponse.FromRawUnchecked(rawData);
}
