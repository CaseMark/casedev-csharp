using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;
using CaseDev.Exceptions;

namespace CaseDev.Models.Llm.V1.Chat;

/// <summary>
/// Create a completion for the provided prompt and parameters. Compatible with OpenAI's
/// chat completions API. Supports 40+ models including GPT-4, Claude, Gemini, and
/// CaseMark legal AI models. Includes streaming support, token counting, and usage tracking.
/// </summary>
public sealed record class ChatCreateCompletionParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// List of messages comprising the conversation
    /// </summary>
    public required IReadOnlyList<Message> Messages
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("messages", out JsonElement element))
                throw new CasedevInvalidDataException(
                    "'messages' cannot be null",
                    new ArgumentOutOfRangeException("messages", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<Message>>(element, ModelBase.SerializerOptions)
                ?? throw new CasedevInvalidDataException(
                    "'messages' cannot be null",
                    new ArgumentNullException("messages")
                );
        }
        init
        {
            this._rawBodyData["messages"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Frequency penalty parameter
    /// </summary>
    public double? FrequencyPenalty
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("frequency_penalty", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData["frequency_penalty"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Maximum number of tokens to generate
    /// </summary>
    public long? MaxTokens
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("max_tokens", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData["max_tokens"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Model to use for completion. Defaults to casemark-core-1 if not specified
    /// </summary>
    public string? Model
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("model", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData["model"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Presence penalty parameter
    /// </summary>
    public double? PresencePenalty
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("presence_penalty", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData["presence_penalty"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Whether to stream back partial progress
    /// </summary>
    public bool? Stream
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("stream", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData["stream"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Sampling temperature between 0 and 2
    /// </summary>
    public double? Temperature
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("temperature", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData["temperature"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Nucleus sampling parameter
    /// </summary>
    public double? TopP
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("top_p", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData["top_p"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public ChatCreateCompletionParams() { }

    public ChatCreateCompletionParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChatCreateCompletionParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }
#pragma warning restore CS8618

    public static ChatCreateCompletionParams FromRawUnchecked(
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

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/llm/v1/chat/completions")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override StringContent? BodyContent()
    {
        return new(JsonSerializer.Serialize(this.RawBodyData), Encoding.UTF8, "application/json");
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}

[JsonConverter(typeof(ModelConverter<Message, MessageFromRaw>))]
public sealed record class Message : ModelBase
{
    /// <summary>
    /// The contents of the message
    /// </summary>
    public string? Content
    {
        get
        {
            if (!this._rawData.TryGetValue("content", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["content"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The role of the message author
    /// </summary>
    public ApiEnum<string, Role>? Role
    {
        get
        {
            if (!this._rawData.TryGetValue("role", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, Role>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["role"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Content;
        this.Role?.Validate();
    }

    public Message() { }

    public Message(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Message(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Message FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MessageFromRaw : IFromRaw<Message>
{
    public Message FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Message.FromRawUnchecked(rawData);
}

/// <summary>
/// The role of the message author
/// </summary>
[JsonConverter(typeof(RoleConverter))]
public enum Role
{
    System,
    User,
    Assistant,
}

sealed class RoleConverter : JsonConverter<Role>
{
    public override Role Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "system" => Role.System,
            "user" => Role.User,
            "assistant" => Role.Assistant,
            _ => (Role)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Role value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Role.System => "system",
                Role.User => "user",
                Role.Assistant => "assistant",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
