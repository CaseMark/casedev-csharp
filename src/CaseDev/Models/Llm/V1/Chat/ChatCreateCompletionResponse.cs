using System.Collections.Frozen;
using System.Collections.Generic;
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
        get { return JsonModel.GetNullableClass<string>(this.RawData, "id"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "id", value);
        }
    }

    public IReadOnlyList<Choice>? Choices
    {
        get { return JsonModel.GetNullableClass<List<Choice>>(this.RawData, "choices"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "choices", value);
        }
    }

    /// <summary>
    /// Unix timestamp of completion creation
    /// </summary>
    public long? Created
    {
        get { return JsonModel.GetNullableStruct<long>(this.RawData, "created"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "created", value);
        }
    }

    /// <summary>
    /// Model used for completion
    /// </summary>
    public string? Model
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "model"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "model", value);
        }
    }

    public string? Object
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "object"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "object", value);
        }
    }

    public Usage? Usage
    {
        get { return JsonModel.GetNullableClass<Usage>(this.RawData, "usage"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "usage", value);
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
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChatCreateCompletionResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
        get { return JsonModel.GetNullableClass<string>(this.RawData, "finish_reason"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "finish_reason", value);
        }
    }

    public long? Index
    {
        get { return JsonModel.GetNullableStruct<long>(this.RawData, "index"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "index", value);
        }
    }

    public ChoiceMessage? Message
    {
        get { return JsonModel.GetNullableClass<ChoiceMessage>(this.RawData, "message"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "message", value);
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
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Choice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
        get { return JsonModel.GetNullableClass<string>(this.RawData, "content"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "content", value);
        }
    }

    public string? Role
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "role"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "role", value);
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
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChoiceMessage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
        get { return JsonModel.GetNullableStruct<long>(this.RawData, "completion_tokens"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "completion_tokens", value);
        }
    }

    /// <summary>
    /// Cost in USD
    /// </summary>
    public double? Cost
    {
        get { return JsonModel.GetNullableStruct<double>(this.RawData, "cost"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "cost", value);
        }
    }

    public long? PromptTokens
    {
        get { return JsonModel.GetNullableStruct<long>(this.RawData, "prompt_tokens"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "prompt_tokens", value);
        }
    }

    public long? TotalTokens
    {
        get { return JsonModel.GetNullableStruct<long>(this.RawData, "total_tokens"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "total_tokens", value);
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
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Usage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
