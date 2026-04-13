using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Casedev.Core;

namespace Casedev.Models.Agent.V2.Chat;

[JsonConverter(
    typeof(JsonModelConverter<ChatCreateStreamTokenResponse, ChatCreateStreamTokenResponseFromRaw>)
)]
public sealed record class ChatCreateStreamTokenResponse : JsonModel
{
    public required string Token
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("token");
        }
        init { this._rawData.Set("token", value); }
    }

    public required DateTimeOffset ExpiresAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("expiresAt");
        }
        init { this._rawData.Set("expiresAt", value); }
    }

    public required string StreamUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("streamUrl");
        }
        init { this._rawData.Set("streamUrl", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Token;
        _ = this.ExpiresAt;
        _ = this.StreamUrl;
    }

    public ChatCreateStreamTokenResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChatCreateStreamTokenResponse(
        ChatCreateStreamTokenResponse chatCreateStreamTokenResponse
    )
        : base(chatCreateStreamTokenResponse) { }
#pragma warning restore CS8618

    public ChatCreateStreamTokenResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChatCreateStreamTokenResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChatCreateStreamTokenResponseFromRaw.FromRawUnchecked"/>
    public static ChatCreateStreamTokenResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChatCreateStreamTokenResponseFromRaw : IFromRawJson<ChatCreateStreamTokenResponse>
{
    /// <inheritdoc/>
    public ChatCreateStreamTokenResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChatCreateStreamTokenResponse.FromRawUnchecked(rawData);
}
