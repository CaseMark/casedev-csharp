using System.Collections.Generic;
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
}
