using System;
using System.Collections.Generic;
using Casedev.Models.Agent.V2.Chat;

namespace Casedev.Tests.Models.Agent.V2.Chat;

public class ChatReplyToQuestionParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ChatReplyToQuestionParams
        {
            ID = "id",
            RequestID = "requestID",
            Answers =
            [
                ["string"],
            ],
        };

        string expectedID = "id";
        string expectedRequestID = "requestID";
        List<List<string>> expectedAnswers =
        [
            ["string"],
        ];

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedRequestID, parameters.RequestID);
        Assert.Equal(expectedAnswers.Count, parameters.Answers.Count);
        for (int i = 0; i < expectedAnswers.Count; i++)
        {
            Assert.Equal(expectedAnswers[i].Count, parameters.Answers[i].Count);
            for (int i1 = 0; i1 < expectedAnswers[i].Count; i1++)
            {
                Assert.Equal(expectedAnswers[i][i1], parameters.Answers[i][i1]);
            }
        }
    }

    [Fact]
    public void Url_Works()
    {
        ChatReplyToQuestionParams parameters = new()
        {
            ID = "id",
            RequestID = "requestID",
            Answers =
            [
                ["string"],
            ],
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.case.dev/agent/v2/chat/id/question/requestID/reply"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ChatReplyToQuestionParams
        {
            ID = "id",
            RequestID = "requestID",
            Answers =
            [
                ["string"],
            ],
        };

        ChatReplyToQuestionParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
