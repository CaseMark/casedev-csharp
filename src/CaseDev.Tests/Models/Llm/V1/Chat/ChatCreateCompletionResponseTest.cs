using System.Collections.Generic;
using System.Text.Json;
using CaseDev.Models.Llm.V1.Chat;

namespace CaseDev.Tests.Models.Llm.V1.Chat;

public class ChatCreateCompletionResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChatCreateCompletionResponse
        {
            ID = "id",
            Choices =
            [
                new()
                {
                    FinishReason = "finish_reason",
                    Index = 0,
                    Message = new() { Content = "content", Role = "role" },
                },
            ],
            Created = 0,
            Model = "model",
            Object = "chat.completion",
            Usage = new()
            {
                CompletionTokens = 0,
                Cost = 0,
                PromptTokens = 0,
                TotalTokens = 0,
            },
        };

        string expectedID = "id";
        List<Choice> expectedChoices =
        [
            new()
            {
                FinishReason = "finish_reason",
                Index = 0,
                Message = new() { Content = "content", Role = "role" },
            },
        ];
        long expectedCreated = 0;
        string expectedModel = "model";
        string expectedObject = "chat.completion";
        Usage expectedUsage = new()
        {
            CompletionTokens = 0,
            Cost = 0,
            PromptTokens = 0,
            TotalTokens = 0,
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedChoices.Count, model.Choices.Count);
        for (int i = 0; i < expectedChoices.Count; i++)
        {
            Assert.Equal(expectedChoices[i], model.Choices[i]);
        }
        Assert.Equal(expectedCreated, model.Created);
        Assert.Equal(expectedModel, model.Model);
        Assert.Equal(expectedObject, model.Object);
        Assert.Equal(expectedUsage, model.Usage);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChatCreateCompletionResponse
        {
            ID = "id",
            Choices =
            [
                new()
                {
                    FinishReason = "finish_reason",
                    Index = 0,
                    Message = new() { Content = "content", Role = "role" },
                },
            ],
            Created = 0,
            Model = "model",
            Object = "chat.completion",
            Usage = new()
            {
                CompletionTokens = 0,
                Cost = 0,
                PromptTokens = 0,
                TotalTokens = 0,
            },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ChatCreateCompletionResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChatCreateCompletionResponse
        {
            ID = "id",
            Choices =
            [
                new()
                {
                    FinishReason = "finish_reason",
                    Index = 0,
                    Message = new() { Content = "content", Role = "role" },
                },
            ],
            Created = 0,
            Model = "model",
            Object = "chat.completion",
            Usage = new()
            {
                CompletionTokens = 0,
                Cost = 0,
                PromptTokens = 0,
                TotalTokens = 0,
            },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ChatCreateCompletionResponse>(json);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        List<Choice> expectedChoices =
        [
            new()
            {
                FinishReason = "finish_reason",
                Index = 0,
                Message = new() { Content = "content", Role = "role" },
            },
        ];
        long expectedCreated = 0;
        string expectedModel = "model";
        string expectedObject = "chat.completion";
        Usage expectedUsage = new()
        {
            CompletionTokens = 0,
            Cost = 0,
            PromptTokens = 0,
            TotalTokens = 0,
        };

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedChoices.Count, deserialized.Choices.Count);
        for (int i = 0; i < expectedChoices.Count; i++)
        {
            Assert.Equal(expectedChoices[i], deserialized.Choices[i]);
        }
        Assert.Equal(expectedCreated, deserialized.Created);
        Assert.Equal(expectedModel, deserialized.Model);
        Assert.Equal(expectedObject, deserialized.Object);
        Assert.Equal(expectedUsage, deserialized.Usage);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChatCreateCompletionResponse
        {
            ID = "id",
            Choices =
            [
                new()
                {
                    FinishReason = "finish_reason",
                    Index = 0,
                    Message = new() { Content = "content", Role = "role" },
                },
            ],
            Created = 0,
            Model = "model",
            Object = "chat.completion",
            Usage = new()
            {
                CompletionTokens = 0,
                Cost = 0,
                PromptTokens = 0,
                TotalTokens = 0,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ChatCreateCompletionResponse { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Choices);
        Assert.False(model.RawData.ContainsKey("choices"));
        Assert.Null(model.Created);
        Assert.False(model.RawData.ContainsKey("created"));
        Assert.Null(model.Model);
        Assert.False(model.RawData.ContainsKey("model"));
        Assert.Null(model.Object);
        Assert.False(model.RawData.ContainsKey("object"));
        Assert.Null(model.Usage);
        Assert.False(model.RawData.ContainsKey("usage"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ChatCreateCompletionResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ChatCreateCompletionResponse
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            Choices = null,
            Created = null,
            Model = null,
            Object = null,
            Usage = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Choices);
        Assert.False(model.RawData.ContainsKey("choices"));
        Assert.Null(model.Created);
        Assert.False(model.RawData.ContainsKey("created"));
        Assert.Null(model.Model);
        Assert.False(model.RawData.ContainsKey("model"));
        Assert.Null(model.Object);
        Assert.False(model.RawData.ContainsKey("object"));
        Assert.Null(model.Usage);
        Assert.False(model.RawData.ContainsKey("usage"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ChatCreateCompletionResponse
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            Choices = null,
            Created = null,
            Model = null,
            Object = null,
            Usage = null,
        };

        model.Validate();
    }
}

public class ChoiceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Choice
        {
            FinishReason = "finish_reason",
            Index = 0,
            Message = new() { Content = "content", Role = "role" },
        };

        string expectedFinishReason = "finish_reason";
        long expectedIndex = 0;
        ChoiceMessage expectedMessage = new() { Content = "content", Role = "role" };

        Assert.Equal(expectedFinishReason, model.FinishReason);
        Assert.Equal(expectedIndex, model.Index);
        Assert.Equal(expectedMessage, model.Message);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Choice
        {
            FinishReason = "finish_reason",
            Index = 0,
            Message = new() { Content = "content", Role = "role" },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Choice>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Choice
        {
            FinishReason = "finish_reason",
            Index = 0,
            Message = new() { Content = "content", Role = "role" },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Choice>(json);
        Assert.NotNull(deserialized);

        string expectedFinishReason = "finish_reason";
        long expectedIndex = 0;
        ChoiceMessage expectedMessage = new() { Content = "content", Role = "role" };

        Assert.Equal(expectedFinishReason, deserialized.FinishReason);
        Assert.Equal(expectedIndex, deserialized.Index);
        Assert.Equal(expectedMessage, deserialized.Message);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Choice
        {
            FinishReason = "finish_reason",
            Index = 0,
            Message = new() { Content = "content", Role = "role" },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Choice { };

        Assert.Null(model.FinishReason);
        Assert.False(model.RawData.ContainsKey("finish_reason"));
        Assert.Null(model.Index);
        Assert.False(model.RawData.ContainsKey("index"));
        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Choice { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Choice
        {
            // Null should be interpreted as omitted for these properties
            FinishReason = null,
            Index = null,
            Message = null,
        };

        Assert.Null(model.FinishReason);
        Assert.False(model.RawData.ContainsKey("finish_reason"));
        Assert.Null(model.Index);
        Assert.False(model.RawData.ContainsKey("index"));
        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Choice
        {
            // Null should be interpreted as omitted for these properties
            FinishReason = null,
            Index = null,
            Message = null,
        };

        model.Validate();
    }
}

public class ChoiceMessageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChoiceMessage { Content = "content", Role = "role" };

        string expectedContent = "content";
        string expectedRole = "role";

        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedRole, model.Role);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChoiceMessage { Content = "content", Role = "role" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ChoiceMessage>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChoiceMessage { Content = "content", Role = "role" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ChoiceMessage>(json);
        Assert.NotNull(deserialized);

        string expectedContent = "content";
        string expectedRole = "role";

        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedRole, deserialized.Role);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChoiceMessage { Content = "content", Role = "role" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ChoiceMessage { };

        Assert.Null(model.Content);
        Assert.False(model.RawData.ContainsKey("content"));
        Assert.Null(model.Role);
        Assert.False(model.RawData.ContainsKey("role"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ChoiceMessage { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ChoiceMessage
        {
            // Null should be interpreted as omitted for these properties
            Content = null,
            Role = null,
        };

        Assert.Null(model.Content);
        Assert.False(model.RawData.ContainsKey("content"));
        Assert.Null(model.Role);
        Assert.False(model.RawData.ContainsKey("role"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ChoiceMessage
        {
            // Null should be interpreted as omitted for these properties
            Content = null,
            Role = null,
        };

        model.Validate();
    }
}

public class UsageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Usage
        {
            CompletionTokens = 0,
            Cost = 0,
            PromptTokens = 0,
            TotalTokens = 0,
        };

        long expectedCompletionTokens = 0;
        double expectedCost = 0;
        long expectedPromptTokens = 0;
        long expectedTotalTokens = 0;

        Assert.Equal(expectedCompletionTokens, model.CompletionTokens);
        Assert.Equal(expectedCost, model.Cost);
        Assert.Equal(expectedPromptTokens, model.PromptTokens);
        Assert.Equal(expectedTotalTokens, model.TotalTokens);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Usage
        {
            CompletionTokens = 0,
            Cost = 0,
            PromptTokens = 0,
            TotalTokens = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Usage>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Usage
        {
            CompletionTokens = 0,
            Cost = 0,
            PromptTokens = 0,
            TotalTokens = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Usage>(json);
        Assert.NotNull(deserialized);

        long expectedCompletionTokens = 0;
        double expectedCost = 0;
        long expectedPromptTokens = 0;
        long expectedTotalTokens = 0;

        Assert.Equal(expectedCompletionTokens, deserialized.CompletionTokens);
        Assert.Equal(expectedCost, deserialized.Cost);
        Assert.Equal(expectedPromptTokens, deserialized.PromptTokens);
        Assert.Equal(expectedTotalTokens, deserialized.TotalTokens);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Usage
        {
            CompletionTokens = 0,
            Cost = 0,
            PromptTokens = 0,
            TotalTokens = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Usage { };

        Assert.Null(model.CompletionTokens);
        Assert.False(model.RawData.ContainsKey("completion_tokens"));
        Assert.Null(model.Cost);
        Assert.False(model.RawData.ContainsKey("cost"));
        Assert.Null(model.PromptTokens);
        Assert.False(model.RawData.ContainsKey("prompt_tokens"));
        Assert.Null(model.TotalTokens);
        Assert.False(model.RawData.ContainsKey("total_tokens"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Usage { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Usage
        {
            // Null should be interpreted as omitted for these properties
            CompletionTokens = null,
            Cost = null,
            PromptTokens = null,
            TotalTokens = null,
        };

        Assert.Null(model.CompletionTokens);
        Assert.False(model.RawData.ContainsKey("completion_tokens"));
        Assert.Null(model.Cost);
        Assert.False(model.RawData.ContainsKey("cost"));
        Assert.Null(model.PromptTokens);
        Assert.False(model.RawData.ContainsKey("prompt_tokens"));
        Assert.Null(model.TotalTokens);
        Assert.False(model.RawData.ContainsKey("total_tokens"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Usage
        {
            // Null should be interpreted as omitted for these properties
            CompletionTokens = null,
            Cost = null,
            PromptTokens = null,
            TotalTokens = null,
        };

        model.Validate();
    }
}
