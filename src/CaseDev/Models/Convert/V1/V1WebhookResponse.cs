using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;

namespace CaseDev.Models.Convert.V1;

[JsonConverter(typeof(ModelConverter<V1WebhookResponse, V1WebhookResponseFromRaw>))]
public sealed record class V1WebhookResponse : ModelBase
{
    public string? Message
    {
        get
        {
            if (!this._rawData.TryGetValue("message", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["message"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public bool? Success
    {
        get
        {
            if (!this._rawData.TryGetValue("success", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["success"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Message;
        _ = this.Success;
    }

    public V1WebhookResponse() { }

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

    public static V1WebhookResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class V1WebhookResponseFromRaw : IFromRaw<V1WebhookResponse>
{
    public V1WebhookResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        V1WebhookResponse.FromRawUnchecked(rawData);
}
