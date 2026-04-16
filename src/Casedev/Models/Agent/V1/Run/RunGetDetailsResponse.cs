using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Casedev.Core;
using Casedev.Exceptions;
using System = System;

namespace Casedev.Models.Agent.V1.Run;

[JsonConverter(typeof(JsonModelConverter<RunGetDetailsResponse, RunGetDetailsResponseFromRaw>))]
public sealed record class RunGetDetailsResponse : JsonModel
{
    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    public string? AgentID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("agentId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("agentId", value);
        }
    }

    public System::DateTimeOffset? CompletedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("completedAt");
        }
        init { this._rawData.Set("completedAt", value); }
    }

    public System::DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("createdAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("createdAt", value);
        }
    }

    public string? Guidance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("guidance");
        }
        init { this._rawData.Set("guidance", value); }
    }

    /// <summary>
    /// Deprecated legacy Modal sandbox ID. Prefer `provider` and `runtimeId`.
    /// </summary>
    [System::Obsolete("deprecated")]
    public string? ModalSandboxID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("modalSandboxId");
        }
        init { this._rawData.Set("modalSandboxId", value); }
    }

    public string? Model
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("model");
        }
        init { this._rawData.Set("model", value); }
    }

    public string? Prompt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("prompt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("prompt", value);
        }
    }

    /// <summary>
    /// Runtime provider for this run
    /// </summary>
    public ApiEnum<string, Provider>? Provider
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Provider>>("provider");
        }
        init { this._rawData.Set("provider", value); }
    }

    /// <summary>
    /// Final output from the agent
    /// </summary>
    public Result? Result
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Result>("result");
        }
        init { this._rawData.Set("result", value); }
    }

    /// <summary>
    /// Provider-specific runtime identifier
    /// </summary>
    public string? RuntimeID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("runtimeId");
        }
        init { this._rawData.Set("runtimeId", value); }
    }

    /// <summary>
    /// Current runtime state, when available
    /// </summary>
    public ApiEnum<string, RuntimeState>? RuntimeState
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, RuntimeState>>("runtimeState");
        }
        init { this._rawData.Set("runtimeState", value); }
    }

    public System::DateTimeOffset? StartedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("startedAt");
        }
        init { this._rawData.Set("startedAt", value); }
    }

    public ApiEnum<string, RunGetDetailsResponseStatus>? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, RunGetDetailsResponseStatus>>(
                "status"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("status", value);
        }
    }

    public IReadOnlyList<Step>? Steps
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Step>>("steps");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Step>?>(
                "steps",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Token usage statistics
    /// </summary>
    public RunGetDetailsResponseUsage? Usage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<RunGetDetailsResponseUsage>("usage");
        }
        init { this._rawData.Set("usage", value); }
    }

    /// <summary>
    /// Durable workflow run ID
    /// </summary>
    public string? WorkflowID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("workflowId");
        }
        init { this._rawData.Set("workflowId", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AgentID;
        _ = this.CompletedAt;
        _ = this.CreatedAt;
        _ = this.Guidance;
        _ = this.ModalSandboxID;
        _ = this.Model;
        _ = this.Prompt;
        this.Provider?.Validate();
        this.Result?.Validate();
        _ = this.RuntimeID;
        this.RuntimeState?.Validate();
        _ = this.StartedAt;
        this.Status?.Validate();
        foreach (var item in this.Steps ?? [])
        {
            item.Validate();
        }
        this.Usage?.Validate();
        _ = this.WorkflowID;
    }

    public RunGetDetailsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RunGetDetailsResponse(RunGetDetailsResponse runGetDetailsResponse)
        : base(runGetDetailsResponse) { }
#pragma warning restore CS8618

    public RunGetDetailsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RunGetDetailsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RunGetDetailsResponseFromRaw.FromRawUnchecked"/>
    public static RunGetDetailsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RunGetDetailsResponseFromRaw : IFromRawJson<RunGetDetailsResponse>
{
    /// <inheritdoc/>
    public RunGetDetailsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RunGetDetailsResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Runtime provider for this run
/// </summary>
[JsonConverter(typeof(ProviderConverter))]
public enum Provider
{
    Daytona,
    Vercel,
}

sealed class ProviderConverter : JsonConverter<Provider>
{
    public override Provider Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "daytona" => Provider.Daytona,
            "vercel" => Provider.Vercel,
            _ => (Provider)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Provider value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Provider.Daytona => "daytona",
                Provider.Vercel => "vercel",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Final output from the agent
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Result, ResultFromRaw>))]
public sealed record class Result : JsonModel
{
    /// <summary>
    /// Compact agent-facing result summary and execution issues
    /// </summary>
    public FinalResponse? FinalResponse
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FinalResponse>("finalResponse");
        }
        init { this._rawData.Set("finalResponse", value); }
    }

    /// <summary>
    /// Sandbox execution logs (OpenCode server + runner script)
    /// </summary>
    public Logs? Logs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Logs>("logs");
        }
        init { this._rawData.Set("logs", value); }
    }

    public string? Output
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("output");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("output", value);
        }
    }

    public IReadOnlyList<string>? OutputObjectIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("outputObjectIds");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "outputObjectIds",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.FinalResponse?.Validate();
        this.Logs?.Validate();
        _ = this.Output;
        _ = this.OutputObjectIds;
    }

    public Result() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Result(Result result)
        : base(result) { }
#pragma warning restore CS8618

    public Result(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Result(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ResultFromRaw.FromRawUnchecked"/>
    public static Result FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ResultFromRaw : IFromRawJson<Result>
{
    /// <inheritdoc/>
    public Result FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Result.FromRawUnchecked(rawData);
}

/// <summary>
/// Compact agent-facing result summary and execution issues
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FinalResponse, FinalResponseFromRaw>))]
public sealed record class FinalResponse : JsonModel
{
    public IReadOnlyList<string>? CreatedObjectIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("createdObjectIds");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "createdObjectIds",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public IReadOnlyList<string>? Issues
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("issues");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "issues",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? Summary
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("summary");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("summary", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CreatedObjectIds;
        _ = this.Issues;
        _ = this.Summary;
    }

    public FinalResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FinalResponse(FinalResponse finalResponse)
        : base(finalResponse) { }
#pragma warning restore CS8618

    public FinalResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FinalResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FinalResponseFromRaw.FromRawUnchecked"/>
    public static FinalResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FinalResponseFromRaw : IFromRawJson<FinalResponse>
{
    /// <inheritdoc/>
    public FinalResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FinalResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Sandbox execution logs (OpenCode server + runner script)
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Logs, LogsFromRaw>))]
public sealed record class Logs : JsonModel
{
    /// <summary>
    /// OpenCode server stdout/stderr
    /// </summary>
    public string? Opencode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("opencode");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("opencode", value);
        }
    }

    /// <summary>
    /// Runner script stdout/stderr
    /// </summary>
    public string? Runner
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("runner");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("runner", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Opencode;
        _ = this.Runner;
    }

    public Logs() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Logs(Logs logs)
        : base(logs) { }
#pragma warning restore CS8618

    public Logs(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Logs(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LogsFromRaw.FromRawUnchecked"/>
    public static Logs FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LogsFromRaw : IFromRawJson<Logs>
{
    /// <inheritdoc/>
    public Logs FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Logs.FromRawUnchecked(rawData);
}

/// <summary>
/// Current runtime state, when available
/// </summary>
[JsonConverter(typeof(RuntimeStateConverter))]
public enum RuntimeState
{
    Running,
    Stopped,
    Archived,
    Ended,
    Error,
}

sealed class RuntimeStateConverter : JsonConverter<RuntimeState>
{
    public override RuntimeState Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "running" => RuntimeState.Running,
            "stopped" => RuntimeState.Stopped,
            "archived" => RuntimeState.Archived,
            "ended" => RuntimeState.Ended,
            "error" => RuntimeState.Error,
            _ => (RuntimeState)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RuntimeState value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RuntimeState.Running => "running",
                RuntimeState.Stopped => "stopped",
                RuntimeState.Archived => "archived",
                RuntimeState.Ended => "ended",
                RuntimeState.Error => "error",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(RunGetDetailsResponseStatusConverter))]
public enum RunGetDetailsResponseStatus
{
    Queued,
    Running,
    Completed,
    Failed,
    Cancelled,
}

sealed class RunGetDetailsResponseStatusConverter : JsonConverter<RunGetDetailsResponseStatus>
{
    public override RunGetDetailsResponseStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "queued" => RunGetDetailsResponseStatus.Queued,
            "running" => RunGetDetailsResponseStatus.Running,
            "completed" => RunGetDetailsResponseStatus.Completed,
            "failed" => RunGetDetailsResponseStatus.Failed,
            "cancelled" => RunGetDetailsResponseStatus.Cancelled,
            _ => (RunGetDetailsResponseStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RunGetDetailsResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RunGetDetailsResponseStatus.Queued => "queued",
                RunGetDetailsResponseStatus.Running => "running",
                RunGetDetailsResponseStatus.Completed => "completed",
                RunGetDetailsResponseStatus.Failed => "failed",
                RunGetDetailsResponseStatus.Cancelled => "cancelled",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<Step, StepFromRaw>))]
public sealed record class Step : JsonModel
{
    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    public string? Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("content");
        }
        init { this._rawData.Set("content", value); }
    }

    public long? DurationMs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("durationMs");
        }
        init { this._rawData.Set("durationMs", value); }
    }

    public System::DateTimeOffset? Timestamp
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("timestamp");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("timestamp", value);
        }
    }

    public JsonElement? ToolInput
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("toolInput");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("toolInput", value);
        }
    }

    public string? ToolName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("toolName");
        }
        init { this._rawData.Set("toolName", value); }
    }

    public JsonElement? ToolOutput
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("toolOutput");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("toolOutput", value);
        }
    }

    public ApiEnum<string, global::Casedev.Models.Agent.V1.Run.Type>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, global::Casedev.Models.Agent.V1.Run.Type>
            >("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Content;
        _ = this.DurationMs;
        _ = this.Timestamp;
        _ = this.ToolInput;
        _ = this.ToolName;
        _ = this.ToolOutput;
        this.Type?.Validate();
    }

    public Step() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Step(Step step)
        : base(step) { }
#pragma warning restore CS8618

    public Step(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Step(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="StepFromRaw.FromRawUnchecked"/>
    public static Step FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class StepFromRaw : IFromRawJson<Step>
{
    /// <inheritdoc/>
    public Step FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Step.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Output,
    Thinking,
    ToolCall,
    ToolResult,
}

sealed class TypeConverter : JsonConverter<global::Casedev.Models.Agent.V1.Run.Type>
{
    public override global::Casedev.Models.Agent.V1.Run.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "output" => global::Casedev.Models.Agent.V1.Run.Type.Output,
            "thinking" => global::Casedev.Models.Agent.V1.Run.Type.Thinking,
            "tool_call" => global::Casedev.Models.Agent.V1.Run.Type.ToolCall,
            "tool_result" => global::Casedev.Models.Agent.V1.Run.Type.ToolResult,
            _ => (global::Casedev.Models.Agent.V1.Run.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Casedev.Models.Agent.V1.Run.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Casedev.Models.Agent.V1.Run.Type.Output => "output",
                global::Casedev.Models.Agent.V1.Run.Type.Thinking => "thinking",
                global::Casedev.Models.Agent.V1.Run.Type.ToolCall => "tool_call",
                global::Casedev.Models.Agent.V1.Run.Type.ToolResult => "tool_result",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Token usage statistics
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<RunGetDetailsResponseUsage, RunGetDetailsResponseUsageFromRaw>)
)]
public sealed record class RunGetDetailsResponseUsage : JsonModel
{
    public long? DurationMs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("durationMs");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("durationMs", value);
        }
    }

    public IReadOnlyList<Entry>? Entries
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Entry>>("entries");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Entry>?>(
                "entries",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public long? InputTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("inputTokens");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("inputTokens", value);
        }
    }

    public string? Model
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("model");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("model", value);
        }
    }

    public long? OutputTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("outputTokens");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("outputTokens", value);
        }
    }

    public Summary? Summary
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Summary>("summary");
        }
        init { this._rawData.Set("summary", value); }
    }

    public long? ToolCalls
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("toolCalls");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("toolCalls", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DurationMs;
        foreach (var item in this.Entries ?? [])
        {
            item.Validate();
        }
        _ = this.InputTokens;
        _ = this.Model;
        _ = this.OutputTokens;
        this.Summary?.Validate();
        _ = this.ToolCalls;
    }

    public RunGetDetailsResponseUsage() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RunGetDetailsResponseUsage(RunGetDetailsResponseUsage runGetDetailsResponseUsage)
        : base(runGetDetailsResponseUsage) { }
#pragma warning restore CS8618

    public RunGetDetailsResponseUsage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RunGetDetailsResponseUsage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RunGetDetailsResponseUsageFromRaw.FromRawUnchecked"/>
    public static RunGetDetailsResponseUsage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RunGetDetailsResponseUsageFromRaw : IFromRawJson<RunGetDetailsResponseUsage>
{
    /// <inheritdoc/>
    public RunGetDetailsResponseUsage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RunGetDetailsResponseUsage.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Entry, EntryFromRaw>))]
public sealed record class Entry : JsonModel
{
    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    public long? CompletionTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("completionTokens");
        }
        init { this._rawData.Set("completionTokens", value); }
    }

    public long? CostMicros
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("costMicros");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("costMicros", value);
        }
    }

    public string? Endpoint
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("endpoint");
        }
        init { this._rawData.Set("endpoint", value); }
    }

    public ApiEnum<string, Kind>? Kind
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Kind>>("kind");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("kind", value);
        }
    }

    public JsonElement? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("metadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("metadata", value);
        }
    }

    public string? Method
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("method");
        }
        init { this._rawData.Set("method", value); }
    }

    public string? Model
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("model");
        }
        init { this._rawData.Set("model", value); }
    }

    public long? PromptTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("promptTokens");
        }
        init { this._rawData.Set("promptTokens", value); }
    }

    public string? Service
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("service");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("service", value);
        }
    }

    public long? StatusCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("statusCode");
        }
        init { this._rawData.Set("statusCode", value); }
    }

    public System::DateTimeOffset? Timestamp
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("timestamp");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("timestamp", value);
        }
    }

    public long? TotalTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("totalTokens");
        }
        init { this._rawData.Set("totalTokens", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CompletionTokens;
        _ = this.CostMicros;
        _ = this.Endpoint;
        this.Kind?.Validate();
        _ = this.Metadata;
        _ = this.Method;
        _ = this.Model;
        _ = this.PromptTokens;
        _ = this.Service;
        _ = this.StatusCode;
        _ = this.Timestamp;
        _ = this.TotalTokens;
    }

    public Entry() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Entry(Entry entry)
        : base(entry) { }
#pragma warning restore CS8618

    public Entry(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Entry(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntryFromRaw.FromRawUnchecked"/>
    public static Entry FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntryFromRaw : IFromRawJson<Entry>
{
    /// <inheritdoc/>
    public Entry FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Entry.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(KindConverter))]
public enum Kind
{
    Llm,
    Api,
}

sealed class KindConverter : JsonConverter<Kind>
{
    public override Kind Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "llm" => Kind.Llm,
            "api" => Kind.Api,
            _ => (Kind)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Kind value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Kind.Llm => "llm",
                Kind.Api => "api",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<Summary, SummaryFromRaw>))]
public sealed record class Summary : JsonModel
{
    public long? CostMicros
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("costMicros");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("costMicros", value);
        }
    }

    public long? TotalInputTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("totalInputTokens");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("totalInputTokens", value);
        }
    }

    public long? TotalOutputTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("totalOutputTokens");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("totalOutputTokens", value);
        }
    }

    public long? TotalTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("totalTokens");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("totalTokens", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CostMicros;
        _ = this.TotalInputTokens;
        _ = this.TotalOutputTokens;
        _ = this.TotalTokens;
    }

    public Summary() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Summary(Summary summary)
        : base(summary) { }
#pragma warning restore CS8618

    public Summary(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Summary(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SummaryFromRaw.FromRawUnchecked"/>
    public static Summary FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SummaryFromRaw : IFromRawJson<Summary>
{
    /// <inheritdoc/>
    public Summary FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Summary.FromRawUnchecked(rawData);
}
