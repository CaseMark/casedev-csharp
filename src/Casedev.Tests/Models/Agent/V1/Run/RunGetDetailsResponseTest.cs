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
            ModalSandboxID = "modalSandboxId",
            Model = "model",
            Prompt = "prompt",
            Provider = Run::Provider.Daytona,
            Result = new()
            {
                FinalResponse = new()
                {
                    CreatedObjectIds = ["string"],
                    Issues = ["string"],
                    Summary = "summary",
                },
                Logs = new() { Opencode = "opencode", Runner = "runner" },
                Output = "output",
                OutputObjectIds = ["string"],
            },
            RuntimeID = "runtimeId",
            RuntimeState = Run::RuntimeState.Running,
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
                Entries =
                [
                    new()
                    {
                        ID = "id",
                        CompletionTokens = 0,
                        CostMicros = 0,
                        Endpoint = "endpoint",
                        Kind = Run::Kind.Llm,
                        Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                        Method = "method",
                        Model = "model",
                        PromptTokens = 0,
                        Service = "service",
                        StatusCode = 0,
                        Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        TotalTokens = 0,
                    },
                ],
                InputTokens = 0,
                Model = "model",
                OutputTokens = 0,
                Summary = new()
                {
                    CostMicros = 0,
                    TotalInputTokens = 0,
                    TotalOutputTokens = 0,
                    TotalTokens = 0,
                },
                ToolCalls = 0,
            },
            WorkflowID = "workflowId",
        };

        string expectedID = "id";
        string expectedAgentID = "agentId";
        DateTimeOffset expectedCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedGuidance = "guidance";
        string expectedModalSandboxID = "modalSandboxId";
        string expectedModel = "model";
        string expectedPrompt = "prompt";
        ApiEnum<string, Run::Provider> expectedProvider = Run::Provider.Daytona;
        Run::Result expectedResult = new()
        {
            FinalResponse = new()
            {
                CreatedObjectIds = ["string"],
                Issues = ["string"],
                Summary = "summary",
            },
            Logs = new() { Opencode = "opencode", Runner = "runner" },
            Output = "output",
            OutputObjectIds = ["string"],
        };
        string expectedRuntimeID = "runtimeId";
        ApiEnum<string, Run::RuntimeState> expectedRuntimeState = Run::RuntimeState.Running;
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
        Run::RunGetDetailsResponseUsage expectedUsage = new()
        {
            DurationMs = 0,
            Entries =
            [
                new()
                {
                    ID = "id",
                    CompletionTokens = 0,
                    CostMicros = 0,
                    Endpoint = "endpoint",
                    Kind = Run::Kind.Llm,
                    Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Method = "method",
                    Model = "model",
                    PromptTokens = 0,
                    Service = "service",
                    StatusCode = 0,
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    TotalTokens = 0,
                },
            ],
            InputTokens = 0,
            Model = "model",
            OutputTokens = 0,
            Summary = new()
            {
                CostMicros = 0,
                TotalInputTokens = 0,
                TotalOutputTokens = 0,
                TotalTokens = 0,
            },
            ToolCalls = 0,
        };
        string expectedWorkflowID = "workflowId";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAgentID, model.AgentID);
        Assert.Equal(expectedCompletedAt, model.CompletedAt);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedGuidance, model.Guidance);
        Assert.Equal(expectedModalSandboxID, model.ModalSandboxID);
        Assert.Equal(expectedModel, model.Model);
        Assert.Equal(expectedPrompt, model.Prompt);
        Assert.Equal(expectedProvider, model.Provider);
        Assert.Equal(expectedResult, model.Result);
        Assert.Equal(expectedRuntimeID, model.RuntimeID);
        Assert.Equal(expectedRuntimeState, model.RuntimeState);
        Assert.Equal(expectedStartedAt, model.StartedAt);
        Assert.Equal(expectedStatus, model.Status);
        Assert.NotNull(model.Steps);
        Assert.Equal(expectedSteps.Count, model.Steps.Count);
        for (int i = 0; i < expectedSteps.Count; i++)
        {
            Assert.Equal(expectedSteps[i], model.Steps[i]);
        }
        Assert.Equal(expectedUsage, model.Usage);
        Assert.Equal(expectedWorkflowID, model.WorkflowID);
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
            ModalSandboxID = "modalSandboxId",
            Model = "model",
            Prompt = "prompt",
            Provider = Run::Provider.Daytona,
            Result = new()
            {
                FinalResponse = new()
                {
                    CreatedObjectIds = ["string"],
                    Issues = ["string"],
                    Summary = "summary",
                },
                Logs = new() { Opencode = "opencode", Runner = "runner" },
                Output = "output",
                OutputObjectIds = ["string"],
            },
            RuntimeID = "runtimeId",
            RuntimeState = Run::RuntimeState.Running,
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
                Entries =
                [
                    new()
                    {
                        ID = "id",
                        CompletionTokens = 0,
                        CostMicros = 0,
                        Endpoint = "endpoint",
                        Kind = Run::Kind.Llm,
                        Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                        Method = "method",
                        Model = "model",
                        PromptTokens = 0,
                        Service = "service",
                        StatusCode = 0,
                        Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        TotalTokens = 0,
                    },
                ],
                InputTokens = 0,
                Model = "model",
                OutputTokens = 0,
                Summary = new()
                {
                    CostMicros = 0,
                    TotalInputTokens = 0,
                    TotalOutputTokens = 0,
                    TotalTokens = 0,
                },
                ToolCalls = 0,
            },
            WorkflowID = "workflowId",
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
            ModalSandboxID = "modalSandboxId",
            Model = "model",
            Prompt = "prompt",
            Provider = Run::Provider.Daytona,
            Result = new()
            {
                FinalResponse = new()
                {
                    CreatedObjectIds = ["string"],
                    Issues = ["string"],
                    Summary = "summary",
                },
                Logs = new() { Opencode = "opencode", Runner = "runner" },
                Output = "output",
                OutputObjectIds = ["string"],
            },
            RuntimeID = "runtimeId",
            RuntimeState = Run::RuntimeState.Running,
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
                Entries =
                [
                    new()
                    {
                        ID = "id",
                        CompletionTokens = 0,
                        CostMicros = 0,
                        Endpoint = "endpoint",
                        Kind = Run::Kind.Llm,
                        Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                        Method = "method",
                        Model = "model",
                        PromptTokens = 0,
                        Service = "service",
                        StatusCode = 0,
                        Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        TotalTokens = 0,
                    },
                ],
                InputTokens = 0,
                Model = "model",
                OutputTokens = 0,
                Summary = new()
                {
                    CostMicros = 0,
                    TotalInputTokens = 0,
                    TotalOutputTokens = 0,
                    TotalTokens = 0,
                },
                ToolCalls = 0,
            },
            WorkflowID = "workflowId",
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
        string expectedModalSandboxID = "modalSandboxId";
        string expectedModel = "model";
        string expectedPrompt = "prompt";
        ApiEnum<string, Run::Provider> expectedProvider = Run::Provider.Daytona;
        Run::Result expectedResult = new()
        {
            FinalResponse = new()
            {
                CreatedObjectIds = ["string"],
                Issues = ["string"],
                Summary = "summary",
            },
            Logs = new() { Opencode = "opencode", Runner = "runner" },
            Output = "output",
            OutputObjectIds = ["string"],
        };
        string expectedRuntimeID = "runtimeId";
        ApiEnum<string, Run::RuntimeState> expectedRuntimeState = Run::RuntimeState.Running;
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
        Run::RunGetDetailsResponseUsage expectedUsage = new()
        {
            DurationMs = 0,
            Entries =
            [
                new()
                {
                    ID = "id",
                    CompletionTokens = 0,
                    CostMicros = 0,
                    Endpoint = "endpoint",
                    Kind = Run::Kind.Llm,
                    Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Method = "method",
                    Model = "model",
                    PromptTokens = 0,
                    Service = "service",
                    StatusCode = 0,
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    TotalTokens = 0,
                },
            ],
            InputTokens = 0,
            Model = "model",
            OutputTokens = 0,
            Summary = new()
            {
                CostMicros = 0,
                TotalInputTokens = 0,
                TotalOutputTokens = 0,
                TotalTokens = 0,
            },
            ToolCalls = 0,
        };
        string expectedWorkflowID = "workflowId";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAgentID, deserialized.AgentID);
        Assert.Equal(expectedCompletedAt, deserialized.CompletedAt);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedGuidance, deserialized.Guidance);
        Assert.Equal(expectedModalSandboxID, deserialized.ModalSandboxID);
        Assert.Equal(expectedModel, deserialized.Model);
        Assert.Equal(expectedPrompt, deserialized.Prompt);
        Assert.Equal(expectedProvider, deserialized.Provider);
        Assert.Equal(expectedResult, deserialized.Result);
        Assert.Equal(expectedRuntimeID, deserialized.RuntimeID);
        Assert.Equal(expectedRuntimeState, deserialized.RuntimeState);
        Assert.Equal(expectedStartedAt, deserialized.StartedAt);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.NotNull(deserialized.Steps);
        Assert.Equal(expectedSteps.Count, deserialized.Steps.Count);
        for (int i = 0; i < expectedSteps.Count; i++)
        {
            Assert.Equal(expectedSteps[i], deserialized.Steps[i]);
        }
        Assert.Equal(expectedUsage, deserialized.Usage);
        Assert.Equal(expectedWorkflowID, deserialized.WorkflowID);
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
            ModalSandboxID = "modalSandboxId",
            Model = "model",
            Prompt = "prompt",
            Provider = Run::Provider.Daytona,
            Result = new()
            {
                FinalResponse = new()
                {
                    CreatedObjectIds = ["string"],
                    Issues = ["string"],
                    Summary = "summary",
                },
                Logs = new() { Opencode = "opencode", Runner = "runner" },
                Output = "output",
                OutputObjectIds = ["string"],
            },
            RuntimeID = "runtimeId",
            RuntimeState = Run::RuntimeState.Running,
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
                Entries =
                [
                    new()
                    {
                        ID = "id",
                        CompletionTokens = 0,
                        CostMicros = 0,
                        Endpoint = "endpoint",
                        Kind = Run::Kind.Llm,
                        Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                        Method = "method",
                        Model = "model",
                        PromptTokens = 0,
                        Service = "service",
                        StatusCode = 0,
                        Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        TotalTokens = 0,
                    },
                ],
                InputTokens = 0,
                Model = "model",
                OutputTokens = 0,
                Summary = new()
                {
                    CostMicros = 0,
                    TotalInputTokens = 0,
                    TotalOutputTokens = 0,
                    TotalTokens = 0,
                },
                ToolCalls = 0,
            },
            WorkflowID = "workflowId",
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
            ModalSandboxID = "modalSandboxId",
            Model = "model",
            Provider = Run::Provider.Daytona,
            Result = new()
            {
                FinalResponse = new()
                {
                    CreatedObjectIds = ["string"],
                    Issues = ["string"],
                    Summary = "summary",
                },
                Logs = new() { Opencode = "opencode", Runner = "runner" },
                Output = "output",
                OutputObjectIds = ["string"],
            },
            RuntimeID = "runtimeId",
            RuntimeState = Run::RuntimeState.Running,
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Usage = new()
            {
                DurationMs = 0,
                Entries =
                [
                    new()
                    {
                        ID = "id",
                        CompletionTokens = 0,
                        CostMicros = 0,
                        Endpoint = "endpoint",
                        Kind = Run::Kind.Llm,
                        Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                        Method = "method",
                        Model = "model",
                        PromptTokens = 0,
                        Service = "service",
                        StatusCode = 0,
                        Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        TotalTokens = 0,
                    },
                ],
                InputTokens = 0,
                Model = "model",
                OutputTokens = 0,
                Summary = new()
                {
                    CostMicros = 0,
                    TotalInputTokens = 0,
                    TotalOutputTokens = 0,
                    TotalTokens = 0,
                },
                ToolCalls = 0,
            },
            WorkflowID = "workflowId",
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
            ModalSandboxID = "modalSandboxId",
            Model = "model",
            Provider = Run::Provider.Daytona,
            Result = new()
            {
                FinalResponse = new()
                {
                    CreatedObjectIds = ["string"],
                    Issues = ["string"],
                    Summary = "summary",
                },
                Logs = new() { Opencode = "opencode", Runner = "runner" },
                Output = "output",
                OutputObjectIds = ["string"],
            },
            RuntimeID = "runtimeId",
            RuntimeState = Run::RuntimeState.Running,
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Usage = new()
            {
                DurationMs = 0,
                Entries =
                [
                    new()
                    {
                        ID = "id",
                        CompletionTokens = 0,
                        CostMicros = 0,
                        Endpoint = "endpoint",
                        Kind = Run::Kind.Llm,
                        Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                        Method = "method",
                        Model = "model",
                        PromptTokens = 0,
                        Service = "service",
                        StatusCode = 0,
                        Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        TotalTokens = 0,
                    },
                ],
                InputTokens = 0,
                Model = "model",
                OutputTokens = 0,
                Summary = new()
                {
                    CostMicros = 0,
                    TotalInputTokens = 0,
                    TotalOutputTokens = 0,
                    TotalTokens = 0,
                },
                ToolCalls = 0,
            },
            WorkflowID = "workflowId",
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
            ModalSandboxID = "modalSandboxId",
            Model = "model",
            Provider = Run::Provider.Daytona,
            Result = new()
            {
                FinalResponse = new()
                {
                    CreatedObjectIds = ["string"],
                    Issues = ["string"],
                    Summary = "summary",
                },
                Logs = new() { Opencode = "opencode", Runner = "runner" },
                Output = "output",
                OutputObjectIds = ["string"],
            },
            RuntimeID = "runtimeId",
            RuntimeState = Run::RuntimeState.Running,
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Usage = new()
            {
                DurationMs = 0,
                Entries =
                [
                    new()
                    {
                        ID = "id",
                        CompletionTokens = 0,
                        CostMicros = 0,
                        Endpoint = "endpoint",
                        Kind = Run::Kind.Llm,
                        Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                        Method = "method",
                        Model = "model",
                        PromptTokens = 0,
                        Service = "service",
                        StatusCode = 0,
                        Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        TotalTokens = 0,
                    },
                ],
                InputTokens = 0,
                Model = "model",
                OutputTokens = 0,
                Summary = new()
                {
                    CostMicros = 0,
                    TotalInputTokens = 0,
                    TotalOutputTokens = 0,
                    TotalTokens = 0,
                },
                ToolCalls = 0,
            },
            WorkflowID = "workflowId",

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
            ModalSandboxID = "modalSandboxId",
            Model = "model",
            Provider = Run::Provider.Daytona,
            Result = new()
            {
                FinalResponse = new()
                {
                    CreatedObjectIds = ["string"],
                    Issues = ["string"],
                    Summary = "summary",
                },
                Logs = new() { Opencode = "opencode", Runner = "runner" },
                Output = "output",
                OutputObjectIds = ["string"],
            },
            RuntimeID = "runtimeId",
            RuntimeState = Run::RuntimeState.Running,
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Usage = new()
            {
                DurationMs = 0,
                Entries =
                [
                    new()
                    {
                        ID = "id",
                        CompletionTokens = 0,
                        CostMicros = 0,
                        Endpoint = "endpoint",
                        Kind = Run::Kind.Llm,
                        Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                        Method = "method",
                        Model = "model",
                        PromptTokens = 0,
                        Service = "service",
                        StatusCode = 0,
                        Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        TotalTokens = 0,
                    },
                ],
                InputTokens = 0,
                Model = "model",
                OutputTokens = 0,
                Summary = new()
                {
                    CostMicros = 0,
                    TotalInputTokens = 0,
                    TotalOutputTokens = 0,
                    TotalTokens = 0,
                },
                ToolCalls = 0,
            },
            WorkflowID = "workflowId",

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
        Assert.Null(model.ModalSandboxID);
        Assert.False(model.RawData.ContainsKey("modalSandboxId"));
        Assert.Null(model.Model);
        Assert.False(model.RawData.ContainsKey("model"));
        Assert.Null(model.Provider);
        Assert.False(model.RawData.ContainsKey("provider"));
        Assert.Null(model.Result);
        Assert.False(model.RawData.ContainsKey("result"));
        Assert.Null(model.RuntimeID);
        Assert.False(model.RawData.ContainsKey("runtimeId"));
        Assert.Null(model.RuntimeState);
        Assert.False(model.RawData.ContainsKey("runtimeState"));
        Assert.Null(model.StartedAt);
        Assert.False(model.RawData.ContainsKey("startedAt"));
        Assert.Null(model.Usage);
        Assert.False(model.RawData.ContainsKey("usage"));
        Assert.Null(model.WorkflowID);
        Assert.False(model.RawData.ContainsKey("workflowId"));
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
            ModalSandboxID = null,
            Model = null,
            Provider = null,
            Result = null,
            RuntimeID = null,
            RuntimeState = null,
            StartedAt = null,
            Usage = null,
            WorkflowID = null,
        };

        Assert.Null(model.CompletedAt);
        Assert.True(model.RawData.ContainsKey("completedAt"));
        Assert.Null(model.Guidance);
        Assert.True(model.RawData.ContainsKey("guidance"));
        Assert.Null(model.ModalSandboxID);
        Assert.True(model.RawData.ContainsKey("modalSandboxId"));
        Assert.Null(model.Model);
        Assert.True(model.RawData.ContainsKey("model"));
        Assert.Null(model.Provider);
        Assert.True(model.RawData.ContainsKey("provider"));
        Assert.Null(model.Result);
        Assert.True(model.RawData.ContainsKey("result"));
        Assert.Null(model.RuntimeID);
        Assert.True(model.RawData.ContainsKey("runtimeId"));
        Assert.Null(model.RuntimeState);
        Assert.True(model.RawData.ContainsKey("runtimeState"));
        Assert.Null(model.StartedAt);
        Assert.True(model.RawData.ContainsKey("startedAt"));
        Assert.Null(model.Usage);
        Assert.True(model.RawData.ContainsKey("usage"));
        Assert.Null(model.WorkflowID);
        Assert.True(model.RawData.ContainsKey("workflowId"));
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
            ModalSandboxID = null,
            Model = null,
            Provider = null,
            Result = null,
            RuntimeID = null,
            RuntimeState = null,
            StartedAt = null,
            Usage = null,
            WorkflowID = null,
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
            ModalSandboxID = "modalSandboxId",
            Model = "model",
            Prompt = "prompt",
            Provider = Run::Provider.Daytona,
            Result = new()
            {
                FinalResponse = new()
                {
                    CreatedObjectIds = ["string"],
                    Issues = ["string"],
                    Summary = "summary",
                },
                Logs = new() { Opencode = "opencode", Runner = "runner" },
                Output = "output",
                OutputObjectIds = ["string"],
            },
            RuntimeID = "runtimeId",
            RuntimeState = Run::RuntimeState.Running,
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
                Entries =
                [
                    new()
                    {
                        ID = "id",
                        CompletionTokens = 0,
                        CostMicros = 0,
                        Endpoint = "endpoint",
                        Kind = Run::Kind.Llm,
                        Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                        Method = "method",
                        Model = "model",
                        PromptTokens = 0,
                        Service = "service",
                        StatusCode = 0,
                        Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        TotalTokens = 0,
                    },
                ],
                InputTokens = 0,
                Model = "model",
                OutputTokens = 0,
                Summary = new()
                {
                    CostMicros = 0,
                    TotalInputTokens = 0,
                    TotalOutputTokens = 0,
                    TotalTokens = 0,
                },
                ToolCalls = 0,
            },
            WorkflowID = "workflowId",
        };

        Run::RunGetDetailsResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ProviderTest : TestBase
{
    [Theory]
    [InlineData(Run::Provider.Daytona)]
    [InlineData(Run::Provider.Vercel)]
    public void Validation_Works(Run::Provider rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Run::Provider> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Run::Provider>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Run::Provider.Daytona)]
    [InlineData(Run::Provider.Vercel)]
    public void SerializationRoundtrip_Works(Run::Provider rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Run::Provider> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Run::Provider>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Run::Provider>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Run::Provider>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Run::Result
        {
            FinalResponse = new()
            {
                CreatedObjectIds = ["string"],
                Issues = ["string"],
                Summary = "summary",
            },
            Logs = new() { Opencode = "opencode", Runner = "runner" },
            Output = "output",
            OutputObjectIds = ["string"],
        };

        Run::FinalResponse expectedFinalResponse = new()
        {
            CreatedObjectIds = ["string"],
            Issues = ["string"],
            Summary = "summary",
        };
        Run::Logs expectedLogs = new() { Opencode = "opencode", Runner = "runner" };
        string expectedOutput = "output";
        List<string> expectedOutputObjectIds = ["string"];

        Assert.Equal(expectedFinalResponse, model.FinalResponse);
        Assert.Equal(expectedLogs, model.Logs);
        Assert.Equal(expectedOutput, model.Output);
        Assert.NotNull(model.OutputObjectIds);
        Assert.Equal(expectedOutputObjectIds.Count, model.OutputObjectIds.Count);
        for (int i = 0; i < expectedOutputObjectIds.Count; i++)
        {
            Assert.Equal(expectedOutputObjectIds[i], model.OutputObjectIds[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Run::Result
        {
            FinalResponse = new()
            {
                CreatedObjectIds = ["string"],
                Issues = ["string"],
                Summary = "summary",
            },
            Logs = new() { Opencode = "opencode", Runner = "runner" },
            Output = "output",
            OutputObjectIds = ["string"],
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
            FinalResponse = new()
            {
                CreatedObjectIds = ["string"],
                Issues = ["string"],
                Summary = "summary",
            },
            Logs = new() { Opencode = "opencode", Runner = "runner" },
            Output = "output",
            OutputObjectIds = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Run::Result>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Run::FinalResponse expectedFinalResponse = new()
        {
            CreatedObjectIds = ["string"],
            Issues = ["string"],
            Summary = "summary",
        };
        Run::Logs expectedLogs = new() { Opencode = "opencode", Runner = "runner" };
        string expectedOutput = "output";
        List<string> expectedOutputObjectIds = ["string"];

        Assert.Equal(expectedFinalResponse, deserialized.FinalResponse);
        Assert.Equal(expectedLogs, deserialized.Logs);
        Assert.Equal(expectedOutput, deserialized.Output);
        Assert.NotNull(deserialized.OutputObjectIds);
        Assert.Equal(expectedOutputObjectIds.Count, deserialized.OutputObjectIds.Count);
        for (int i = 0; i < expectedOutputObjectIds.Count; i++)
        {
            Assert.Equal(expectedOutputObjectIds[i], deserialized.OutputObjectIds[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Run::Result
        {
            FinalResponse = new()
            {
                CreatedObjectIds = ["string"],
                Issues = ["string"],
                Summary = "summary",
            },
            Logs = new() { Opencode = "opencode", Runner = "runner" },
            Output = "output",
            OutputObjectIds = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Run::Result
        {
            FinalResponse = new()
            {
                CreatedObjectIds = ["string"],
                Issues = ["string"],
                Summary = "summary",
            },
            Logs = new() { Opencode = "opencode", Runner = "runner" },
        };

        Assert.Null(model.Output);
        Assert.False(model.RawData.ContainsKey("output"));
        Assert.Null(model.OutputObjectIds);
        Assert.False(model.RawData.ContainsKey("outputObjectIds"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Run::Result
        {
            FinalResponse = new()
            {
                CreatedObjectIds = ["string"],
                Issues = ["string"],
                Summary = "summary",
            },
            Logs = new() { Opencode = "opencode", Runner = "runner" },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Run::Result
        {
            FinalResponse = new()
            {
                CreatedObjectIds = ["string"],
                Issues = ["string"],
                Summary = "summary",
            },
            Logs = new() { Opencode = "opencode", Runner = "runner" },

            // Null should be interpreted as omitted for these properties
            Output = null,
            OutputObjectIds = null,
        };

        Assert.Null(model.Output);
        Assert.False(model.RawData.ContainsKey("output"));
        Assert.Null(model.OutputObjectIds);
        Assert.False(model.RawData.ContainsKey("outputObjectIds"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Run::Result
        {
            FinalResponse = new()
            {
                CreatedObjectIds = ["string"],
                Issues = ["string"],
                Summary = "summary",
            },
            Logs = new() { Opencode = "opencode", Runner = "runner" },

            // Null should be interpreted as omitted for these properties
            Output = null,
            OutputObjectIds = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Run::Result { Output = "output", OutputObjectIds = ["string"] };

        Assert.Null(model.FinalResponse);
        Assert.False(model.RawData.ContainsKey("finalResponse"));
        Assert.Null(model.Logs);
        Assert.False(model.RawData.ContainsKey("logs"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Run::Result { Output = "output", OutputObjectIds = ["string"] };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Run::Result
        {
            Output = "output",
            OutputObjectIds = ["string"],

            FinalResponse = null,
            Logs = null,
        };

        Assert.Null(model.FinalResponse);
        Assert.True(model.RawData.ContainsKey("finalResponse"));
        Assert.Null(model.Logs);
        Assert.True(model.RawData.ContainsKey("logs"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Run::Result
        {
            Output = "output",
            OutputObjectIds = ["string"],

            FinalResponse = null,
            Logs = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Run::Result
        {
            FinalResponse = new()
            {
                CreatedObjectIds = ["string"],
                Issues = ["string"],
                Summary = "summary",
            },
            Logs = new() { Opencode = "opencode", Runner = "runner" },
            Output = "output",
            OutputObjectIds = ["string"],
        };

        Run::Result copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FinalResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Run::FinalResponse
        {
            CreatedObjectIds = ["string"],
            Issues = ["string"],
            Summary = "summary",
        };

        List<string> expectedCreatedObjectIds = ["string"];
        List<string> expectedIssues = ["string"];
        string expectedSummary = "summary";

        Assert.NotNull(model.CreatedObjectIds);
        Assert.Equal(expectedCreatedObjectIds.Count, model.CreatedObjectIds.Count);
        for (int i = 0; i < expectedCreatedObjectIds.Count; i++)
        {
            Assert.Equal(expectedCreatedObjectIds[i], model.CreatedObjectIds[i]);
        }
        Assert.NotNull(model.Issues);
        Assert.Equal(expectedIssues.Count, model.Issues.Count);
        for (int i = 0; i < expectedIssues.Count; i++)
        {
            Assert.Equal(expectedIssues[i], model.Issues[i]);
        }
        Assert.Equal(expectedSummary, model.Summary);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Run::FinalResponse
        {
            CreatedObjectIds = ["string"],
            Issues = ["string"],
            Summary = "summary",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Run::FinalResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Run::FinalResponse
        {
            CreatedObjectIds = ["string"],
            Issues = ["string"],
            Summary = "summary",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Run::FinalResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<string> expectedCreatedObjectIds = ["string"];
        List<string> expectedIssues = ["string"];
        string expectedSummary = "summary";

        Assert.NotNull(deserialized.CreatedObjectIds);
        Assert.Equal(expectedCreatedObjectIds.Count, deserialized.CreatedObjectIds.Count);
        for (int i = 0; i < expectedCreatedObjectIds.Count; i++)
        {
            Assert.Equal(expectedCreatedObjectIds[i], deserialized.CreatedObjectIds[i]);
        }
        Assert.NotNull(deserialized.Issues);
        Assert.Equal(expectedIssues.Count, deserialized.Issues.Count);
        for (int i = 0; i < expectedIssues.Count; i++)
        {
            Assert.Equal(expectedIssues[i], deserialized.Issues[i]);
        }
        Assert.Equal(expectedSummary, deserialized.Summary);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Run::FinalResponse
        {
            CreatedObjectIds = ["string"],
            Issues = ["string"],
            Summary = "summary",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Run::FinalResponse { };

        Assert.Null(model.CreatedObjectIds);
        Assert.False(model.RawData.ContainsKey("createdObjectIds"));
        Assert.Null(model.Issues);
        Assert.False(model.RawData.ContainsKey("issues"));
        Assert.Null(model.Summary);
        Assert.False(model.RawData.ContainsKey("summary"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Run::FinalResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Run::FinalResponse
        {
            // Null should be interpreted as omitted for these properties
            CreatedObjectIds = null,
            Issues = null,
            Summary = null,
        };

        Assert.Null(model.CreatedObjectIds);
        Assert.False(model.RawData.ContainsKey("createdObjectIds"));
        Assert.Null(model.Issues);
        Assert.False(model.RawData.ContainsKey("issues"));
        Assert.Null(model.Summary);
        Assert.False(model.RawData.ContainsKey("summary"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Run::FinalResponse
        {
            // Null should be interpreted as omitted for these properties
            CreatedObjectIds = null,
            Issues = null,
            Summary = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Run::FinalResponse
        {
            CreatedObjectIds = ["string"],
            Issues = ["string"],
            Summary = "summary",
        };

        Run::FinalResponse copied = new(model);

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

public class RuntimeStateTest : TestBase
{
    [Theory]
    [InlineData(Run::RuntimeState.Running)]
    [InlineData(Run::RuntimeState.Stopped)]
    [InlineData(Run::RuntimeState.Archived)]
    [InlineData(Run::RuntimeState.Ended)]
    [InlineData(Run::RuntimeState.Error)]
    public void Validation_Works(Run::RuntimeState rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Run::RuntimeState> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Run::RuntimeState>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Run::RuntimeState.Running)]
    [InlineData(Run::RuntimeState.Stopped)]
    [InlineData(Run::RuntimeState.Archived)]
    [InlineData(Run::RuntimeState.Ended)]
    [InlineData(Run::RuntimeState.Error)]
    public void SerializationRoundtrip_Works(Run::RuntimeState rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Run::RuntimeState> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Run::RuntimeState>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Run::RuntimeState>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Run::RuntimeState>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
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

public class RunGetDetailsResponseUsageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Run::RunGetDetailsResponseUsage
        {
            DurationMs = 0,
            Entries =
            [
                new()
                {
                    ID = "id",
                    CompletionTokens = 0,
                    CostMicros = 0,
                    Endpoint = "endpoint",
                    Kind = Run::Kind.Llm,
                    Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Method = "method",
                    Model = "model",
                    PromptTokens = 0,
                    Service = "service",
                    StatusCode = 0,
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    TotalTokens = 0,
                },
            ],
            InputTokens = 0,
            Model = "model",
            OutputTokens = 0,
            Summary = new()
            {
                CostMicros = 0,
                TotalInputTokens = 0,
                TotalOutputTokens = 0,
                TotalTokens = 0,
            },
            ToolCalls = 0,
        };

        long expectedDurationMs = 0;
        List<Run::Entry> expectedEntries =
        [
            new()
            {
                ID = "id",
                CompletionTokens = 0,
                CostMicros = 0,
                Endpoint = "endpoint",
                Kind = Run::Kind.Llm,
                Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                Method = "method",
                Model = "model",
                PromptTokens = 0,
                Service = "service",
                StatusCode = 0,
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                TotalTokens = 0,
            },
        ];
        long expectedInputTokens = 0;
        string expectedModel = "model";
        long expectedOutputTokens = 0;
        Run::Summary expectedSummary = new()
        {
            CostMicros = 0,
            TotalInputTokens = 0,
            TotalOutputTokens = 0,
            TotalTokens = 0,
        };
        long expectedToolCalls = 0;

        Assert.Equal(expectedDurationMs, model.DurationMs);
        Assert.NotNull(model.Entries);
        Assert.Equal(expectedEntries.Count, model.Entries.Count);
        for (int i = 0; i < expectedEntries.Count; i++)
        {
            Assert.Equal(expectedEntries[i], model.Entries[i]);
        }
        Assert.Equal(expectedInputTokens, model.InputTokens);
        Assert.Equal(expectedModel, model.Model);
        Assert.Equal(expectedOutputTokens, model.OutputTokens);
        Assert.Equal(expectedSummary, model.Summary);
        Assert.Equal(expectedToolCalls, model.ToolCalls);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Run::RunGetDetailsResponseUsage
        {
            DurationMs = 0,
            Entries =
            [
                new()
                {
                    ID = "id",
                    CompletionTokens = 0,
                    CostMicros = 0,
                    Endpoint = "endpoint",
                    Kind = Run::Kind.Llm,
                    Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Method = "method",
                    Model = "model",
                    PromptTokens = 0,
                    Service = "service",
                    StatusCode = 0,
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    TotalTokens = 0,
                },
            ],
            InputTokens = 0,
            Model = "model",
            OutputTokens = 0,
            Summary = new()
            {
                CostMicros = 0,
                TotalInputTokens = 0,
                TotalOutputTokens = 0,
                TotalTokens = 0,
            },
            ToolCalls = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Run::RunGetDetailsResponseUsage>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Run::RunGetDetailsResponseUsage
        {
            DurationMs = 0,
            Entries =
            [
                new()
                {
                    ID = "id",
                    CompletionTokens = 0,
                    CostMicros = 0,
                    Endpoint = "endpoint",
                    Kind = Run::Kind.Llm,
                    Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Method = "method",
                    Model = "model",
                    PromptTokens = 0,
                    Service = "service",
                    StatusCode = 0,
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    TotalTokens = 0,
                },
            ],
            InputTokens = 0,
            Model = "model",
            OutputTokens = 0,
            Summary = new()
            {
                CostMicros = 0,
                TotalInputTokens = 0,
                TotalOutputTokens = 0,
                TotalTokens = 0,
            },
            ToolCalls = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Run::RunGetDetailsResponseUsage>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedDurationMs = 0;
        List<Run::Entry> expectedEntries =
        [
            new()
            {
                ID = "id",
                CompletionTokens = 0,
                CostMicros = 0,
                Endpoint = "endpoint",
                Kind = Run::Kind.Llm,
                Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                Method = "method",
                Model = "model",
                PromptTokens = 0,
                Service = "service",
                StatusCode = 0,
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                TotalTokens = 0,
            },
        ];
        long expectedInputTokens = 0;
        string expectedModel = "model";
        long expectedOutputTokens = 0;
        Run::Summary expectedSummary = new()
        {
            CostMicros = 0,
            TotalInputTokens = 0,
            TotalOutputTokens = 0,
            TotalTokens = 0,
        };
        long expectedToolCalls = 0;

        Assert.Equal(expectedDurationMs, deserialized.DurationMs);
        Assert.NotNull(deserialized.Entries);
        Assert.Equal(expectedEntries.Count, deserialized.Entries.Count);
        for (int i = 0; i < expectedEntries.Count; i++)
        {
            Assert.Equal(expectedEntries[i], deserialized.Entries[i]);
        }
        Assert.Equal(expectedInputTokens, deserialized.InputTokens);
        Assert.Equal(expectedModel, deserialized.Model);
        Assert.Equal(expectedOutputTokens, deserialized.OutputTokens);
        Assert.Equal(expectedSummary, deserialized.Summary);
        Assert.Equal(expectedToolCalls, deserialized.ToolCalls);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Run::RunGetDetailsResponseUsage
        {
            DurationMs = 0,
            Entries =
            [
                new()
                {
                    ID = "id",
                    CompletionTokens = 0,
                    CostMicros = 0,
                    Endpoint = "endpoint",
                    Kind = Run::Kind.Llm,
                    Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Method = "method",
                    Model = "model",
                    PromptTokens = 0,
                    Service = "service",
                    StatusCode = 0,
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    TotalTokens = 0,
                },
            ],
            InputTokens = 0,
            Model = "model",
            OutputTokens = 0,
            Summary = new()
            {
                CostMicros = 0,
                TotalInputTokens = 0,
                TotalOutputTokens = 0,
                TotalTokens = 0,
            },
            ToolCalls = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Run::RunGetDetailsResponseUsage
        {
            Summary = new()
            {
                CostMicros = 0,
                TotalInputTokens = 0,
                TotalOutputTokens = 0,
                TotalTokens = 0,
            },
        };

        Assert.Null(model.DurationMs);
        Assert.False(model.RawData.ContainsKey("durationMs"));
        Assert.Null(model.Entries);
        Assert.False(model.RawData.ContainsKey("entries"));
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
        var model = new Run::RunGetDetailsResponseUsage
        {
            Summary = new()
            {
                CostMicros = 0,
                TotalInputTokens = 0,
                TotalOutputTokens = 0,
                TotalTokens = 0,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Run::RunGetDetailsResponseUsage
        {
            Summary = new()
            {
                CostMicros = 0,
                TotalInputTokens = 0,
                TotalOutputTokens = 0,
                TotalTokens = 0,
            },

            // Null should be interpreted as omitted for these properties
            DurationMs = null,
            Entries = null,
            InputTokens = null,
            Model = null,
            OutputTokens = null,
            ToolCalls = null,
        };

        Assert.Null(model.DurationMs);
        Assert.False(model.RawData.ContainsKey("durationMs"));
        Assert.Null(model.Entries);
        Assert.False(model.RawData.ContainsKey("entries"));
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
        var model = new Run::RunGetDetailsResponseUsage
        {
            Summary = new()
            {
                CostMicros = 0,
                TotalInputTokens = 0,
                TotalOutputTokens = 0,
                TotalTokens = 0,
            },

            // Null should be interpreted as omitted for these properties
            DurationMs = null,
            Entries = null,
            InputTokens = null,
            Model = null,
            OutputTokens = null,
            ToolCalls = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Run::RunGetDetailsResponseUsage
        {
            DurationMs = 0,
            Entries =
            [
                new()
                {
                    ID = "id",
                    CompletionTokens = 0,
                    CostMicros = 0,
                    Endpoint = "endpoint",
                    Kind = Run::Kind.Llm,
                    Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Method = "method",
                    Model = "model",
                    PromptTokens = 0,
                    Service = "service",
                    StatusCode = 0,
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    TotalTokens = 0,
                },
            ],
            InputTokens = 0,
            Model = "model",
            OutputTokens = 0,
            ToolCalls = 0,
        };

        Assert.Null(model.Summary);
        Assert.False(model.RawData.ContainsKey("summary"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Run::RunGetDetailsResponseUsage
        {
            DurationMs = 0,
            Entries =
            [
                new()
                {
                    ID = "id",
                    CompletionTokens = 0,
                    CostMicros = 0,
                    Endpoint = "endpoint",
                    Kind = Run::Kind.Llm,
                    Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Method = "method",
                    Model = "model",
                    PromptTokens = 0,
                    Service = "service",
                    StatusCode = 0,
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    TotalTokens = 0,
                },
            ],
            InputTokens = 0,
            Model = "model",
            OutputTokens = 0,
            ToolCalls = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Run::RunGetDetailsResponseUsage
        {
            DurationMs = 0,
            Entries =
            [
                new()
                {
                    ID = "id",
                    CompletionTokens = 0,
                    CostMicros = 0,
                    Endpoint = "endpoint",
                    Kind = Run::Kind.Llm,
                    Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Method = "method",
                    Model = "model",
                    PromptTokens = 0,
                    Service = "service",
                    StatusCode = 0,
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    TotalTokens = 0,
                },
            ],
            InputTokens = 0,
            Model = "model",
            OutputTokens = 0,
            ToolCalls = 0,

            Summary = null,
        };

        Assert.Null(model.Summary);
        Assert.True(model.RawData.ContainsKey("summary"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Run::RunGetDetailsResponseUsage
        {
            DurationMs = 0,
            Entries =
            [
                new()
                {
                    ID = "id",
                    CompletionTokens = 0,
                    CostMicros = 0,
                    Endpoint = "endpoint",
                    Kind = Run::Kind.Llm,
                    Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Method = "method",
                    Model = "model",
                    PromptTokens = 0,
                    Service = "service",
                    StatusCode = 0,
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    TotalTokens = 0,
                },
            ],
            InputTokens = 0,
            Model = "model",
            OutputTokens = 0,
            ToolCalls = 0,

            Summary = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Run::RunGetDetailsResponseUsage
        {
            DurationMs = 0,
            Entries =
            [
                new()
                {
                    ID = "id",
                    CompletionTokens = 0,
                    CostMicros = 0,
                    Endpoint = "endpoint",
                    Kind = Run::Kind.Llm,
                    Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Method = "method",
                    Model = "model",
                    PromptTokens = 0,
                    Service = "service",
                    StatusCode = 0,
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    TotalTokens = 0,
                },
            ],
            InputTokens = 0,
            Model = "model",
            OutputTokens = 0,
            Summary = new()
            {
                CostMicros = 0,
                TotalInputTokens = 0,
                TotalOutputTokens = 0,
                TotalTokens = 0,
            },
            ToolCalls = 0,
        };

        Run::RunGetDetailsResponseUsage copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Run::Entry
        {
            ID = "id",
            CompletionTokens = 0,
            CostMicros = 0,
            Endpoint = "endpoint",
            Kind = Run::Kind.Llm,
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Method = "method",
            Model = "model",
            PromptTokens = 0,
            Service = "service",
            StatusCode = 0,
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TotalTokens = 0,
        };

        string expectedID = "id";
        long expectedCompletionTokens = 0;
        long expectedCostMicros = 0;
        string expectedEndpoint = "endpoint";
        ApiEnum<string, Run::Kind> expectedKind = Run::Kind.Llm;
        JsonElement expectedMetadata = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedMethod = "method";
        string expectedModel = "model";
        long expectedPromptTokens = 0;
        string expectedService = "service";
        long expectedStatusCode = 0;
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedTotalTokens = 0;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCompletionTokens, model.CompletionTokens);
        Assert.Equal(expectedCostMicros, model.CostMicros);
        Assert.Equal(expectedEndpoint, model.Endpoint);
        Assert.Equal(expectedKind, model.Kind);
        Assert.NotNull(model.Metadata);
        Assert.True(JsonElement.DeepEquals(expectedMetadata, model.Metadata.Value));
        Assert.Equal(expectedMethod, model.Method);
        Assert.Equal(expectedModel, model.Model);
        Assert.Equal(expectedPromptTokens, model.PromptTokens);
        Assert.Equal(expectedService, model.Service);
        Assert.Equal(expectedStatusCode, model.StatusCode);
        Assert.Equal(expectedTimestamp, model.Timestamp);
        Assert.Equal(expectedTotalTokens, model.TotalTokens);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Run::Entry
        {
            ID = "id",
            CompletionTokens = 0,
            CostMicros = 0,
            Endpoint = "endpoint",
            Kind = Run::Kind.Llm,
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Method = "method",
            Model = "model",
            PromptTokens = 0,
            Service = "service",
            StatusCode = 0,
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TotalTokens = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Run::Entry>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Run::Entry
        {
            ID = "id",
            CompletionTokens = 0,
            CostMicros = 0,
            Endpoint = "endpoint",
            Kind = Run::Kind.Llm,
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Method = "method",
            Model = "model",
            PromptTokens = 0,
            Service = "service",
            StatusCode = 0,
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TotalTokens = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Run::Entry>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        long expectedCompletionTokens = 0;
        long expectedCostMicros = 0;
        string expectedEndpoint = "endpoint";
        ApiEnum<string, Run::Kind> expectedKind = Run::Kind.Llm;
        JsonElement expectedMetadata = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedMethod = "method";
        string expectedModel = "model";
        long expectedPromptTokens = 0;
        string expectedService = "service";
        long expectedStatusCode = 0;
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedTotalTokens = 0;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCompletionTokens, deserialized.CompletionTokens);
        Assert.Equal(expectedCostMicros, deserialized.CostMicros);
        Assert.Equal(expectedEndpoint, deserialized.Endpoint);
        Assert.Equal(expectedKind, deserialized.Kind);
        Assert.NotNull(deserialized.Metadata);
        Assert.True(JsonElement.DeepEquals(expectedMetadata, deserialized.Metadata.Value));
        Assert.Equal(expectedMethod, deserialized.Method);
        Assert.Equal(expectedModel, deserialized.Model);
        Assert.Equal(expectedPromptTokens, deserialized.PromptTokens);
        Assert.Equal(expectedService, deserialized.Service);
        Assert.Equal(expectedStatusCode, deserialized.StatusCode);
        Assert.Equal(expectedTimestamp, deserialized.Timestamp);
        Assert.Equal(expectedTotalTokens, deserialized.TotalTokens);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Run::Entry
        {
            ID = "id",
            CompletionTokens = 0,
            CostMicros = 0,
            Endpoint = "endpoint",
            Kind = Run::Kind.Llm,
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Method = "method",
            Model = "model",
            PromptTokens = 0,
            Service = "service",
            StatusCode = 0,
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TotalTokens = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Run::Entry
        {
            CompletionTokens = 0,
            Endpoint = "endpoint",
            Method = "method",
            Model = "model",
            PromptTokens = 0,
            StatusCode = 0,
            TotalTokens = 0,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CostMicros);
        Assert.False(model.RawData.ContainsKey("costMicros"));
        Assert.Null(model.Kind);
        Assert.False(model.RawData.ContainsKey("kind"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.Service);
        Assert.False(model.RawData.ContainsKey("service"));
        Assert.Null(model.Timestamp);
        Assert.False(model.RawData.ContainsKey("timestamp"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Run::Entry
        {
            CompletionTokens = 0,
            Endpoint = "endpoint",
            Method = "method",
            Model = "model",
            PromptTokens = 0,
            StatusCode = 0,
            TotalTokens = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Run::Entry
        {
            CompletionTokens = 0,
            Endpoint = "endpoint",
            Method = "method",
            Model = "model",
            PromptTokens = 0,
            StatusCode = 0,
            TotalTokens = 0,

            // Null should be interpreted as omitted for these properties
            ID = null,
            CostMicros = null,
            Kind = null,
            Metadata = null,
            Service = null,
            Timestamp = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CostMicros);
        Assert.False(model.RawData.ContainsKey("costMicros"));
        Assert.Null(model.Kind);
        Assert.False(model.RawData.ContainsKey("kind"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.Service);
        Assert.False(model.RawData.ContainsKey("service"));
        Assert.Null(model.Timestamp);
        Assert.False(model.RawData.ContainsKey("timestamp"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Run::Entry
        {
            CompletionTokens = 0,
            Endpoint = "endpoint",
            Method = "method",
            Model = "model",
            PromptTokens = 0,
            StatusCode = 0,
            TotalTokens = 0,

            // Null should be interpreted as omitted for these properties
            ID = null,
            CostMicros = null,
            Kind = null,
            Metadata = null,
            Service = null,
            Timestamp = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Run::Entry
        {
            ID = "id",
            CostMicros = 0,
            Kind = Run::Kind.Llm,
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Service = "service",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.CompletionTokens);
        Assert.False(model.RawData.ContainsKey("completionTokens"));
        Assert.Null(model.Endpoint);
        Assert.False(model.RawData.ContainsKey("endpoint"));
        Assert.Null(model.Method);
        Assert.False(model.RawData.ContainsKey("method"));
        Assert.Null(model.Model);
        Assert.False(model.RawData.ContainsKey("model"));
        Assert.Null(model.PromptTokens);
        Assert.False(model.RawData.ContainsKey("promptTokens"));
        Assert.Null(model.StatusCode);
        Assert.False(model.RawData.ContainsKey("statusCode"));
        Assert.Null(model.TotalTokens);
        Assert.False(model.RawData.ContainsKey("totalTokens"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Run::Entry
        {
            ID = "id",
            CostMicros = 0,
            Kind = Run::Kind.Llm,
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Service = "service",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Run::Entry
        {
            ID = "id",
            CostMicros = 0,
            Kind = Run::Kind.Llm,
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Service = "service",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            CompletionTokens = null,
            Endpoint = null,
            Method = null,
            Model = null,
            PromptTokens = null,
            StatusCode = null,
            TotalTokens = null,
        };

        Assert.Null(model.CompletionTokens);
        Assert.True(model.RawData.ContainsKey("completionTokens"));
        Assert.Null(model.Endpoint);
        Assert.True(model.RawData.ContainsKey("endpoint"));
        Assert.Null(model.Method);
        Assert.True(model.RawData.ContainsKey("method"));
        Assert.Null(model.Model);
        Assert.True(model.RawData.ContainsKey("model"));
        Assert.Null(model.PromptTokens);
        Assert.True(model.RawData.ContainsKey("promptTokens"));
        Assert.Null(model.StatusCode);
        Assert.True(model.RawData.ContainsKey("statusCode"));
        Assert.Null(model.TotalTokens);
        Assert.True(model.RawData.ContainsKey("totalTokens"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Run::Entry
        {
            ID = "id",
            CostMicros = 0,
            Kind = Run::Kind.Llm,
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Service = "service",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            CompletionTokens = null,
            Endpoint = null,
            Method = null,
            Model = null,
            PromptTokens = null,
            StatusCode = null,
            TotalTokens = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Run::Entry
        {
            ID = "id",
            CompletionTokens = 0,
            CostMicros = 0,
            Endpoint = "endpoint",
            Kind = Run::Kind.Llm,
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Method = "method",
            Model = "model",
            PromptTokens = 0,
            Service = "service",
            StatusCode = 0,
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TotalTokens = 0,
        };

        Run::Entry copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class KindTest : TestBase
{
    [Theory]
    [InlineData(Run::Kind.Llm)]
    [InlineData(Run::Kind.Api)]
    public void Validation_Works(Run::Kind rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Run::Kind> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Run::Kind>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Run::Kind.Llm)]
    [InlineData(Run::Kind.Api)]
    public void SerializationRoundtrip_Works(Run::Kind rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Run::Kind> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Run::Kind>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Run::Kind>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Run::Kind>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SummaryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Run::Summary
        {
            CostMicros = 0,
            TotalInputTokens = 0,
            TotalOutputTokens = 0,
            TotalTokens = 0,
        };

        long expectedCostMicros = 0;
        long expectedTotalInputTokens = 0;
        long expectedTotalOutputTokens = 0;
        long expectedTotalTokens = 0;

        Assert.Equal(expectedCostMicros, model.CostMicros);
        Assert.Equal(expectedTotalInputTokens, model.TotalInputTokens);
        Assert.Equal(expectedTotalOutputTokens, model.TotalOutputTokens);
        Assert.Equal(expectedTotalTokens, model.TotalTokens);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Run::Summary
        {
            CostMicros = 0,
            TotalInputTokens = 0,
            TotalOutputTokens = 0,
            TotalTokens = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Run::Summary>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Run::Summary
        {
            CostMicros = 0,
            TotalInputTokens = 0,
            TotalOutputTokens = 0,
            TotalTokens = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Run::Summary>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedCostMicros = 0;
        long expectedTotalInputTokens = 0;
        long expectedTotalOutputTokens = 0;
        long expectedTotalTokens = 0;

        Assert.Equal(expectedCostMicros, deserialized.CostMicros);
        Assert.Equal(expectedTotalInputTokens, deserialized.TotalInputTokens);
        Assert.Equal(expectedTotalOutputTokens, deserialized.TotalOutputTokens);
        Assert.Equal(expectedTotalTokens, deserialized.TotalTokens);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Run::Summary
        {
            CostMicros = 0,
            TotalInputTokens = 0,
            TotalOutputTokens = 0,
            TotalTokens = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Run::Summary { };

        Assert.Null(model.CostMicros);
        Assert.False(model.RawData.ContainsKey("costMicros"));
        Assert.Null(model.TotalInputTokens);
        Assert.False(model.RawData.ContainsKey("totalInputTokens"));
        Assert.Null(model.TotalOutputTokens);
        Assert.False(model.RawData.ContainsKey("totalOutputTokens"));
        Assert.Null(model.TotalTokens);
        Assert.False(model.RawData.ContainsKey("totalTokens"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Run::Summary { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Run::Summary
        {
            // Null should be interpreted as omitted for these properties
            CostMicros = null,
            TotalInputTokens = null,
            TotalOutputTokens = null,
            TotalTokens = null,
        };

        Assert.Null(model.CostMicros);
        Assert.False(model.RawData.ContainsKey("costMicros"));
        Assert.Null(model.TotalInputTokens);
        Assert.False(model.RawData.ContainsKey("totalInputTokens"));
        Assert.Null(model.TotalOutputTokens);
        Assert.False(model.RawData.ContainsKey("totalOutputTokens"));
        Assert.Null(model.TotalTokens);
        Assert.False(model.RawData.ContainsKey("totalTokens"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Run::Summary
        {
            // Null should be interpreted as omitted for these properties
            CostMicros = null,
            TotalInputTokens = null,
            TotalOutputTokens = null,
            TotalTokens = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Run::Summary
        {
            CostMicros = 0,
            TotalInputTokens = 0,
            TotalOutputTokens = 0,
            TotalTokens = 0,
        };

        Run::Summary copied = new(model);

        Assert.Equal(model, copied);
    }
}
