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
    public Usage? Usage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Usage>("usage");
        }
        init { this._rawData.Set("usage", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AgentID;
        _ = this.CompletedAt;
        _ = this.CreatedAt;
        _ = this.Guidance;
        _ = this.Model;
        _ = this.Prompt;
        this.Result?.Validate();
        _ = this.StartedAt;
        this.Status?.Validate();
        foreach (var item in this.Steps ?? [])
        {
            item.Validate();
        }
        this.Usage?.Validate();
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
/// Final output from the agent
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Result, ResultFromRaw>))]
public sealed record class Result : JsonModel
{
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

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Logs?.Validate();
        _ = this.Output;
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
[JsonConverter(typeof(JsonModelConverter<Usage, UsageFromRaw>))]
public sealed record class Usage : JsonModel
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
        _ = this.InputTokens;
        _ = this.Model;
        _ = this.OutputTokens;
        _ = this.ToolCalls;
    }

    public Usage() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Usage(Usage usage)
        : base(usage) { }
#pragma warning restore CS8618

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
