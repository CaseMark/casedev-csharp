using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Casedev.Core;

namespace Casedev.Models.Agent.V1.Chat;

[JsonConverter(typeof(JsonModelConverter<ChatCreateResponse, ChatCreateResponseFromRaw>))]
public sealed record class ChatCreateResponse : JsonModel
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

    public DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("createdAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("createdAt", value);
        }
    }

    public long? IdleTimeoutMs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("idleTimeoutMs");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("idleTimeoutMs", value);
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
        _ = this.CreatedAt;
        _ = this.IdleTimeoutMs;
        _ = this.Status;
    }

    public ChatCreateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChatCreateResponse(ChatCreateResponse chatCreateResponse)
        : base(chatCreateResponse) { }
#pragma warning restore CS8618

    public ChatCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChatCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChatCreateResponseFromRaw.FromRawUnchecked"/>
    public static ChatCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChatCreateResponseFromRaw : IFromRawJson<ChatCreateResponse>
{
    /// <inheritdoc/>
    public ChatCreateResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ChatCreateResponse.FromRawUnchecked(rawData);
}
