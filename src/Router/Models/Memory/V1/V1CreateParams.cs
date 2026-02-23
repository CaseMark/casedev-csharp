using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Router.Core;
using Router.Exceptions;

namespace Router.Models.Memory.V1;

/// <summary>
/// Store memories from conversation messages. Automatically extracts facts and handles deduplication.
///
/// <para>Use tag_1 through tag_12 for filtering - these are generic indexed fields
/// you can use for any purpose: - Legal app: tag_1=client_id, tag_2=matter_id -
/// Healthcare: tag_1=patient_id, tag_2=encounter_id - E-commerce: tag_1=customer_id, tag_2=order_id</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class V1CreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Conversation messages to extract memories from
    /// </summary>
    public required IReadOnlyList<Message> Messages
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<ImmutableArray<Message>>("messages");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<Message>>(
                "messages",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Custom category (e.g., "fact", "preference", "deadline")
    /// </summary>
    public string? Category
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("category");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("category", value);
        }
    }

    /// <summary>
    /// Optional custom prompt for fact extraction
    /// </summary>
    public string? ExtractionPrompt
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("extraction_prompt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("extraction_prompt", value);
        }
    }

    /// <summary>
    /// Whether to extract facts from messages (default: true)
    /// </summary>
    public bool? Infer
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("infer");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("infer", value);
        }
    }

    /// <summary>
    /// Additional metadata (not indexed)
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Metadata
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "metadata"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<FrozenDictionary<string, JsonElement>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Generic indexed filter field 1 (you decide what it means)
    /// </summary>
    public string? Tag1
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("tag_1");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("tag_1", value);
        }
    }

    /// <summary>
    /// Generic indexed filter field 10
    /// </summary>
    public string? Tag10
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("tag_10");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("tag_10", value);
        }
    }

    /// <summary>
    /// Generic indexed filter field 11
    /// </summary>
    public string? Tag11
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("tag_11");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("tag_11", value);
        }
    }

    /// <summary>
    /// Generic indexed filter field 12
    /// </summary>
    public string? Tag12
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("tag_12");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("tag_12", value);
        }
    }

    /// <summary>
    /// Generic indexed filter field 2
    /// </summary>
    public string? Tag2
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("tag_2");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("tag_2", value);
        }
    }

    /// <summary>
    /// Generic indexed filter field 3
    /// </summary>
    public string? Tag3
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("tag_3");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("tag_3", value);
        }
    }

    /// <summary>
    /// Generic indexed filter field 4
    /// </summary>
    public string? Tag4
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("tag_4");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("tag_4", value);
        }
    }

    /// <summary>
    /// Generic indexed filter field 5
    /// </summary>
    public string? Tag5
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("tag_5");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("tag_5", value);
        }
    }

    /// <summary>
    /// Generic indexed filter field 6
    /// </summary>
    public string? Tag6
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("tag_6");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("tag_6", value);
        }
    }

    /// <summary>
    /// Generic indexed filter field 7
    /// </summary>
    public string? Tag7
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("tag_7");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("tag_7", value);
        }
    }

    /// <summary>
    /// Generic indexed filter field 8
    /// </summary>
    public string? Tag8
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("tag_8");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("tag_8", value);
        }
    }

    /// <summary>
    /// Generic indexed filter field 9
    /// </summary>
    public string? Tag9
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("tag_9");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("tag_9", value);
        }
    }

    public V1CreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public V1CreateParams(V1CreateParams v1CreateParams)
        : base(v1CreateParams)
    {
        this._rawBodyData = new(v1CreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public V1CreateParams(
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
    V1CreateParams(
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

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static V1CreateParams FromRawUnchecked(
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

    public virtual bool Equals(V1CreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/memory/v1")
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

[JsonConverter(typeof(JsonModelConverter<Message, MessageFromRaw>))]
public sealed record class Message : JsonModel
{
    /// <summary>
    /// Message content
    /// </summary>
    public required string Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("content");
        }
        init { this._rawData.Set("content", value); }
    }

    /// <summary>
    /// Message role
    /// </summary>
    public required ApiEnum<string, Role> Role
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Role>>("role");
        }
        init { this._rawData.Set("role", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Content;
        this.Role.Validate();
    }

    public Message() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Message(Message message)
        : base(message) { }
#pragma warning restore CS8618

    public Message(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Message(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MessageFromRaw.FromRawUnchecked"/>
    public static Message FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MessageFromRaw : IFromRawJson<Message>
{
    /// <inheritdoc/>
    public Message FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Message.FromRawUnchecked(rawData);
}

/// <summary>
/// Message role
/// </summary>
[JsonConverter(typeof(RoleConverter))]
public enum Role
{
    User,
    Assistant,
    System,
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
            "user" => Role.User,
            "assistant" => Role.Assistant,
            "system" => Role.System,
            _ => (Role)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Role value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Role.User => "user",
                Role.Assistant => "assistant",
                Role.System => "system",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
