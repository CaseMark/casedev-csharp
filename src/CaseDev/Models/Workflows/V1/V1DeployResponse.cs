using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;

namespace CaseDev.Models.Workflows.V1;

[JsonConverter(typeof(ModelConverter<V1DeployResponse, V1DeployResponseFromRaw>))]
public sealed record class V1DeployResponse : ModelBase
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

    /// <summary>
    /// Only returned once - save this!
    /// </summary>
    public string? WebhookSecret
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "webhookSecret"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "webhookSecret", value);
        }
    }

    public string? WebhookURL
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "webhookUrl"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "webhookUrl", value);
        }
    }

    public override void Validate()
    {
        _ = this.Message;
        _ = this.Success;
        _ = this.WebhookSecret;
        _ = this.WebhookURL;
    }

    public V1DeployResponse() { }

    public V1DeployResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1DeployResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static V1DeployResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class V1DeployResponseFromRaw : IFromRaw<V1DeployResponse>
{
    public V1DeployResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        V1DeployResponse.FromRawUnchecked(rawData);
}
