using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;

namespace CaseDev.Models.Llm.V1.Chat;

[JsonConverter(
    typeof(JsonModelConverter<ChatCreateCompletionResponse, ChatCreateCompletionResponseFromRaw>)
)]
public sealed record class ChatCreateCompletionResponse : JsonModel
{
    /// <summary>
    /// Unique identifier for the completion
    /// </summary>
    public string? ID
    {
        get { return this._rawData.GetNullableClass<string>("id"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    public IReadOnlyList<Choice>? Choices
    {
        get { return this._rawData.GetNullableStruct<ImmutableArray<Choice>>("choices"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Choice>?>(
                "choices",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Unix timestamp of completion creation
    /// </summary>
    public long? Created
    {
        get { return this._rawData.GetNullableStruct<long>("created"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("created", value);
        }
    }

    /// <summary>
    /// Model used for completion
    /// </summary>
    public string? Model
    {
        get { return this._rawData.GetNullableClass<string>("model"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("model", value);
        }
    }

    public string? Object
    {
        get { return this._rawData.GetNullableClass<string>("object"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("object", value);
        }
    }

    public Usage? Usage
    {
        get { return this._rawData.GetNullableClass<Usage>("usage"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("usage", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        foreach (var item in this.Choices ?? [])
        {
            item.Validate();
        }
        _ = this.Created;
        _ = this.Model;
        _ = this.Object;
        this.Usage?.Validate();
    }

    public ChatCreateCompletionResponse() { }

    public ChatCreateCompletionResponse(ChatCreateCompletionResponse chatCreateCompletionResponse)
        : base(chatCreateCompletionResponse) { }

    public ChatCreateCompletionResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChatCreateCompletionResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChatCreateCompletionResponseFromRaw.FromRawUnchecked"/>
    public static ChatCreateCompletionResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChatCreateCompletionResponseFromRaw : IFromRawJson<ChatCreateCompletionResponse>
{
    /// <inheritdoc/>
    public ChatCreateCompletionResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChatCreateCompletionResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Choice, ChoiceFromRaw>))]
public sealed record class Choice : JsonModel
{
    public string? FinishReason
    {
        get { return this._rawData.GetNullableClass<string>("finish_reason"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("finish_reason", value);
        }
    }

    public long? Index
    {
        get { return this._rawData.GetNullableStruct<long>("index"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("index", value);
        }
    }

    public ChoiceMessage? Message
    {
        get { return this._rawData.GetNullableClass<ChoiceMessage>("message"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("message", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FinishReason;
        _ = this.Index;
        this.Message?.Validate();
    }

    public Choice() { }

    public Choice(Choice choice)
        : base(choice) { }

    public Choice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Choice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChoiceFromRaw.FromRawUnchecked"/>
    public static Choice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChoiceFromRaw : IFromRawJson<Choice>
{
    /// <inheritdoc/>
    public Choice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Choice.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<ChoiceMessage, ChoiceMessageFromRaw>))]
public sealed record class ChoiceMessage : JsonModel
{
    public string? Content
    {
        get { return this._rawData.GetNullableClass<string>("content"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("content", value);
        }
    }

    public string? Role
    {
        get { return this._rawData.GetNullableClass<string>("role"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("role", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Content;
        _ = this.Role;
    }

    public ChoiceMessage() { }

    public ChoiceMessage(ChoiceMessage choiceMessage)
        : base(choiceMessage) { }

    public ChoiceMessage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChoiceMessage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChoiceMessageFromRaw.FromRawUnchecked"/>
    public static ChoiceMessage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChoiceMessageFromRaw : IFromRawJson<ChoiceMessage>
{
    /// <inheritdoc/>
    public ChoiceMessage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ChoiceMessage.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Usage, UsageFromRaw>))]
public sealed record class Usage : JsonModel
{
    public long? CompletionTokens
    {
        get { return this._rawData.GetNullableStruct<long>("completion_tokens"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("completion_tokens", value);
        }
    }

    /// <summary>
    /// Cost in USD
    /// </summary>
    public double? Cost
    {
        get { return this._rawData.GetNullableStruct<double>("cost"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("cost", value);
        }
    }

    public long? PromptTokens
    {
        get { return this._rawData.GetNullableStruct<long>("prompt_tokens"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("prompt_tokens", value);
        }
    }

    public long? TotalTokens
    {
        get { return this._rawData.GetNullableStruct<long>("total_tokens"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("total_tokens", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CompletionTokens;
        _ = this.Cost;
        _ = this.PromptTokens;
        _ = this.TotalTokens;
    }

    public Usage() { }

    public Usage(Usage usage)
        : base(usage) { }

    public Usage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Usage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UsageFromRaw.FromRawUnchecked"/>
    public static Usage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UsageFromRaw : IFromRawJson<Usage>
{
    /// <inheritdoc/>
    public Usage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Usage.FromRawUnchecked(rawData);
}
