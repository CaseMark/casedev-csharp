using System;
using System.Collections.Generic;
using Casedev.Models.Agent.V1.Run;

namespace Casedev.Tests.Models.Agent.V1.Run;

public class RunCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new RunCreateParams
        {
            AgentID = "agentId",
            Prompt = "prompt",
            Guidance = "guidance",
            Model = "model",
            ObjectIds = ["string"],
        };

        string expectedAgentID = "agentId";
        string expectedPrompt = "prompt";
        string expectedGuidance = "guidance";
        string expectedModel = "model";
        List<string> expectedObjectIds = ["string"];

        Assert.Equal(expectedAgentID, parameters.AgentID);
        Assert.Equal(expectedPrompt, parameters.Prompt);
        Assert.Equal(expectedGuidance, parameters.Guidance);
        Assert.Equal(expectedModel, parameters.Model);
        Assert.NotNull(parameters.ObjectIds);
        Assert.Equal(expectedObjectIds.Count, parameters.ObjectIds.Count);
        for (int i = 0; i < expectedObjectIds.Count; i++)
        {
            Assert.Equal(expectedObjectIds[i], parameters.ObjectIds[i]);
        }
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new RunCreateParams { AgentID = "agentId", Prompt = "prompt" };

        Assert.Null(parameters.Guidance);
        Assert.False(parameters.RawBodyData.ContainsKey("guidance"));
        Assert.Null(parameters.Model);
        Assert.False(parameters.RawBodyData.ContainsKey("model"));
        Assert.Null(parameters.ObjectIds);
        Assert.False(parameters.RawBodyData.ContainsKey("objectIds"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new RunCreateParams
        {
            AgentID = "agentId",
            Prompt = "prompt",

            Guidance = null,
            Model = null,
            ObjectIds = null,
        };

        Assert.Null(parameters.Guidance);
        Assert.True(parameters.RawBodyData.ContainsKey("guidance"));
        Assert.Null(parameters.Model);
        Assert.True(parameters.RawBodyData.ContainsKey("model"));
        Assert.Null(parameters.ObjectIds);
        Assert.True(parameters.RawBodyData.ContainsKey("objectIds"));
    }

    [Fact]
    public void Url_Works()
    {
        RunCreateParams parameters = new() { AgentID = "agentId", Prompt = "prompt" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/agent/v1/run"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new RunCreateParams
        {
            AgentID = "agentId",
            Prompt = "prompt",
            Guidance = "guidance",
            Model = "model",
            ObjectIds = ["string"],
        };

        RunCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
