using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Casedev.Core;

namespace Casedev.Models.Agent.V2.Chat;

[JsonConverter(typeof(JsonModelConverter<ChatDeleteResponse, ChatDeleteResponseFromRaw>))]
public sealed record class ChatDeleteResponse : JsonModel
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

    public double? Cost
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("cost");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("cost", value);
        }
    }

    public string? Provider
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("provider");
        }
        init { this._rawData.Set("provider", value); }
    }

    public string? RuntimeID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("runtimeId");
        }
        init { this._rawData.Set("runtimeId", value); }
    }

    public long? RuntimeMs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("runtimeMs");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("runtimeMs", value);
        }
    }

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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Cost;
        _ = this.Provider;
        _ = this.RuntimeID;
        _ = this.RuntimeMs;
        _ = this.Status;
    }

    public ChatDeleteResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChatDeleteResponse(ChatDeleteResponse chatDeleteResponse)
        : base(chatDeleteResponse) { }
#pragma warning restore CS8618

    public ChatDeleteResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChatDeleteResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChatDeleteResponseFromRaw.FromRawUnchecked"/>
    public static ChatDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChatDeleteResponseFromRaw : IFromRawJson<ChatDeleteResponse>
{
    /// <inheritdoc/>
    public ChatDeleteResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ChatDeleteResponse.FromRawUnchecked(rawData);
}
