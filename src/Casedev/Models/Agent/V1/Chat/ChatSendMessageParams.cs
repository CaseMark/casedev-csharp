using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Casedev.Core;
using Casedev.Exceptions;
using System = System;

namespace Casedev.Models.Agent.V1.Chat;

/// <summary>
/// Sends a message and returns the complete response as a single JSON body. Blocks
/// until the agent turn completes.
///
/// <para>**When to use this endpoint:** Best for server-to-server integrations, background
/// processing, or any context where you want the full response in one call without
/// managing an SSE stream.</para>
///
/// <para>**Alternatives:** - `POST /chat/:id/respond` — streaming SSE with normalized
/// events (recommended for custom chat UIs)</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ChatSendMessageParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ID { get; init; }

    /// <summary>
    /// Message content parts. Currently only "text" type is supported. Additional
    /// types (e.g. file, image) may be added in future versions.
    /// </summary>
    public IReadOnlyList<ChatSendMessageParamsPart>? Parts
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<ChatSendMessageParamsPart>>(
                "parts"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<ChatSendMessageParamsPart>?>(
                "parts",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public ChatSendMessageParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChatSendMessageParams(ChatSendMessageParams chatSendMessageParams)
        : base(chatSendMessageParams)
    {
        this.ID = chatSendMessageParams.ID;

        this._rawBodyData = new(chatSendMessageParams._rawBodyData);
    }
#pragma warning restore CS8618

    public ChatSendMessageParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChatSendMessageParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ChatSendMessageParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["ID"] = JsonSerializer.SerializeToElement(this.ID),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(ChatSendMessageParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ID?.Equals(other.ID) ?? other.ID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/agent/v1/chat/{0}/message", this.ID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

[JsonConverter(
    typeof(JsonModelConverter<ChatSendMessageParamsPart, ChatSendMessageParamsPartFromRaw>)
)]
public sealed record class ChatSendMessageParamsPart : JsonModel
{
    /// <summary>
    /// The message text content
    /// </summary>
    public required string Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("text");
        }
        init { this._rawData.Set("text", value); }
    }

    /// <summary>
    /// Part type. Currently only "text" is supported.
    /// </summary>
    public required ApiEnum<string, ChatSendMessageParamsPartType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ChatSendMessageParamsPartType>>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Text;
        this.Type.Validate();
    }

    public ChatSendMessageParamsPart() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChatSendMessageParamsPart(ChatSendMessageParamsPart chatSendMessageParamsPart)
        : base(chatSendMessageParamsPart) { }
#pragma warning restore CS8618

    public ChatSendMessageParamsPart(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChatSendMessageParamsPart(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChatSendMessageParamsPartFromRaw.FromRawUnchecked"/>
    public static ChatSendMessageParamsPart FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChatSendMessageParamsPartFromRaw : IFromRawJson<ChatSendMessageParamsPart>
{
    /// <inheritdoc/>
    public ChatSendMessageParamsPart FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChatSendMessageParamsPart.FromRawUnchecked(rawData);
}

/// <summary>
/// Part type. Currently only "text" is supported.
/// </summary>
[JsonConverter(typeof(ChatSendMessageParamsPartTypeConverter))]
public enum ChatSendMessageParamsPartType
{
    Text,
}

sealed class ChatSendMessageParamsPartTypeConverter : JsonConverter<ChatSendMessageParamsPartType>
{
    public override ChatSendMessageParamsPartType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "text" => ChatSendMessageParamsPartType.Text,
            _ => (ChatSendMessageParamsPartType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChatSendMessageParamsPartType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChatSendMessageParamsPartType.Text => "text",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
