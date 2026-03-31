using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Casedev.Core;

namespace Casedev.Models.Agent.V2.Chat;

[JsonConverter(typeof(JsonModelConverter<ChatCancelResponse, ChatCancelResponseFromRaw>))]
public sealed record class ChatCancelResponse : JsonModel
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

    public bool? Ok
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("ok");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("ok", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Ok;
    }

    public ChatCancelResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChatCancelResponse(ChatCancelResponse chatCancelResponse)
        : base(chatCancelResponse) { }
#pragma warning restore CS8618

    public ChatCancelResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChatCancelResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChatCancelResponseFromRaw.FromRawUnchecked"/>
    public static ChatCancelResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChatCancelResponseFromRaw : IFromRawJson<ChatCancelResponse>
{
    /// <inheritdoc/>
    public ChatCancelResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ChatCancelResponse.FromRawUnchecked(rawData);
}
