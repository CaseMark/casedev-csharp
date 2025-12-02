using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;

namespace CaseDev.Models.Llm.V1.Chat;

[JsonConverter(
    typeof(ModelConverter<ChatCreateCompletionResponse, ChatCreateCompletionResponseFromRaw>)
)]
public sealed record class ChatCreateCompletionResponse : ModelBase
{
    /// <summary>
    /// Unique identifier for the completion
    /// </summary>
    public string? ID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "id"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "id", value);
        }
    }

    public IReadOnlyList<Choice>? Choices
    {
        get { return ModelBase.GetNullableClass<List<Choice>>(this.RawData, "choices"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "choices", value);
        }
    }

    /// <summary>
    /// Unix timestamp of completion creation
    /// </summary>
    public long? Created
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "created"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "created", value);
        }
    }

    /// <summary>
    /// Model used for completion
    /// </summary>
    public string? Model
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "model"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "model", value);
        }
    }

    public string? Object
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "object"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "object", value);
        }
    }

    public Usage? Usage
    {
        get { return ModelBase.GetNullableClass<Usage>(this.RawData, "usage"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "usage", value);
        }
    }

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

    public static ChatCreateCompletionResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChatCreateCompletionResponseFromRaw : IFromRaw<ChatCreateCompletionResponse>
{
    public ChatCreateCompletionResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChatCreateCompletionResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<Choice, ChoiceFromRaw>))]
public sealed record class Choice : ModelBase
{
    public string? FinishReason
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "finish_reason"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "finish_reason", value);
        }
    }

    public long? Index
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "index"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "index", value);
        }
    }

    public ChoiceMessage? Message
    {
        get { return ModelBase.GetNullableClass<ChoiceMessage>(this.RawData, "message"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "message", value);
        }
    }

    public override void Validate()
    {
        _ = this.FinishReason;
        _ = this.Index;
        this.Message?.Validate();
    }

    public Choice() { }

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

    public static Choice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChoiceFromRaw : IFromRaw<Choice>
{
    public Choice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Choice.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<ChoiceMessage, ChoiceMessageFromRaw>))]
public sealed record class ChoiceMessage : ModelBase
{
    public string? Content
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "content"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "content", value);
        }
    }

    public string? Role
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "role"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "role", value);
        }
    }

    public override void Validate()
    {
        _ = this.Content;
        _ = this.Role;
    }

    public ChoiceMessage() { }

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

    public static ChoiceMessage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChoiceMessageFromRaw : IFromRaw<ChoiceMessage>
{
    public ChoiceMessage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ChoiceMessage.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<Usage, UsageFromRaw>))]
public sealed record class Usage : ModelBase
{
    public long? CompletionTokens
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "completion_tokens"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "completion_tokens", value);
        }
    }

    /// <summary>
    /// Cost in USD
    /// </summary>
    public double? Cost
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawData, "cost"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "cost", value);
        }
    }

    public long? PromptTokens
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "prompt_tokens"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "prompt_tokens", value);
        }
    }

    public long? TotalTokens
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "total_tokens"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "total_tokens", value);
        }
    }

    public override void Validate()
    {
        _ = this.CompletionTokens;
        _ = this.Cost;
        _ = this.PromptTokens;
        _ = this.TotalTokens;
    }

    public Usage() { }

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

    public static Usage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UsageFromRaw : IFromRaw<Usage>
{
    public Usage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Usage.FromRawUnchecked(rawData);
}
