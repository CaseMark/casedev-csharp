using System;
using System.Collections.Generic;
using System.Text.Json;
using Casedev.Core;
using Casedev.Exceptions;
using Run = Casedev.Models.Agent.V1.Run;

namespace Casedev.Tests.Models.Agent.V1.Run;

public class RunGetDetailsResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Run::RunGetDetailsResponse
        {
            ID = "id",
            AgentID = "agentId",
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Guidance = "guidance",
            Model = "model",
            Prompt = "prompt",
            Result = new()
            {
                Logs = new() { Opencode = "opencode", Runner = "runner" },
                Output = "output",
            },
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = Run::RunGetDetailsResponseStatus.Queued,
            Steps =
            [
                new()
                {
                    ID = "id",
                    Content = "content",
                    DurationMs = 0,
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ToolInput = JsonSerializer.Deserialize<JsonElement>("{}"),
                    ToolName = "toolName",
                    ToolOutput = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Type = Run::Type.Output,
                },
            ],
            Usage = new()
            {
                DurationMs = 0,
                InputTokens = 0,
                Model = "model",
                OutputTokens = 0,
                ToolCalls = 0,
            },
        };

        string expectedID = "id";
        string expectedAgentID = "agentId";
        DateTimeOffset expectedCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedGuidance = "guidance";
        string expectedModel = "model";
        string expectedPrompt = "prompt";
        Run::Result expectedResult = new()
        {
            Logs = new() { Opencode = "opencode", Runner = "runner" },
            Output = "output",
        };
        DateTimeOffset expectedStartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, Run::RunGetDetailsResponseStatus> expectedStatus =
            Run::RunGetDetailsResponseStatus.Queued;
        List<Run::Step> expectedSteps =
        [
            new()
            {
                ID = "id",
                Content = "content",
                DurationMs = 0,
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ToolInput = JsonSerializer.Deserialize<JsonElement>("{}"),
                ToolName = "toolName",
                ToolOutput = JsonSerializer.Deserialize<JsonElement>("{}"),
                Type = Run::Type.Output,
            },
        ];
        Run::Usage expectedUsage = new()
        {
            DurationMs = 0,
            InputTokens = 0,
            Model = "model",
            OutputTokens = 0,
            ToolCalls = 0,
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAgentID, model.AgentID);
        Assert.Equal(expectedCompletedAt, model.CompletedAt);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedGuidance, model.Guidance);
        Assert.Equal(expectedModel, model.Model);
        Assert.Equal(expectedPrompt, model.Prompt);
        Assert.Equal(expectedResult, model.Result);
        Assert.Equal(expectedStartedAt, model.StartedAt);
        Assert.Equal(expectedStatus, model.Status);
        Assert.NotNull(model.Steps);
        Assert.Equal(expectedSteps.Count, model.Steps.Count);
        for (int i = 0; i < expectedSteps.Count; i++)
        {
            Assert.Equal(expectedSteps[i], model.Steps[i]);
        }
        Assert.Equal(expectedUsage, model.Usage);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Run::RunGetDetailsResponse
        {
            ID = "id",
            AgentID = "agentId",
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Guidance = "guidance",
            Model = "model",
            Prompt = "prompt",
            Result = new()
            {
                Logs = new() { Opencode = "opencode", Runner = "runner" },
                Output = "output",
            },
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = Run::RunGetDetailsResponseStatus.Queued,
            Steps =
            [
                new()
                {
                    ID = "id",
                    Content = "content",
                    DurationMs = 0,
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ToolInput = JsonSerializer.Deserialize<JsonElement>("{}"),
                    ToolName = "toolName",
                    ToolOutput = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Type = Run::Type.Output,
                },
            ],
            Usage = new()
            {
                DurationMs = 0,
                InputTokens = 0,
                Model = "model",
                OutputTokens = 0,
                ToolCalls = 0,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Run::RunGetDetailsResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Run::RunGetDetailsResponse
        {
            ID = "id",
            AgentID = "agentId",
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Guidance = "guidance",
            Model = "model",
            Prompt = "prompt",
            Result = new()
            {
                Logs = new() { Opencode = "opencode", Runner = "runner" },
                Output = "output",
            },
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = Run::RunGetDetailsResponseStatus.Queued,
            Steps =
            [
                new()
                {
                    ID = "id",
                    Content = "content",
                    DurationMs = 0,
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ToolInput = JsonSerializer.Deserialize<JsonElement>("{}"),
                    ToolName = "toolName",
                    ToolOutput = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Type = Run::Type.Output,
                },
            ],
            Usage = new()
            {
                DurationMs = 0,
                InputTokens = 0,
                Model = "model",
                OutputTokens = 0,
                ToolCalls = 0,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Run::RunGetDetailsResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedAgentID = "agentId";
        DateTimeOffset expectedCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedGuidance = "guidance";
        string expectedModel = "model";
        string expectedPrompt = "prompt";
        Run::Result expectedResult = new()
        {
            Logs = new() { Opencode = "opencode", Runner = "runner" },
            Output = "output",
        };
        DateTimeOffset expectedStartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, Run::RunGetDetailsResponseStatus> expectedStatus =
            Run::RunGetDetailsResponseStatus.Queued;
        List<Run::Step> expectedSteps =
        [
            new()
            {
                ID = "id",
                Content = "content",
                DurationMs = 0,
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ToolInput = JsonSerializer.Deserialize<JsonElement>("{}"),
                ToolName = "toolName",
                ToolOutput = JsonSerializer.Deserialize<JsonElement>("{}"),
                Type = Run::Type.Output,
            },
        ];
        Run::Usage expectedUsage = new()
        {
            DurationMs = 0,
            InputTokens = 0,
            Model = "model",
            OutputTokens = 0,
            ToolCalls = 0,
        };

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAgentID, deserialized.AgentID);
        Assert.Equal(expectedCompletedAt, deserialized.CompletedAt);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedGuidance, deserialized.Guidance);
        Assert.Equal(expectedModel, deserialized.Model);
        Assert.Equal(expectedPrompt, deserialized.Prompt);
        Assert.Equal(expectedResult, deserialized.Result);
        Assert.Equal(expectedStartedAt, deserialized.StartedAt);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.NotNull(deserialized.Steps);
        Assert.Equal(expectedSteps.Count, deserialized.Steps.Count);
        for (int i = 0; i < expectedSteps.Count; i++)
        {
            Assert.Equal(expectedSteps[i], deserialized.Steps[i]);
        }
        Assert.Equal(expectedUsage, deserialized.Usage);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Run::RunGetDetailsResponse
        {
            ID = "id",
            AgentID = "agentId",
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Guidance = "guidance",
            Model = "model",
            Prompt = "prompt",
            Result = new()
            {
                Logs = new() { Opencode = "opencode", Runner = "runner" },
                Output = "output",
            },
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = Run::RunGetDetailsResponseStatus.Queued,
            Steps =
            [
                new()
                {
                    ID = "id",
                    Content = "content",
                    DurationMs = 0,
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ToolInput = JsonSerializer.Deserialize<JsonElement>("{}"),
                    ToolName = "toolName",
                    ToolOutput = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Type = Run::Type.Output,
                },
            ],
            Usage = new()
            {
                DurationMs = 0,
                InputTokens = 0,
                Model = "model",
                OutputTokens = 0,
                ToolCalls = 0,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Run::RunGetDetailsResponse
        {
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Guidance = "guidance",
            Model = "model",
            Result = new()
            {
                Logs = new() { Opencode = "opencode", Runner = "runner" },
                Output = "output",
            },
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Usage = new()
            {
                DurationMs = 0,
                InputTokens = 0,
                Model = "model",
                OutputTokens = 0,
                ToolCalls = 0,
            },
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.AgentID);
        Assert.False(model.RawData.ContainsKey("agentId"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.Prompt);
        Assert.False(model.RawData.ContainsKey("prompt"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.Steps);
        Assert.False(model.RawData.ContainsKey("steps"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Run::RunGetDetailsResponse
        {
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Guidance = "guidance",
            Model = "model",
            Result = new()
            {
                Logs = new() { Opencode = "opencode", Runner = "runner" },
                Output = "output",
            },
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Usage = new()
            {
                DurationMs = 0,
                InputTokens = 0,
                Model = "model",
                OutputTokens = 0,
                ToolCalls = 0,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Run::RunGetDetailsResponse
        {
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Guidance = "guidance",
            Model = "model",
            Result = new()
            {
                Logs = new() { Opencode = "opencode", Runner = "runner" },
                Output = "output",
            },
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Usage = new()
            {
                DurationMs = 0,
                InputTokens = 0,
                Model = "model",
                OutputTokens = 0,
                ToolCalls = 0,
            },

            // Null should be interpreted as omitted for these properties
            ID = null,
            AgentID = null,
            CreatedAt = null,
            Prompt = null,
            Status = null,
            Steps = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.AgentID);
        Assert.False(model.RawData.ContainsKey("agentId"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.Prompt);
        Assert.False(model.RawData.ContainsKey("prompt"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.Steps);
        Assert.False(model.RawData.ContainsKey("steps"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Run::RunGetDetailsResponse
        {
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Guidance = "guidance",
            Model = "model",
            Result = new()
            {
                Logs = new() { Opencode = "opencode", Runner = "runner" },
                Output = "output",
            },
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Usage = new()
            {
                DurationMs = 0,
                InputTokens = 0,
                Model = "model",
                OutputTokens = 0,
                ToolCalls = 0,
            },

            // Null should be interpreted as omitted for these properties
            ID = null,
            AgentID = null,
            CreatedAt = null,
            Prompt = null,
            Status = null,
            Steps = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Run::RunGetDetailsResponse
        {
            ID = "id",
            AgentID = "agentId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Prompt = "prompt",
            Status = Run::RunGetDetailsResponseStatus.Queued,
            Steps =
            [
                new()
                {
                    ID = "id",
                    Content = "content",
                    DurationMs = 0,
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ToolInput = JsonSerializer.Deserialize<JsonElement>("{}"),
                    ToolName = "toolName",
                    ToolOutput = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Type = Run::Type.Output,
                },
            ],
        };

        Assert.Null(model.CompletedAt);
        Assert.False(model.RawData.ContainsKey("completedAt"));
        Assert.Null(model.Guidance);
        Assert.False(model.RawData.ContainsKey("guidance"));
        Assert.Null(model.Model);
        Assert.False(model.RawData.ContainsKey("model"));
        Assert.Null(model.Result);
        Assert.False(model.RawData.ContainsKey("result"));
        Assert.Null(model.StartedAt);
        Assert.False(model.RawData.ContainsKey("startedAt"));
        Assert.Null(model.Usage);
        Assert.False(model.RawData.ContainsKey("usage"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Run::RunGetDetailsResponse
        {
            ID = "id",
            AgentID = "agentId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Prompt = "prompt",
            Status = Run::RunGetDetailsResponseStatus.Queued,
            Steps =
            [
                new()
                {
                    ID = "id",
                    Content = "content",
                    DurationMs = 0,
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ToolInput = JsonSerializer.Deserialize<JsonElement>("{}"),
                    ToolName = "toolName",
                    ToolOutput = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Type = Run::Type.Output,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Run::RunGetDetailsResponse
        {
            ID = "id",
            AgentID = "agentId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Prompt = "prompt",
            Status = Run::RunGetDetailsResponseStatus.Queued,
            Steps =
            [
                new()
                {
                    ID = "id",
                    Content = "content",
                    DurationMs = 0,
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ToolInput = JsonSerializer.Deserialize<JsonElement>("{}"),
                    ToolName = "toolName",
                    ToolOutput = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Type = Run::Type.Output,
                },
            ],

            CompletedAt = null,
            Guidance = null,
            Model = null,
            Result = null,
            StartedAt = null,
            Usage = null,
        };

        Assert.Null(model.CompletedAt);
        Assert.True(model.RawData.ContainsKey("completedAt"));
        Assert.Null(model.Guidance);
        Assert.True(model.RawData.ContainsKey("guidance"));
        Assert.Null(model.Model);
        Assert.True(model.RawData.ContainsKey("model"));
        Assert.Null(model.Result);
        Assert.True(model.RawData.ContainsKey("result"));
        Assert.Null(model.StartedAt);
        Assert.True(model.RawData.ContainsKey("startedAt"));
        Assert.Null(model.Usage);
        Assert.True(model.RawData.ContainsKey("usage"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Run::RunGetDetailsResponse
        {
            ID = "id",
            AgentID = "agentId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Prompt = "prompt",
            Status = Run::RunGetDetailsResponseStatus.Queued,
            Steps =
            [
                new()
                {
                    ID = "id",
                    Content = "content",
                    DurationMs = 0,
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ToolInput = JsonSerializer.Deserialize<JsonElement>("{}"),
                    ToolName = "toolName",
                    ToolOutput = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Type = Run::Type.Output,
                },
            ],

            CompletedAt = null,
            Guidance = null,
            Model = null,
            Result = null,
            StartedAt = null,
            Usage = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Run::RunGetDetailsResponse
        {
            ID = "id",
            AgentID = "agentId",
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Guidance = "guidance",
            Model = "model",
            Prompt = "prompt",
            Result = new()
            {
                Logs = new() { Opencode = "opencode", Runner = "runner" },
                Output = "output",
            },
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = Run::RunGetDetailsResponseStatus.Queued,
            Steps =
            [
                new()
                {
                    ID = "id",
                    Content = "content",
                    DurationMs = 0,
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ToolInput = JsonSerializer.Deserialize<JsonElement>("{}"),
                    ToolName = "toolName",
                    ToolOutput = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Type = Run::Type.Output,
                },
            ],
            Usage = new()
            {
                DurationMs = 0,
                InputTokens = 0,
                Model = "model",
                OutputTokens = 0,
                ToolCalls = 0,
            },
        };

        Run::RunGetDetailsResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Run::Result
        {
            Logs = new() { Opencode = "opencode", Runner = "runner" },
            Output = "output",
        };

        Run::Logs expectedLogs = new() { Opencode = "opencode", Runner = "runner" };
        string expectedOutput = "output";

        Assert.Equal(expectedLogs, model.Logs);
        Assert.Equal(expectedOutput, model.Output);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Run::Result
        {
            Logs = new() { Opencode = "opencode", Runner = "runner" },
            Output = "output",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Run::Result>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Run::Result
        {
            Logs = new() { Opencode = "opencode", Runner = "runner" },
            Output = "output",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Run::Result>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Run::Logs expectedLogs = new() { Opencode = "opencode", Runner = "runner" };
        string expectedOutput = "output";

        Assert.Equal(expectedLogs, deserialized.Logs);
        Assert.Equal(expectedOutput, deserialized.Output);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Run::Result
        {
            Logs = new() { Opencode = "opencode", Runner = "runner" },
            Output = "output",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Run::Result
        {
            Logs = new() { Opencode = "opencode", Runner = "runner" },
        };

        Assert.Null(model.Output);
        Assert.False(model.RawData.ContainsKey("output"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Run::Result
        {
            Logs = new() { Opencode = "opencode", Runner = "runner" },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Run::Result
        {
            Logs = new() { Opencode = "opencode", Runner = "runner" },

            // Null should be interpreted as omitted for these properties
            Output = null,
        };

        Assert.Null(model.Output);
        Assert.False(model.RawData.ContainsKey("output"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Run::Result
        {
            Logs = new() { Opencode = "opencode", Runner = "runner" },

            // Null should be interpreted as omitted for these properties
            Output = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Run::Result { Output = "output" };

        Assert.Null(model.Logs);
        Assert.False(model.RawData.ContainsKey("logs"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Run::Result { Output = "output" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Run::Result
        {
            Output = "output",

            Logs = null,
        };

        Assert.Null(model.Logs);
        Assert.True(model.RawData.ContainsKey("logs"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Run::Result
        {
            Output = "output",

            Logs = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Run::Result
        {
            Logs = new() { Opencode = "opencode", Runner = "runner" },
            Output = "output",
        };

        Run::Result copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class LogsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Run::Logs { Opencode = "opencode", Runner = "runner" };

        string expectedOpencode = "opencode";
        string expectedRunner = "runner";

        Assert.Equal(expectedOpencode, model.Opencode);
        Assert.Equal(expectedRunner, model.Runner);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Run::Logs { Opencode = "opencode", Runner = "runner" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Run::Logs>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Run::Logs { Opencode = "opencode", Runner = "runner" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Run::Logs>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedOpencode = "opencode";
        string expectedRunner = "runner";

        Assert.Equal(expectedOpencode, deserialized.Opencode);
        Assert.Equal(expectedRunner, deserialized.Runner);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Run::Logs { Opencode = "opencode", Runner = "runner" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Run::Logs { };

        Assert.Null(model.Opencode);
        Assert.False(model.RawData.ContainsKey("opencode"));
        Assert.Null(model.Runner);
        Assert.False(model.RawData.ContainsKey("runner"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Run::Logs { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Run::Logs
        {
            // Null should be interpreted as omitted for these properties
            Opencode = null,
            Runner = null,
        };

        Assert.Null(model.Opencode);
        Assert.False(model.RawData.ContainsKey("opencode"));
        Assert.Null(model.Runner);
        Assert.False(model.RawData.ContainsKey("runner"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Run::Logs
        {
            // Null should be interpreted as omitted for these properties
            Opencode = null,
            Runner = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Run::Logs { Opencode = "opencode", Runner = "runner" };

        Run::Logs copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RunGetDetailsResponseStatusTest : TestBase
{
    [Theory]
    [InlineData(Run::RunGetDetailsResponseStatus.Queued)]
    [InlineData(Run::RunGetDetailsResponseStatus.Running)]
    [InlineData(Run::RunGetDetailsResponseStatus.Completed)]
    [InlineData(Run::RunGetDetailsResponseStatus.Failed)]
    [InlineData(Run::RunGetDetailsResponseStatus.Cancelled)]
    public void Validation_Works(Run::RunGetDetailsResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Run::RunGetDetailsResponseStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Run::RunGetDetailsResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Run::RunGetDetailsResponseStatus.Queued)]
    [InlineData(Run::RunGetDetailsResponseStatus.Running)]
    [InlineData(Run::RunGetDetailsResponseStatus.Completed)]
    [InlineData(Run::RunGetDetailsResponseStatus.Failed)]
    [InlineData(Run::RunGetDetailsResponseStatus.Cancelled)]
    public void SerializationRoundtrip_Works(Run::RunGetDetailsResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Run::RunGetDetailsResponseStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Run::RunGetDetailsResponseStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Run::RunGetDetailsResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Run::RunGetDetailsResponseStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class StepTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Run::Step
        {
            ID = "id",
            Content = "content",
            DurationMs = 0,
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ToolInput = JsonSerializer.Deserialize<JsonElement>("{}"),
            ToolName = "toolName",
            ToolOutput = JsonSerializer.Deserialize<JsonElement>("{}"),
            Type = Run::Type.Output,
        };

        string expectedID = "id";
        string expectedContent = "content";
        long expectedDurationMs = 0;
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        JsonElement expectedToolInput = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedToolName = "toolName";
        JsonElement expectedToolOutput = JsonSerializer.Deserialize<JsonElement>("{}");
        ApiEnum<string, Run::Type> expectedType = Run::Type.Output;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedDurationMs, model.DurationMs);
        Assert.Equal(expectedTimestamp, model.Timestamp);
        Assert.NotNull(model.ToolInput);
        Assert.True(JsonElement.DeepEquals(expectedToolInput, model.ToolInput.Value));
        Assert.Equal(expectedToolName, model.ToolName);
        Assert.NotNull(model.ToolOutput);
        Assert.True(JsonElement.DeepEquals(expectedToolOutput, model.ToolOutput.Value));
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Run::Step
        {
            ID = "id",
            Content = "content",
            DurationMs = 0,
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ToolInput = JsonSerializer.Deserialize<JsonElement>("{}"),
            ToolName = "toolName",
            ToolOutput = JsonSerializer.Deserialize<JsonElement>("{}"),
            Type = Run::Type.Output,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Run::Step>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Run::Step
        {
            ID = "id",
            Content = "content",
            DurationMs = 0,
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ToolInput = JsonSerializer.Deserialize<JsonElement>("{}"),
            ToolName = "toolName",
            ToolOutput = JsonSerializer.Deserialize<JsonElement>("{}"),
            Type = Run::Type.Output,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Run::Step>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedContent = "content";
        long expectedDurationMs = 0;
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        JsonElement expectedToolInput = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedToolName = "toolName";
        JsonElement expectedToolOutput = JsonSerializer.Deserialize<JsonElement>("{}");
        ApiEnum<string, Run::Type> expectedType = Run::Type.Output;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedDurationMs, deserialized.DurationMs);
        Assert.Equal(expectedTimestamp, deserialized.Timestamp);
        Assert.NotNull(deserialized.ToolInput);
        Assert.True(JsonElement.DeepEquals(expectedToolInput, deserialized.ToolInput.Value));
        Assert.Equal(expectedToolName, deserialized.ToolName);
        Assert.NotNull(deserialized.ToolOutput);
        Assert.True(JsonElement.DeepEquals(expectedToolOutput, deserialized.ToolOutput.Value));
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Run::Step
        {
            ID = "id",
            Content = "content",
            DurationMs = 0,
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ToolInput = JsonSerializer.Deserialize<JsonElement>("{}"),
            ToolName = "toolName",
            ToolOutput = JsonSerializer.Deserialize<JsonElement>("{}"),
            Type = Run::Type.Output,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Run::Step
        {
            Content = "content",
            DurationMs = 0,
            ToolName = "toolName",
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Timestamp);
        Assert.False(model.RawData.ContainsKey("timestamp"));
        Assert.Null(model.ToolInput);
        Assert.False(model.RawData.ContainsKey("toolInput"));
        Assert.Null(model.ToolOutput);
        Assert.False(model.RawData.ContainsKey("toolOutput"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Run::Step
        {
            Content = "content",
            DurationMs = 0,
            ToolName = "toolName",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Run::Step
        {
            Content = "content",
            DurationMs = 0,
            ToolName = "toolName",

            // Null should be interpreted as omitted for these properties
            ID = null,
            Timestamp = null,
            ToolInput = null,
            ToolOutput = null,
            Type = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Timestamp);
        Assert.False(model.RawData.ContainsKey("timestamp"));
        Assert.Null(model.ToolInput);
        Assert.False(model.RawData.ContainsKey("toolInput"));
        Assert.Null(model.ToolOutput);
        Assert.False(model.RawData.ContainsKey("toolOutput"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Run::Step
        {
            Content = "content",
            DurationMs = 0,
            ToolName = "toolName",

            // Null should be interpreted as omitted for these properties
            ID = null,
            Timestamp = null,
            ToolInput = null,
            ToolOutput = null,
            Type = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Run::Step
        {
            ID = "id",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ToolInput = JsonSerializer.Deserialize<JsonElement>("{}"),
            ToolOutput = JsonSerializer.Deserialize<JsonElement>("{}"),
            Type = Run::Type.Output,
        };

        Assert.Null(model.Content);
        Assert.False(model.RawData.ContainsKey("content"));
        Assert.Null(model.DurationMs);
        Assert.False(model.RawData.ContainsKey("durationMs"));
        Assert.Null(model.ToolName);
        Assert.False(model.RawData.ContainsKey("toolName"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Run::Step
        {
            ID = "id",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ToolInput = JsonSerializer.Deserialize<JsonElement>("{}"),
            ToolOutput = JsonSerializer.Deserialize<JsonElement>("{}"),
            Type = Run::Type.Output,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Run::Step
        {
            ID = "id",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ToolInput = JsonSerializer.Deserialize<JsonElement>("{}"),
            ToolOutput = JsonSerializer.Deserialize<JsonElement>("{}"),
            Type = Run::Type.Output,

            Content = null,
            DurationMs = null,
            ToolName = null,
        };

        Assert.Null(model.Content);
        Assert.True(model.RawData.ContainsKey("content"));
        Assert.Null(model.DurationMs);
        Assert.True(model.RawData.ContainsKey("durationMs"));
        Assert.Null(model.ToolName);
        Assert.True(model.RawData.ContainsKey("toolName"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Run::Step
        {
            ID = "id",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ToolInput = JsonSerializer.Deserialize<JsonElement>("{}"),
            ToolOutput = JsonSerializer.Deserialize<JsonElement>("{}"),
            Type = Run::Type.Output,

            Content = null,
            DurationMs = null,
            ToolName = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Run::Step
        {
            ID = "id",
            Content = "content",
            DurationMs = 0,
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ToolInput = JsonSerializer.Deserialize<JsonElement>("{}"),
            ToolName = "toolName",
            ToolOutput = JsonSerializer.Deserialize<JsonElement>("{}"),
            Type = Run::Type.Output,
        };

        Run::Step copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Run::Type.Output)]
    [InlineData(Run::Type.Thinking)]
    [InlineData(Run::Type.ToolCall)]
    [InlineData(Run::Type.ToolResult)]
    public void Validation_Works(Run::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Run::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Run::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Run::Type.Output)]
    [InlineData(Run::Type.Thinking)]
    [InlineData(Run::Type.ToolCall)]
    [InlineData(Run::Type.ToolResult)]
    public void SerializationRoundtrip_Works(Run::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Run::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Run::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Run::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Run::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class UsageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Run::Usage
        {
            DurationMs = 0,
            InputTokens = 0,
            Model = "model",
            OutputTokens = 0,
            ToolCalls = 0,
        };

        long expectedDurationMs = 0;
        long expectedInputTokens = 0;
        string expectedModel = "model";
        long expectedOutputTokens = 0;
        long expectedToolCalls = 0;

        Assert.Equal(expectedDurationMs, model.DurationMs);
        Assert.Equal(expectedInputTokens, model.InputTokens);
        Assert.Equal(expectedModel, model.Model);
        Assert.Equal(expectedOutputTokens, model.OutputTokens);
        Assert.Equal(expectedToolCalls, model.ToolCalls);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Run::Usage
        {
            DurationMs = 0,
            InputTokens = 0,
            Model = "model",
            OutputTokens = 0,
            ToolCalls = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Run::Usage>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Run::Usage
        {
            DurationMs = 0,
            InputTokens = 0,
            Model = "model",
            OutputTokens = 0,
            ToolCalls = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Run::Usage>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedDurationMs = 0;
        long expectedInputTokens = 0;
        string expectedModel = "model";
        long expectedOutputTokens = 0;
        long expectedToolCalls = 0;

        Assert.Equal(expectedDurationMs, deserialized.DurationMs);
        Assert.Equal(expectedInputTokens, deserialized.InputTokens);
        Assert.Equal(expectedModel, deserialized.Model);
        Assert.Equal(expectedOutputTokens, deserialized.OutputTokens);
        Assert.Equal(expectedToolCalls, deserialized.ToolCalls);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Run::Usage
        {
            DurationMs = 0,
            InputTokens = 0,
            Model = "model",
            OutputTokens = 0,
            ToolCalls = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Run::Usage { };

        Assert.Null(model.DurationMs);
        Assert.False(model.RawData.ContainsKey("durationMs"));
        Assert.Null(model.InputTokens);
        Assert.False(model.RawData.ContainsKey("inputTokens"));
        Assert.Null(model.Model);
        Assert.False(model.RawData.ContainsKey("model"));
        Assert.Null(model.OutputTokens);
        Assert.False(model.RawData.ContainsKey("outputTokens"));
        Assert.Null(model.ToolCalls);
        Assert.False(model.RawData.ContainsKey("toolCalls"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Run::Usage { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Run::Usage
        {
            // Null should be interpreted as omitted for these properties
            DurationMs = null,
            InputTokens = null,
            Model = null,
            OutputTokens = null,
            ToolCalls = null,
        };

        Assert.Null(model.DurationMs);
        Assert.False(model.RawData.ContainsKey("durationMs"));
        Assert.Null(model.InputTokens);
        Assert.False(model.RawData.ContainsKey("inputTokens"));
        Assert.Null(model.Model);
        Assert.False(model.RawData.ContainsKey("model"));
        Assert.Null(model.OutputTokens);
        Assert.False(model.RawData.ContainsKey("outputTokens"));
        Assert.Null(model.ToolCalls);
        Assert.False(model.RawData.ContainsKey("toolCalls"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Run::Usage
        {
            // Null should be interpreted as omitted for these properties
            DurationMs = null,
            InputTokens = null,
            Model = null,
            OutputTokens = null,
            ToolCalls = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Run::Usage
        {
            DurationMs = 0,
            InputTokens = 0,
            Model = "model",
            OutputTokens = 0,
            ToolCalls = 0,
        };

        Run::Usage copied = new(model);

        Assert.Equal(model, copied);
    }
}
